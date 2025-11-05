#!/usr/bin/env python3
"""
Albion Online Packet Sniffer - GERÇEK ZQRadar Parser ile
"""

import asyncio
import json
from typing import Dict, List
from scapy.all import sniff, UDP, Raw
import threading

# Gerçek ZQRadar parser'ı import et
from zqradar_real_parser import parse_photon_packet, EventCodes

# ============================================================================
# PACKET SNIFFER
# ============================================================================

class AlbionRealSniffer:
    """
    Albion Online UDP paketlerini dinle
    GERÇEK ZQRadar parser'ı ile parse et
    """

    def __init__(self, port: int = 5056):
        self.port = port
        self.running = False
        self.packet_count = 0

        # Veri saklama
        self.local_player_pos = None
        self.players = {}
        self.harvestables = {}

    def start(self):
        """Packet sniffing'i başlat"""
        self.running = True
        print(f"🔍 Albion Online paketleri dinleniyor (UDP port {self.port})...")
        print(f"⚠️  NOT: Root/Admin izni gerekli!\n")

        try:
            sniff(
                filter=f"udp port {self.port}",
                prn=self.process_packet,
                store=False,
                stop_filter=lambda x: not self.running
            )
        except PermissionError:
            print("❌ Hata: Root/Admin izni gerekli!")
            print("   Linux: sudo python3 albion_sniffer_real.py")
            print("   Windows: Yönetici olarak çalıştır")
        except Exception as e:
            print(f"❌ Hata: {e}")

    def process_packet(self, packet):
        """Her paketi işle"""
        if not packet.haslayer(UDP):
            return

        udp_layer = packet[UDP]
        if udp_layer.dport != self.port and udp_layer.sport != self.port:
            return

        # Payload'ı al
        if packet.haslayer(Raw):
            payload = bytes(packet[Raw].load)

            # GERÇEK ZQRadar parser'ı ile parse et
            events = parse_photon_packet(payload)

            if events:
                for event in events:
                    self.packet_count += 1
                    self.handle_event(event)

    def handle_event(self, event: Dict):
        """
        Event'i işle
        ZQRadar'ın event handler'larını taklit et
        """
        code = event['code']
        params = event['parameters']

        # Event 3: Move (Oyuncu hareketi)
        if code == EventCodes.Move:
            if 4 in params and 5 in params:
                posX = params[4]
                posY = params[5]

                # İlk gördüğümüz = local player
                if not self.local_player_pos:
                    print(f"✅ Local player bulundu!")

                self.local_player_pos = (posX, posY)
                print(f"🚶 Oyuncu pozisyonu: ({posX:.1f}, {posY:.1f})")

        # Event 38: NewSimpleHarvestableObject (Basit kaynak spawn)
        elif code == EventCodes.NewSimpleHarvestableObject:
            if 0 in params and 1 in params and 2 in params and 3 in params:
                ids = params[0] if isinstance(params[0], list) else [params[0]]
                types = params[1] if isinstance(params[1], list) else [params[1]]
                tiers = params[2] if isinstance(params[2], list) else [params[2]]
                positions = params[3] if isinstance(params[3], list) else []

                for i in range(len(ids)):
                    resource_id = ids[i]
                    resource_type = types[i] if i < len(types) else 0
                    tier = tiers[i] if i < len(tiers) else 0

                    # Pozisyonlar çift olarak gelir: [x1, y1, x2, y2, ...]
                    if i * 2 + 1 < len(positions):
                        posX = positions[i * 2]
                        posY = positions[i * 2 + 1]

                        self.harvestables[resource_id] = {
                            'id': resource_id,
                            'type': resource_type,
                            'tier': tier,
                            'posX': posX,
                            'posY': posY
                        }

                        print(f"📦 Kaynak T{tier} @ ({posX:.1f}, {posY:.1f})")

        # Event 40: NewHarvestableObject (Detaylı kaynak spawn)
        elif code == EventCodes.NewHarvestableObject:
            # ZQRadar: Parameters[5]=type, [7]=tier, [8]=[posX,posY]
            resource_type = params.get(5, 0)
            tier = params.get(7, 0)
            location = params.get(8)

            if location and len(location) >= 2:
                posX, posY = location[0], location[1]
                print(f"📦 Kaynak (detaylı) T{tier} @ ({posX:.1f}, {posY:.1f})")

        # Event 61: HarvestFinished
        elif code == EventCodes.HarvestFinished:
            print(f"✅ Toplama tamamlandı!")

        # Her 10 pakette özet
        if self.packet_count % 10 == 0:
            self.print_summary()

    def print_summary(self):
        """Özet yazdır"""
        print(f"\n{'='*60}")
        print(f"Toplam event: {self.packet_count}")
        print(f"Kaynaklar: {len(self.harvestables)}")

        if self.local_player_pos:
            print(f"Sen: ({self.local_player_pos[0]:.1f}, {self.local_player_pos[1]:.1f})")

        print(f"{'='*60}\n")

    def stop(self):
        """Sniffing'i durdur"""
        self.running = False
        print("\n⏹️  Sniffer durduruldu")

    def get_data(self) -> Dict:
        """Mevcut veriyi al (WebSocket için)"""
        return {
            'localPlayer': {
                'posX': self.local_player_pos[0] if self.local_player_pos else 0,
                'posY': self.local_player_pos[1] if self.local_player_pos else 0
            } if self.local_player_pos else None,
            'harvestableList': list(self.harvestables.values())
        }


# ============================================================================
# WEBSOCKET SERVER
# ============================================================================

class SnifferWebSocketServer:
    """
    Gerçek veriyi WebSocket ile yayınla
    ws://localhost:5002 (ZQRadar gibi)
    """

    def __init__(self, sniffer: AlbionRealSniffer, port: int = 5002):
        self.sniffer = sniffer
        self.port = port
        self.clients = set()

    async def handler(self, websocket, path):
        """WebSocket client handler"""
        self.clients.add(websocket)
        print(f"✅ Client bağlandı (Toplam: {len(self.clients)})")

        try:
            while True:
                await asyncio.sleep(1)

                data = self.sniffer.get_data()
                message = json.dumps({
                    'code': 'event',
                    'dictionary': data
                })

                await websocket.send(message)

        except:
            pass
        finally:
            self.clients.remove(websocket)
            print(f"❌ Client ayrıldı (Kalan: {len(self.clients)})")

    async def start(self):
        """WebSocket sunucusunu başlat"""
        import websockets

        print(f"🌐 WebSocket başlatılıyor (ws://localhost:{self.port})...")

        async with websockets.serve(self.handler, "localhost", self.port):
            print(f"✅ WebSocket aktif: ws://localhost:{self.port}")
            print(f"   Artık botlar bu adrese bağlanabilir!\n")
            await asyncio.Future()


# ============================================================================
# MAIN
# ============================================================================

def main():
    print("╔══════════════════════════════════════════════════╗")
    print("║  Albion Sniffer - GERÇEK ZQRadar Parser ile    ║")
    print("╚══════════════════════════════════════════════════╝\n")

    print("⚠️  UYARI:")
    print("   - Root/Admin izni gerekli!")
    print("   - Npcap/WinPcap kurulu olmalı!")
    print("   - ZQRadar'ın kaynak kodundan çevrildi!\n")

    print("Mod seçin:")
    print("1. Sadece Konsol (paket izleme)")
    print("2. WebSocket Server (ws://localhost:5002)")
    choice = input("\nSeçim (1/2): ")

    sniffer = AlbionRealSniffer(port=5056)

    if choice == "1":
        # SADECE KONSOL
        try:
            sniffer.start()
        except KeyboardInterrupt:
            sniffer.stop()

    elif choice == "2":
        # WEBSOCKET SERVER
        import websockets

        # Sniffer'ı thread'de çalıştır
        sniffer_thread = threading.Thread(target=sniffer.start, daemon=True)
        sniffer_thread.start()

        # WebSocket server başlat
        ws_server = SnifferWebSocketServer(sniffer)

        try:
            asyncio.run(ws_server.start())
        except KeyboardInterrupt:
            sniffer.stop()
            print("\n👋 Kapatılıyor...")


if __name__ == "__main__":
    main()

#!/usr/bin/env python3
"""
Basit Albion Online Packet Sniffer
ZQRadar'ın yaptığını bizim yapmamız - Network paketlerinden veri çıkarma
"""

import socket
import struct
import json
import asyncio
from typing import Dict, List, Optional, Tuple
from dataclasses import dataclass, asdict
from scapy.all import sniff, UDP, IP, Raw
import threading

# ============================================================================
# VERİ YAPILARI
# ============================================================================

@dataclass
class PlayerData:
    """Oyuncu verisi"""
    id: int = 0
    nickname: str = ""
    posX: float = 0.0
    posY: float = 0.0
    health: int = 0
    mounted: bool = False

    def to_dict(self):
        return asdict(self)


@dataclass
class HarvestableData:
    """Kaynak verisi"""
    id: int = 0
    type: int = 0
    tier: int = 0
    posX: float = 0.0
    posY: float = 0.0
    charges: int = 0
    size: int = 0

    def to_dict(self):
        return asdict(self)


# ============================================================================
# PHOTON PACKET PARSER (BASİTLEŞTİRİLMİŞ)
# ============================================================================

class SimplePhotonParser:
    """
    Basitleştirilmiş Photon protokol parser'ı

    Photon protokolü binary bir format kullanır.
    Her paket şu yapıda:
    - Header (protokol bilgisi)
    - Command Type
    - Parameters (değişken sayıda)
    """

    # Photon Command Types (Albion Online için tahminler)
    CMD_PLAYER_MOVE = 0x01
    CMD_PLAYER_UPDATE = 0x02
    CMD_HARVESTABLE_SPAWN = 0x10
    CMD_HARVESTABLE_UPDATE = 0x11

    def __init__(self):
        self.local_player: Optional[PlayerData] = None
        self.players: Dict[int, PlayerData] = {}
        self.harvestables: Dict[int, HarvestableData] = {}

    def parse_packet(self, data: bytes) -> Optional[Dict]:
        """
        Binary paketi parse et

        NOT: Gerçek Photon protokolü çok karmaşık!
        Bu basitleştirilmiş bir versiyondur.
        """
        if len(data) < 12:  # Minimum header boyutu
            return None

        try:
            # Header parse (basitleştirilmiş)
            # Gerçek Photon: https://doc.photonengine.com/en-us/realtime/current/reference/binary-protocol

            # İlk byte: Protocol type
            protocol_type = data[0]

            # Command type (tahminî pozisyon)
            if len(data) > 4:
                command_type = data[4]

                # Command'e göre parse et
                if command_type == self.CMD_PLAYER_MOVE:
                    return self._parse_player_move(data[5:])
                elif command_type == self.CMD_HARVESTABLE_SPAWN:
                    return self._parse_harvestable_spawn(data[5:])

        except Exception as e:
            # Parse hatası - atla
            pass

        return None

    def _parse_player_move(self, data: bytes) -> Optional[Dict]:
        """Oyuncu hareket paketini parse et"""
        try:
            if len(data) < 16:
                return None

            # Basitleştirilmiş parse (gerçek format farklı olabilir)
            player_id = struct.unpack('<I', data[0:4])[0]
            pos_x = struct.unpack('<f', data[4:8])[0]
            pos_y = struct.unpack('<f', data[8:12])[0]

            player = PlayerData(id=player_id, posX=pos_x, posY=pos_y)
            self.players[player_id] = player

            # İlk gördüğümüz oyuncu = local player
            if not self.local_player:
                self.local_player = player

            return {'type': 'player_move', 'player': player.to_dict()}

        except:
            return None

    def _parse_harvestable_spawn(self, data: bytes) -> Optional[Dict]:
        """Kaynak spawn paketini parse et"""
        try:
            if len(data) < 20:
                return None

            resource_id = struct.unpack('<I', data[0:4])[0]
            resource_type = data[4]
            tier = data[5]
            pos_x = struct.unpack('<f', data[8:12])[0]
            pos_y = struct.unpack('<f', data[12:16])[0]
            size = data[16]

            harvestable = HarvestableData(
                id=resource_id,
                type=resource_type,
                tier=tier,
                posX=pos_x,
                posY=pos_y,
                size=size
            )

            self.harvestables[resource_id] = harvestable

            return {'type': 'harvestable_spawn', 'harvestable': harvestable.to_dict()}

        except:
            return None


# ============================================================================
# PACKET SNIFFER
# ============================================================================

class AlbionPacketSniffer:
    """
    Albion Online UDP paketlerini dinle
    Port: 5056
    """

    def __init__(self, port: int = 5056):
        self.port = port
        self.parser = SimplePhotonParser()
        self.running = False
        self.packet_count = 0

    def start(self):
        """Packet sniffing'i başlat"""
        self.running = True
        print(f"🔍 Albion Online paketleri dinleniyor (UDP port {self.port})...")
        print(f"⚠️  NOT: Root/Admin izni gerekebilir!\n")

        # Scapy ile sniff
        try:
            sniff(
                filter=f"udp port {self.port}",
                prn=self.process_packet,
                store=False,
                stop_filter=lambda x: not self.running
            )
        except PermissionError:
            print("❌ Hata: Root/Admin izni gerekli!")
            print("   Linux: sudo python3 packet_sniffer.py")
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

            # Parse et
            result = self.parser.parse_packet(payload)

            if result:
                self.packet_count += 1
                self.handle_parsed_data(result)

    def handle_parsed_data(self, data: Dict):
        """Parse edilmiş veriyi işle"""
        if data['type'] == 'player_move':
            player = data['player']
            print(f"🚶 Player #{player['id']}: ({player['posX']:.1f}, {player['posY']:.1f})")

        elif data['type'] == 'harvestable_spawn':
            resource = data['harvestable']
            print(f"📦 Resource T{resource['tier']} @ ({resource['posX']:.1f}, {resource['posY']:.1f})")

        # Her 10 pakette bir özet
        if self.packet_count % 10 == 0:
            self.print_summary()

    def print_summary(self):
        """Özet bilgi yazdır"""
        print(f"\n{'='*60}")
        print(f"Toplam paket: {self.packet_count}")
        print(f"Oyuncular: {len(self.parser.players)}")
        print(f"Kaynaklar: {len(self.parser.harvestables)}")

        if self.parser.local_player:
            lp = self.parser.local_player
            print(f"Sen: ({lp.posX:.1f}, {lp.posY:.1f})")

        print(f"{'='*60}\n")

    def stop(self):
        """Sniffing'i durdur"""
        self.running = False
        print("\n⏹️  Sniffer durduruldu")

    def get_data(self) -> Dict:
        """Mevcut veriyi al (API için)"""
        return {
            'localPlayer': self.parser.local_player.to_dict() if self.parser.local_player else None,
            'players': [p.to_dict() for p in self.parser.players.values()],
            'harvestables': [h.to_dict() for h in self.parser.harvestables.values()]
        }


# ============================================================================
# WEBSOCKET SERVER (ZQRadar gibi)
# ============================================================================

class SnifferWebSocketServer:
    """
    Packet sniffer verilerini WebSocket ile yayınla
    ZQRadar'ın yaptığı gibi: ws://localhost:5002
    """

    def __init__(self, sniffer: AlbionPacketSniffer, port: int = 5002):
        self.sniffer = sniffer
        self.port = port
        self.clients = set()

    async def handler(self, websocket, path):
        """WebSocket client handler"""
        self.clients.add(websocket)
        print(f"✅ Yeni client bağlandı (Toplam: {len(self.clients)})")

        try:
            # İlk veriyi gönder
            await websocket.send(json.dumps({
                'code': 'event',
                'dictionary': self.sniffer.get_data()
            }))

            # Client bağlı kaldığı sürece güncelleme gönder
            while True:
                await asyncio.sleep(1)  # 1 saniyede bir güncelle

                data = self.sniffer.get_data()
                message = json.dumps({
                    'code': 'event',
                    'dictionary': data
                })

                await websocket.send(message)

        except websockets.exceptions.ConnectionClosed:
            pass
        finally:
            self.clients.remove(websocket)
            print(f"❌ Client ayrıldı (Kalan: {len(self.clients)})")

    async def start(self):
        """WebSocket sunucusunu başlat"""
        import websockets

        print(f"🌐 WebSocket sunucusu başlatılıyor (ws://localhost:{self.port})...")

        async with websockets.serve(self.handler, "localhost", self.port):
            print(f"✅ WebSocket aktif: ws://localhost:{self.port}")
            await asyncio.Future()  # Sonsuz bekle


# ============================================================================
# MAIN
# ============================================================================

def main():
    print("╔══════════════════════════════════════════════════╗")
    print("║     Basit Albion Online Packet Sniffer         ║")
    print("║       (ZQRadar'ın yaptığını kendimiz yapıyoruz) ║")
    print("╚══════════════════════════════════════════════════╝\n")

    print("⚠️  UYARI:")
    print("   - Root/Admin izni gerekli!")
    print("   - Npcap/WinPcap kurulu olmalı!")
    print("   - Bu eğitim amaçlıdır!\n")

    print("Mod seçin:")
    print("1. Packet Sniffer (konsol çıktısı)")
    print("2. Packet Sniffer + WebSocket (ws://localhost:5002)")
    choice = input("\nSeçim (1/2): ")

    # Sniffer oluştur
    sniffer = AlbionPacketSniffer(port=5056)

    if choice == "1":
        # SADECE KONSOL ÇIKTISI
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

        # WebSocket server'ı başlat
        ws_server = SnifferWebSocketServer(sniffer)

        try:
            asyncio.run(ws_server.start())
        except KeyboardInterrupt:
            sniffer.stop()


if __name__ == "__main__":
    # Gerekli: pip install scapy websockets
    main()

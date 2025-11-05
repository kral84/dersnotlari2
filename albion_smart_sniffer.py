#!/usr/bin/env python3
"""
Albion Smart Sniffer - DOĞRU Parser + Rota Kayıt Sistemi
Local player pozisyonunu REQUEST'ten alır!
"""

import sys
import traceback

# Bağımlılık kontrolü
missing_deps = []
try:
    import asyncio
except ImportError:
    missing_deps.append("asyncio")

try:
    import json
except ImportError:
    missing_deps.append("json")

try:
    import time
except ImportError:
    missing_deps.append("time")

try:
    from typing import Dict, List, Optional, Tuple
except ImportError:
    missing_deps.append("typing")

try:
    from scapy.all import sniff, UDP, Raw
except ImportError:
    missing_deps.append("scapy")

try:
    import threading
except ImportError:
    missing_deps.append("threading")

try:
    import keyboard
except ImportError:
    missing_deps.append("keyboard")

# Eksik bağımlılık varsa bildir ve çık
if missing_deps:
    print("❌ HATA: Eksik Python kütüphaneleri!\n")
    print("Eksik olan:", ", ".join(missing_deps))
    print("\n📦 Kurulum için:")
    print("   pip3 install -r requirements.txt")
    print("\n   VEYA:")
    print("   pip3 install scapy keyboard websockets")
    print("\n⚠️  Linux'ta scapy için:")
    print("   sudo apt-get install python3-scapy")
    sys.exit(1)

# DOĞRU parser'ı import et
try:
    from zqradar_correct_parser import parse_photon_packet_correct, OperationCodes
except ImportError as e:
    print(f"❌ HATA: Parser import edilemedi: {e}")
    print("   zqradar_correct_parser.py dosyası mevcut mu?")
    sys.exit(1)

# ============================================================================
# ROTA KAYIT SİSTEMİ
# ============================================================================

class RouteRecorder:
    """Space tuşu ile rota kaydet"""

    def __init__(self):
        self.route: List[Tuple[float, float]] = []
        self.recording = False
        self.last_recorded_time = 0
        self.min_interval = 2.0  # En az 2 saniye aralıkla kaydet

    def start_recording(self):
        """Kayıt modunu başlat"""
        self.recording = True
        print("\n🔴 ROTA KAYIT MODU BAŞLADI!")
        print("   Space: Waypoint ekle (otomatik)")
        print("   Ctrl+C: Kaydı bitir\n")

    def stop_recording(self):
        """Kaydı durdur"""
        self.recording = False
        print(f"\n⏹️  Kayıt durduruldu. Toplam {len(self.route)} waypoint.\n")

    def add_waypoint(self, x: float, y: float, auto: bool = False):
        """Waypoint ekle"""
        current_time = time.time()

        # Çok sık ekleme önleme
        if current_time - self.last_recorded_time < self.min_interval:
            return False

        self.route.append((x, y))
        self.last_recorded_time = current_time

        if auto:
            print(f"✅ Auto Waypoint #{len(self.route)}: ({x:.1f}, {y:.1f})")
        else:
            print(f"📍 Waypoint #{len(self.route)}: ({x:.1f}, {y:.1f})")

        return True

    def save_route(self, filename: str = "route.json"):
        """Rotayı dosyaya kaydet"""
        data = [{"x": x, "y": y, "name": f"WP{i+1}"} for i, (x, y) in enumerate(self.route)]
        with open(filename, 'w') as f:
            json.dump(data, f, indent=2)
        print(f"💾 Rota kaydedildi: {filename}")

    def load_route(self, filename: str = "route.json") -> List[Tuple[float, float]]:
        """Rotayı dosyadan yükle"""
        with open(filename, 'r') as f:
            data = json.load(f)
        route = [(wp['x'], wp['y']) for wp in data]
        print(f"📂 Rota yüklendi: {len(route)} waypoint")
        return route


# ============================================================================
# SMART PACKET SNIFFER
# ============================================================================

class AlbionSmartSniffer:
    """
    Akıllı Albion sniffer
    - Request/Response parse (doğru local player pozisyonu)
    - Event parse (kaynaklar, diğer oyuncular)
    - Otomatik rota kaydı
    """

    def __init__(self, port: int = 5056):
        self.port = port
        self.running = False
        self.packet_count = 0

        # Veri saklama
        self.local_player_pos: Optional[Tuple[float, float]] = None
        self.harvestables: Dict[int, Dict] = {}
        self.last_pos_update = 0

        # Rota kaydedici
        self.recorder = RouteRecorder()

    def start(self, record_mode: bool = False):
        """Packet sniffing'i başlat"""
        self.running = True

        if record_mode:
            self.recorder.start_recording()
            # Space tuşunu dinle
            keyboard.on_press_key("space", self._on_space_pressed)

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
            print("   Linux: sudo python3 albion_smart_sniffer.py")
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

            # DOĞRU parser ile parse et
            result = parse_photon_packet_correct(payload)

            if result:
                self.packet_count += 1
                self.handle_result(result)

    def handle_result(self, result: Dict):
        """Parse sonucunu işle"""

        # 1. Local player pozisyonu
        if result['local_player_pos']:
            x, y = result['local_player_pos']
            self.local_player_pos = (x, y)
            self.last_pos_update = time.time()

            # Kayıt modundaysa otomatik ekle
            if self.recorder.recording:
                self.recorder.add_waypoint(x, y, auto=True)

        # 2. Events (kaynaklar vb)
        for event in result.get('events', []):
            code = event.get('code')
            params = event.get('parameters', {})

            # Kaynak spawn
            if code == 38:  # NewSimpleHarvestableObject
                self._handle_simple_harvestables(params)
            elif code == 40:  # NewHarvestableObject
                self._handle_harvestable(params)

        # 3. Özet
        if self.packet_count % 20 == 0:
            self.print_summary()

    def _handle_simple_harvestables(self, params: Dict):
        """Basit kaynak listesi parse et"""
        if 0 in params and 1 in params and 2 in params and 3 in params:
            ids = params[0] if isinstance(params[0], list) else [params[0]]
            types = params[1] if isinstance(params[1], list) else [params[1]]
            tiers = params[2] if isinstance(params[2], list) else [params[2]]
            positions = params[3] if isinstance(params[3], list) else []

            for i in range(len(ids)):
                resource_id = ids[i]
                resource_type = types[i] if i < len(types) else 0
                tier = tiers[i] if i < len(tiers) else 0

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

    def _handle_harvestable(self, params: Dict):
        """Detaylı kaynak parse et"""
        resource_type = params.get(5, 0)
        tier = params.get(7, 0)
        location = params.get(8)

        if location and len(location) >= 2:
            posX, posY = location[0], location[1]
            print(f"📦 Kaynak (detaylı) T{tier} @ ({posX:.1f}, {posY:.1f})")

    def _on_space_pressed(self, event):
        """Space tuşuna basıldığında"""
        if self.recorder.recording and self.local_player_pos:
            x, y = self.local_player_pos
            self.recorder.add_waypoint(x, y, auto=False)

    def print_summary(self):
        """Özet yazdır"""
        print(f"\n{'='*60}")
        print(f"Toplam paket: {self.packet_count}")
        print(f"Kaynaklar: {len(self.harvestables)}")

        if self.local_player_pos:
            print(f"Local Player: ({self.local_player_pos[0]:.1f}, {self.local_player_pos[1]:.1f})")
        else:
            print(f"⚠️  Local Player pozisyonu henüz alınmadı")
            print(f"   (Oyunda hareket et, Request 21 gönderilecek)")

        if self.recorder.recording:
            print(f"🔴 Kayıt Modu: {len(self.recorder.route)} waypoint")

        print(f"{'='*60}\n")

    def stop(self):
        """Sniffing'i durdur"""
        self.running = False

        if self.recorder.recording:
            self.recorder.stop_recording()

        keyboard.unhook_all()
        print("\n⏹️  Sniffer durduruldu")

    def get_data(self) -> Dict:
        """Mevcut veriyi al (WebSocket için)"""
        return {
            'localPlayer': {
                'posX': self.local_player_pos[0] if self.local_player_pos else 0,
                'posY': self.local_player_pos[1] if self.local_player_pos else 0,
                'online': self.local_player_pos is not None,
                'lastUpdate': self.last_pos_update
            } if self.local_player_pos else None,
            'harvestableList': list(self.harvestables.values()),
            'route': self.recorder.route if self.recorder.recording else []
        }


# ============================================================================
# WEBSOCKET SERVER
# ============================================================================

class SnifferWebSocketServer:
    """WebSocket server - ZQRadar uyumlu"""

    def __init__(self, sniffer: AlbionSmartSniffer, port: int = 5002):
        self.sniffer = sniffer
        self.port = port
        self.clients = set()

    async def handler(self, websocket, path):
        """WebSocket client handler"""
        self.clients.add(websocket)
        print(f"✅ Client bağlandı (Toplam: {len(self.clients)})")

        try:
            while True:
                await asyncio.sleep(0.5)  # 0.5 saniyede bir güncelle

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
            print(f"   Botlar artık bağlanabilir!\n")
            await asyncio.Future()


# ============================================================================
# MAIN
# ============================================================================

def main():
    try:
        print("╔══════════════════════════════════════════════════╗")
        print("║   Albion Smart Sniffer - DOĞRU Parser          ║")
        print("║   Local Player: Request/Response                ║")
        print("╚══════════════════════════════════════════════════╝\n")

        print("⚠️  UYARI:")
        print("   - Root/Admin izni gerekli!")
        print("   - Npcap/WinPcap kurulu olmalı!\n")

        print("Mod seçin:")
        print("1. Konsol + Rota Kayıt (Space ile)")
        print("2. WebSocket Server (ws://localhost:5002)")
        print("3. Sadece İzleme (rota kayıt YOK)")
        choice = input("\nSeçim (1/2/3): ").strip()

        if choice not in ["1", "2", "3"]:
            print("❌ Geçersiz seçim! 1, 2 veya 3 seçin.")
            sys.exit(1)

        sniffer = AlbionSmartSniffer(port=5056)

        if choice == "1":
            # ROTA KAYIT MODU
            print("\n⚠️  5 saniye içinde oyuna geç ve hareket et!")
            time.sleep(5)

            try:
                sniffer.start(record_mode=True)
            except KeyboardInterrupt:
                sniffer.stop()
                sniffer.recorder.save_route("route.json")
                print("\n👋 Kapatılıyor...")

        elif choice == "2":
            # WEBSOCKET SERVER
            import websockets

            # Sniffer'ı thread'de çalıştır
            sniffer_thread = threading.Thread(target=lambda: sniffer.start(record_mode=False), daemon=True)
            sniffer_thread.start()

            # WebSocket server başlat
            ws_server = SnifferWebSocketServer(sniffer)

            try:
                asyncio.run(ws_server.start())
            except KeyboardInterrupt:
                sniffer.stop()
                print("\n👋 Kapatılıyor...")

        elif choice == "3":
            # SADECE İZLEME
            try:
                sniffer.start(record_mode=False)
            except KeyboardInterrupt:
                sniffer.stop()
                print("\n👋 Kapatılıyor...")

    except Exception as e:
        print(f"\n❌ KRITIK HATA:")
        print(f"   {type(e).__name__}: {e}")
        print("\n📋 Detaylı hata:")
        traceback.print_exc()
        print("\n⚠️  Yardım:")
        print("   - Root/Admin izni ile çalıştırın (sudo python3 ...)")
        print("   - Tüm bağımlılıkların kurulu olduğundan emin olun")
        print("   - Albion Online'ın açık olduğundan emin olun")
        sys.exit(1)


if __name__ == "__main__":
    main()

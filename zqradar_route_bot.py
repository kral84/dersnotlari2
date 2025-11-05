#!/usr/bin/env python3
"""
ZQRadar Rota Botu - Otomatik Kaynak Toplama
Python + WebSocket + Klavye Kontrolü
"""

import asyncio
import websockets
import json
import time
import math
from typing import List, Dict, Optional, Tuple
from dataclasses import dataclass
import keyboard
import pyautogui

# ============================================================================
# VERİ YAPILARI
# ============================================================================

@dataclass
class Harvestable:
    """ZQRadar'dan gelen kaynak verisi"""
    id: int
    type: int           # 0-27: demir, odun, elyaf vs
    tier: int           # T1-T8
    posX: float
    posY: float
    charges: int        # Enchantment 0-3
    size: int           # Kalan miktar

    @classmethod
    def from_dict(cls, data: dict):
        return cls(
            id=data.get('id', 0),
            type=data.get('type', 0),
            tier=data.get('tier', 0),
            posX=data.get('posX', 0.0),
            posY=data.get('posY', 0.0),
            charges=data.get('charges', 0),
            size=data.get('size', 0)
        )


@dataclass
class Player:
    """Oyuncu verisi"""
    id: int
    nickname: str
    posX: float
    posY: float
    currentHealth: int
    mounted: bool

    @classmethod
    def from_dict(cls, data: dict):
        return cls(
            id=data.get('id', 0),
            nickname=data.get('nickname', ''),
            posX=data.get('posX', 0.0),
            posY=data.get('posY', 0.0),
            currentHealth=data.get('currentHealth', 0),
            mounted=data.get('mounted', False)
        )


@dataclass
class Waypoint:
    """Rota noktası"""
    x: float
    y: float
    name: str = ""

    def __repr__(self):
        return f"Waypoint({self.name or 'unnamed'}: {self.x:.1f}, {self.y:.1f})"


# ============================================================================
# HAREKET KONTROLÜ (Klavye ile)
# ============================================================================

class MovementController:
    """Klavye ile karakteri hareket ettir"""

    def __init__(self):
        self.is_moving = False

    def move_to_position(self, current_x: float, current_y: float,
                         target_x: float, target_y: float,
                         threshold: float = 2.0) -> bool:
        """
        Hedef pozisyona git (klavye ile)

        Args:
            current_x, current_y: Mevcut pozisyon
            target_x, target_y: Hedef pozisyon
            threshold: Hedefe ulaşma mesafesi

        Returns:
            True: Hedefe ulaştı, False: Hala yolda
        """
        # Mesafe hesapla
        distance = self.calculate_distance(current_x, current_y, target_x, target_y)

        if distance <= threshold:
            self.stop_movement()
            return True

        # Yön hesapla
        dx = target_x - current_x
        dy = target_y - current_y

        # Normalize et
        magnitude = math.sqrt(dx*dx + dy*dy)
        if magnitude == 0:
            return True

        dx /= magnitude
        dy /= magnitude

        # Hangi tuşlara basacağız?
        # Albion Online'da: W=yukarı, S=aşağı, A=sol, D=sağ
        # Koordinat sistemi: X=sağ, Y=aşağı

        keys_to_press = []

        # Y ekseninde hareket (W/S)
        if dy > 0.3:  # Aşağı git
            keys_to_press.append('s')
        elif dy < -0.3:  # Yukarı git
            keys_to_press.append('w')

        # X ekseninde hareket (A/D)
        if dx > 0.3:  # Sağa git
            keys_to_press.append('d')
        elif dx < -0.3:  # Sola git
            keys_to_press.append('a')

        # Tuşlara bas
        if keys_to_press:
            self.is_moving = True
            for key in keys_to_press:
                keyboard.press(key)

            # Kısa süre bekle
            time.sleep(0.1)

            # Tuşları bırak
            for key in keys_to_press:
                keyboard.release(key)

        return False

    def stop_movement(self):
        """Tüm hareket tuşlarını bırak"""
        if self.is_moving:
            for key in ['w', 'a', 's', 'd']:
                keyboard.release(key)
            self.is_moving = False

    @staticmethod
    def calculate_distance(x1: float, y1: float, x2: float, y2: float) -> float:
        """İki nokta arası mesafe"""
        return math.sqrt((x2 - x1)**2 + (y2 - y1)**2)


# ============================================================================
# ZQRADAR BAĞLANTISI
# ============================================================================

class ZQRadarClient:
    """ZQRadar WebSocket istemcisi"""

    def __init__(self, uri: str = "ws://localhost:5002"):
        self.uri = uri
        self.websocket = None
        self.local_player: Optional[Player] = None
        self.harvestables: List[Harvestable] = []
        self.all_players: Dict[int, Player] = {}
        self.running = False

    async def connect(self):
        """ZQRadar'a bağlan"""
        try:
            print(f"🔌 ZQRadar'a bağlanılıyor ({self.uri})...")
            self.websocket = await websockets.connect(self.uri)
            print("✅ ZQRadar'a bağlandı!")
            self.running = True
        except Exception as e:
            print(f"❌ Bağlantı hatası: {e}")
            print("   ZQRadar açık mı? (localhost:5001)")
            raise

    async def listen(self):
        """WebSocket mesajlarını dinle"""
        try:
            async for message in self.websocket:
                await self.process_message(message)
        except websockets.exceptions.ConnectionClosed:
            print("⚠️  ZQRadar bağlantısı kesildi!")
            self.running = False

    async def process_message(self, message: str):
        """Gelen mesajları işle"""
        try:
            data = json.loads(message)

            if data.get('code') == 'event' and 'dictionary' in data:
                dictionary = data['dictionary']

                # Kaynak listesini güncelle
                if 'harvestableList' in dictionary:
                    harvestables_data = dictionary['harvestableList']
                    self.harvestables = [
                        Harvestable.from_dict(h) for h in harvestables_data
                    ]

                # Oyuncu listesini güncelle
                if 'playersList' in dictionary:
                    players_data = dictionary['playersList']
                    for player_data in players_data:
                        player = Player.from_dict(player_data)
                        self.all_players[player.id] = player

                # Local player'ı belirle (ilk oyuncu genelde sen olursun)
                # Veya nickname ile eşleştirilebilir
                if 'localPlayer' in dictionary:
                    self.local_player = Player.from_dict(dictionary['localPlayer'])
                elif self.all_players and not self.local_player:
                    # İlk oyuncuyu al (geçici çözüm)
                    self.local_player = list(self.all_players.values())[0]

        except json.JSONDecodeError:
            pass  # Bazı mesajlar JSON olmayabilir
        except Exception as e:
            print(f"⚠️  Mesaj işleme hatası: {e}")

    def get_player_position(self) -> Optional[Tuple[float, float]]:
        """Oyuncunun gerçek pozisyonunu al"""
        if self.local_player:
            return (self.local_player.posX, self.local_player.posY)
        return None

    def find_nearby_harvestables(self, x: float, y: float,
                                  radius: float = 50.0,
                                  min_tier: int = 5,
                                  max_tier: int = 8) -> List[Harvestable]:
        """Yakındaki toplanabilir kaynakları bul"""
        nearby = []

        for h in self.harvestables:
            # Mesafe kontrolü
            distance = MovementController.calculate_distance(x, y, h.posX, h.posY)
            if distance > radius:
                continue

            # Tier kontrolü
            if h.tier < min_tier or h.tier > max_tier:
                continue

            # Size kontrolü (kaynak bitmişse atla)
            if h.size <= 0:
                continue

            nearby.append(h)

        # Mesafeye göre sırala (en yakından)
        nearby.sort(key=lambda h: MovementController.calculate_distance(x, y, h.posX, h.posY))

        return nearby

    async def disconnect(self):
        """Bağlantıyı kapat"""
        self.running = False
        if self.websocket:
            await self.websocket.close()
            print("🔌 ZQRadar bağlantısı kapatıldı")


# ============================================================================
# ANA BOT
# ============================================================================

class RouteBot:
    """Rota tabanlı otomasyon botu"""

    def __init__(self, zqradar: ZQRadarClient):
        self.zqradar = zqradar
        self.movement = MovementController()
        self.route: List[Waypoint] = []
        self.running = False

        # Ayarlar
        self.harvest_radius = 50.0
        self.min_tier = 5
        self.max_tier = 8
        self.waypoint_threshold = 3.0  # Waypoint'e ulaşma mesafesi
        self.max_stuck_time = 10.0     # Maksimum takılma süresi (saniye)

    def add_waypoint(self, x: float, y: float, name: str = ""):
        """Rotaya waypoint ekle"""
        wp = Waypoint(x, y, name)
        self.route.append(wp)
        print(f"📍 Waypoint eklendi: {wp}")

    def load_route(self, waypoints: List[Waypoint]):
        """Rota yükle"""
        self.route = waypoints
        print(f"📍 {len(self.route)} waypoint'lik rota yüklendi")

    async def start_route(self, loop: bool = True):
        """Rotayı başlat"""
        if not self.route:
            print("❌ Rota boş! add_waypoint() ile waypoint ekle.")
            return

        print("\n🚀 ROTA BAŞLADI!")
        print(f"   Toplam waypoint: {len(self.route)}")
        print(f"   Toplama yarıçapı: {self.harvest_radius}")
        print(f"   Tier aralığı: T{self.min_tier}-T{self.max_tier}")
        print(f"   Döngü: {'Evet (sonsuz)' if loop else 'Hayır (1 tur)'}\n")

        self.running = True
        tour_count = 0

        while self.running:
            tour_count += 1
            print(f"\n{'='*60}")
            print(f"  TUR {tour_count}")
            print(f"{'='*60}\n")

            for waypoint in self.route:
                if not self.running:
                    break

                print(f"\n🎯 Waypoint: {waypoint}")

                # Waypoint'e git
                reached = await self.navigate_to_waypoint(waypoint)

                if not reached:
                    print(f"   ⚠️  Waypoint'e ulaşılamadı, devam ediliyor...")
                    continue

                # Gerçek pozisyonu al
                pos = self.zqradar.get_player_position()
                if not pos:
                    print("   ⚠️  Oyuncu pozisyonu alınamadı!")
                    await asyncio.sleep(1)
                    continue

                current_x, current_y = pos
                print(f"   📍 Gerçek pozisyon: ({current_x:.1f}, {current_y:.1f})")

                # Yakındaki kaynakları kontrol et
                nearby = self.zqradar.find_nearby_harvestables(
                    current_x, current_y,
                    self.harvest_radius,
                    self.min_tier,
                    self.max_tier
                )

                if nearby:
                    print(f"   📦 {len(nearby)} toplanabilir kaynak bulundu!")

                    for resource in nearby[:5]:  # İlk 5 tanesi
                        await self.harvest_resource(resource)
                else:
                    print("   ⚪ Yakında kaynak yok, devam ediliyor...")

                # Bir sonraki waypoint'e geçmeden kısa bekle
                await asyncio.sleep(1)

            if not loop:
                print("\n✅ Rota tamamlandı (döngü kapalı)")
                break

            print("\n🔄 Rota tekrar başlıyor...")
            await asyncio.sleep(2)

        self.running = False
        self.movement.stop_movement()

    async def navigate_to_waypoint(self, waypoint: Waypoint) -> bool:
        """Waypoint'e git (gerçek pozisyon takibi ile)"""
        start_time = time.time()
        last_distance = float('inf')
        stuck_count = 0

        while True:
            # Gerçek pozisyonu al
            pos = self.zqradar.get_player_position()
            if not pos:
                await asyncio.sleep(0.5)
                continue

            current_x, current_y = pos

            # Hedefe ulaştık mı?
            distance = self.movement.calculate_distance(
                current_x, current_y, waypoint.x, waypoint.y
            )

            if distance <= self.waypoint_threshold:
                self.movement.stop_movement()
                print(f"   ✅ Waypoint'e ulaşıldı!")
                return True

            # Takılma kontrolü
            if abs(distance - last_distance) < 0.5:
                stuck_count += 1
                if stuck_count > 5:
                    print(f"   ⚠️  Karakter takıldı! (Mesafe: {distance:.1f})")
                    # Hafif rastgele hareket (takılmadan kurtulmak için)
                    keyboard.press('a')
                    await asyncio.sleep(0.3)
                    keyboard.release('a')
                    stuck_count = 0
            else:
                stuck_count = 0

            last_distance = distance

            # Timeout kontrolü
            if time.time() - start_time > self.max_stuck_time:
                print(f"   ❌ Timeout! Waypoint'e {self.max_stuck_time}s'de ulaşılamadı")
                self.movement.stop_movement()
                return False

            # Hedefe doğru hareket et
            self.movement.move_to_position(
                current_x, current_y, waypoint.x, waypoint.y
            )

            # Kısa bekle
            await asyncio.sleep(0.2)

    async def harvest_resource(self, resource: Harvestable):
        """Kaynağı topla"""
        print(f"   ⛏️  T{resource.tier} kaynak toplanıyor (ID: {resource.id})")

        # Kaynağın yanına git
        pos = self.zqradar.get_player_position()
        if not pos:
            print("   ❌ Pozisyon alınamadı!")
            return

        current_x, current_y = pos
        distance = self.movement.calculate_distance(
            current_x, current_y, resource.posX, resource.posY
        )

        # Eğer kaynağa çok uzaksak, yanına git
        if distance > 3.0:
            print(f"   🚶 Kaynağa yaklaşılıyor... (mesafe: {distance:.1f})")

            # Kaynağa git
            start_time = time.time()
            while distance > 3.0:
                pos = self.zqradar.get_player_position()
                if not pos:
                    break

                current_x, current_y = pos
                distance = self.movement.calculate_distance(
                    current_x, current_y, resource.posX, resource.posY
                )

                self.movement.move_to_position(
                    current_x, current_y, resource.posX, resource.posY
                )

                await asyncio.sleep(0.2)

                # Timeout
                if time.time() - start_time > 5.0:
                    print("   ⚠️  Kaynağa yaklaşılamadı")
                    return

        self.movement.stop_movement()

        # E tuşuna bas (toplama)
        keyboard.press('e')
        await asyncio.sleep(0.1)
        keyboard.release('e')

        # Toplama süresi (tier'e göre)
        harvest_time = 2.0 + (resource.tier * 0.5)
        await asyncio.sleep(harvest_time)

        print(f"   ✅ Toplandı!")

    def stop(self):
        """Botu durdur"""
        self.running = False
        self.movement.stop_movement()
        print("\n⏹️  Bot durduruldu!")


# ============================================================================
# MAIN
# ============================================================================

async def main():
    print("╔══════════════════════════════════════════════════╗")
    print("║   ZQRadar Rota Botu - Otomatik Kaynak Toplama  ║")
    print("║              Python + WebSocket + WASD          ║")
    print("╚══════════════════════════════════════════════════╝\n")

    print("⚠️  UYARI: Bu bot eğitim amaçlıdır!")
    print("⚠️  Albion Online kullanım şartlarını ihlal edebilir!\n")

    # ZQRadar'a bağlan
    client = ZQRadarClient()
    await client.connect()

    # Arka planda mesajları dinle
    asyncio.create_task(client.listen())

    # Bağlantının stabilize olması için bekle
    print("⏳ ZQRadar verisi bekleniyor...")
    await asyncio.sleep(3)

    # Bot oluştur
    bot = RouteBot(client)
    bot.min_tier = 5
    bot.max_tier = 8
    bot.harvest_radius = 50.0

    # Rotayı tanımla
    print("\n📍 Rota oluşturuluyor...\n")
    bot.add_waypoint(100, 100, "Başlangıç")
    bot.add_waypoint(200, 150, "Maden Bölgesi 1")
    bot.add_waypoint(300, 200, "Maden Bölgesi 2")
    bot.add_waypoint(400, 250, "Maden Bölgesi 3")
    bot.add_waypoint(300, 300, "Dönüş Noktası")

    print("\n⏳ 5 saniye içinde Albion Online'a geç!")
    print("   (Oyun penceresi aktif olmalı!)")
    await asyncio.sleep(5)

    try:
        # Rotayı başlat (sonsuz döngü)
        await bot.start_route(loop=True)
    except KeyboardInterrupt:
        print("\n\n⏹️  Kullanıcı tarafından durduruldu (Ctrl+C)")
    finally:
        bot.stop()
        await client.disconnect()


if __name__ == "__main__":
    # Gerekli kütüphaneler:
    # pip install websockets keyboard pyautogui

    asyncio.run(main())

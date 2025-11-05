#!/usr/bin/env python3
"""
ZQRadar Rota Botu - World-to-Screen ÇÖZÜMÜ
Yöntem: Kamera Kontrolü + Ekran Merkezi
"""

import asyncio
import websockets
import json
import time
import math
from typing import List, Dict, Optional, Tuple
from dataclasses import dataclass
import pyautogui
import keyboard

# ============================================================================
# VERİ YAPILARI
# ============================================================================

@dataclass
class Harvestable:
    """ZQRadar'dan gelen kaynak verisi"""
    id: int
    type: int
    tier: int
    posX: float
    posY: float
    charges: int
    size: int

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
        return f"{self.name or 'waypoint'}: ({self.x:.1f}, {self.y:.1f})"


# ============================================================================
# HAREKET KONTROLÜ - Kamera + Ekran Merkezi Yöntemi
# ============================================================================

class SmartMovementController:
    """
    W2S problemi çözümü:
    - Oyuncu her zaman ekran merkezinde durur
    - Kamerayı hedefe çeviririz (mouse drag)
    - Hedef ekran merkezine gelince tıklarız
    """

    def __init__(self):
        # Oyun penceresi bilgileri (manuel ayarla veya otomatik tespit et)
        self.game_window_x = 0
        self.game_window_y = 0
        self.game_window_width = 1920
        self.game_window_height = 1080

    @property
    def screen_center_x(self) -> int:
        """Oyun ekranının merkez X koordinatı"""
        return self.game_window_x + self.game_window_width // 2

    @property
    def screen_center_y(self) -> int:
        """Oyun ekranının merkez Y koordinatı"""
        return self.game_window_y + self.game_window_height // 2

    def move_camera_towards_target(self, current_x: float, current_y: float,
                                     target_x: float, target_y: float):
        """
        Kamerayı hedefe doğru çevir

        Args:
            current_x, current_y: Oyuncunun dünya koordinatı
            target_x, target_y: Hedefin dünya koordinatı
        """
        # Yön vektörü hesapla
        dx = target_x - current_x
        dy = target_y - current_y

        # Normalize et
        magnitude = math.sqrt(dx*dx + dy*dy)
        if magnitude == 0:
            return

        dx /= magnitude
        dy /= magnitude

        # Kamera hareketini simüle et (mouse drag)
        # Albion Online'da sağ tık + drag ile kamera döner
        # VEYA fare imlecini hedefe yakın tutarak kamera otomatik kayar

        # Basit yöntem: Ekran kenarına doğru mouse'u hareket ettir
        # Albion'da mouse ekran kenarındayken kamera kayar

        edge_threshold = 100  # Ekran kenarından 100 piksel

        if dx > 0.5:  # Sağa git
            mouse_x = self.game_window_x + self.game_window_width - edge_threshold
            mouse_y = self.screen_center_y
            pyautogui.moveTo(mouse_x, mouse_y, duration=0.1)
        elif dx < -0.5:  # Sola git
            mouse_x = self.game_window_x + edge_threshold
            mouse_y = self.screen_center_y
            pyautogui.moveTo(mouse_x, mouse_y, duration=0.1)

        if dy > 0.5:  # Aşağı git
            mouse_x = self.screen_center_x
            mouse_y = self.game_window_y + self.game_window_height - edge_threshold
            pyautogui.moveTo(mouse_x, mouse_y, duration=0.1)
        elif dy < -0.5:  # Yukarı git
            mouse_x = self.screen_center_x
            mouse_y = self.game_window_y + edge_threshold
            pyautogui.moveTo(mouse_x, mouse_y, duration=0.1)

    def click_at_target(self, current_x: float, current_y: float,
                        target_x: float, target_y: float):
        """
        Hedefe git (kamera + tıklama)

        Mantık:
        1. Hedefe yönel (kamera)
        2. Ekran merkezine tıkla (oyuncu oraya gider)
        """
        # Yön hesapla
        dx = target_x - current_x
        dy = target_y - current_y
        distance = math.sqrt(dx*dx + dy*dy)

        if distance < 3.0:  # Çok yakınsa direkt tıkla
            pyautogui.click(self.screen_center_x, self.screen_center_y)
            return

        # Hedefe doğru bir nokta hesapla (mesafe sınırlı)
        max_click_distance = 30.0  # Bir tıklamada max 30 birim git

        if distance > max_click_distance:
            # Normalize ve sınırla
            dx = (dx / distance) * max_click_distance
            dy = (dy / distance) * max_click_distance

        # Şimdi bu dx/dy'yi ekran piksellerine çevirmemiz lazım
        # İŞTE BURADA W2S GEREKLİ!

        # ===== ÇÖZÜM: ZQRadar'ın formülünü kullan (YAKLASIK) =====
        screen_offset = self.approximate_world_to_screen_offset(dx, dy)

        # Ekran merkezinden offset kadar kaydır
        click_x = self.screen_center_x + screen_offset[0]
        click_y = self.screen_center_y + screen_offset[1]

        # Ekran sınırları içinde mi kontrol et
        click_x = max(self.game_window_x, min(click_x, self.game_window_x + self.game_window_width))
        click_y = max(self.game_window_y, min(click_y, self.game_window_y + self.game_window_height))

        # Tıkla
        pyautogui.click(click_x, click_y)

    def approximate_world_to_screen_offset(self, dx: float, dy: float) -> Tuple[int, int]:
        """
        Dünya offset'ini ekran offset'ine çevir (YAKLASIK)

        ZQRadar formülünden esinlenerek:
        - 45 derece izometrik projeksiyon
        - Ölçeklendirme faktörü

        NOT: Bu TAM DOĞRU olmayabilir, kalibre edilmeli!
        """
        angle = -0.785398  # -45°

        # İzometrik dönüşüm
        screen_dx = dx * math.cos(angle) - dy * math.sin(angle)
        screen_dy = dx * math.sin(angle) + dy * math.cos(angle)

        # Ölçeklendirme (oyuna göre ayarla)
        # ZQRadar *4 kullanıyor, oyun farklı olabilir
        scale_factor = 10.0  # DENEYSEL! Oyunda test et

        screen_dx *= scale_factor
        screen_dy *= scale_factor

        return (int(screen_dx), int(screen_dy))

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
                    self.harvestables = [
                        Harvestable.from_dict(h) for h in dictionary['harvestableList']
                    ]

                # Local player'ı güncelle
                if 'localPlayer' in dictionary:
                    self.local_player = Player.from_dict(dictionary['localPlayer'])

        except:
            pass

    def get_player_position(self) -> Optional[Tuple[float, float]]:
        """Oyuncunun gerçek pozisyonunu al"""
        if self.local_player:
            return (self.local_player.posX, self.local_player.posY)
        return None

    def find_nearby_harvestables(self, x: float, y: float, radius: float = 50.0,
                                  min_tier: int = 5, max_tier: int = 8) -> List[Harvestable]:
        """Yakındaki toplanabilir kaynakları bul"""
        nearby = []
        for h in self.harvestables:
            distance = SmartMovementController.calculate_distance(x, y, h.posX, h.posY)
            if distance <= radius and min_tier <= h.tier <= max_tier and h.size > 0:
                nearby.append(h)
        nearby.sort(key=lambda h: SmartMovementController.calculate_distance(x, y, h.posX, h.posY))
        return nearby

    async def disconnect(self):
        """Bağlantıyı kapat"""
        if self.websocket:
            await self.websocket.close()


# ============================================================================
# ROTA KAYIT SİSTEMİ
# ============================================================================

class RouteRecorder:
    """Space tuşu ile rota kaydet"""

    def __init__(self, zqradar: ZQRadarClient):
        self.zqradar = zqradar
        self.route: List[Waypoint] = []
        self.recording = False

    async def start_recording(self):
        """Rota kaydını başlat"""
        print("\n🔴 KAYIT MODU BAŞLADI!")
        print("   Space: Waypoint ekle")
        print("   Ctrl+C: Kaydı bitir\n")

        self.recording = True
        keyboard.on_press_key("space", self.on_space_pressed)

        try:
            while self.recording:
                await asyncio.sleep(0.1)
        except KeyboardInterrupt:
            self.stop_recording()

    def on_space_pressed(self, event):
        """Space tuşuna basıldığında waypoint ekle"""
        if not self.recording:
            return

        pos = self.zqradar.get_player_position()
        if pos:
            x, y = pos
            wp = Waypoint(x, y, f"WP{len(self.route) + 1}")
            self.route.append(wp)
            print(f"✅ Waypoint eklendi: {wp}")
        else:
            print("❌ Pozisyon alınamadı!")

    def stop_recording(self):
        """Kaydı durdur"""
        self.recording = False
        keyboard.unhook_all()
        print(f"\n⏹️  Kayıt durduruldu. Toplam {len(self.route)} waypoint.\n")

    def save_route(self, filename: str = "route.json"):
        """Rotayı dosyaya kaydet"""
        data = [{"x": wp.x, "y": wp.y, "name": wp.name} for wp in self.route]
        with open(filename, 'w') as f:
            json.dump(data, f, indent=2)
        print(f"💾 Rota kaydedildi: {filename}")

    def load_route(self, filename: str = "route.json") -> List[Waypoint]:
        """Rotayı dosyadan yükle"""
        with open(filename, 'r') as f:
            data = json.load(f)
        route = [Waypoint(**wp) for wp in data]
        print(f"📂 Rota yüklendi: {len(route)} waypoint")
        return route


# ============================================================================
# ANA BOT
# ============================================================================

class RouteBot:
    """Rota tabanlı otomasyon botu"""

    def __init__(self, zqradar: ZQRadarClient):
        self.zqradar = zqradar
        self.movement = SmartMovementController()
        self.route: List[Waypoint] = []
        self.running = False

        # Ayarlar
        self.harvest_radius = 50.0
        self.min_tier = 5
        self.max_tier = 8

    def load_route(self, waypoints: List[Waypoint]):
        """Rota yükle"""
        self.route = waypoints
        print(f"📍 {len(self.route)} waypoint'lik rota yüklendi")

    async def start_route(self, loop: bool = True):
        """Rotayı başlat"""
        if not self.route:
            print("❌ Rota boş!")
            return

        print("\n🚀 ROTA BAŞLADI!\n")
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

                print(f"\n🎯 Hedef: {waypoint}")

                # Waypoint'e git
                await self.navigate_to_waypoint(waypoint)

                # Kaynakları topla
                pos = self.zqradar.get_player_position()
                if pos:
                    nearby = self.zqradar.find_nearby_harvestables(
                        pos[0], pos[1], self.harvest_radius, self.min_tier, self.max_tier
                    )

                    if nearby:
                        print(f"   📦 {len(nearby)} kaynak bulundu!")
                        for resource in nearby[:5]:
                            await self.harvest_resource(resource)

                await asyncio.sleep(1)

            if not loop:
                break

            print("\n🔄 Rota tekrar başlıyor...")
            await asyncio.sleep(2)

        self.running = False

    async def navigate_to_waypoint(self, waypoint: Waypoint):
        """Waypoint'e git"""
        max_attempts = 20

        for _ in range(max_attempts):
            pos = self.zqradar.get_player_position()
            if not pos:
                await asyncio.sleep(0.5)
                continue

            current_x, current_y = pos
            distance = self.movement.calculate_distance(
                current_x, current_y, waypoint.x, waypoint.y
            )

            if distance <= 3.0:
                print(f"   ✅ Waypoint'e ulaşıldı!")
                return

            # Hedefe tıkla
            self.movement.click_at_target(current_x, current_y, waypoint.x, waypoint.y)
            await asyncio.sleep(1.5)

        print(f"   ⚠️  Waypoint'e tam ulaşılamadı (mesafe: {distance:.1f})")

    async def harvest_resource(self, resource: Harvestable):
        """Kaynağı topla"""
        print(f"   ⛏️  T{resource.tier} kaynak toplanıyor...")

        # Kaynağa git
        pos = self.zqradar.get_player_position()
        if pos:
            self.movement.click_at_target(pos[0], pos[1], resource.posX, resource.posY)
            await asyncio.sleep(2)

        # E tuşuna bas
        keyboard.press_and_release('e')
        await asyncio.sleep(2 + resource.tier * 0.5)

        print(f"   ✅ Toplandı!")

    def stop(self):
        """Botu durdur"""
        self.running = False


# ============================================================================
# MAIN
# ============================================================================

async def main():
    print("╔══════════════════════════════════════════════════╗")
    print("║       ZQRadar Rota Botu - W2S ÇÖZÜMLÜ         ║")
    print("╚══════════════════════════════════════════════════╝\n")

    print("Mod seçin:")
    print("1. Rota kaydet (Space tuşu ile)")
    print("2. Rotayı oynat (route.json)")
    choice = input("\nSeçim (1/2): ")

    client = ZQRadarClient()
    await client.connect()
    asyncio.create_task(client.listen())
    await asyncio.sleep(2)

    if choice == "1":
        # ROTA KAYIT MODU
        recorder = RouteRecorder(client)
        await recorder.start_recording()
        recorder.save_route("route.json")

    elif choice == "2":
        # ROTA OYNATMA MODU
        recorder = RouteRecorder(client)
        route = recorder.load_route("route.json")

        bot = RouteBot(client)
        bot.load_route(route)

        print("\n⏳ 5 saniye içinde oyuna geç!")
        await asyncio.sleep(5)

        await bot.start_route(loop=True)

    await client.disconnect()


if __name__ == "__main__":
    asyncio.run(main())

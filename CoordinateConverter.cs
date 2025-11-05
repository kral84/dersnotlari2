using System;

namespace AlbionAutoRouter
{
    // GERÇEK izometrik koordinat dönüşümü
    public class CoordinateConverter
    {
        private MemoryReader memoryReader;

        // Kamera bilgileri (memory'den okunmalı)
        private float cameraX;
        private float cameraY;
        private float cameraZoom;
        private float cameraRotation;

        // Ekran bilgileri
        private int screenWidth = 1920;
        private int screenHeight = 1080;
        private int screenCenterX => screenWidth / 2;
        private int screenCenterY => screenHeight / 2;

        public CoordinateConverter(MemoryReader reader)
        {
            memoryReader = reader;
        }

        // Kamera bilgilerini oyundan oku
        public void UpdateCameraData()
        {
            // Memory'den kamera pozisyonunu oku
            // Bu offsetler oyuna göre değişir
            // cameraX = ...
            // cameraY = ...
            // cameraZoom = ...
            // cameraRotation = ...

            // Örnek placeholder
            var (playerX, playerY) = memoryReader.GetPlayerPosition();
            cameraX = playerX;
            cameraY = playerY;
            cameraZoom = 1.0f;
            cameraRotation = 0.0f;
        }

        // ✅ DOĞRU: İzometrik World-to-Screen dönüşümü
        public (int screenX, int screenY) WorldToScreen(float worldX, float worldY)
        {
            // 1. Oyun dünyası koordinatlarını kameraya göre ayarla
            float relativeX = worldX - cameraX;
            float relativeY = worldY - cameraY;

            // 2. İzometrik projeksiyon uygula
            // Albion Online 45 derece izometrik kullanır
            double angle = Math.PI / 4; // 45 derece

            float isoX = (relativeX - relativeY) * (float)Math.Cos(angle);
            float isoY = (relativeX + relativeY) * (float)Math.Sin(angle);

            // 3. Kamera rotasyonunu uygula
            if (cameraRotation != 0)
            {
                float cosRot = (float)Math.Cos(cameraRotation);
                float sinRot = (float)Math.Sin(cameraRotation);

                float rotatedX = isoX * cosRot - isoY * sinRot;
                float rotatedY = isoX * sinRot + isoY * cosRot;

                isoX = rotatedX;
                isoY = rotatedY;
            }

            // 4. Zoom uygula
            isoX *= cameraZoom;
            isoY *= cameraZoom;

            // 5. Ekran merkezine göre ayarla
            int screenX = screenCenterX + (int)isoX;
            int screenY = screenCenterY + (int)isoY;

            return (screenX, screenY);
        }

        // Ters işlem: Screen-to-World (fare tıklamasından dünya koordinatı)
        public (float worldX, float worldY) ScreenToWorld(int screenX, int screenY)
        {
            // Ekran merkezinden farkı al
            float relX = (screenX - screenCenterX) / cameraZoom;
            float relY = (screenY - screenCenterY) / cameraZoom;

            // Rotasyonu geri al
            if (cameraRotation != 0)
            {
                float cosRot = (float)Math.Cos(-cameraRotation);
                float sinRot = (float)Math.Sin(-cameraRotation);

                float unrotatedX = relX * cosRot - relY * sinRot;
                float unrotatedY = relX * sinRot + relY * cosRot;

                relX = unrotatedX;
                relY = unrotatedY;
            }

            // İzometrik projeksiyon geri al
            double angle = Math.PI / 4;
            float worldX = (relX / (float)Math.Cos(angle) + relY / (float)Math.Sin(angle)) / 2 + cameraX;
            float worldY = (relY / (float)Math.Sin(angle) - relX / (float)Math.Cos(angle)) / 2 + cameraY;

            return (worldX, worldY);
        }

        // Alternatif: Direct Memory Read (en doğru yöntem)
        public (int screenX, int screenY) WorldToScreenFromMemory(float worldX, float worldY)
        {
            // Oyunun kendi World-to-Screen fonksiyonunu çağır
            // Bu, oyunun memory'sinde bir fonksiyon çağrısı gerektirir
            // Cheat Engine ile bulunabilir

            // Örnek pseudo-kod:
            // IntPtr worldToScreenFunc = (IntPtr)0x12345678;
            // Call the function with worldX, worldY
            // Return screenX, screenY

            // Şimdilik fallback
            return WorldToScreen(worldX, worldY);
        }

        // Ekran koordinatının geçerli olup olmadığını kontrol et
        public bool IsScreenCoordinateValid(int screenX, int screenY)
        {
            return screenX >= 0 && screenX < screenWidth &&
                   screenY >= 0 && screenY < screenHeight;
        }

        // Dünya koordinatının ekranda görünür olup olmadığını kontrol et
        public bool IsWorldCoordinateVisible(float worldX, float worldY)
        {
            var (screenX, screenY) = WorldToScreen(worldX, worldY);
            return IsScreenCoordinateValid(screenX, screenY);
        }
    }

    // ✅ TAM DOĞRU KULLANIM ÖRNEĞİ
    public class FinalAutoRouter
    {
        private MouseController mouse;
        private MemoryReader memoryReader;
        private CoordinateConverter coordConverter;
        private ZQRadarIntegration zqRadar;

        public FinalAutoRouter()
        {
            memoryReader = new MemoryReader();

            if (!memoryReader.AttachToGame())
            {
                throw new Exception("Oyuna bağlanılamadı!");
            }

            coordConverter = new CoordinateConverter(memoryReader);
            zqRadar = new ZQRadarIntegration(memoryReader);
            mouse = new MouseController();
        }

        // ✅✅✅ TAMAMEN DOĞRU VERSİYON
        public void GoToResourceAndHarvest(Resource resource)
        {
            Console.WriteLine($"\n🎯 Hedef: {resource.Type} T{resource.Tier}");
            Console.WriteLine($"   Dünya Koordinatı: ({resource.Position.X}, {resource.Position.Y})");

            int maxAttempts = 20;
            int attempt = 0;
            float lastX = 0, lastY = 0;
            int stuckCount = 0;

            while (attempt < maxAttempts)
            {
                // 1. Gerçek oyuncu pozisyonunu oku
                var (currentX, currentY) = memoryReader.GetPlayerPosition();
                Console.WriteLine($"   📍 Mevcut pozisyon: ({currentX:F2}, {currentY:F2})");

                // 2. Hedefe ulaştık mı kontrol et
                if (memoryReader.HasReachedDestination(resource.Position.X, resource.Position.Y, 3.0f))
                {
                    Console.WriteLine("   ✅ Hedefe ulaşıldı!");

                    // 3. Kaynağı topla
                    HarvestResource(resource);
                    return;
                }

                // 4. Kamera bilgilerini güncelle
                coordConverter.UpdateCameraData();

                // 5. DOĞRU koordinat dönüşümü yap
                var (screenX, screenY) = coordConverter.WorldToScreen(resource.Position.X, resource.Position.Y);
                Console.WriteLine($"   🖱️  Ekran koordinatı: ({screenX}, {screenY})");

                // 6. Koordinat geçerli mi kontrol et
                if (!coordConverter.IsScreenCoordinateValid(screenX, screenY))
                {
                    Console.WriteLine("   ⚠️  Hedef ekran dışında! Kameraya yaklaştırılıyor...");

                    // Önce karaktere daha yakın bir noktaya tıkla
                    var (midX, midY) = ((currentX + resource.Position.X) / 2, (currentY + resource.Position.Y) / 2);
                    var (midScreenX, midScreenY) = coordConverter.WorldToScreen(midX, midY);

                    if (coordConverter.IsScreenCoordinateValid(midScreenX, midScreenY))
                    {
                        mouse.HumanLikeClick(midScreenX, midScreenY);
                    }
                }
                else
                {
                    // 7. İnsan gibi tıkla
                    mouse.HumanLikeClick(screenX, screenY);
                }

                // 8. Hareket etmesini bekle
                System.Threading.Thread.Sleep(2000);

                // 9. Takıldı mı kontrol et
                var (newX, newY) = memoryReader.GetPlayerPosition();
                if (memoryReader.IsPlayerStuck(lastX, lastY))
                {
                    stuckCount++;
                    Console.WriteLine($"   ⚠️  Karakter takıldı! ({stuckCount}/3)");

                    if (stuckCount >= 3)
                    {
                        Console.WriteLine("   ❌ Hedefe ulaşılamıyor, sonraki kaynağa geçiliyor...");
                        return;
                    }

                    // Alternatif rota dene: Biraz sağa kaydır
                    var (altX, altY) = coordConverter.WorldToScreen(resource.Position.X + 5, resource.Position.Y + 5);
                    mouse.ClickAt(altX, altY);
                    System.Threading.Thread.Sleep(1000);
                }
                else
                {
                    stuckCount = 0; // İlerleme var, sıfırla
                }

                lastX = currentX;
                lastY = currentY;
                attempt++;
            }

            Console.WriteLine("   ❌ Maksimum deneme sayısına ulaşıldı!");
        }

        private void HarvestResource(Resource resource)
        {
            Console.WriteLine($"   ⛏️  {resource.Type} toplanıyor...");

            // Kaynağa tıkla
            var (screenX, screenY) = coordConverter.WorldToScreen(resource.Position.X, resource.Position.Y);
            mouse.ClickAt(screenX, screenY);

            System.Threading.Thread.Sleep(500);

            // E tuşuna bas (toplama)
            SendKeys.SendWait("E");

            // Toplama animasyonunu bekle (tier'e göre değişir)
            int harvestTime = 2000 + (resource.Tier * 500);
            System.Threading.Thread.Sleep(harvestTime);

            Console.WriteLine("   ✅ Toplama tamamlandı!");
        }

        // Otomatik farming loop
        public void AutoFarm(int minTier, int maxTier, string[] resourceTypes)
        {
            Console.WriteLine("\n🌾 Otomatik farming başladı!");
            Console.WriteLine($"   Tier: {minTier}-{maxTier}");
            Console.WriteLine($"   Tipler: {string.Join(", ", resourceTypes)}");

            while (true) // Sonsuz döngü (Ctrl+C ile dur)
            {
                // 1. Güncel kaynakları al
                var allResources = zqRadar.GetResourcesFromMemory();
                var filtered = zqRadar.FilterResourcesByType(allResources, resourceTypes);
                var tiered = zqRadar.FilterResourcesByTier(filtered, minTier, maxTier);
                var nearest = zqRadar.GetNearestResources(tiered, 10);

                if (nearest.Count == 0)
                {
                    Console.WriteLine("\n⏳ Kaynak bulunamadı, 30 saniye bekleniyor...");
                    System.Threading.Thread.Sleep(30000);
                    continue;
                }

                Console.WriteLine($"\n📦 {nearest.Count} kaynak bulundu, toplanıyor...");

                // 2. Her kaynağı topla
                foreach (var resource in nearest)
                {
                    GoToResourceAndHarvest(resource);
                }

                Console.WriteLine("\n🔄 Tur tamamlandı, yeni kaynaklar aranıyor...");
                System.Threading.Thread.Sleep(5000);
            }
        }
    }

    // 📖 KULLANIM
    class FinalExample
    {
        static void Main()
        {
            try
            {
                var bot = new FinalAutoRouter();

                // T5-T8 demir madeni topla
                bot.AutoFarm(5, 8, new[] { "Iron Ore", "Gold Ore" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Hata: {ex.Message}");
            }
        }
    }
}

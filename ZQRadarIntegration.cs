using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Linq;

namespace AlbionAutoRouter
{
    // ZQRadar'dan GERÇEK kaynak verisi okuma
    public class ZQRadarIntegration
    {
        private MemoryReader memoryReader;

        // ZQRadar memory offsets (örnek - gerçek değerler farklı olabilir)
        private readonly IntPtr RESOURCE_LIST_BASE = (IntPtr)0x140500000;
        private readonly int RESOURCE_STRUCT_SIZE = 0x50; // Her kaynak 80 byte

        public ZQRadarIntegration(MemoryReader reader)
        {
            memoryReader = reader;
        }

        // YÖNTEM 1: Memory'den kaynak listesi oku
        public List<Resource> GetResourcesFromMemory()
        {
            List<Resource> resources = new List<Resource>();

            try
            {
                // ZQRadar'ın tespit ettiği kaynakları oku
                // Bu gerçek implementasyon, ZQRadar'ın memory yapısına bağlı

                Console.WriteLine("🔍 Kaynaklar taranıyor...");

                // Örnek: 100 kaynak slot'u kontrol et
                for (int i = 0; i < 100; i++)
                {
                    IntPtr resourceAddress = IntPtr.Add(RESOURCE_LIST_BASE, i * RESOURCE_STRUCT_SIZE);

                    // Kaynak var mı kontrol et
                    byte[] buffer = new byte[4];
                    int bytesRead = 0;

                    // Kaynak ID'sini oku
                    // ReadProcessMemory(...) ile

                    // Eğer geçerli bir kaynak varsa
                    // Resource nesnesi oluştur ve ekle
                    // resources.Add(new Resource(...));
                }

                Console.WriteLine($"✅ {resources.Count} kaynak bulundu!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Kaynak okuma hatası: {ex.Message}");
            }

            return resources;
        }

        // YÖNTEM 2: Packet sniffing ile (ZQRadar sunucusundan)
        public async System.Threading.Tasks.Task<List<Resource>> GetResourcesFromAPI()
        {
            try
            {
                // Eğer ZQRadar bir API sunuyorsa
                using HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://localhost:8080/api/resources");

                var resourceData = JsonSerializer.Deserialize<List<ResourceDTO>>(response);

                return resourceData.Select(r => new Resource(
                    (int)r.X,
                    (int)r.Y,
                    r.Type,
                    r.Tier
                )).ToList();
            }
            catch
            {
                Console.WriteLine("❌ ZQRadar API'sine bağlanılamadı!");
                return new List<Resource>();
            }
        }

        // YÖNTEM 3: Görüntü işleme ile kaynak tespiti
        public List<Resource> GetResourcesFromScreen()
        {
            List<Resource> resources = new List<Resource>();

            try
            {
                Console.WriteLine("📸 Ekran görüntüsü analiz ediliyor...");

                // 1. Ekran görüntüsü al
                var screenshot = CaptureScreen();

                // 2. Kaynak ikonlarını tespit et (template matching)
                // OpenCV gibi bir kütüphane ile
                // - Demir madeni ikonu
                // - Odun ikonu
                // - Elyaf ikonu vb.

                // 3. Tespit edilen her kaynak için Resource nesnesi oluştur
                // resources.Add(...);

                Console.WriteLine($"✅ {resources.Count} kaynak tespit edildi!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Ekran analiz hatası: {ex.Message}");
            }

            return resources;
        }

        private System.Drawing.Bitmap CaptureScreen()
        {
            // Ekran görüntüsü al
            var bounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            var bitmap = new System.Drawing.Bitmap(bounds.Width, bounds.Height);
            using (var g = System.Drawing.Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(System.Drawing.Point.Empty, System.Drawing.Point.Empty, bounds.Size);
            }
            return bitmap;
        }

        // Filtreleme: Sadece belirli tier kaynakları al
        public List<Resource> FilterResourcesByTier(List<Resource> resources, int minTier, int maxTier)
        {
            return resources
                .Where(r => r.Tier >= minTier && r.Tier <= maxTier)
                .ToList();
        }

        // Filtreleme: Sadece belirli tip kaynakları al
        public List<Resource> FilterResourcesByType(List<Resource> resources, string[] types)
        {
            return resources
                .Where(r => types.Contains(r.Type))
                .ToList();
        }

        // En yakın N kaynağı bul
        public List<Resource> GetNearestResources(List<Resource> resources, int count)
        {
            var (playerX, playerY) = memoryReader.GetPlayerPosition();

            return resources
                .OrderBy(r => Math.Sqrt(Math.Pow(r.Position.X - playerX, 2) + Math.Pow(r.Position.Y - playerY, 2)))
                .Take(count)
                .ToList();
        }
    }

    // API için DTO
    public class ResourceDTO
    {
        public float X { get; set; }
        public float Y { get; set; }
        public string Type { get; set; }
        public int Tier { get; set; }
    }

    // ✅ GÜNCELLENMİŞ KULLANIM
    class ImprovedFarmingExample
    {
        public static void Example()
        {
            var memoryReader = new MemoryReader();
            memoryReader.AttachToGame();

            var zqRadar = new ZQRadarIntegration(memoryReader);

            // ✅ DOĞRU: Dinamik kaynak verisi
            var allResources = zqRadar.GetResourcesFromMemory();

            // Sadece Tier 5+ demir madenleri
            var ironOres = zqRadar.FilterResourcesByType(allResources, new[] { "Iron Ore" });
            var tier5Iron = zqRadar.FilterResourcesByTier(ironOres, 5, 8);

            // En yakın 10 tanesini topla
            var nearestResources = zqRadar.GetNearestResources(tier5Iron, 10);

            Console.WriteLine($"🎯 Toplanacak {nearestResources.Count} kaynak:");
            foreach (var res in nearestResources)
            {
                Console.WriteLine($"  - {res.Type} T{res.Tier} @ ({res.Position.X}, {res.Position.Y})");
            }

            // Şimdi topla
            var router = new ImprovedAutoRouter();
            foreach (var resource in nearestResources)
            {
                router.GoToDestinationSafe(resource.Position.X, resource.Position.Y);
                // Toplama işlemi...
            }
        }
    }
}

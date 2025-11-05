using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Linq;

namespace SimpleAlbionBot
{
    // BASİT YAKLAŞIM: ZQRadar'ın gösterdiği kaynakları ekrandan oku
    public class SimpleZQRadarBot
    {
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        const uint MOUSEEVENTF_LEFTUP = 0x04;

        // ZQRadar'ın kaynak ikonlarının renkleri (örnek)
        // ZQRadar'da demir = kırmızı, odun = kahverengi vb.
        private static readonly Color IRON_COLOR = Color.FromArgb(255, 100, 100);
        private static readonly Color WOOD_COLOR = Color.FromArgb(139, 69, 19);
        private static readonly Color FIBER_COLOR = Color.FromArgb(100, 255, 100);

        // 1. EKRAN GÖRÜNTÜSÜ AL
        public static Bitmap CaptureScreen()
        {
            var bounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            var screenshot = new Bitmap(bounds.Width, bounds.Height);

            using (var graphics = Graphics.FromImage(screenshot))
            {
                graphics.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
            }

            return screenshot;
        }

        // 2. ZQRadar OVERLAY'İNDEN KAYNAK İKONLARINI BUL
        // ZQRadar kaynakları harita üzerinde renkli noktalar olarak gösterir
        public static List<Point> FindResourcesOnScreen(Bitmap screenshot, Color targetColor, int tolerance = 30)
        {
            List<Point> resourcePoints = new List<Point>();

            // Her pikseli tara
            for (int x = 0; x < screenshot.Width; x += 5) // Her 5 piksel (hız için)
            {
                for (int y = 0; y < screenshot.Height; y += 5)
                {
                    Color pixelColor = screenshot.GetPixel(x, y);

                    // Renk eşleşmesi (toleranslı)
                    if (IsColorSimilar(pixelColor, targetColor, tolerance))
                    {
                        resourcePoints.Add(new Point(x, y));
                    }
                }
            }

            // Yakın noktaları birleştir (kümeleme)
            return ClusterPoints(resourcePoints, 20);
        }

        // Renk benzerliği kontrolü
        private static bool IsColorSimilar(Color c1, Color c2, int tolerance)
        {
            return Math.Abs(c1.R - c2.R) < tolerance &&
                   Math.Abs(c1.G - c2.G) < tolerance &&
                   Math.Abs(c1.B - c2.B) < tolerance;
        }

        // Yakın noktaları birleştir (aynı kaynak için)
        private static List<Point> ClusterPoints(List<Point> points, int distance)
        {
            List<Point> clustered = new List<Point>();

            foreach (var point in points)
            {
                bool nearExisting = clustered.Any(p =>
                    Math.Sqrt(Math.Pow(p.X - point.X, 2) + Math.Pow(p.Y - point.Y, 2)) < distance
                );

                if (!nearExisting)
                {
                    clustered.Add(point);
                }
            }

            return clustered;
        }

        // 3. MOUSE TIK
        public static void ClickAt(int x, int y)
        {
            Console.WriteLine($"Tıklanıyor: ({x}, {y})");

            SetCursorPos(x, y);
            Thread.Sleep(100);

            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            Thread.Sleep(50);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        // 4. RASTGELE TIK (anti-cheat için)
        public static void HumanClick(int x, int y)
        {
            Random rand = new Random();

            int randomX = x + rand.Next(-10, 10);
            int randomY = y + rand.Next(-10, 10);

            Thread.Sleep(rand.Next(200, 500));

            ClickAt(randomX, randomY);
        }

        // 5. ANA BOT LOGİĞİ
        public static void RunBot()
        {
            Console.WriteLine("=== BASİT ALBION BOT (ZQRadar ile) ===\n");
            Console.WriteLine("⚠️  5 saniye içinde Albion Online penceresine geç!\n");
            Thread.Sleep(5000);

            Console.WriteLine("🤖 Bot başladı! (Durdurmak için Ctrl+C)");

            int cycle = 0;

            while (true)
            {
                cycle++;
                Console.WriteLine($"\n--- TUR {cycle} ---");

                try
                {
                    // 1. Ekran görüntüsü al
                    Console.WriteLine("📸 Ekran taranıyor...");
                    using (var screenshot = CaptureScreen())
                    {
                        // 2. Demir madenlerini bul (kırmızı noktalar)
                        var ironOres = FindResourcesOnScreen(screenshot, IRON_COLOR, 30);
                        Console.WriteLine($"   ⛏️  {ironOres.Count} demir madeni bulundu");

                        // 3. Her kaynağa git
                        foreach (var resource in ironOres.Take(5)) // İlk 5 tanesi
                        {
                            Console.WriteLine($"   🎯 Gidiliyor: ({resource.X}, {resource.Y})");

                            // Kaynağa tıkla (harita üzerinde)
                            HumanClick(resource.X, resource.Y);

                            // Karakterin gitmesini bekle
                            Thread.Sleep(3000);

                            // Tekrar kaynağa tıkla (toplama için)
                            HumanClick(resource.X, resource.Y);
                            Thread.Sleep(500);

                            // E tuşuna bas (toplama)
                            System.Windows.Forms.SendKeys.SendWait("E");

                            // Toplama animasyonu (3-5 saniye)
                            Thread.Sleep(4000);

                            Console.WriteLine("   ✅ Toplandı!");
                        }
                    }

                    // 4. Bir sonraki tura hazırlan
                    Console.WriteLine("\n⏳ 10 saniye bekleniyor...");
                    Thread.Sleep(10000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Hata: {ex.Message}");
                    Thread.Sleep(5000);
                }
            }
        }
    }

    // DAHA BASİT: ZQRadar JSON/API Çıktısı Varsa
    public class ZQRadarAPIBot
    {
        // ZQRadar'ın bir API'si varsa (localhost:8080 gibi)
        // ya da bir JSON dosyası oluşturuyorsa
        public static void RunWithAPI()
        {
            Console.WriteLine("ZQRadar API botu başladı!");

            while (true)
            {
                try
                {
                    // 1. ZQRadar'dan kaynak listesini al
                    // Örnek: http://localhost:8080/resources.json
                    var resources = GetResourcesFromZQRadar();

                    Console.WriteLine($"📦 {resources.Count} kaynak bulundu");

                    // 2. Her kaynağa git
                    foreach (var res in resources)
                    {
                        Console.WriteLine($"🎯 {res.Type} @ ({res.ScreenX}, {res.ScreenY})");

                        // Tıkla
                        SimpleZQRadarBot.HumanClick(res.ScreenX, res.ScreenY);
                        Thread.Sleep(3000);

                        // Topla
                        System.Windows.Forms.SendKeys.SendWait("E");
                        Thread.Sleep(4000);
                    }

                    Thread.Sleep(10000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Hata: {ex.Message}");
                    Thread.Sleep(5000);
                }
            }
        }

        private static List<ResourceData> GetResourcesFromZQRadar()
        {
            // SEÇENEK 1: Dosyadan oku
            // ZQRadar bir resources.txt dosyası oluşturuyorsa
            // string[] lines = File.ReadAllLines("C:\\ZQRadar\\resources.txt");

            // SEÇENEK 2: HTTP API'den al
            // using var client = new System.Net.Http.HttpClient();
            // var json = client.GetStringAsync("http://localhost:8080/resources").Result;
            // return JsonSerializer.Deserialize<List<ResourceData>>(json);

            // ŞİMDİLİK boş liste dön
            return new List<ResourceData>();
        }
    }

    public class ResourceData
    {
        public string Type { get; set; }
        public int ScreenX { get; set; }
        public int ScreenY { get; set; }
        public int Tier { get; set; }
    }

    // EN BASİT: Manuel koordinatlar
    public class ManualBot
    {
        public static void RunManual()
        {
            Console.WriteLine("=== MANUEL ROTA BOTU ===");
            Console.WriteLine("ZQRadar'da kaynakları gör, koordinatları not et, buraya yaz!\n");

            // ZQRadar'da gördüğün kaynakların ekran koordinatları
            List<Point> manualResources = new List<Point>
            {
                new Point(800, 400),   // 1. demir
                new Point(950, 450),   // 2. demir
                new Point(1100, 500),  // 3. demir
                // ... daha fazla ekle
            };

            Console.WriteLine($"📍 {manualResources.Count} manuel nokta eklendi");
            Console.WriteLine("⚠️  5 saniye içinde oyuna geç!\n");
            Thread.Sleep(5000);

            int loop = 0;

            while (true) // Sonsuz git-gel
            {
                loop++;
                Console.WriteLine($"\n--- TUR {loop} ---");

                foreach (var resource in manualResources)
                {
                    Console.WriteLine($"🎯 Gidiliyor: ({resource.X}, {resource.Y})");

                    // Haritaya tıkla
                    SimpleZQRadarBot.HumanClick(resource.X, resource.Y);
                    Thread.Sleep(3000);

                    // Kaynağa tıkla
                    SimpleZQRadarBot.HumanClick(resource.X, resource.Y);
                    Thread.Sleep(500);

                    // Topla
                    System.Windows.Forms.SendKeys.SendWait("E");
                    Thread.Sleep(4000);

                    Console.WriteLine("✅ Toplandı!");
                }

                Console.WriteLine("\n🔄 Rota tamamlandı, tekrar başlıyor...");
                Thread.Sleep(5000);
            }
        }
    }

    // KULLANIM
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hangi modu kullanmak istiyorsun?");
            Console.WriteLine("1. Otomatik (Ekrandan kaynak tespiti)");
            Console.WriteLine("2. Manuel (Elle girdiğin koordinatlar)");
            Console.WriteLine("3. API (ZQRadar API/JSON çıktısı)");
            Console.Write("\nSeçim: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    SimpleZQRadarBot.RunBot();
                    break;
                case "2":
                    ManualBot.RunManual();
                    break;
                case "3":
                    ZQRadarAPIBot.RunWithAPI();
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim!");
                    break;
            }
        }
    }
}

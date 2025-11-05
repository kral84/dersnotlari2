using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;

namespace ZQRadarRouteBot
{
    // ZQRadar'dan gelen kaynak verisi
    public class Harvestable
    {
        public int id { get; set; }
        public int type { get; set; }         // 0-27: demir, odun, elyaf vs
        public int tier { get; set; }         // T1-T8
        public float posX { get; set; }
        public float posY { get; set; }
        public int charges { get; set; }      // Enchantment 0-3
        public int size { get; set; }         // Kalan miktar
    }

    // ZQRadar WebSocket mesaj yapısı
    public class ZQRadarEvent
    {
        public string code { get; set; }
        public Dictionary<string, object> dictionary { get; set; }
    }

    // Rota noktası
    public class Waypoint
    {
        public float X { get; set; }
        public float Y { get; set; }
        public string Name { get; set; }

        public Waypoint(float x, float y, string name = "")
        {
            X = x;
            Y = y;
            Name = name;
        }
    }

    // Mouse kontrolü
    public class MouseControl
    {
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        const uint MOUSEEVENTF_LEFTUP = 0x04;

        public static void Click(int x, int y)
        {
            SetCursorPos(x, y);
            Thread.Sleep(50);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            Thread.Sleep(50);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public static void HumanClick(int x, int y)
        {
            Random rand = new Random();
            Click(x + rand.Next(-5, 5), y + rand.Next(-5, 5));
            Thread.Sleep(rand.Next(100, 300));
        }
    }

    // ANA BOT: ZQRadar ile rota sistemi
    public class RouteBot
    {
        private ClientWebSocket webSocket;
        private List<Harvestable> nearbyResources = new List<Harvestable>();
        private List<Waypoint> route = new List<Waypoint>();
        private bool isRunning = false;

        // Ayarlar
        public int HarvestRadius { get; set; } = 50;      // Kaç birim yakınlıktaki kaynakları topla
        public int MinTier { get; set; } = 5;             // Minimum tier
        public int MaxTier { get; set; } = 8;             // Maximum tier
        public List<int> ResourceTypes { get; set; }      // Hangi kaynak tipleri (opsiyonel)

        public RouteBot()
        {
            webSocket = new ClientWebSocket();
            ResourceTypes = new List<int>(); // Boş = tümü
        }

        // 1. ZQRadar'a bağlan
        public async Task ConnectToZQRadar()
        {
            try
            {
                Console.WriteLine("🔌 ZQRadar'a bağlanılıyor (ws://localhost:5002)...");
                await webSocket.ConnectAsync(new Uri("ws://localhost:5002"), CancellationToken.None);
                Console.WriteLine("✅ ZQRadar'a bağlandı!");

                // Arka planda mesajları dinle
                _ = Task.Run(() => ListenForMessages());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Bağlantı hatası: {ex.Message}");
                Console.WriteLine("   ZQRadar açık mı? (localhost:5001)");
            }
        }

        // 2. WebSocket mesajlarını dinle
        private async Task ListenForMessages()
        {
            byte[] buffer = new byte[1024 * 1024]; // 1MB buffer

            while (webSocket.State == WebSocketState.Open)
            {
                try
                {
                    var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                        ProcessMessage(message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Mesaj okuma hatası: {ex.Message}");
                    break;
                }
            }
        }

        // 3. Gelen mesajları işle
        private void ProcessMessage(string message)
        {
            try
            {
                var eventData = JsonSerializer.Deserialize<ZQRadarEvent>(message);

                if (eventData?.code == "event" && eventData.dictionary != null)
                {
                    // Kaynak listesini güncelle
                    if (eventData.dictionary.ContainsKey("harvestableList"))
                    {
                        var resourcesJson = JsonSerializer.Serialize(eventData.dictionary["harvestableList"]);
                        var resources = JsonSerializer.Deserialize<List<Harvestable>>(resourcesJson);

                        if (resources != null)
                        {
                            nearbyResources = resources;
                            // Console.WriteLine($"📦 {nearbyResources.Count} kaynak güncellendi");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Sessizce atla (bazı mesajlar parse edilemeyebilir)
            }
        }

        // 4. Rota ekle
        public void AddWaypoint(float x, float y, string name = "")
        {
            route.Add(new Waypoint(x, y, name));
            Console.WriteLine($"📍 Waypoint eklendi: {name} ({x}, {y})");
        }

        public void SetRoute(List<Waypoint> waypoints)
        {
            route = waypoints;
            Console.WriteLine($"📍 {route.Count} waypoint'lik rota yüklendi");
        }

        // 5. Mesafe hesapla
        private float Distance(float x1, float y1, float x2, float y2)
        {
            return (float)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        // 6. Yakındaki toplanabilir kaynakları bul
        private List<Harvestable> FindNearbyHarvestables(float currentX, float currentY)
        {
            return nearbyResources
                .Where(r =>
                {
                    // Mesafe kontrolü
                    if (Distance(currentX, currentY, r.posX, r.posY) > HarvestRadius)
                        return false;

                    // Tier kontrolü
                    if (r.tier < MinTier || r.tier > MaxTier)
                        return false;

                    // Tip kontrolü (eğer filtre varsa)
                    if (ResourceTypes.Count > 0 && !ResourceTypes.Contains(r.type))
                        return false;

                    // Size kontrolü (kaynak bitmişse atla)
                    if (r.size <= 0)
                        return false;

                    return true;
                })
                .OrderBy(r => Distance(currentX, currentY, r.posX, r.posY))
                .ToList();
        }

        // 7. Kaynağı topla
        private void HarvestResource(Harvestable resource)
        {
            Console.WriteLine($"   ⛏️  T{resource.tier} kaynak toplanıyor (ID: {resource.id})");

            // Kaynağa tıkla (koordinat dönüşümü gerekebilir - şimdilik basit)
            int screenX = (int)resource.posX; // TODO: World-to-screen
            int screenY = (int)resource.posY;

            MouseControl.HumanClick(screenX, screenY);
            Thread.Sleep(500);

            // E tuşuna bas (toplama)
            System.Windows.Forms.SendKeys.SendWait("E");

            // Toplama süresi (tier'e göre)
            int harvestTime = 2000 + (resource.tier * 500);
            Thread.Sleep(harvestTime);

            Console.WriteLine($"   ✅ Toplandı!");
        }

        // 8. ROTAYI BAŞLAT (Ana Fonksiyon!)
        public async Task StartRoute(bool loop = true)
        {
            if (route.Count == 0)
            {
                Console.WriteLine("❌ Rota boş! AddWaypoint() ile waypoint ekle.");
                return;
            }

            Console.WriteLine("\n🚀 ROTA BAŞLADI!");
            Console.WriteLine($"   Toplam waypoint: {route.Count}");
            Console.WriteLine($"   Toplama yarıçapı: {HarvestRadius}");
            Console.WriteLine($"   Tier aralığı: T{MinTier}-T{MaxTier}");
            Console.WriteLine($"   Döngü: {(loop ? "Evet (sonsuz)" : "Hayır (1 tur)")}\n");

            isRunning = true;
            int tourCount = 0;

            while (isRunning)
            {
                tourCount++;
                Console.WriteLine($"\n{'='}{new string('=', 50)}");
                Console.WriteLine($"  TUR {tourCount}");
                Console.WriteLine($"{'='}{new string('=', 50)}\n");

                foreach (var waypoint in route)
                {
                    if (!isRunning) break;

                    Console.WriteLine($"\n🎯 Waypoint: {waypoint.Name} ({waypoint.X}, {waypoint.Y})");

                    // Waypoint'e git
                    int screenX = (int)waypoint.X; // TODO: World-to-screen dönüşümü
                    int screenY = (int)waypoint.Y;
                    MouseControl.HumanClick(screenX, screenY);

                    // Karakterin gitmesini bekle
                    await Task.Delay(3000);

                    // Yakındaki kaynakları kontrol et
                    var nearby = FindNearbyHarvestables(waypoint.X, waypoint.Y);

                    if (nearby.Count > 0)
                    {
                        Console.WriteLine($"   📦 {nearby.Count} toplanabilir kaynak bulundu!");

                        foreach (var resource in nearby)
                        {
                            HarvestResource(resource);
                        }
                    }
                    else
                    {
                        Console.WriteLine("   ⚪ Yakında kaynak yok, devam ediliyor...");
                    }

                    // Bir sonraki waypoint'e geçmeden kısa bekle
                    await Task.Delay(1000);
                }

                if (!loop)
                {
                    Console.WriteLine("\n✅ Rota tamamlandı (döngü kapalı)");
                    break;
                }

                Console.WriteLine("\n🔄 Rota tekrar başlıyor...");
                await Task.Delay(2000);
            }

            isRunning = false;
        }

        // Rotayı durdur
        public void StopRoute()
        {
            isRunning = false;
            Console.WriteLine("\n⏹️  Rota durduruldu!");
        }

        // Bağlantıyı kapat
        public async Task Disconnect()
        {
            if (webSocket.State == WebSocketState.Open)
            {
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
                Console.WriteLine("🔌 ZQRadar bağlantısı kapatıldı");
            }
        }
    }

    // KULLANIM ÖRNEĞİ
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("╔══════════════════════════════════════════════════╗");
            Console.WriteLine("║   ZQRadar Rota Botu - Otomatik Kaynak Toplama  ║");
            Console.WriteLine("╚══════════════════════════════════════════════════╝\n");

            Console.WriteLine("⚠️  UYARI: Bu bot eğitim amaçlıdır!");
            Console.WriteLine("⚠️  Albion Online kullanım şartlarını ihlal edebilir!\n");

            // Bot oluştur
            var bot = new RouteBot();

            // Ayarlar
            bot.MinTier = 5;                    // T5+ kaynaklar
            bot.MaxTier = 8;                    // T8'e kadar
            bot.HarvestRadius = 50;             // 50 birim yarıçapında topla
            // bot.ResourceTypes = new List<int> { 5 }; // Sadece demir (5 = iron, opsiyonel)

            // ZQRadar'a bağlan
            await bot.ConnectToZQRadar();
            await Task.Delay(2000); // Bağlantının stabilize olması için bekle

            // Rotayı tanımla (manuel waypoint'ler)
            Console.WriteLine("\n📍 Rota oluşturuluyor...\n");

            bot.AddWaypoint(100, 100, "Başlangıç");
            bot.AddWaypoint(200, 150, "Maden Bölgesi 1");
            bot.AddWaypoint(300, 200, "Maden Bölgesi 2");
            bot.AddWaypoint(400, 250, "Maden Bölgesi 3");
            bot.AddWaypoint(300, 300, "Dönüş Noktası");

            // VEYA: Dosyadan rota yükle
            // var route = LoadRouteFromFile("my_route.json");
            // bot.SetRoute(route);

            Console.WriteLine("\n⏳ 5 saniye içinde Albion Online'a geç!");
            await Task.Delay(5000);

            // Rotayı başlat (sonsuz döngü)
            await bot.StartRoute(loop: true);

            // Temizlik
            await bot.Disconnect();
        }
    }
}

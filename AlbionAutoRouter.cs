using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing;

namespace AlbionAutoRouter
{
    // 1. MOUSE CONTROL - Mouse tıklama için Windows API
    public class MouseController
    {
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        const uint MOUSEEVENTF_LEFTUP = 0x04;

        // Belirtilen koordinata tıkla
        public void ClickAt(int x, int y)
        {
            // Önce mouse'u hareket ettir
            SetCursorPos(x, y);
            Thread.Sleep(50); // Kısa bekleme

            // Sol tık yap
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            Thread.Sleep(50);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

            Console.WriteLine($"Tıklandı: ({x}, {y})");
        }

        // İnsan gibi rastgele tıklama (anti-cheat bypass için)
        public void HumanLikeClick(int x, int y)
        {
            Random rand = new Random();

            // Koordinata +/- 5 piksel rastgele ekle
            int randomX = x + rand.Next(-5, 5);
            int randomY = y + rand.Next(-5, 5);

            // Rastgele bekleme (100-300ms arası)
            Thread.Sleep(rand.Next(100, 300));

            ClickAt(randomX, randomY);
        }
    }

    // 2. HARITA NODE'U - Her nokta için veri yapısı
    public class MapNode
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsWalkable { get; set; } // Yürünebilir mi?
        public int Cost { get; set; } // Geçiş maliyeti (tepe=yüksek, düz=düşük)

        public MapNode(int x, int y, bool walkable = true, int cost = 1)
        {
            X = x;
            Y = y;
            IsWalkable = walkable;
            Cost = cost;
        }
    }

    // 3. PATHFINDING - Basit A* algoritması
    public class PathFinder
    {
        private MapNode[,] grid;
        private int width;
        private int height;

        public PathFinder(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.grid = new MapNode[width, height];

            // Grid'i doldur (başlangıçta her yer yürünebilir)
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    grid[x, y] = new MapNode(x, y);
                }
            }
        }

        // Engel ekle (tepe, duvar, su vb)
        public void SetObstacle(int x, int y)
        {
            if (x >= 0 && x < width && y >= 0 && y < height)
            {
                grid[x, y].IsWalkable = false;
            }
        }

        // Tepe gibi zor alanlar için maliyet artır
        public void SetDifficultTerrain(int x, int y, int cost)
        {
            if (x >= 0 && x < width && y >= 0 && y < height)
            {
                grid[x, y].Cost = cost;
            }
        }

        // Basitleştirilmiş A* pathfinding
        public List<Point> FindPath(Point start, Point end)
        {
            List<Point> path = new List<Point>();

            // Basit yaklaşım: Doğrudan git ama engelleri kontrol et
            int currentX = start.X;
            int currentY = start.Y;

            while (currentX != end.X || currentY != end.Y)
            {
                path.Add(new Point(currentX, currentY));

                // X yönünde hareket
                if (currentX < end.X && IsPointWalkable(currentX + 1, currentY))
                    currentX++;
                else if (currentX > end.X && IsPointWalkable(currentX - 1, currentY))
                    currentX--;

                // Y yönünde hareket
                if (currentY < end.Y && IsPointWalkable(currentX, currentY + 1))
                    currentY++;
                else if (currentY > end.Y && IsPointWalkable(currentX, currentY - 1))
                    currentY--;

                // Sonsuz döngü koruması
                if (path.Count > 1000) break;
            }

            path.Add(end);
            return path;
        }

        private bool IsPointWalkable(int x, int y)
        {
            if (x < 0 || x >= width || y < 0 || y >= height)
                return false;

            return grid[x, y].IsWalkable;
        }
    }

    // 4. KAYNAK TOPLAMA - ZQRadar ile entegrasyon
    public class Resource
    {
        public Point Position { get; set; }
        public string Type { get; set; } // "Ore", "Wood", "Fiber" vb
        public int Tier { get; set; }

        public Resource(int x, int y, string type, int tier)
        {
            Position = new Point(x, y);
            Type = type;
            Tier = tier;
        }
    }

    // 5. ANA OTOMASYON SİSTEMİ
    public class AutoRouter
    {
        private MouseController mouse;
        private PathFinder pathfinder;
        private Point playerPosition;

        public AutoRouter(int mapWidth, int mapHeight)
        {
            mouse = new MouseController();
            pathfinder = new PathFinder(mapWidth, mapHeight);
        }

        // Haritaya engel ekle
        public void AddObstacles(List<Point> obstacles)
        {
            foreach (var obs in obstacles)
            {
                pathfinder.SetObstacle(obs.X, obs.Y);
            }
        }

        // Tek bir hedefe git
        public void GoToDestination(Point destination)
        {
            Console.WriteLine($"Hedefe gidiliyor: ({destination.X}, {destination.Y})");

            // Rota hesapla
            List<Point> route = pathfinder.FindPath(playerPosition, destination);

            Console.WriteLine($"Rota bulundu: {route.Count} adım");

            // Her waypoint'e git
            foreach (var waypoint in route)
            {
                // KISA ADIMLARLA GİT (tepeler/çukurlar için önemli!)
                // Her 50-100 piksel için bir tıklama
                if (Math.Abs(waypoint.X - playerPosition.X) > 50 ||
                    Math.Abs(waypoint.Y - playerPosition.Y) > 50)
                {
                    // Ekran koordinatına çevir (örnek: 800x600 oyun penceresi)
                    int screenX = waypoint.X * 2; // Ölçeklendirme
                    int screenY = waypoint.Y * 2;

                    // İnsan gibi tıkla
                    mouse.HumanLikeClick(screenX, screenY);

                    // Karakterin hareket etmesini bekle (1-2 saniye)
                    Thread.Sleep(1500);

                    // Pozisyonu güncelle (gerçek uygulamada oyundan oku)
                    playerPosition = waypoint;

                    Console.WriteLine($"Waypoint'e ulaşıldı: ({waypoint.X}, {waypoint.Y})");
                }
            }

            Console.WriteLine("Hedefe ulaşıldı!");
        }

        // Birden fazla kaynağı topla (farming route)
        public void FarmResources(List<Resource> resources)
        {
            Console.WriteLine($"Toplam {resources.Count} kaynak toplanacak");

            // En yakından başla (TSP benzeri)
            var sortedResources = resources
                .OrderBy(r => Distance(playerPosition, r.Position))
                .ToList();

            foreach (var resource in sortedResources)
            {
                Console.WriteLine($"Gidiliyor: {resource.Type} (Tier {resource.Tier})");

                // Kaynağa git
                GoToDestination(resource.Position);

                // Kaynağı topla (E tuşuna bas vb)
                HarvestResource(resource);

                // Bir sonraki kaynağa geçmeden önce bekle
                Thread.Sleep(2000);
            }

            Console.WriteLine("Tüm kaynaklar toplandı!");
        }

        // Mesafe hesapla
        private double Distance(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        // Kaynak toplama simülasyonu
        private void HarvestResource(Resource resource)
        {
            Console.WriteLine($"Toplama başladı: {resource.Type}");

            // Kaynağa tıkla
            mouse.ClickAt(resource.Position.X * 2, resource.Position.Y * 2);

            // Toplama animasyonunu bekle (3-5 saniye)
            Thread.Sleep(4000);

            Console.WriteLine("Toplama tamamlandı!");
        }

        // GİT-GEL ROTASI
        public void PatrolRoute(List<Point> waypoints, int loops)
        {
            Console.WriteLine($"順巡路 başladı: {waypoints.Count} nokta, {loops} tur");

            for (int i = 0; i < loops; i++)
            {
                Console.WriteLine($"\n--- TUR {i + 1}/{loops} ---");

                // İleri git
                foreach (var point in waypoints)
                {
                    GoToDestination(point);
                }

                // Geri dön (listeyi ters çevir)
                var reversed = new List<Point>(waypoints);
                reversed.Reverse();

                foreach (var point in reversed)
                {
                    GoToDestination(point);
                }
            }

            Console.WriteLine("\n順巡路 tamamlandı!");
        }
    }

    // ÖRNEK KULLANIM
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ALBION ONLINE OTO ROTA SİSTEMİ ===\n");

            // ⚠️ UYARI ⚠️
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("⚠️ UYARI: Bu sistem eğitim amaçlıdır!");
            Console.WriteLine("⚠️ Albion Online'da bot kullanmak BAN sebebidir!");
            Console.WriteLine("⚠️ Kendi sorumluluğunuzdadır!\n");
            Console.ResetColor();

            // Sistem oluştur (1000x1000 harita)
            AutoRouter router = new AutoRouter(1000, 1000);

            // Örnek engeller (tepe, duvar, su vb)
            List<Point> obstacles = new List<Point>
            {
                new Point(100, 100),
                new Point(101, 100),
                new Point(102, 100),
                // ... daha fazla engel
            };
            router.AddObstacles(obstacles);

            // Örnek 1: Tek noktaya git
            Console.WriteLine("\n--- ÖRNEK 1: Tek Hedefe Git ---");
            // router.GoToDestination(new Point(200, 150));

            // Örnek 2: Kaynak toplama rotası
            Console.WriteLine("\n--- ÖRNEK 2: Kaynak Toplama ---");
            List<Resource> resources = new List<Resource>
            {
                new Resource(150, 100, "Iron Ore", 3),
                new Resource(180, 120, "Iron Ore", 4),
                new Resource(200, 140, "Iron Ore", 3),
                new Resource(220, 160, "Silver Ore", 5),
            };
            // router.FarmResources(resources);

            // Örnek 3: Git-Gel devriyesi
            Console.WriteLine("\n--- ÖRNEK 3: Git-Gel Devriyesi ---");
            List<Point> patrolPoints = new List<Point>
            {
                new Point(100, 100),
                new Point(200, 150),
                new Point(300, 200),
                new Point(400, 150),
            };
            // router.PatrolRoute(patrolPoints, 3); // 3 tur

            Console.WriteLine("\n\nProgram bitti. Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}

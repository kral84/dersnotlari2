using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AlbionAutoRouter
{
    // GERÇEK OYUNCU POZİSYONU OKUMA
    public class MemoryReader
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        private IntPtr processHandle;
        private Process gameProcess;

        // Albion Online memory offsets (örnek - gerçek değerler değişebilir)
        private readonly IntPtr BASE_ADDRESS = (IntPtr)0x140000000; // Oyunun base adresi
        private readonly int PLAYER_X_OFFSET = 0x1234; // X koordinatı offset
        private readonly int PLAYER_Y_OFFSET = 0x1238; // Y koordinatı offset

        public bool AttachToGame()
        {
            try
            {
                // Albion Online process'ini bul
                Process[] processes = Process.GetProcessesByName("Albion-Online");

                if (processes.Length == 0)
                {
                    Console.WriteLine("❌ Albion Online bulunamadı!");
                    return false;
                }

                gameProcess = processes[0];
                processHandle = OpenProcess(0x0010, false, gameProcess.Id); // PROCESS_VM_READ

                if (processHandle == IntPtr.Zero)
                {
                    Console.WriteLine("❌ Process'e erişim başarısız!");
                    return false;
                }

                Console.WriteLine("✅ Albion Online'a bağlanıldı!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Hata: {ex.Message}");
                return false;
            }
        }

        // GERÇEK oyuncu pozisyonunu oku
        public (float x, float y) GetPlayerPosition()
        {
            try
            {
                // X koordinatını oku
                byte[] bufferX = new byte[4];
                int bytesRead = 0;
                IntPtr addressX = IntPtr.Add(BASE_ADDRESS, PLAYER_X_OFFSET);
                ReadProcessMemory(processHandle, addressX, bufferX, bufferX.Length, ref bytesRead);
                float x = BitConverter.ToSingle(bufferX, 0);

                // Y koordinatını oku
                byte[] bufferY = new byte[4];
                IntPtr addressY = IntPtr.Add(BASE_ADDRESS, PLAYER_Y_OFFSET);
                ReadProcessMemory(processHandle, addressY, bufferY, bufferY.Length, ref bytesRead);
                float y = BitConverter.ToSingle(bufferY, 0);

                return (x, y);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Pozisyon okuma hatası: {ex.Message}");
                return (0, 0);
            }
        }

        // Karakterin takılıp takılmadığını kontrol et
        public bool IsPlayerStuck(float lastX, float lastY, int timeoutMs = 5000)
        {
            var (currentX, currentY) = GetPlayerPosition();

            // 5 saniyede 1 birimden az hareket ettiyse takılmış
            double distance = Math.Sqrt(Math.Pow(currentX - lastX, 2) + Math.Pow(currentY - lastY, 2));

            return distance < 1.0;
        }

        // Hedefe ulaştı mı kontrol et
        public bool HasReachedDestination(float targetX, float targetY, float threshold = 2.0f)
        {
            var (currentX, currentY) = GetPlayerPosition();
            double distance = Math.Sqrt(Math.Pow(currentX - targetX, 2) + Math.Pow(currentY - targetY, 2));

            return distance <= threshold;
        }
    }

    // GÜNCELLENMİŞ AutoRouter
    public class ImprovedAutoRouter
    {
        private MouseController mouse;
        private MemoryReader memoryReader;
        private PathFinder pathfinder;

        public ImprovedAutoRouter()
        {
            mouse = new MouseController();
            memoryReader = new MemoryReader();
            pathfinder = new PathFinder(1000, 1000);

            // Oyuna bağlan
            if (!memoryReader.AttachToGame())
            {
                throw new Exception("Oyuna bağlanılamadı!");
            }
        }

        // ✅ DOĞRU versiyon: Gerçek pozisyon kontrolü ile
        public void GoToDestinationSafe(float targetX, float targetY)
        {
            Console.WriteLine($"Hedefe gidiliyor: ({targetX}, {targetY})");

            int maxAttempts = 10;
            int attempt = 0;

            while (!memoryReader.HasReachedDestination(targetX, targetY) && attempt < maxAttempts)
            {
                var (currentX, currentY) = memoryReader.GetPlayerPosition();
                Console.WriteLine($"Mevcut pozisyon: ({currentX}, {currentY})");

                // Ekran koordinatına çevir (doğru yöntemle - aşağıda)
                var (screenX, screenY) = WorldToScreen(targetX, targetY);

                // Tıkla
                mouse.HumanLikeClick(screenX, screenY);

                // Hareket etmesini bekle
                System.Threading.Thread.Sleep(2000);

                // Takıldı mı kontrol et
                var (newX, newY) = memoryReader.GetPlayerPosition();
                if (memoryReader.IsPlayerStuck(currentX, currentY))
                {
                    Console.WriteLine("⚠️ Karakter takıldı! Alternatif rota aranıyor...");

                    // Biraz sağa/sola kaydır
                    mouse.ClickAt(screenX + 50, screenY);
                    System.Threading.Thread.Sleep(1000);
                }

                attempt++;
            }

            if (memoryReader.HasReachedDestination(targetX, targetY))
            {
                Console.WriteLine("✅ Hedefe ulaşıldı!");
            }
            else
            {
                Console.WriteLine("❌ Hedefe ulaşılamadı!");
            }
        }

        // Placeholder - aşağıda düzelteceğiz
        private (int, int) WorldToScreen(float worldX, float worldY)
        {
            return ((int)worldX * 2, (int)worldY * 2); // Geçici
        }
    }
}

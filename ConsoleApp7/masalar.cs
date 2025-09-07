using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class masalar
    {
        public int masaNo;
        public int kisiSayisi;
        public bool masaDolumu = false;

        public static List<masalar> masa = new List<masalar>()
        {
            new masalar {masaNo = 1, kisiSayisi = 1, masaDolumu = false},
            new masalar {masaNo = 2 , kisiSayisi = 2, masaDolumu = false},
            new masalar {masaNo = 3 , kisiSayisi = 3, masaDolumu = false},
            new masalar {masaNo = 4 , kisiSayisi = 4, masaDolumu = false},
            new masalar {masaNo = 5 , kisiSayisi = 5, masaDolumu = false},
        };
        public static bool masagöster() // bool yap diger tarafta 0 ise alttaki kodlar calışmaz....
        {

            if (masa.Count == 0)
            {
                Console.WriteLine("Gösterilecek masa yok.");
                return false;
            }
            int sayac = 1;
            foreach (masalar masalar in masa)
            {

                Console.WriteLine($"{sayac} -Masa Numarası: {masalar.masaNo}- Kişi sayısı: {masalar.kisiSayisi}-Masa dolumu ? {masalar.masaDolumu}");
                sayac++;
            }
            return true;
        }
        public static void masaekle()
        {
            while (true)
            {
                masalar yenimasa = new masalar();
                Console.WriteLine("kişi sayısı kaç olsun");
                string input = (Console.ReadLine());
                if (input == "9")
                {
                    return;
                }
                if (!int.TryParse(input, out int kisisayısı))
                {
                    Console.WriteLine("Geçersiz giriş. Lütfen bir sayı girin.");
                }
                else
                {
                    yenimasa.masaNo = masa.Count + 1;
                    yenimasa.kisiSayisi = kisisayısı;
                    yenimasa.masaDolumu = false;
                    masa.Add(yenimasa);
                    Console.WriteLine("Masa eklendi.");
                }
            }
        }
        public static void masasil()
        {
            while (true)
            {
                if (!masagöster()) return; // alttaki kodlar calısmaz
                Console.WriteLine("silmek istediğiniz masa numarasını girin. 9 ile çıkış yapabilirsin.");
                string input = (Console.ReadLine());
                if (input == "9")
                {
                    break;
                }
                if (!int.TryParse(input, out int masano))
                {
                    Console.WriteLine("Geçersiz giriş. Lütfen bir sayı girin.");
                    continue;
                }
                if (masano < 1 || masano > masa.Count)
                {
                    Console.WriteLine("Geçersiz masa numarası.");
                    continue;
                }
                else
                {
                    masa.RemoveAt(masano - 1);
                    Console.WriteLine($"Masa silindi.{masano}");
                }
            }
        }
        public static void toplumasasil()
        {
            if (!masagöster()) return; // alttaki kodlar calısmaz
            Console.WriteLine("Tüm masalar silinecek. 1 tuşu ile sil 9 ile çıkış yap.");
            string input = (Console.ReadLine());
            if (input == "9")
            {
                return;
            }
            if (input == "1")
            {
                masa.Clear();
                Console.WriteLine("Tüm masalar silindi.");
            }
            else
            {
                Console.WriteLine("Geçersiz giriş. Lütfen 1 veya 9 girin.");
            }
        }
        public static void masagüncelle()
        {
            while (true)
            {
                masagöster();
                Console.WriteLine("Güncellenecek masayı seçiniz seciniz. çıkış yapmak için 9 tuşuna basınız.");
                string input = Console.ReadLine();
                if (input == "9")
                {
                    break;
                }

                if (!int.TryParse(input, out int güncellenecekmasano))
                {
                    Console.WriteLine("hatalı girdiniz.");
                    continue;
                }
                if (güncellenecekmasano < 1 || güncellenecekmasano > masa.Count)
                {
                    Console.WriteLine("Geçersiz masa numarası.");
                    continue;
                }
                int index = güncellenecekmasano - 1;
                Console.WriteLine($"Masa Numarasını değiştir. Güncel Numara {masa[index].masaNo}");
                string yeniStr = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(yeniStr))
                    continue;
                if (!int.TryParse(yeniStr, out int yeniNo) || yeniNo <= 0)
                {
                    Console.WriteLine("Geçersiz numara.");
                    continue;
                }
                if (yeniNo == masa[index].masaNo)
                {
                    Console.WriteLine("Aynı numara girildi. Değişiklik yapılmadı.");
                    continue;
                }
                bool var = false;
                for (int i = 0; i < masa.Count; i++)
                {
                    if (masa[i].masaNo == yeniNo)
                    {
                        var = true;
                        break;
                    }
                }
                if (var)
                {
                    Console.WriteLine("Bu numara zaten kullanılıyor. Farklı bir numara girin.");
                    continue;
                }

                masa[index].masaNo = yeniNo;
                Console.WriteLine($"Güncellendi. Yeni numara: {yeniNo}");
                do
                {
                    Console.WriteLine($"Kişi sayısını değiştir. Güncel Kişi sayısı {masa[index].kisiSayisi}");
                    string yeniStr2 = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(yeniStr2))
                        break;
                    if (!int.TryParse(yeniStr2, out int yenikisisayisi) || yenikisisayisi <= 0)
                    {
                        Console.WriteLine("Geçersiz kişi sayısı.");
                        continue;
                    }
                    masa[index].kisiSayisi = yenikisisayisi;
                    Console.WriteLine($"Güncellendi. Yeni kişi sayısı: {yenikisisayisi}");
                    break;
                } while (true);

            }
        }
        public static void gelenmüsteriler()
        {
            while (true)
            {
                Console.WriteLine("kaç kişisiniz ???? cıkış için 9 basın");
                int kisisayısı = Convert.ToInt32(Console.ReadLine());
                if (kisisayısı == 9)
                {
                    break;
                }
                masalar enuygunmasa = null;
                for (int i = 0; i < masa.Count; i++)
                {
                    if (!masa[i].masaDolumu && masa[i].kisiSayisi >= kisisayısı)
                    {
                        if (enuygunmasa == null || masa[i].kisiSayisi < enuygunmasa.kisiSayisi)
                        {
                            enuygunmasa = masa[i];
                        }
                    }
                }
                if (enuygunmasa != null)
                {
                    Console.WriteLine($"masa {enuygunmasa.masaNo} size verildi. Kapasiste {enuygunmasa.kisiSayisi}");
                    enuygunmasa.masaDolumu = true;
                    break;
                }
                else
                {
                    Console.WriteLine($"uygun masa bulunamadı. {kisisayısı}");
                }
            }
        }
        public static void masabosalt()
        {
            while (true)
            {
                Console.WriteLine("Boşaltmak istediğiniz masa numarasını girin. 9 ile çıkış yapabilirsin.");
                string input = (Console.ReadLine());
                if (input == "9")
                {
                    return;
                }
                if (!int.TryParse(input, out int masano))
                {
                    Console.WriteLine("Geçersiz giriş. Lütfen bir sayı girin.");
                    continue;
                }
                if (masano < 1 || masano > masa.Count)
                {
                    Console.WriteLine("Geçersiz masa numarası.");
                    continue;
                }
                else
                {
                    int index = masano - 1;
                    if (!masa[index].masaDolumu)
                    {
                        Console.WriteLine($"Masa zaten boş. {masano}");
                        continue;
                    }
                    masa[index].masaDolumu = false;
                    Console.WriteLine($"Masa boşaltıldı.{masano}");
                }
            }
        }
        public static void toplumasabosalt()
        {
            if (!masagöster()) return; // alttaki kodlar calısmaz
            Console.WriteLine("Tüm masalar boşaltılacak. 1 tuşu ile boşalt 9 ile çıkış yap.");
            string input = (Console.ReadLine());
            if (input == "9")
            {
                return;
            }
            if (input == "1")
            {
                foreach (var m in masa)
                {
                    m.masaDolumu = false;
                }
                Console.WriteLine("Tüm masalar boşaltıldı.");
            }
            else
            {
                Console.WriteLine("Geçersiz giriş. Lütfen 1 veya 9 girin.");
            }
        }
    }
}





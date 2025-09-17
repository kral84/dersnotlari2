using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class menü
    {
        static string input = "";
        static string kategorisecim = "";
        static int secim;
        public string icecekadi = "";
        public string yemekadi = "";
        public int No;
        public int fiyat;
        public int stokmiktari;
        public string kategori = "";

        public static List<menü> menüler = new List<menü>()
        {
        new menü { yemekadi = "pilav", No = 1, fiyat = 200, stokmiktari = 300, kategori = "yemek"},
        new menü { yemekadi = "köfte", No = 2,fiyat = 100, stokmiktari = 100,kategori = "yemek"},
        new menü { yemekadi = "et", No = 3,fiyat = 300, stokmiktari = 200,kategori = "yemek"},
         new menü { icecekadi = "su", No = 4,fiyat = 300, stokmiktari = 200,kategori = "icecek"}
        };
        public static bool menügöster()  // 1 numara menüleri gösteriyor
        {

            if (0 == menüler.Count)
            {
                Console.WriteLine("Silincek birşey kalmadı");
                return false;
            }
            int sayac = 1;
            Console.WriteLine("-----Yemek Menüsü-----");
            foreach (menü i in menüler)
            {
                if ("yemek" == i.kategori)
                {
                    Console.WriteLine($"{sayac}-{i.yemekadi}||Fiyat:{i.fiyat}||Stokmiktarı:{i.stokmiktari}");
                    sayac++;
                }

            }
            Console.WriteLine("-----İçecek Menüsü-----");
            foreach (menü i in menüler)
            {
                if ("icecek" == i.kategori)
                {
                    Console.WriteLine($"{sayac}-{i.icecekadi}||Fiyat:{i.fiyat}||Stokmiktarı:{i.stokmiktari}");
                    sayac++;
                }

            }
            return true;
        }
        public static void yemeksilindex()  // 2 numara indexe göre siliyor.
        {
            while (true)
            {
                if (menügöster() == false)
                {
                    return;
                }
                Console.WriteLine("Hangi yemeği silmek istiyorsunz? 9 ile çıkabilirsiniz.");
                input = Console.ReadLine();
                if (input == "9")
                {
                    break;
                }
                if (int.TryParse(input, out secim) && 0 < secim && secim <= menüler.Count)
                {
                    int yenisecim = secim - 1;
                    Console.WriteLine($"{menüler[yenisecim].yemekadi} silindi");
                    menüler.RemoveAt(yenisecim);
                }
            }
        }
        public static void yemeksilid()   // 3 No  göre silme işlemi yapıyor. 
        {
            while (true)
            {
                foreach (menü i in menüler)
                {
                    Console.WriteLine($"{i.No}-{i.yemekadi}{i.icecekadi}||Fiyat:{i.fiyat}||Stokmiktarı:{i.stokmiktari}");
                }
                if (menüler.Count == 0)
                {
                    Console.WriteLine("gösterilcek bisi kalmadı");
                    break;
                }
                Console.WriteLine("yemek numarasına göre silinir. 9 ile çıkılır.");
                input = Console.ReadLine();
                if (input == "9")
                {
                    break;
                }
                if (int.TryParse(input, out secim) && 0 < secim)
                {
                    int Index = -1;
                    for (int i = 0; i < menüler.Count; i++)
                    {
                        if (menüler[i].No == secim)
                        {
                            Index = i; break;
                        }
                    }
                    if (Index != -1)
                    {
                        Console.WriteLine($"{menüler[Index].yemekadi} silindi");
                        menüler.RemoveAt(Index);
                    }
                    else
                    {
                        Console.WriteLine($"{secim} Bulunamadı");
                    }
                }
                else
                {
                    Console.WriteLine("gecersiz secim");
                }
            }
        }
        public static void yemeksilismegöre()  // yemek ismine göre silme işlemi yapıyor.
        {
            while (true)
            {
                if (menügöster() == false)
                {
                    return;
                }
                Console.WriteLine("yemek ismini girin. 9 ile çıkılır.");
                input = Console.ReadLine().ToLower();
                if (input == "9")
                {
                    break;
                }
                int Index = -1;
                for (int i = 0; i < menüler.Count; i++)
                {
                    if (menüler[i].yemekadi.ToLower() == input)
                    {
                        Index = i;
                        break;
                    }
                }
                if (Index != -1)
                {
                    Console.WriteLine($"{menüler[Index].yemekadi} silindi");
                    menüler.RemoveAt(Index);
                }
                else
                {
                    Console.WriteLine("hatalı secimmi acaba");
                }
            }
        }
        public static void yemeksilhepsi() // hepsini siliyor.
        {
            while (true)
            {
                if (menügöster() == false)
                {
                    return;
                }
                Console.WriteLine("1 tuşuna bas hepsi silinsin 9 tuşu çıkış");
                input = Console.ReadLine();
                if (input == "9")
                {
                    break;
                }
                if (input == "1")
                {
                    Console.WriteLine($"hepsi silindi");
                    menüler.Clear();
                }
            }
        }
        public static void yemekekle() //indexe göre ekliyor
        {
            while (true)
            {
                menü yeniyemek = new menü();
                menügöster();
                Console.WriteLine("Önce kategoriyi seç hangi kategoriye yemek veya içecek eklemek istiyorsun. 9 ile çıkış yapabilirsin");
                kategorisecim = Console.ReadLine();
                if (kategorisecim == "9")
                {
                    break;
                }
                if (kategorisecim == "1")
                {
                    Console.WriteLine("yemek ismini giriniz.");
                    input = Console.ReadLine();
                    bool ok = false;
                    foreach (menü i in menüler)
                    {
                        if (i.yemekadi == input)
                        {
                            Console.WriteLine("zaten aynı isimde var");
                            ok = true;
                            break;
                        }
                    }
                    foreach (var c in input)
                    {
                        if (!char.IsLetter(c))
                        {
                            Console.WriteLine("sadece isim girebilirsin");
                            ok = true;
                            break;
                        }
                    }
                    if (!ok)
                    {
                        yeniyemek.yemekadi = input;
                        yeniyemek.kategori = "yemek";
                        Console.WriteLine($"✓ '{input}' eklendi.");
                        
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (kategorisecim == "2")
                {
                    Console.WriteLine("icecek ismini giriniz.");
                    input = Console.ReadLine();
                    bool ok = false;
                    foreach (menü i in menüler)
                    {
                        if (i.yemekadi == input)
                        {
                            Console.WriteLine("zaten aynı isimde var");
                            ok = true;
                            break;
                        }
                    }
                    foreach (var c in input)
                    {
                        if (!char.IsLetter(c))
                        {
                            Console.WriteLine("sadece isim girebilirsin");
                            ok = true;
                            break;
                        }
                    }
                    if (!ok)
                    {
                        yeniyemek.icecekadi = input;
                        yeniyemek.kategori = "icecek";
                        Console.WriteLine($"✓ '{input}' eklendi.");
                      
                    }
                    else
                    {
                        continue; 
                    }
                }
                do
                {
                    Console.WriteLine("fiyatı giriniz.");
                    input = Console.ReadLine();
                    if (!int.TryParse(input, out secim))
                    {
                        Console.WriteLine("sayı gir.");
                        continue;
                    }
                    yeniyemek.fiyat = secim;
                    break;

                } while (true);
                do
                {
                    Console.WriteLine("stok miktarını giriniz.");
                    input = Console.ReadLine();
                    if (!int.TryParse(input, out secim))
                    {
                        Console.WriteLine("sayı gir.");
                        continue;
                    }
                    yeniyemek.stokmiktari = secim;
                    break;
                } while (true);

                menüler.Add(yeniyemek);
            }
        }
        //public static void menüekleme2()
        //{
        //    menü yenimenücük = new menü();
        //    Console.WriteLine("no sec");
        //    yenimenücük.No = Convert.ToInt32(Console.ReadLine());
        //    menüler.Insert(yenimenücük.No - 1, yenimenücük);

        //    Console.WriteLine("isim gir");
        //    input = Console.ReadLine();
        //    yenimenücük.yemekadi = input;
        //    yenimenücük.kategori = "yemek";


    }
}

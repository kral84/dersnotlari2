using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class menü
    {
        public string yemekadı;
        public string fiyat;
        public string kategori;

        public static List<menü> yemekler = new List<menü>
        {
             new menü {yemekadı = "pilav", fiyat = "50", kategori = "yemek"},
             new menü {yemekadı = "su", fiyat = "20", kategori = "icecek"},
             new menü {yemekadı = "fasülye", fiyat = "55", kategori = "yemek"},
             new menü {yemekadı = "kola", fiyat = "25", kategori = "icecek"},
             new menü {yemekadı = "köfte", fiyat = "60", kategori = "yemek"},
             new menü {yemekadı = "fanta", fiyat = "30", kategori = "icecek"},
             new menü {yemekadı = "et", fiyat = "65", kategori = "yemek"},
             new menü {yemekadı = "meyvesuyu", fiyat = "35", kategori = "icecek"},

        };
        public static void menügöster()
        {
            Console.WriteLine("----Yemek Listesi----");
            int sayac = 1;
            foreach (var item in yemekler)
            {
                if (item.kategori == "yemek")
                {
                    Console.WriteLine($"{sayac}-{item.yemekadı}-{item.fiyat}");
                    sayac++;
                }
            }
            Console.WriteLine("-----İcecek Listesi-----");
            sayac = 1;
            foreach (var item in yemekler)
            {
                if (item.kategori == "icecek")
                {
                    Console.WriteLine($"{sayac}-{item.yemekadı}-{item.fiyat}");
                    sayac++;
                }
            }
        }
        public static void yemekekle()
        {
            
            while (true)
            {
                menü.menügöster();
                Console.WriteLine("Yemek eklemek için 1, çıkış için 0 tuşuna basın:");
                int secim = Convert.ToInt32(Console.ReadLine()); 

                if (secim == 0)
                {
                    Console.WriteLine("Ana menüye dönülüyor...");
                    break;
                }

                if (secim != 1)
                {
                    Console.WriteLine("Geçersiz seçim! 0 veya 1 girin.");
                    continue; 
                }
            menü yeni = new menü();
            Console.WriteLine("Yemek İsmini Giriniz.");
            yeni.yemekadı = Console.ReadLine();
            Console.WriteLine("Fiyatını giriniz.");
            yeni.fiyat = Console.ReadLine();
                do
                {
                    Console.WriteLine("Kategorisini Giriniz (yemek veya icecek):");
                    yeni.kategori = Console.ReadLine().ToLower();

                    if (yeni.kategori != "yemek" && yeni.kategori != "icecek")
                    {
                        Console.WriteLine("Hatalı! Sadece 'yemek' veya 'icecek' yazın.");
                    }

                } while (yeni.kategori != "yemek" && yeni.kategori != "icecek");

                yemekler.Add(yeni);
            Console.Clear();
            Console.WriteLine("Menüye Eklendi.");
            }
        }
        public static void yemeksil()
        {
           
            while (true)
            {
                menü.menügöster();
                Console.WriteLine("Yemek Numarasını Gir Silinsin. \ntuşu ile çıkış 0");
                int sil = Convert.ToInt32(Console.ReadLine());
                if (sil == 0)
                {
                    Console.WriteLine("Ana menüye dönülüyor...");
                    break;
                }
                int sayac = 0;
                for (int i = 0; i < yemekler.Count; i++)
                {
                    if (yemekler[i].kategori == "yemek")
                        sayac++;
                    if (sayac == sil)
                    {
                        Console.WriteLine($"Silindi {yemekler[i].yemekadı}");
                        yemekler.RemoveAt(i);
                        
                        break;
                    }
                }
            }
            
        }
    }


}

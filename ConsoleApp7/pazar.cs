using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class pazar
    {
        public string icecek;
        public string yemek;
        public double fiyat;
        public int stok;
        public string kategori;

        public static List<pazar> pazaragidelimYiyecek = new List<pazar>()
        {
            new pazar { yemek = "mercimek çorbası", fiyat = 50, stok = 10, kategori = "yemek" },
            new pazar { yemek = "ezogelin çorbası", fiyat = 55, stok = 8, kategori = "yemek" },
            new pazar { yemek = "tavuk döner", fiyat = 80, stok = 15, kategori = "yemek" },
            new pazar { yemek = "et döner", fiyat = 120, stok = 12, kategori = "yemek" },
            new pazar { yemek = "lahmacun", fiyat = 60, stok = 20, kategori = "yemek" },
            new pazar { yemek = "pide kıymalı", fiyat = 90, stok = 10, kategori = "yemek" },
            new pazar { yemek = "pizza", fiyat = 130, stok = 7, kategori = "yemek" },
            new pazar { yemek = "hamburger", fiyat = 100, stok = 14, kategori = "yemek" },
            new pazar { yemek = "ızgara köfte", fiyat = 110, stok = 9, kategori = "yemek" },
            new pazar { yemek = "makarna", fiyat = 70, stok = 18, kategori = "yemek" },
        };
        public static void pazaryiyeceklistele()
        {
            int sayac = 1;
            foreach (var item in pazaragidelimYiyecek)
            {

                Console.WriteLine($"{sayac}- {item.yemek}, Fiyat: {item.fiyat} TL, Stok: {item.stok}, Kategori: {item.kategori}");
                sayac++;
            }
        }
        public static void pazaryiyecekal()
        {
            while (true)
            {
                pazaryiyeceklistele();
                Console.WriteLine("almak istediğiniz ürünü seçiniz. 9 tuşu ile çıkış yapabilirsiniz.");
                string input = Console.ReadLine();
                if (input == "9")
                    return;
                if (!int.TryParse(input, out int secim))
                {
                    Console.WriteLine("Geçersiz giriş. Lütfen bir sayı girin.");
                }
                if (secim < 1 || secim > pazaragidelimYiyecek.Count)
                {
                    Console.WriteLine("Geçersiz seçim aralığı.");
                    return;
                }
                pazar secilen = pazaragidelimYiyecek[secim - 1];
                Console.Write($"{secilen.yemek} kaç adet almak istiyorsunuz?: ");
                string adet1 = Console.ReadLine();
                if (!int.TryParse(adet1, out int adet) || adet <= 0)
                {
                    Console.WriteLine("Geçersiz adet!");
                    return;
                }
                if (secilen.stok <= adet)
                {
                    Console.WriteLine($"{secilen.yemek} okadar  stokta yok");
                    return;
                }
                double tutar = secilen.fiyat * adet;
                if (kasa.kasamız < tutar)
                {
                    Console.WriteLine($"Kasada yeterli para yok Gerekli: {tutar} TL, Kasa: {kasa.kasamız} TL");
                    return;
                }
                menüler listedevarmı = null;
                foreach (var item in menüler.YemekMenü)
                {
                    if (item.yemekadı == secilen.yemek)
                    {
                        listedevarmı = item;
                        break;
                    }
                }
                if (listedevarmı != null)
                {
                    listedevarmı.stok += adet;
                    Console.WriteLine($"{listedevarmı.yemekadı} menüde vardı, stok +{adet} => {listedevarmı.stok}");
                }
                else
                {
                    menüler yemek = new menüler
                    {
                        yemekadı = secilen.yemek,
                        fiyat = secilen.fiyat,
                        stok = adet,
                        kategori = secilen.kategori,
                    };
                    menüler.YemekMenü.Add(yemek);
                    Console.WriteLine($"{yemek.yemekadı} menüye eklendi (stok: {adet}).");
                }
                secilen.stok -= adet;
                kasa.paracıkıyor(tutar);
                kasa.kasagöster();
            }
        }
        public static List<pazar> pazaragidelimicecek = new List<pazar>()
        {
            new pazar { icecek = "su",        fiyat = 50, stok = 10, kategori = "içecek" },
            new pazar { icecek = "kola",      fiyat = 5, stok = 20, kategori = "içecek" },
            new pazar { icecek = "fanta",     fiyat = 10, stok = 40, kategori = "içecek" },
            new pazar { icecek = "ayran",     fiyat = 20, stok = 50, kategori = "içecek" },
            new pazar { icecek = "soda",      fiyat = 40, stok = 60, kategori = "içecek" },
            new pazar { icecek = "gazoz",     fiyat = 20, stok = 170, kategori = "içecek"},
            new pazar { icecek = "şalgam",    fiyat = 30, stok = 80, kategori = "içecek" },
            new pazar { icecek = "limonata",  fiyat = 40, stok = 90, kategori = "içecek" },
            new pazar { icecek = "çay",       fiyat = 20, stok = 100, kategori = "içecek"},
            new pazar { icecek = "kahve",     fiyat = 10, stok = 21, kategori = "içecek" },
        };
        public static void pazaricecekgöster()
        {
            int sayac = 1;
            foreach (var item in pazaragidelimicecek)
            {
                Console.WriteLine($"{item.icecek}, Fiyat: {item.fiyat} TL, Stok: {item.stok}, Kategori: {item.kategori}");
                sayac++;
            }
        }
        public static void pazaricecekal()
        {
            while (true)
            {
             pazaricecekgöster();
                Console.WriteLine("almak istediğiniz ürünü giriniz. çıkış için 9 tuşuna basınız.");
            string input = Console.ReadLine();
            if (input == "9")
                return;
            if (!int.TryParse(input, out int secim))
            {
                Console.WriteLine("Geçersiz giriş. Lütfen bir sayı girin.");
            }
            if (secim < 1 || secim > pazaragidelimicecek.Count)
            {
                Console.WriteLine("Geçersiz seçim aralığı.");
                    break;
            }
            pazar secilen = pazaragidelimicecek[secim - 1];
            Console.Write($"{secilen.icecek} kaç adet almak istiyorsunuz?: ");
            string adet1 = Console.ReadLine();
            if (!int.TryParse(adet1, out int adet) || adet <= 0)
            {
                Console.WriteLine("Geçersiz adet!");
                    break;
            }
            if (secilen.stok <= adet)
            {
                Console.WriteLine($"{secilen.icecek} okadar  stokta yok");
                    break;
            }
            double tutar = secilen.fiyat * adet;
            if (kasa.kasamız < tutar)
            {
                Console.WriteLine($"Kasada yeterli para yok Gerekli: {tutar} TL, Kasa: {kasa.kasamız} TL");
                    break;
            }
            menüler listedevarmı = null;
            foreach (var item in menüler.icecekler)
            {
                if (item.yemekadı == secilen.icecek)
                {
                    listedevarmı = item;
                    break;
                }
            }
            if (listedevarmı != null)
            {
                listedevarmı.stok += adet;
                Console.WriteLine($"{listedevarmı.yemekadı} menüde vardı, stok +{adet} = {listedevarmı.stok}");
            }
            else
            {
                menüler icecek = new menüler
                {
                    icecekadı = secilen.icecek,
                    fiyat = secilen.fiyat,
                    stok = adet,
                    kategori = secilen.kategori,
                };
                    menüler.icecekler.Add(icecek);
                    Console.WriteLine($"{icecek.icecekadı} menüye eklendi (stok: {adet}).");
            }
            secilen.stok -= adet;
            kasa.paracıkıyor(tutar);
            kasa.kasagöster();
            }
        }

    }
}



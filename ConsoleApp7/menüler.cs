using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class menüler
    {
        public string yemekadı;
        public double fiyat;
        public int stok;
        public string kategori;

        public static List<menüler> YemekMenü = new List<menüler>()
        {
        new menüler {yemekadı = "pilav", fiyat =100, stok = 200, kategori = "yemek"},
        new menüler {yemekadı = "su", fiyat =50, stok = 300, kategori = "yemek"},
        new menüler {yemekadı = "köfte", fiyat = 150, stok =100, kategori = "yemek"},
};

        public static void yemekmenügöster()
        {

            if (YemekMenü.Count == 0)
            {
                Console.WriteLine("Yemek Menüsü Boş...");
            }
            int sayac = 1;
            foreach (var item in YemekMenü)
            {
                Console.WriteLine($"{sayac}-{item.yemekadı} Adı - {item.fiyat} TL - {item.stok} Kalan Miktar - {item.kategori}");
                sayac++;
            }
        }
        public static void yemekekle()
        {
            menüler yeniYemek = new menüler();
            Console.WriteLine("Eklemek istediğiniz yemeğin adını girin:");
            yeniYemek.yemekadı = Console.ReadLine();
            Console.WriteLine("Eklemek istediğiniz yemeğin fiyatını girin:");
            yeniYemek.fiyat = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Eklemek istediğiniz yemeğin stok miktarını girin:");
            yeniYemek.stok = Convert.ToInt32(Console.ReadLine());
            yeniYemek.kategori = "yemek";
            YemekMenü.Add(yeniYemek);
            Console.WriteLine($"Yemek başarılı bir şekilde {yeniYemek.kategori} Eklendi.");
        }
        public static void yemeksil()
        {
            while (true)
            {
                yemekmenügöster();
                Console.WriteLine("silmek istediğiniz yemeğin numarasını girin: \nçıkış için 9'a basın.");
                string input = Console.ReadLine();
                if (input == "9")
                    break;
                if (int.TryParse(input, out int silinecekNumara)) ;
                else
                {
                    Console.WriteLine("Geçersiz giriş. Lütfen bir sayı girin.");
                }
                if (silinecekNumara > 0 && silinecekNumara < YemekMenü.Count)
                {
                    Console.WriteLine($"{YemekMenü[silinecekNumara - 1].yemekadı} silindi.");
                    YemekMenü.RemoveAt(silinecekNumara - 1);
                }
                else
                {
                    Console.WriteLine("Geçersiz numara.");
                }
            }
        }
        public static void topluyemeksil()
        {
            yemekmenügöster();
            Console.WriteLine("Yemeklerin hepsi  1 tuşu ile silinecektir. 9 tuşu ile çıkabilirsiniz.");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int secim))
                if (YemekMenü.Count == 0)
                {
                    Console.WriteLine("Yemek Menüsü Boş...");
                    return;
                }
            if (secim == 9)
            {
                Console.WriteLine("Ana menüye dönülüyor...");
            }
            else if (secim == 1)
            {
                Console.WriteLine("Tüm yemekler silindi.");
                YemekMenü.Clear();
            }
            else
            {
                Console.WriteLine("Geçersiz seçim. Lütfen 1 veya 9 girin.");
            }
        }
        public static void yemekgüncelle()
        {
            while (true)
            {
                yemekmenügöster();
                Console.WriteLine("Güncellemek istediğiniz yemeğin numarasını girin: // Çıkış için 9'a basın.");
                string input = Console.ReadLine();
                if (input == "9")
                    return;
                if (!int.TryParse(input, out int guncellenecekNumara))
                {
                    Console.WriteLine("Geçersiz giriş. Lütfen bir sayı girin.");
                    continue;
                }
                ;
                if (guncellenecekNumara > 0 && guncellenecekNumara <= YemekMenü.Count)
                {
                    menüler guncellenecekYemek = YemekMenü[guncellenecekNumara - 1];
                    Console.WriteLine($"Güncellemek istediğiniz yemek: {guncellenecekYemek.yemekadı}");
                    Console.WriteLine("Yeni yemek adını girin (değiştirmek istemiyorsanız Enter'a basın):");
                    string yeniAd = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(yeniAd))
                    {
                        bool harf = true;
                        foreach (var c in yeniAd)
                        {
                            if (!char.IsLetter(c) && !char.IsWhiteSpace(c)) //IsLetter har harf mi kontrol eder. iswhitespace boşluk mu kontrol eder.
                            {
                                Console.WriteLine("Yemek adı sadece harf ve boşluk içerebilir.");
                                harf = false;
                                break;
                            }
                        }
                        if (harf)
                        {
                            guncellenecekYemek.yemekadı = yeniAd;
                        }
                    }
                    do // fiyat güncelleme burda
                    {
                        string fiyatInput;
                        double yeniFiyat;
                        Console.WriteLine($"Yeni fiyatı girin. Güncel {guncellenecekYemek.fiyat} (değiştirmek istemiyorsanız Enter'a basın):");
                        fiyatInput = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(fiyatInput))
                            break;
                        if (double.TryParse(fiyatInput, out yeniFiyat))
                        {
                            guncellenecekYemek.fiyat = yeniFiyat;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz fiyat. Fiyat bir sayı olmalıdır, tekrar deneyin.");
                        }
                    } while (true);
                    do
                    {
                        string yeniStok;
                        int stokMiktar;
                        Console.WriteLine($"Yeni stok miktarını girin. Güncel: {guncellenecekYemek.stok} (değiştirmek istemiyorsanız Enter'a basın):"); // stok güncelleme burda
                        yeniStok = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(yeniStok))
                            break;
                        {
                            if (int.TryParse(yeniStok, out stokMiktar) && stokMiktar >= 0)
                            {
                                guncellenecekYemek.stok = stokMiktar;
                                Console.WriteLine($"Stok güncellendi. Yeni stok: {guncellenecekYemek.stok}");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Geçersiz stok miktarı. Stok bir sayı olmalıdır, tekrar deneyin.");
                            }
                        }
                    } while (true);
                    Console.WriteLine($"Kategori ??? güncel: {guncellenecekYemek.kategori}");
                    string kategori = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(kategori))
                    {
                        foreach (var c in kategori)
                        {
                            if (!char.IsLetter(c) && !char.IsWhiteSpace(c)) //IsLetter har harf mi kontrol eder. iswhitespace boşluk mu kontrol eder.
                            {
                                Console.WriteLine("Kategori sadece harf ve boşluk içerebilir.");
                                harf = false;
                                break;
                            }
                        }
                        if (harf)
                        {
                            guncellenecekYemek.kategori = kategori;
                            Console.WriteLine("Kategori güncellendi.");
                            Console.WriteLine("Yemek başarıyla güncellendi.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz numara.");
                }
            }
        }
    }
}

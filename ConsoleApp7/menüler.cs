using ConsoleApp7;
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
        public static double gunlukCiro = 0;

        public class SatilanUrun
        {
            public string Ad = "";
            public int Adet;
            public double Tutar;
            public int KalanStok;
        }
        public static List<SatilanUrun> Satilanlar = new List<SatilanUrun>(); // Satılan ürünleri tutmak için liste


        public string icecekadı;
        public string yemekadı;
        public double fiyat;
        public int stok;
        public string kategori;

        public static List<menüler> YemekMenü = new List<menüler>()
        {
        new menüler {yemekadı = "pilav", fiyat =100, stok = 200, kategori = "yemek"},
        new menüler {yemekadı = "icliköfte", fiyat =50, stok = 300, kategori = "yemek"},
        new menüler {yemekadı = "köfte", fiyat = 150, stok =100, kategori = "yemek"},
        new menüler {yemekadı = "mercimek çorbası", fiyat = 50, stok = 10, kategori = "yemek" },
        new menüler {yemekadı = "ezogelin çorbası", fiyat = 55, stok = 8, kategori = "yemek" },
        new menüler {yemekadı = "tavuk döner", fiyat = 80, stok = 15, kategori = "yemek" },
        new menüler {yemekadı = "et döner", fiyat = 120, stok = 12, kategori = "yemek" },
        new menüler {yemekadı = "lahmacun", fiyat = 60, stok = 20, kategori = "yemek" },
};

        public static void yemekmenügöster()
        {
            Console.WriteLine("----Yemek Menüsü-----");

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
            yeniYemek.fiyat = Convert.ToDouble(Console.ReadLine());
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
                if (int.TryParse(input, out int silinecekNumara))
                {
                    if (silinecekNumara > 0 && silinecekNumara <= YemekMenü.Count)
                    {
                        Console.WriteLine($"{YemekMenü[silinecekNumara - 1].yemekadı} silindi.");
                        YemekMenü.RemoveAt(silinecekNumara - 1);
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz numara.");
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz giriş. Lütfen bir sayı girin.");
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
                        bool harf = true;
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
        // icecek göster
        // icecek ekle
        // icecek sil
        // icecek toplu sil
        // icecek güncelle
        public static List<menüler> icecekler = new List<menüler>()
        {
            new menüler {icecekadı = "kola", fiyat = 30, stok = 150, kategori = "içecek"},
            new menüler {icecekadı = "fanta", fiyat = 25, stok = 100, kategori = "içecek"},
            new menüler { icecekadı = "ayran", fiyat = 20, stok = 200, kategori = "içecek" },
        };
        public static void icecekmenügöster()
        {
            Console.WriteLine("------İçecek Menüsü-----");
            if (icecekler.Count == 0)
            {
                Console.WriteLine("icecek listesi zaten boş.");
                return;
            }
            int sayac = 1;
            foreach (menüler item in icecekler)
            {
                Console.WriteLine($"{sayac}-{item.icecekadı} {item.fiyat} TL-{item.stok} Kalan miktar-{item.kategori}");
                sayac++;
            }
        }
        public static void içecekekle()
        {
            while (true)
            {
                menüler yeniicecekler = new();
                do
                {
                    Console.WriteLine("Eklemek istediğiniz içeceğin adını girin: \n çıkış için 9 tuşuna basabilirsiniz.");
                    yeniicecekler.icecekadı = Console.ReadLine();
                    if (yeniicecekler.icecekadı == "9")
                        return;
                    if (string.IsNullOrWhiteSpace(yeniicecekler.icecekadı))
                    {
                        Console.WriteLine("Hata: İçecek adı boş olamaz!");
                        continue;
                    }
                    bool icecekvar = false;
                    foreach (menüler item in icecekler)
                    {
                        if (item.icecekadı == yeniicecekler.icecekadı)
                        {
                            Console.WriteLine("Aynı isimde içecek giremessin.");
                            icecekvar = true;
                            break;
                        }
                    }
                    if (icecekvar)
                        continue;
                    bool harf = true;
                    foreach (var item in yeniicecekler.icecekadı)
                    {
                        if (!char.IsLetter(item) && !char.IsWhiteSpace(item))
                        {
                            Console.WriteLine("Hata: İçecek adı sadece harf ve boşluk içerebilir.");
                            harf = false;
                            break;
                        }
                    }
                    if (!harf)
                        continue;
                    break;
                }
                while (true);
                do
                {
                    double fiyat = 0;
                    Console.WriteLine("Eklemek istediğiniz içeceğin fiyatını girin:");

                    if (!double.TryParse(Console.ReadLine(), out fiyat) || fiyat <= 0)
                    {
                        Console.WriteLine("Fiyat negatif olamaz ve harf giremessiniz.");
                        continue;
                    }
                    yeniicecekler.fiyat = fiyat;
                    break;

                } while (true);
                do
                {
                    Console.WriteLine("Eklemek istediğiniz içeceğin stok miktarını girin:");
                    if (!int.TryParse(Console.ReadLine(), out int stok) || stok < 0)
                    {
                        Console.WriteLine("Stok miktarı negatif olamaz ve harf giremessiniz.");
                        continue;
                    }
                    yeniicecekler.stok = stok;
                    break;
                } while (true);
                yeniicecekler.kategori = "içecek";
                icecekler.Add(yeniicecekler);

            }
        }
        public static void iceceksilme()
        {
            while (true)
            {
                icecekmenügöster();
                Console.WriteLine("Silmek istediğiniz içeceğin numarasını girin: \n çıkış için 9 tuşuna basabilirsiniz.");
                string input = Console.ReadLine();
                if (input == "9")
                    return;
                if (int.TryParse(input, out int silinecekNumara))
                {
                    if (silinecekNumara > 0 && silinecekNumara <= icecekler.Count)
                    {

                        Console.WriteLine($"{icecekler[silinecekNumara - 1].icecekadı} silindi.");
                        icecekler.RemoveAt(silinecekNumara - 1);
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz numara. Lütfen geçerli bir içecek numarası girin.");
                    }
                }

                else
                {
                    Console.WriteLine("Geçersiz giriş. Lütfen bir sayı girin.");
                }

            }
        }
        public static void icecektoplusil()
        {
            do
            {
                Console.WriteLine("İçeceklerin hepsi 1 tuşu ile silinecektir. 9 tuşu ile çıkabilirsiniz.");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int secim))
                    if (icecekler.Count == 0)
                    {
                        Console.WriteLine("İçecek listesi zaten boş.");
                        return;
                    }
                if (secim == 9)
                {
                    Console.WriteLine("Ana menüye dönülüyor...");
                }
                else if (secim == 1)
                {
                    Console.WriteLine("Tüm içecekler silindi.");
                    icecekler.Clear();
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim. Lütfen 1 veya 9 girin.");
                }
            } while (true);
        }
        public static void icecektgüncelle()
        {
            while (true)
            {
                icecekmenügöster();
                Console.WriteLine("Güncellemek istediğiniz içeceğin numarasını girin: \n çıkış için 9 tuşuna basabilirsiniz.");
                string input = Console.ReadLine();
                if (input == "9")
                    return;
                if (!int.TryParse(input, out int guncellenecekNumara))
                {
                    Console.WriteLine("Geçersiz giriş. Lütfen bir sayı girin.");

                }
                if (guncellenecekNumara > 0 && guncellenecekNumara <= icecekler.Count)
                {
                    Console.WriteLine($"Güncellemek istediğiniz içecek: {icecekler[guncellenecekNumara - 1].icecekadı}");
                    menüler guncellenecekicecek = icecekler[guncellenecekNumara - 1];
                    Console.WriteLine("Yeni içecek adını girin (değiştirmek istemiyorsanız Enter'a basın):");
                    string yeniAd = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(yeniAd)) // boşluk değilse aşağıdaki kodlardan devam et. boş ise direk çıkış yapar.
                    {
                        bool harf = true;
                        foreach (var c in yeniAd)
                        {
                            if (!char.IsLetter(c) && !char.IsWhiteSpace(c)) //IsLetter har harf mi kontrol eder. iswhitespace boşluk mu kontrol eder.
                            {
                                Console.WriteLine("İçecek adı sadece harf ve boşluk içerebilir.");
                                harf = false;
                                break;
                            }
                        }
                        if (harf)
                        {
                            guncellenecekicecek.icecekadı = yeniAd;
                        }

                    }
                    else
                    {
                        Console.WriteLine("İsim değiştirilmedi.");
                    }
                    do // fiyat güncelleme burda
                    {
                        string fiyatInput;
                        double yeniFiyat;
                        Console.WriteLine($"Yeni fiyatı girin. Güncel {guncellenecekicecek.fiyat} (değiştirmek istemiyorsanız Enter'a basın):");
                        fiyatInput = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(fiyatInput))
                            break;
                        if (double.TryParse(fiyatInput, out yeniFiyat))
                        {
                            guncellenecekicecek.fiyat = yeniFiyat;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz fiyat. Fiyat bir sayı olmalıdır, tekrar deneyin.");
                        }
                    } while (true);
                    do
                    {
                        Console.WriteLine($"stok miktarını giriniz Mevcut stok miktarı: {guncellenecekicecek.stok}");
                        input = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(input))
                            break;
                        if (int.TryParse(input, out int stokMiktar) && stokMiktar >= 0)
                        {
                            guncellenecekicecek.stok = stokMiktar;
                            Console.WriteLine($"Stok güncellendi. Yeni stok: {guncellenecekicecek.stok}");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz stok miktarı. Stok bir sayı olmalıdır, tekrar deneyin.");
                        }
                    } while (true);
                    do
                    {
                        Console.WriteLine($"Kategoriyi giriniz.Not sadece yemek veya içecek girebilirsiniz. Mevcut olan {guncellenecekicecek.kategori}");
                        input = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(input))
                        {
                            return;
                        }
                        if (input == "yemek" || input == "içecek")
                        {
                            guncellenecekicecek.kategori = input;
                            break;
                        }
                    } while (true);
                }
            }
        }
        public static void menüsec() //index mantığı var burda o yüzden index üzerinden gittik. id olsa idi foreach kullanabirdik. 
        {
            double kalanbakiye = 2000;
            while (true)
            {

                yemekmenügöster();
                icecekmenügöster();
                Console.WriteLine("Hangi yemegi seçmek istiyorsunuz? çıkış için 9a basabilirsiniz.");
                string input = Console.ReadLine();
                if (input == "9")
                {
                    break;
                }
                if (int.TryParse(input, out int yemeksecim) && 0 < yemeksecim && yemeksecim <= YemekMenü.Count)
                {
                    menüler secilenyemek = YemekMenü[yemeksecim - 1];
                    Console.WriteLine($"Seçtiğiniz Yemek = {secilenyemek.yemekadı}- Fiyatı {secilenyemek.fiyat}");
                    Console.WriteLine("kaç adet istiyorsunuz?");
                    if (int.TryParse(Console.ReadLine(), out int adet) && adet > 0)
                    {
                        if (secilenyemek.stok >= adet)
                        {
                            if (secilenyemek.stok >= adet)
                            {
                                if (kalanbakiye < secilenyemek.fiyat * adet)
                                {
                                    Console.WriteLine("Yeterli bakiyeniz yok.");
                                    continue;
                                }
                                secilenyemek.stok -= adet;
                                kalanbakiye -= secilenyemek.fiyat * adet;
                                double tutar = secilenyemek.fiyat * adet;

                                gunlukCiro += tutar;
                                kasa.parageliyor(tutar);
                                Satilanlar.Add(new SatilanUrun { Ad = secilenyemek.yemekadı, Adet = adet, Tutar = tutar, KalanStok = secilenyemek.stok });

                                Console.WriteLine($"{adet} adet {secilenyemek.yemekadı} siparişiniz alındı. Kalan stok: {secilenyemek.stok} Kalan paranız: {kalanbakiye}");
                            }
                            else
                            {
                                Console.WriteLine($"Yeterli stok yok. Mevcut stok: {secilenyemek.stok}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz adet. Lütfen pozitif bir sayı girin.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("hatalı secimler yapmayın");
                    }
                    Console.WriteLine("Hangi içeceği seçmek istiyorsunuz? çıkış için 9a basabilirsiniz.");
                    input = Console.ReadLine();
                    if (input == "9")
                    {
                        break;
                    }
                    if (int.TryParse(input, out int iceceksecim) && 0 < iceceksecim && iceceksecim <= icecekler.Count)
                    {
                        menüler secilenicecek = icecekler[iceceksecim - 1];
                        Console.WriteLine($"Seçtiğiniz İçecek = {secilenicecek.icecekadı}- Fiyatı {secilenicecek.fiyat}");
                        Console.WriteLine("kaç adet istiyorsunuz?");
                        if (int.TryParse(Console.ReadLine(), out adet) && adet > 0)
                        {
                            if (secilenicecek.stok >= adet)
                            {
                                if (kalanbakiye < secilenicecek.fiyat * adet)
                                {
                                    Console.WriteLine("Yeterli bakiyeniz yok.");
                                    break;
                                }
                                secilenicecek.stok -= adet;
                                kalanbakiye -= secilenicecek.fiyat * adet;
                                double tutar = secilenyemek.fiyat * adet;

                                gunlukCiro += tutar;

                                kasa.parageliyor(tutar);

                                Satilanlar.Add(new SatilanUrun { Ad = secilenicecek.icecekadı, Adet = adet, Tutar = tutar, KalanStok = secilenicecek.stok });
                                Console.WriteLine($"{adet} adet {secilenicecek.icecekadı} siparişiniz alındı. Kalan stok: {secilenicecek.stok} Kalan paranız: {kalanbakiye}");
                            }
                            else
                            {
                                Console.WriteLine($"Yeterli stok yok. Mevcut stok: {secilenicecek.stok}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz adet. Lütfen pozitif bir sayı girin.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("hatalı secimler yapmayın");
                    }
                }
            }
        }
        public static void SatilanlariYazdir()
        {
            Console.WriteLine("\n=== SATIŞ RAPORU ===");

            if (Satilanlar.Count == 0)
            {
                Console.WriteLine("Bugün hiç satış yapılmadı.");
                return;
            }
            foreach (var s in Satilanlar)
            {
                Console.WriteLine($"{s.Ad} - {s.Adet} adet, Tutar: {s.Tutar} TL, Satıştan sonra kalan stok: {s.KalanStok}");
            }
            Console.WriteLine($"Toplam Ciro: {gunlukCiro} TL");

            kasa.kasagöster();
        }
    }
}


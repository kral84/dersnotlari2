using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

        //Console.WriteLine(); // kullanıcıya bilgi verdiğimiz komut.
        //örnek. 
        //Console.WriteLine("naber");

        //Console.ReadLine(); // kullanıcının girdiği değerleri okur. Her zaman string'e çeviririz.

        // const: sabit değişken. sayı ilerde değiştirelemez sabitler.


        // MATEMATİKSEL OPERATÖRLER(+,-,*,/,%)
        //int sayi = 5;
        //int sayi2 = 12;

        ////Mod Alma(%)

        //Console.WriteLine(sayi%sayi2);


        //Bölme işleminde, işleme uğrayan sayılardan biri dahi ondalıklı ise sonuç ondalıklı ama her iki sayıda int ise sonuç TAM SAYI çıkar.
        //double sayi = 12;
        //int sayi2 = 5;

        //int sonuc = (int)(sayi / sayi2);

        //Console.WriteLine("Sonuç:"+sonuc);

        //Örnek:
        //int a = 5;
        //int b = a++; //a değerini b ye ata sonra a değerini 1 arttır.
        //int c = ++a; //a değerini 1 arttır sonra a değerini c ye ata.
        //int d = b + c;
        //double e = d / a;



        //#region *** KIYAS OPERATÖRÜ(?:) *** 
        // ? kıyas durumu TRUE ise atanacak değer 
        // : kıyas durumu FALSE ise atanacak değer
        //int sayi = 5;

        //string sonuc = 5 > 6 ? "Büyüktür" : "Küçüktür";
        //int sonuc2 = 5 > 6 ? 1 : 0;


        //  karşılastırma operatörü bool
        //int sayi = 5;
        //int sayi2 = 6;

        //bool sonuc  = sayi > sayi2;
        //bool sonuc2 = sayi < sayi2;
        //bool sonuc3 = sayi >= sayi2;
        //bool sonuc4 = sayi <= sayi2;
        //bool sonuc5 = sayi == sayi2; // sayi ile sayi2 eşit mi?
        //bool sonuc6 = sayi != sayi2; // sayi ile sayi2 eşit değil mi?



        //***ERİŞİM OPERATÖRÜ(.) * **

        //Console.WriteLine();

        //Console.ReadLine().ToString().ToLower();

        // AND - &&
        //// Bir işlemin başarılı(true) olması için her şartın sağlanması gerekiyor ise && kullanılır.


        // OR - ||
        //// Bir işlemin başarılı(true) olması için şartlardan herhangi birinin sağlanması gerekiyor ise || kullanılır.



        //#region Kullanıcıdan yaş, mezuniyet ve Cinsiyet bilgilerini alınız.  
        //Ehliyet alma koşulu: Yaş 18 den büyük ve mezuniyet Lise olamalı. veya cinsiyet erkek olmalı. 


        //### Değişkenler ve Veri Tipleri
        //1. * Soru:*Kullanıcının adını, yaşını ve boyunu(metre cinsinden) alıp ekrana yazdıran bir program yazın.
        //-*İpucu:*string, int, ve double veri tiplerini kullanabilirsiniz.
        //CEVAP
        //Console.Write("Kullanıcı adını giriniz : ");
        //  Console.ReadLine();
        //Console.Write("Yaşınızı girin : ");
        //int yas = Convert.ToInt32(Console.ReadLine());
        //Console.Write("Boyunuzu metre cinsinden girin : ");
        //double boy = Convert.ToDouble(Console.ReadLine());

        // Console.WriteLine("Başarılı");

        //2. * Soru:*Aşağıdaki değişkenleri tanımlayın ve uygun değerler atayın:
        //-bool isStudent
        //-char grade
        //-float temperature
        //CEVAP
        //bool isStudent = true; // "Bu kişi öğrenci mi?" sorusunun cevabı true yani doğru.

        //char grade = 'A'; // grade degeri tek harf tutuyor

        //float temperature = 36.5f;

        //### Tür Dönüşümleri
        //3. * Soru:*Kullanıcıdan bir sayı alın ve bu sayıyı hem int hem de double veri tipine dönüştürerek ekrana yazdırın.
        //-*İpucu:*Convert.ToInt32() ve Convert.ToDouble() yöntemlerini kullanabilirsiniz.
        //CEVAP
        //nokta degil virgül kullanmalıyız.
        //Console.WriteLine("Bir sayı giriniz: ");
        //  string girilen = Console.ReadLine();
        // double sayı1 = Convert.ToDouble(girilen);
        //int sayı = Convert.ToInt32(sayı1);

        // Console.WriteLine(sayı1 );
        // Console.WriteLine(sayı );



        //4. * Soru:*double türünde bir değişken oluşturun ve bu değişkenin değerini string olarak ekrana yazdırın.
        //-*İpucu:*ToString() yöntemini kullanabilirsiniz.
        //CEVAP

        //double deger = 12.34;
        //Console.WriteLine(deger.ToString());


        //### Operatörler
        //5. * Soru:*İki tam sayı alın ve bu sayılar üzerinde toplama, çıkarma, çarpma ve bölme işlemlerini yaparak sonuçları ekrana yazdırın.
        //-*İpucu:*+, -, *, / operatörlerini kullanabilirsiniz.
        //CEVAP

        //Console.WriteLine("birinci sayıyı giriniz ");
        //int sayi1 = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine("ikinci sayıyı giriniz ");
        //int sayi2 = Convert.ToInt32(Console.ReadLine());

        //int toplam = sayi1 + sayi2;
        //Console.WriteLine("Toplam: " + toplam);
        //int fark = sayi1 - sayi2;
        //Console.WriteLine("Fark: " + fark);
        //int carpim = sayi1 * sayi2;
        //Console.WriteLine("Çarpım: " + carpim);
        //int bolum = sayi1 / sayi2;
        //Console.WriteLine("Bölüm: " + bolum);

        //6. * Soru:*Kullanıcıdan iki sayı alın ve bu sayıların birbirine eşit olup olmadığını kontrol edin. Sonucu ekrana yazdırın.
        //-*İpucu:* == operatörünü kullanabilirsiniz.
        //CEVAP

        //Console.WriteLine("Birinci sayıyı giriniz: ");
        //int sayi1 = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine("İkinci sayıyı giriniz: ");
        //int sayi2 = Convert.ToInt32(Console.ReadLine());

        //bool esitMi = sayi1 == sayi2;
        //Console.WriteLine(esitMi); 


        //### Karma Sorular
        //7. * Soru:*Kullanıcıdan bir sayı alın ve bu sayının tek mi çift mi olduğunu kontrol edin.Sonucu ekrana yazdırın.
        //-*İpucu:* % operatörü kullanarak kalan değerini kontrol edebilirsiniz.
        //CEVAP

        //Console.WriteLine("Bir sayı giriniz: ");
        //int sayı = Convert.ToInt32(Console.ReadLine());

        //string tekMi = sayı % 2 != 0 ? "tekdir" : "cifttir"; 

        //Console.WriteLine(tekMi);

        //8. * Soru:*Kullanıcıdan bir sıcaklık değeri alın ve bu değerin 0°C'nin altında olup olmadığını kontrol edin. Eğer öyleyse "Dondurucu soğuk!" mesajını ekrana yazdırın.
        //-*İpucu:* < operatörünü kullanabilirsiniz.
        //CEVAP

        //Console.WriteLine("Bir sıcaklık değeri giriniz (°C): ");
        //double sicaklik = Convert.ToDouble(Console.ReadLine());
        //string sicaklikdurumu = sicaklik < 0 ? "Dondurucu soğuk!" : "Soğuk değil.";

        //Console.WriteLine(sicaklikdurumu);



        //Console.WriteLine("Yaşınız");
        //int yas = Convert.ToInt32(Console.ReadLine());
        //string cevap = yas > 18 ? "yetiskin" : "çocuk";
        //Console.WriteLine("cevap " + cevap);



        //if (yas > 18)
        //{
        //    Console.WriteLine("yetişkin");

        //}
        //else 
        //{
        //    Console.WriteLine("çocuk");
        //}


        // Console.WriteLine("Bir sayı giriniz : ");
        // int sayı = Convert.ToInt32(Console.ReadLine());
        // if (sayı > 0 && sayı < 11)
        // {
        //     Console.WriteLine("cevap " + sayı );
        // }
        // else if (sayı > 10 && sayı <21 )
        // {
        //     Console.WriteLine("sayı "+ sayı);
        // }
        // else if (sayı > 20 && sayı < 31)
        // {
        //     Console.WriteLine("sayı " + sayı );
        // }
        // else
        // {
        //     Console.WriteLine("30dan büyük " + sayı);
        // }


        //    Console.WriteLine("Haftanın kaçıncı günü ? : ");
        //    int sayi = Convert.ToInt32(Console.ReadLine());


        //    if (sayi >7 )
        //    {
        //        Console.WriteLine("Lütfen 1-7 arasında bir sayı giriniz.");
        //}
        //    else if (sayi == 1)
        //    {
        //        Console.WriteLine("Pazartesi " + sayi);
        //    }
        //    else if (sayi == 2)
        //    {
        //        Console.WriteLine("salı " + sayi);
        //    }
        //    else if (sayi == 3)
        //    {
        //        Console.WriteLine("carsamba " + sayi);
        //    }
        //    else if (sayi == 4)
        //    {
        //        Console.WriteLine("persembe " + sayi);
        //    }
        //    else if (sayi == 5)
        //    {
        //        Console.WriteLine("cuma " + sayi);
        //    }
        //    else if (sayi == 6)
        //    {
        //        Console.WriteLine("Cumartesi " + sayi);
        //    }
        //    else if (sayi == 7)
        //    {
        //        Console.WriteLine("Pazar " + sayi);
        //    }

        // kullanıcıdan iki ürün fiyatı isteyin, ürün fiyat toplamları 2500 tl geçerse
        // ucuz ürüne
        //yüzde 25 indirim apın ve ekrana yazdırın.

        // cevap:::::::
        //Console.WriteLine("Birinci ürün fiyatını giriniz: ");
        //double fiyat1 = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine("İkinci ürün fiyatını giriniz: ");
        //double fiyat2 = Convert.ToInt32(Console.ReadLine());   
        //double toplamFiyat = fiyat1 + fiyat2;


        //if (toplamFiyat > 2500)
        //{
        //   double indirimliFiyat = toplamFiyat * 0.75; // %25 indirim
        //    Console.WriteLine("Toplam fiyat: " + toplamFiyat + " TL");
        //    Console.WriteLine("İndirimli fiyat: " + indirimliFiyat + " TL");
        //}
        //else
        //{
        //    Console.WriteLine("Toplam fiyat 2500 TL'yi geçmedi, indirim uygulanmadı.");
        //    Console.WriteLine("Fiyat: " + toplamFiyat + "TL");
        //}


        #region Aylık geliri 40000 üstünde ise %12 vergi kesilecek,
        // 40000 ve altında ise %9 vergi kesimi yapılarak 
        // kullanıcıya yeni gelirini bu hesaplamalar sonucunda gösteriniz
        #endregion
        //Console.WriteLine("Aylık geliriniz nedir ?");
        //double gelir = Convert.ToDouble(Console.ReadLine());
        //double vergi = gelir * 0.12; // %12 vergi kesintisi
        //double netgelir = gelir - vergi;           
        //double altvergi = gelir * 0.9; // %9 vergi kesintisi

        //if ( gelir > 4000)
        //{
        //    Console.WriteLine("Aylık geliriniz: " + gelir + " TL, Vergi kesintisi yüzde 12: " + netgelir + " Net gelir TL");
        //}
        // else
        //{
        //    Console.WriteLine("Aylık geliriniz: " + gelir + " TL, Vergi kesintisi yüzde 9: " + altvergi + " Net gelir TL");
        //}

        //#region Öğrenciden vize ve final notlarını alınız ve vize %40 final %60 alınarak ortalamasını hesaplayınız. 


        //Console.WriteLine("Vize notunuzu giriniz: ");
        //double vize = Convert.ToDouble(Console.ReadLine());
        //Console.WriteLine("Final notunuzu giriniz: ");
        //double final = Convert.ToDouble(Console.ReadLine());
        //double ortalama = (vize * 0.4) + (final * 0.6);
        //Console.WriteLine("Ortalamanız: " + ortalama);

        ////  Not ortalamasına göre harf notu verilecek.
        //if (ortalama > 100)
        //    Console.WriteLine("Harf Notunuz: Geçersiz Not");
        //else if (ortalama >= 85)
        //    Console.WriteLine("Harf Notunuz: AA");
        //else if (ortalama >= 70)
        //    Console.WriteLine("Harf Notunuz: BB");
        //else if (ortalama >= 55)
        //    Console.WriteLine("Harf Notunuz: CB");
        //else if (ortalama >= 45)
        //    Console.WriteLine("Harf Notunuz: CC");
        //else if (ortalama >= 25)
        //    Console.WriteLine("Harf Notunuz: DD");          
        //else 
        //    Console.WriteLine("Harf Notunuz: FF");

        //ortalamaya göre 
        /*
         * 
        0,24   FF
        25,44  DD
        45,54  CC
        55,69  CB
        70,84  BB
        85,100 AA

         */

        //#endregion

        //#region  1-50 arasındaki sayıların içinde 7'e tam bölünenleri ekrana teker teker yazdırınız.

        //Console.WriteLine("1-50 arasında sayı gir bakayım ");
        //int sayi = Convert.ToInt32(Console.ReadLine());
        //if (sayi < 1 || sayi > 50)
        //    Console.WriteLine(" 1-50 arasında bir sayı giriniz.");
        //else if (sayi % 7 == 0)
        //    Console.WriteLine("Bu sayı 7'ye tam bölünür: " + sayi);
        //else
        //    Console.WriteLine("Bu sayı 7'ye tam bölünmez: " + sayi);



        //   Kullanıcıdan isim, yaş, maaş ve çocuk sayısı alınsın.

        //Eğer kulanıcının yaşı 45'in altındaysa;
        //    Çocuk sayısına bakılacak.Ve çocuk sayısı 3'ten az ise çocuk başına 2500₺,
        //                                          3 ve 3'ten çok ise çocuk başına 2000₺ 
        //                                                maaşa ekleme yapılacak.
        //45 ve 45'in üzerinde ise çocuk başına para verilmeyecek ancak 5000₺ ekleme yapılacak.
        //Son olarak ekrana: "Nesrin Yılmaz, Maaşınız: 40000₺" yazılacak.


        // Console.WriteLine("İsminizi giriniz: ");
        //    string isim = Console.ReadLine();
        //Console.WriteLine("Yaşınızı giriniz: ");
        //    int yas = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine("Maaşınızı giriniz: ");
        //    double maas = Convert.ToDouble(Console.ReadLine());
        //Console.WriteLine("Çocuk sayınızı giriniz: ");
        //    int cocukSayisi = Convert.ToInt32(Console.ReadLine());
        //double eklenenMaaş = 2000;
        //double ekpara = 5000;

        //    if (yas < 45 && cocukSayisi < 3)
        //    {
        //        double yenimaas = maas + cocukSayisi * 2500;
        //        Console.WriteLine(isim + " Maasınız: " + yenimaas );
        //    }
        //    else if (yas < 45 && cocukSayisi >= 3)
        //    {
        //        double yenimaas2 = maas + cocukSayisi * eklenenMaaş;
        //        Console.WriteLine(isim + " Maasınız: " + eklenenMaaş);
        //    }
        //    else
        //    {
        //        double ekmaas2 = maas + ekpara;
        //        Console.WriteLine(isim + " Maasınız: " +ekmaas2);
        //    }

        //      kullanıcıdan alınan cinsiyet bilgisine göre
        //==> ERKEK ise
        //      yaşı 60 ve üstü ise maaşının 10 katı kadar ikramiye alaral emekli edilecek,
        //      yaş 60'ın altında ise çalıştığı gün sayısına göre 
        //              eğer 6000 ve üstü ise maaşının 11 katı kadar ikramiye alarak emekli edilecek,
        //              6000 altında ise emekli edilmeyecek bilgisi kullanıcıya gösterilecek
        //    ==> KADIN ise
        //     yaşı 58 ve üstü ise maaşının 10 katı kadar ikramiye alarak emekli edilecek, yaş 58'ın altında ise çalıştığı gün sayısına göre eğer 3600 ve üstü ise maaşının 11 katı kadar ikramiye alarak emekli edilecek, 3600 altında ise emekli edilmeyecek bilgisi kullanıcıya gösterilecek
        //    ==> cinsiyet bilgisi switch-case ile sorgulanacak


        //Console.WriteLine("cinsiyetinizi giriniz");
        //string cinsiyet = Console.ReadLine().ToLower();

        //if (cinsiyet == "erkek")
        //{
        //    Console.WriteLine("Yaşınızı giriniz: ");
        //    int yas = Convert.ToInt32(Console.ReadLine());

        //    if (yas > 60)
        //    {
        //        Console.WriteLine("maasınızı girin");
        //        double maas = Convert.ToDouble(Console.ReadLine());
        //        double yenimaas = maas * 10;
        //        Console.WriteLine("Yeni maasınız " + yenimaas);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Çalıştığınız gün sayısını giriniz: ");
        //        int gunSayisi = Convert.ToInt32(Console.ReadLine());

        //        if (gunSayisi >= 6000)
        //        {
        //            Console.WriteLine("maasınızı girin");
        //            double maas = Convert.ToDouble(Console.ReadLine());
        //            double yenimaas = maas * 11;
        //            Console.WriteLine("Yeni maasınız " + yenimaas);
        //        }
        //        else
        //        {
        //            Console.WriteLine("Emekli edilmeyeceksiniz.");
        //        }
        //    }
        //}

        yukarı:
            try
            {
                Console.WriteLine("Merhaba bankamatiğimize hoş geldiniz.");
                Console.WriteLine("Kartlı işlem için 1, Kartsız işlem için 2 tuşuna basınız, Çıkış için 9 tuşuna basınız. ");
                int secim = Convert.ToInt32(Console.ReadLine());
                if (secim == 9)
                {
                    Console.WriteLine("Çıkış yapılıyor. Güle güle");
                    return;
                }
                if (secim != 1 && secim != 2)
                {
                    Console.WriteLine("Lütfen geçerli bir işlem seçiniz.");
                    goto yukarı;
                }

                switch (secim)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Kartlı işlem seçildi.");
                            int hak = 3;
                            while (hak > 0)
                            {
                                Console.WriteLine("Lütfen şifrenizi giriniz: ");
                                string? sifre = Console.ReadLine();        // null 'lu bişi ama tam anlamadım. deneme amaclı koydum uyarı gitti.

                                if (sifre == "1234")
                                {
                                    Console.WriteLine("Şifreniz doğru. Ana menüye yönlendiriliyorsunuz.");

                                    int para = 2500;
                                    int menü = 0;

                                    while (menü != 9)
                                    {
                                    anamenü:
                                        Console.WriteLine("********* Ana Menü ************");
                                        Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz:");
                                        Console.WriteLine("1. Para Çekme");
                                        Console.WriteLine("2. Para Yatırma");
                                        Console.WriteLine("3. Para Transferleri");
                                        Console.WriteLine("4. Eğitim Ödemeleri");
                                        Console.WriteLine("5. Ödemeler");
                                        Console.WriteLine("6. Bilgi Güncelleme");
                                        Console.WriteLine("7. Gİriş ekranına giden yol");
                                        Console.WriteLine("9. Atmden Çıkış");

                                        int islem = 0;
                                        try
                                        {
                                            islem = Convert.ToInt32(Console.ReadLine());
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
                                        }

                                        if (islem == 1)
                                        {
                                            try
                                            {
                                                int tutar = 0;
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.Write("Çekmek istediğiniz tutarı girin: \nAna menüye dönmek için 9\nKart iade için 8\n");
                                                        tutar = Convert.ToInt32(Console.ReadLine());

                                                        if (tutar == 0)
                                                        {
                                                            Console.WriteLine("0 olmaz geçerli bir değer girin.");
                                                        }
                                                        else if (tutar > para)
                                                        {
                                                            Console.WriteLine("Bu kadar paranız yok. Kalan bakiye: " + para);
                                                        }
                                                        else if (tutar < 0)
                                                        {
                                                            Console.WriteLine("Pozitif bir tutar giriniz.");
                                                        }
                                                        else if (tutar == 8)
                                                        {
                                                            Console.WriteLine("Kart iade ediliyor...");
                                                            return;
                                                        }
                                                        else if (tutar == 9)
                                                        {
                                                            Console.WriteLine("Ana menüye dönülüyor...");
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            para -= tutar;
                                                            Console.WriteLine("Para çekildi. Kalan bakiye: " + para);
                                                            break;
                                                        }
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
                                                    }
                                                }
                                            }
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
                                            }
                                        }
                                        else if (islem == 2)
                                        {
                                            try
                                            {
                                                int yatir = 0;
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.Write("Yatırmak istediğiniz tutarı girin: \nAna menü için 9\nKart iade için 8\n");
                                                        yatir = Convert.ToInt32(Console.ReadLine());

                                                        if (yatir == 0)
                                                        {
                                                            Console.WriteLine("0 olmaz geçerli bir değer girin.");
                                                        }
                                                        else if (yatir < 0)
                                                        {
                                                            Console.WriteLine("Pozitif bir tutar giriniz.");
                                                        }
                                                        else if (yatir == 8)
                                                        {
                                                            Console.WriteLine("Kart iade ediliyor...");
                                                            return;
                                                        }
                                                        else if (yatir == 9)
                                                        {
                                                            Console.WriteLine("Ana menüye dönülüyor...");
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            para += yatir;
                                                            Console.WriteLine("Para yatırıldı. Yeni bakiye: " + para);
                                                            break;
                                                        }
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
                                                    }
                                                }
                                            }
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
                                            }
                                        }
                                        else if (islem == 3)
                                        {
                                            try
                                            {
                                                int transfer = 0;
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.Write("EFT için 1, Havale için 2, Ana menü için 9, Kart iade için 8: ");
                                                        transfer = Convert.ToInt32(Console.ReadLine());

                                                        if (transfer == 8)
                                                        {
                                                            Console.WriteLine("Kart iade ediliyor...");
                                                            return;
                                                        }
                                                        else if (transfer == 9)
                                                        {
                                                            Console.WriteLine("Ana menüye dönülüyor...");
                                                            goto anamenü;
                                                        }

                                                        if (transfer == 1)
                                                        {
                                                            Console.Write("Başında TR olan 12 haneli hesap numarası girin: ");
                                                            string hesapNumarasi = Console.ReadLine();

                                                            while (hesapNumarasi.Length != 12 || !hesapNumarasi.StartsWith("TR"))   /// önemli ve güzel bir nokta
                                                            {
                                                                if (hesapNumarasi == "9")
                                                                {
                                                                    Console.WriteLine("İşlem iptal edildi. Ana menüye dönülüyor...");
                                                                    goto anamenü;
                                                                }
                                                                else if (hesapNumarasi == "8")
                                                                {
                                                                    Console.WriteLine("Bir önceki menüye dönülüyor...");
                                                                    break;
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("Hesap numarası geçersiz. Tekrar deneyin.");
                                                                    hesapNumarasi = Console.ReadLine().ToUpper();
                                                                }
                                                            }

                                                            Console.Write("EFT tutarını giriniz: ");
                                                            int eft = Convert.ToInt32(Console.ReadLine());
                                                            para -= eft;
                                                            Console.WriteLine("EFT başarılı. Kalan bakiye: " + para);
                                                            break;
                                                        }
                                                        else if (transfer == 2)
                                                        {
                                                            while (true)
                                                            {
                                                                try
                                                                {
                                                                    Console.WriteLine("11 haneli hesap numarası girin: \nNot hesap no: 0 ile başlıyamaz.");
                                                                    string giris = Console.ReadLine();
                                                                    long havale = Convert.ToInt64(giris); // int'in kapasitesi yetmedi 11 tane sa için

                                                                    if (havale == 9)
                                                                    {
                                                                        Console.WriteLine("İşlem iptal edildi. Ana menüye dönülüyor...");
                                                                        goto anamenü;
                                                                    }
                                                                    else if (havale == 8)
                                                                    {
                                                                        Console.WriteLine("Bir önceki menüye dönülüyor...");
                                                                        break;
                                                                    }
                                                                    else if (havale.ToString().Length != 11)
                                                                    {
                                                                        Console.WriteLine("Hesap numarası 11 haneli olmalı.");
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("Hesap bilgileri doğru.");
                                                                        break;
                                                                    }
                                                                }
                                                                catch
                                                                {
                                                                    Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
                                                                }
                                                            }
                                                            while (true)
                                                            {
                                                                try
                                                                {
                                                                    Console.WriteLine("havale yapacağınız tutarı girin. ");
                                                                    int havaleTutar = Convert.ToInt32(Console.ReadLine());

                                                                    if (havaleTutar == 0)
                                                                    {
                                                                        Console.WriteLine("0 olmaz geçerli bir değer girin.");
                                                                    }
                                                                    else if (havaleTutar < 0)
                                                                    {
                                                                        Console.WriteLine("Negatif deger olamaz.");
                                                                    }
                                                                    else if (havaleTutar > para)
                                                                    {
                                                                        Console.WriteLine("Bu kadar paranız yok. Kalan bakiye: " + para);
                                                                    }
                                                                    else
                                                                    {
                                                                        para -= havaleTutar;
                                                                        Console.WriteLine("Havale başarılı. Kalan bakiye: " + para);
                                                                        break;
                                                                    }
                                                                }
                                                                catch (FormatException)
                                                                {
                                                                    Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
                                                                }
                                                            }
                                                            break;
                                                        }
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
                                                    }
                                                }
                                            }
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
                                            }
                                        }
                                        else if (islem == 4)
                                        {
                                            int egitim = 0;
                                            while (true)
                                            {
                                                try
                                                {
                                                    Console.WriteLine("Bu sayfa suanda arızalı \nÇıkış için 8 tusuna basınız.\nAnaMenüye dönmek için 9 tuşuna basınız");
                                                    egitim = Convert.ToInt32(Console.ReadLine());

                                                    if (egitim == 8)
                                                    {
                                                        Console.WriteLine("çıkış yapılıyor");
                                                        return;
                                                    }
                                                    else if (egitim == 9)
                                                    {
                                                        Console.WriteLine("Ana menüye dönülüyor...");
                                                        goto anamenü;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Geçersiz işlem. Lütfen tekrar deneyin.");
                                                    }
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
                                                }
                                            }
                                        }
                                        else if (islem == 7)
                                        {
                                            Console.WriteLine("Giriş ekranına gidiyorsunuz...");
                                            goto yukarı;
                                        }
                                        else if (islem == 9)
                                        {
                                            Console.WriteLine("ATM'den çıkılıyor. Güle güle!");
                                            return;
                                        }
                                        else if (islem == 5)
                                        {
                                            while (true)
                                            {
                                                try
                                                {
                                                    int fatura = 0;
                                                    Console.WriteLine("\nElektrik faturası için 1 : \nTelefon Faturası icin 2 : \nİnternet Faturası için 3 : \nSu ödemesi 4 : \nOGS Ödemesi 5 : \nÖnceki menü : 6 \nAnaMenü 7 : \nÇıkış 8 ");
                                                    fatura = Convert.ToInt32(Console.ReadLine());
                                                    if (fatura == 1)
                                                    {
                                                        while (true)
                                                        {
                                                            try
                                                            {
                                                                Console.WriteLine("Elektrik fatura tutarını giriniz. \nmevcut paranız:  " + para + "TL " + "\nAnaMenü için 9 tusuna basın. \n Çıkış için 8 tuşuna basın.");
                                                                int elektrik = Convert.ToInt32(Console.ReadLine());
                                                                if (elektrik == 0)
                                                                {
                                                                    Console.WriteLine("Fatura tutarı 9 olamaz");
                                                                }
                                                                else if (elektrik < 0)
                                                                {
                                                                    Console.WriteLine("Negatif değer olamaz.");
                                                                }
                                                                else if (elektrik > para)
                                                                {
                                                                    Console.WriteLine("Bu kadar paranız yok. Kalan bakiye: " + para);
                                                                }
                                                                else if (elektrik == 8)
                                                                {
                                                                    Console.WriteLine("Kart iade ediliyor...");
                                                                    return;
                                                                }
                                                                else if (elektrik == 9)
                                                                {
                                                                    Console.WriteLine("Ana menüye dönülüyor...");
                                                                    goto anamenü;
                                                                }
                                                                else
                                                                {
                                                                    para -= elektrik;
                                                                    Console.WriteLine("Fatura ödendi. Kalan bakiye: " + para);
                                                                    break;
                                                                }
                                                            }
                                                            catch (FormatException)
                                                            {
                                                                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
                                                            }
                                                        }
                                                    }
                                                    else if (fatura == 2)
                                                    {
                                                        while (true)
                                                        {
                                                            try
                                                            {
                                                                Console.WriteLine("Telefon faturası tutarını giriniz. \nmevcut paranız:  " + para + "TL " + "\nAnaMenü için 9 tusuna basın. \n Çıkış için 8 tuşuna basın.");
                                                                int telefon = Convert.ToInt32(Console.ReadLine());
                                                                if (telefon == 0)
                                                                {
                                                                    Console.WriteLine("Fatura tutarı 9 olamaz");
                                                                }
                                                                else if (telefon < 0)
                                                                {
                                                                    Console.WriteLine("Negatif değer olamaz.");
                                                                }
                                                                else if (telefon > para)
                                                                {
                                                                    Console.WriteLine("Bu kadar paranız yok. Kalan bakiye: " + para);
                                                                }
                                                                else if (telefon == 8)
                                                                {
                                                                    Console.WriteLine("Kart iade ediliyor...");
                                                                    return;
                                                                }
                                                                else if (telefon == 9)
                                                                {
                                                                    Console.WriteLine("Ana menüye dönülüyor...");
                                                                    goto anamenü;
                                                                }
                                                                else
                                                                {
                                                                    para -= telefon;
                                                                    Console.WriteLine("Fatura ödendi. Kalan bakiye: " + para);
                                                                    break;
                                                                }
                                                            }
                                                            catch (FormatException)
                                                            {
                                                                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
                                                            }
                                                        }
                                                    }
                                                    else if (fatura == 3)
                                                    {
                                                        while (true)
                                                        {
                                                            try
                                                            {
                                                                Console.WriteLine("İnternet tutarını giriniz. \nmevcut paranız:  " + para + "TL " + "\nAnaMenü için 9 tusuna basın. \n Çıkış için 8 tuşuna basın.");
                                                                int internet = Convert.ToInt32(Console.ReadLine());
                                                                if (internet == 0)
                                                                {
                                                                    Console.WriteLine("Fatura tutarı 9 olamaz");
                                                                }
                                                                else if (internet < 0)
                                                                {
                                                                    Console.WriteLine("Negatif değer olamaz.");
                                                                }
                                                                else if (internet > para)
                                                                {
                                                                    Console.WriteLine("Bu kadar paranız yok. Kalan bakiye: " + para);
                                                                }
                                                                else if (internet == 8)
                                                                {
                                                                    Console.WriteLine("Kart iade ediliyor...");
                                                                    return;
                                                                }
                                                                else if (internet == 9)
                                                                {
                                                                    Console.WriteLine("Ana menüye dönülüyor...");
                                                                    goto anamenü;
                                                                }
                                                                else
                                                                {
                                                                    para -= internet;
                                                                    Console.WriteLine("Fatura ödendi. Kalan bakiye: " + para);
                                                                    break;
                                                                }
                                                            }
                                                            catch (FormatException)
                                                            {
                                                                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
                                                            }
                                                        }
                                                    }
                                                    else if (fatura == 4)
                                                    {
                                                        while (true)
                                                        {
                                                            try
                                                            {
                                                                Console.WriteLine("Su tutarını giriniz. \nmevcut paranız:  " + para + "TL " + "\nAnaMenü için 9 tusuna basın. \n Çıkış için 8 tuşuna basın.");
                                                                int su = Convert.ToInt32(Console.ReadLine());
                                                                if (su == 0)
                                                                {
                                                                    Console.WriteLine("Fatura tutarı 9 olamaz");
                                                                }
                                                                else if (su < 0)
                                                                {
                                                                    Console.WriteLine("Negatif değer olamaz.");
                                                                }
                                                                else if (su > para)
                                                                {
                                                                    Console.WriteLine("Bu kadar paranız yok. Kalan bakiye: " + para);
                                                                }
                                                                else if (su == 8)
                                                                {
                                                                    Console.WriteLine("Kart iade ediliyor...");
                                                                    return;
                                                                }
                                                                else if (su == 9)
                                                                {
                                                                    Console.WriteLine("Ana menüye dönülüyor...");
                                                                    goto anamenü;
                                                                }
                                                                else
                                                                {
                                                                    para -= su;
                                                                    Console.WriteLine("Fatura ödendi. Kalan bakiye: " + para);
                                                                    break;
                                                                }
                                                            }
                                                            catch (FormatException)
                                                            {
                                                                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
                                                            }
                                                        }
                                                    }
                                                    else if (fatura == 5)
                                                    {
                                                        while (true)
                                                        {
                                                            try
                                                            {
                                                                Console.WriteLine("OGS tutarını giriniz. \nmevcut paranız:  " + para + "TL " + "\nAnaMenü için 9 tusuna basın. \n Çıkış için 8 tuşuna basın.");
                                                                int ogs = Convert.ToInt32(Console.ReadLine());
                                                                if (ogs == 0)
                                                                {
                                                                    Console.WriteLine("Fatura tutarı 9 olamaz");
                                                                }
                                                                else if (ogs < 0)
                                                                {
                                                                    Console.WriteLine("Negatif değer olamaz.");
                                                                }
                                                                else if (ogs > para)
                                                                {
                                                                    Console.WriteLine("Bu kadar paranız yok. Kalan bakiye: " + para);
                                                                }
                                                                else if (ogs == 8)
                                                                {
                                                                    Console.WriteLine("Kart iade ediliyor...");
                                                                    return;
                                                                }
                                                                else if (ogs == 9)
                                                                {
                                                                    Console.WriteLine("Ana menüye dönülüyor...");
                                                                    goto anamenü;
                                                                }
                                                                else
                                                                {
                                                                    para -= ogs;
                                                                    Console.WriteLine("Fatura ödendi. Kalan bakiye: " + para);
                                                                    break;
                                                                }
                                                            }
                                                            catch (FormatException)
                                                            {
                                                                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
                                                            }
                                                        }
                                                    }
                                                    else if (fatura == 6)
                                                    {
                                                        Console.WriteLine("Bir önceki menüye dönülüyor...");
                                                        break;
                                                    }
                                                    else if (fatura == 7)
                                                    {
                                                        Console.WriteLine("Ana menüye dönülüyor...");
                                                        goto anamenü;
                                                    }
                                                    else if (fatura == 8)
                                                    {
                                                        Console.WriteLine("Çıkış yapılıyor...");
                                                        return;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Geçersiz işlem. Lütfen tekrar deneyin.");
                                                    }
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    hak--;
                                    Console.WriteLine("Yanlış şifre. Kalan deneme hakkı: " + hak);
                                    if (hak == 0)
                                    {
                                        Console.WriteLine("Kartınız bloke edilmiştir.");
                                        int lupi = 0;
                                        while (lupi < 100)
                                        {
                                            Console.WriteLine("Kartınız bloke edilmiştir. Lütfen bankanızla iletişime geçin.");
                                            Thread.Sleep(1000);  // delayın yerine 1 saniye bekliyor. thread.sleep(1000); 1000 demek 1 saniye demek.
                                            lupi++;
                                        }

                                        return;
                                    }

                                }
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("****** Kartsız İşlem Menüsü *******");
                            Console.WriteLine("Cepbank para çekmek için 1 tuşuna basınız");
                            Console.WriteLine("Para yatırmak için 2 tuşuna basınız");
                            Console.WriteLine("Kredi Kartı ödeme 3 tuşuna basınız");
                            Console.WriteLine("Egitim ödemeleri için 4 tuşuna basınız.");
                            Console.WriteLine("Ödemeler için 5 tuşuna basınız.");
                            int kartsızsecim = Convert.ToInt32(Console.ReadLine());
                            if (kartsızsecim == 1)
                            {
                                int hak2 = 3;
                                while (hak2 > 0)
                                {
                                    try
                                    {
                                        Console.WriteLine("TC kimlik numaranızı giriniz. ");
                                        string tcKimlik1 = Console.ReadLine();
                                        Console.WriteLine("Telefon numarasınız giriniz");
                                        string telefonNumarası1 = Console.ReadLine();
                                        if (tcKimlik1.Length == 11 && telefonNumarası1.Length == 10)
                                        {
                                            Console.WriteLine("TC kimlik ve telefon numarası doğrulandı.");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("TC kimlik numarası 11 haneli ve telefon numarası 10 haneli olmalıdır.");
                                            hak2--;
                                            Console.WriteLine("Kalan deneme hakkı: " + hak2);
                                            if (hak2 == 0)
                                            {
                                                int lupi2 = 0;
                                                while (lupi2 < 100)
                                                {
                                                    Console.WriteLine("Hesabınız kitlendi iletişime geçin birileriyle.");
                                                    Thread.Sleep(1000);  // delayın yerine 1 saniye bekliyor. thread.sleep(1000); 1000 demek 1 saniye demek.
                                                    lupi2++;
                                                }
                                                return;
                                            }
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
                                    }
                                }
                            }
                            break;
                        }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
                goto yukarı;
            }
        }
    }
}


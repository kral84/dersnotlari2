//<<<<<<< HEAD
//﻿using System.ComponentModel.Design;
//using System.Diagnostics;
//using System.Diagnostics.Metrics;
//using System.Linq.Expressions;
//using System.Reflection.Metadata;

//namespace ConsoleApp1
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {

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

//        yukarı:
//            try
//            {
//                Console.WriteLine("Merhaba bankamatiğimize hoş geldiniz.");
//                Console.WriteLine("Kartlı işlem için 1, Kartsız işlem için 2 tuşuna basınız, Çıkış için 9 tuşuna basınız. ");
//                int secim = Convert.ToInt32(Console.ReadLine());
//                if (secim == 9)
//                {
//                    Console.WriteLine("Çıkış yapılıyor. Güle güle");
//                    return;
//                }
//                if (secim != 1 && secim != 2)
//                {
//                    Console.WriteLine("Lütfen geçerli bir işlem seçiniz.");
//                    goto yukarı;
//                }

//                switch (secim)
//                {
//                    case 1:
//                        try
//                        {
//                            Console.WriteLine("Kartlı işlem seçildi.");
//                            int hak = 3;
//                            while (hak > 0)
//                            {
//                                Console.WriteLine("Lütfen şifrenizi giriniz: ");
//                                string? sifre = Console.ReadLine();        // null 'lu bişi ama tam anlamadım. deneme amaclı koydum uyarı gitti.

//                                if (sifre == "ab18")
//                                {
//                                    Console.WriteLine("Şifreniz doğru. Ana menüye yönlendiriliyorsunuz.");

//                                    int para = 2500;
//                                    int menü = 0;

//                                    while (menü != 9)
//                                    {
//                                    anamenü:
//                                        Console.WriteLine("********* Ana Menü ************");
//                                        Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz:");
//                                        Console.WriteLine("1. Para Çekme");
//                                        Console.WriteLine("2. Para Yatırma");
//                                        Console.WriteLine("3. Para Transferleri");
//                                        Console.WriteLine("4. Eğitim Ödemeleri");
//                                        Console.WriteLine("5. Ödemeler");
//                                        Console.WriteLine("6. Bilgi Güncelleme");
//                                        Console.WriteLine("7. Gİriş ekranına giden yol");
//                                        Console.WriteLine("9. Atmden Çıkış");

//                                        int islem = 0;
//                                        try
//                                        {
//                                            islem = Convert.ToInt32(Console.ReadLine());
//                                        }
//                                        catch (FormatException)
//                                        {
//                                            Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                        }

//                                        if (islem == 1)
//                                        {
//                                            try
//                                            {
//                                                int tutar = 0;
//                                                while (true)
//                                                {
//                                                    try
//                                                    {
//                                                        Console.Write("Çekmek istediğiniz tutarı girin: \nAna menüye dönmek için 9\nKart iade için 8\n");
//                                                        tutar = Convert.ToInt32(Console.ReadLine());

//                                                        if (tutar == 0)
//                                                        {
//                                                            Console.WriteLine("0 olmaz geçerli bir değer girin.");
//                                                        }
//                                                        else if (tutar > para)
//                                                        {
//                                                            Console.WriteLine("Bu kadar paranız yok. Kalan bakiye: " + para);
//                                                        }
//                                                        else if (tutar < 0)
//                                                        {
//                                                            Console.WriteLine("Pozitif bir tutar giriniz.");
//                                                        }
//                                                        else if (tutar == 8)
//                                                        {
//                                                            Console.WriteLine("Kart iade ediliyor...");
//                                                            return;
//                                                        }
//                                                        else if (tutar == 9)
//                                                        {
//                                                            Console.WriteLine("Ana menüye dönülüyor...");
//                                                            break;
//                                                        }
//                                                        else
//                                                        {
//                                                            para -= tutar;
//                                                            Console.WriteLine("Para çekildi. Kalan bakiye: " + para);
//                                                            break;
//                                                        }
//                                                    }
//                                                    catch (FormatException)
//                                                    {
//                                                        Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                                    }
//                                                }
//                                            }
//                                            catch (FormatException)
//                                            {
//                                                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                            }
//                                        }
//                                        else if (islem == 2)
//                                        {
//                                            try
//                                            {
//                                                int yatir = 0;
//                                                while (true)
//                                                {
//                                                    try
//                                                    {
//                                                        Console.Write("Yatırmak istediğiniz tutarı girin: \nAna menü için 9\nKart iade için 8\n");
//                                                        yatir = Convert.ToInt32(Console.ReadLine());

//                                                        if (yatir == 0)
//                                                        {
//                                                            Console.WriteLine("0 olmaz geçerli bir değer girin.");
//                                                        }
//                                                        else if (yatir < 0)
//                                                        {
//                                                            Console.WriteLine("Pozitif bir tutar giriniz.");
//                                                        }
//                                                        else if (yatir == 8)
//                                                        {
//                                                            Console.WriteLine("Kart iade ediliyor...");
//                                                            return;
//                                                        }
//                                                        else if (yatir == 9)
//                                                        {
//                                                            Console.WriteLine("Ana menüye dönülüyor...");
//                                                            break;
//                                                        }
//                                                        else
//                                                        {
//                                                            para += yatir;
//                                                            Console.WriteLine("Para yatırıldı. Yeni bakiye: " + para);
//                                                            break;
//                                                        }
//                                                    }
//                                                    catch (FormatException)
//                                                    {
//                                                        Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                                    }
//                                                }
//                                            }
//                                            catch (FormatException)
//                                            {
//                                                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                            }
//                                        }
//                                        else if (islem == 3)
//                                        {
//                                            try
//                                            {
//                                                int transfer = 0;
//                                                while (true)
//                                                {
//                                                    try
//                                                    {
//                                                        Console.Write("EFT için 1, Havale için 2, Ana menü için 9, Kart iade için 8: ");
//                                                        transfer = Convert.ToInt32(Console.ReadLine());

//                                                        if (transfer == 8)
//                                                        {
//                                                            Console.WriteLine("Kart iade ediliyor...");
//                                                            return;
//                                                        }
//                                                        else if (transfer == 9)
//                                                        {
//                                                            Console.WriteLine("Ana menüye dönülüyor...");
//                                                            goto anamenü;
//                                                        }

//                                                        if (transfer == 1)
//                                                        {
//                                                            Console.Write("Başında TR olan 12 haneli hesap numarası girin: ");
//                                                            string hesapNumarasi = Console.ReadLine();

//                                                            while (hesapNumarasi.Length != 12 || !hesapNumarasi.StartsWith("TR"))   /// önemli ve güzel bir nokta
//                                                            {
//                                                                if (hesapNumarasi == "9")
//                                                                {
//                                                                    Console.WriteLine("İşlem iptal edildi. Ana menüye dönülüyor...");
//                                                                    goto anamenü;
//                                                                }
//                                                                else if (hesapNumarasi == "8")
//                                                                {
//                                                                    Console.WriteLine("Bir önceki menüye dönülüyor...");
//                                                                    break;
//                                                                }
//                                                                else
//                                                                {
//                                                                    Console.WriteLine("Hesap numarası geçersiz. Tekrar deneyin.");
//                                                                    hesapNumarasi = Console.ReadLine().ToUpper();
//                                                                }
//                                                            }

//                                                            Console.Write("EFT tutarını giriniz: ");
//                                                            int eft = Convert.ToInt32(Console.ReadLine());
//                                                            para -= eft;
//                                                            Console.WriteLine("EFT başarılı. Kalan bakiye: " + para);
//                                                            break;
//                                                        }
//                                                        else if (transfer == 2)
//                                                        {
//                                                            while (true)
//                                                            {
//                                                                try
//                                                                {
//                                                                    Console.WriteLine("11 haneli hesap numarası girin: \nNot hesap no: 0 ile başlıyamaz.");
//                                                                    string giris = Console.ReadLine();
//                                                                    long havale = Convert.ToInt64(giris); // int'in kapasitesi yetmedi 11 tane sa için

//                                                                    if (havale == 9)
//                                                                    {
//                                                                        Console.WriteLine("İşlem iptal edildi. Ana menüye dönülüyor...");
//                                                                        goto anamenü;
//                                                                    }
//                                                                    else if (havale == 8)
//                                                                    {
//                                                                        Console.WriteLine("Bir önceki menüye dönülüyor...");
//                                                                        break;
//                                                                    }
//                                                                    else if (havale.ToString().Length != 11)
//                                                                    {
//                                                                        Console.WriteLine("Hesap numarası 11 haneli olmalı.");
//                                                                    }
//                                                                    else
//                                                                    {
//                                                                        Console.WriteLine("Hesap bilgileri doğru.");
//                                                                        break;
//                                                                    }
//                                                                }
//                                                                catch
//                                                                {
//                                                                    Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                                                }
//                                                            }
//                                                            while (true)
//                                                            {
//                                                                try
//                                                                {
//                                                                    Console.WriteLine("havale yapacağınız tutarı girin. ");
//                                                                    int havaleTutar = Convert.ToInt32(Console.ReadLine());

//                                                                    if (havaleTutar == 0)
//                                                                    {
//                                                                        Console.WriteLine("0 olmaz geçerli bir değer girin.");
//                                                                    }
//                                                                    else if (havaleTutar < 0)
//                                                                    {
//                                                                        Console.WriteLine("Negatif deger olamaz.");
//                                                                    }
//                                                                    else if (havaleTutar > para)
//                                                                    {
//                                                                        Console.WriteLine("Bu kadar paranız yok. Kalan bakiye: " + para);
//                                                                    }
//                                                                    else
//                                                                    {
//                                                                        para -= havaleTutar;
//                                                                        Console.WriteLine("Havale başarılı. Kalan bakiye: " + para);
//                                                                        break;
//                                                                    }
//                                                                }
//                                                                catch (FormatException)
//                                                                {
//                                                                    Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                                                }
//                                                            }
//                                                            break;
//                                                        }
//                                                    }
//                                                    catch (FormatException)
//                                                    {
//                                                        Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                                    }
//                                                }
//                                            }
//                                            catch (FormatException)
//                                            {
//                                                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                            }
//                                        }
//                                        else if (islem == 4)
//                                        {
//                                            int egitim = 0;
//                                            while (true)
//                                            {
//                                                try
//                                                {
//                                                    Console.WriteLine("Bu sayfa suanda arızalı \nÇıkış için 8 tusuna basınız.\nAnaMenüye dönmek için 9 tuşuna basınız");
//                                                    egitim = Convert.ToInt32(Console.ReadLine());

//                                                    if (egitim == 8)
//                                                    {
//                                                        Console.WriteLine("çıkış yapılıyor");
//                                                        return;
//                                                    }
//                                                    else if (egitim == 9)
//                                                    {
//                                                        Console.WriteLine("Ana menüye dönülüyor...");
//                                                        goto anamenü;
//                                                    }
//                                                    else
//                                                    {
//                                                        Console.WriteLine("Geçersiz işlem. Lütfen tekrar deneyin.");
//                                                    }
//                                                }
//                                                catch (FormatException)
//                                                {
//                                                    Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                                }
//                                            }
//                                        }
//                                        else if (islem == 7)
//                                        {
//                                            Console.WriteLine("Giriş ekranına gidiyorsunuz...");
//                                            goto yukarı;
//                                        }
//                                        else if (islem == 9)
//                                        {
//                                            Console.WriteLine("ATM'den çıkılıyor. Güle güle!");
//                                            return;
//                                        }
//                                        else if (islem == 5)
//                                        {
//                                            while (true)
//                                            {
//                                                try
//                                                {
//                                                    int fatura = 0;
//                                                    Console.WriteLine("\nElektrik faturası için 1 : \nTelefon Faturası icin 2 : \nİnternet Faturası için 3 : \nSu ödemesi 4 : \nOGS Ödemesi 5 : \nÖnceki menü : 6 \nAnaMenü 7 : \nÇıkış 8 ");
//                                                    fatura = Convert.ToInt32(Console.ReadLine());
//                                                    if (fatura == 1)
//                                                    {
//                                                        while (true)
//                                                        {
//                                                            try
//                                                            {
//                                                                Console.WriteLine("Elektrik fatura tutarını giriniz. \nmevcut paranız:  " + para + "TL " + "\nAnaMenü için 9 tusuna basın. \n Çıkış için 8 tuşuna basın.");
//                                                                int elektrik = Convert.ToInt32(Console.ReadLine());
//                                                                if (elektrik == 0)
//                                                                {
//                                                                    Console.WriteLine("Fatura tutarı 9 olamaz");
//                                                                }
//                                                                else if (elektrik < 0)
//                                                                {
//                                                                    Console.WriteLine("Negatif değer olamaz.");
//                                                                }
//                                                                else if (elektrik > para)
//                                                                {
//                                                                    Console.WriteLine("Bu kadar paranız yok. Kalan bakiye: " + para);
//                                                                }
//                                                                else if (elektrik == 8)
//                                                                {
//                                                                    Console.WriteLine("Kart iade ediliyor...");
//                                                                    return;
//                                                                }
//                                                                else if (elektrik == 9)
//                                                                {
//                                                                    Console.WriteLine("Ana menüye dönülüyor...");
//                                                                    goto anamenü;
//                                                                }
//                                                                else
//                                                                {
//                                                                    para -= elektrik;
//                                                                    Console.WriteLine("Fatura ödendi. Kalan bakiye: " + para);
//                                                                    break;
//                                                                }
//                                                            }
//                                                            catch (FormatException)
//                                                            {
//                                                                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                                            }
//                                                        }
//                                                    }
//                                                    else if (fatura == 2)
//                                                    {
//                                                        while (true)
//                                                        {
//                                                            try
//                                                            {
//                                                                Console.WriteLine("Telefon faturası tutarını giriniz. \nmevcut paranız:  " + para + "TL " + "\nAnaMenü için 9 tusuna basın. \n Çıkış için 8 tuşuna basın.");
//                                                                int telefon = Convert.ToInt32(Console.ReadLine());
//                                                                if (telefon == 0)
//                                                                {
//                                                                    Console.WriteLine("Fatura tutarı 9 olamaz");
//                                                                }
//                                                                else if (telefon < 0)
//                                                                {
//                                                                    Console.WriteLine("Negatif değer olamaz.");
//                                                                }
//                                                                else if (telefon > para)
//                                                                {
//                                                                    Console.WriteLine("Bu kadar paranız yok. Kalan bakiye: " + para);
//                                                                }
//                                                                else if (telefon == 8)
//                                                                {
//                                                                    Console.WriteLine("Kart iade ediliyor...");
//                                                                    return;
//                                                                }
//                                                                else if (telefon == 9)
//                                                                {
//                                                                    Console.WriteLine("Ana menüye dönülüyor...");
//                                                                    goto anamenü;
//                                                                }
//                                                                else
//                                                                {
//                                                                    para -= telefon;
//                                                                    Console.WriteLine("Fatura ödendi. Kalan bakiye: " + para);
//                                                                    break;
//                                                                }
//                                                            }
//                                                            catch (FormatException)
//                                                            {
//                                                                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                                            }
//                                                        }
//                                                    }
//                                                    else if (fatura == 3)
//                                                    {
//                                                        while (true)
//                                                        {
//                                                            try
//                                                            {
//                                                                Console.WriteLine("İnternet tutarını giriniz. \nmevcut paranız:  " + para + "TL " + "\nAnaMenü için 9 tusuna basın. \n Çıkış için 8 tuşuna basın.");
//                                                                int internet = Convert.ToInt32(Console.ReadLine());
//                                                                if (internet == 0)
//                                                                {
//                                                                    Console.WriteLine("Fatura tutarı 9 olamaz");
//                                                                }
//                                                                else if (internet < 0)
//                                                                {
//                                                                    Console.WriteLine("Negatif değer olamaz.");
//                                                                }
//                                                                else if (internet > para)
//                                                                {
//                                                                    Console.WriteLine("Bu kadar paranız yok. Kalan bakiye: " + para);
//                                                                }
//                                                                else if (internet == 8)
//                                                                {
//                                                                    Console.WriteLine("Kart iade ediliyor...");
//                                                                    return;
//                                                                }
//                                                                else if (internet == 9)
//                                                                {
//                                                                    Console.WriteLine("Ana menüye dönülüyor...");
//                                                                    goto anamenü;
//                                                                }
//                                                                else
//                                                                {
//                                                                    para -= internet;
//                                                                    Console.WriteLine("Fatura ödendi. Kalan bakiye: " + para);
//                                                                    break;
//                                                                }
//                                                            }
//                                                            catch (FormatException)
//                                                            {
//                                                                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                                            }
//                                                        }
//                                                    }
//                                                    else if (fatura == 4)
//                                                    {
//                                                        while (true)
//                                                        {
//                                                            try
//                                                            {
//                                                                Console.WriteLine("Su tutarını giriniz. \nmevcut paranız:  " + para + "TL " + "\nAnaMenü için 9 tusuna basın. \n Çıkış için 8 tuşuna basın.");
//                                                                int su = Convert.ToInt32(Console.ReadLine());
//                                                                if (su == 0)
//                                                                {
//                                                                    Console.WriteLine("Fatura tutarı 9 olamaz");
//                                                                }
//                                                                else if (su < 0)
//                                                                {
//                                                                    Console.WriteLine("Negatif değer olamaz.");
//                                                                }
//                                                                else if (su > para)
//                                                                {
//                                                                    Console.WriteLine("Bu kadar paranız yok. Kalan bakiye: " + para);
//                                                                }
//                                                                else if (su == 8)
//                                                                {
//                                                                    Console.WriteLine("Kart iade ediliyor...");
//                                                                    return;
//                                                                }
//                                                                else if (su == 9)
//                                                                {
//                                                                    Console.WriteLine("Ana menüye dönülüyor...");
//                                                                    goto anamenü;
//                                                                }
//                                                                else
//                                                                {
//                                                                    para -= su;
//                                                                    Console.WriteLine("Fatura ödendi. Kalan bakiye: " + para);
//                                                                    break;
//                                                                }
//                                                            }
//                                                            catch (FormatException)
//                                                            {
//                                                                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                                            }
//                                                        }
//                                                    }
//                                                    else if (fatura == 5)
//                                                    {
//                                                        while (true)
//                                                        {
//                                                            try
//                                                            {
//                                                                Console.WriteLine("OGS tutarını giriniz. \nmevcut paranız:  " + para + "TL " + "\nAnaMenü için 9 tusuna basın. \n Çıkış için 8 tuşuna basın.");
//                                                                int ogs = Convert.ToInt32(Console.ReadLine());
//                                                                if (ogs == 0)
//                                                                {
//                                                                    Console.WriteLine("Fatura tutarı 9 olamaz");
//                                                                }
//                                                                else if (ogs < 0)
//                                                                {
//                                                                    Console.WriteLine("Negatif değer olamaz.");
//                                                                }
//                                                                else if (ogs > para)
//                                                                {
//                                                                    Console.WriteLine("Bu kadar paranız yok. Kalan bakiye: " + para);
//                                                                }
//                                                                else if (ogs == 8)
//                                                                {
//                                                                    Console.WriteLine("Kart iade ediliyor...");
//                                                                    return;
//                                                                }
//                                                                else if (ogs == 9)
//                                                                {
//                                                                    Console.WriteLine("Ana menüye dönülüyor...");
//                                                                    goto anamenü;
//                                                                }
//                                                                else
//                                                                {
//                                                                    para -= ogs;
//                                                                    Console.WriteLine("Fatura ödendi. Kalan bakiye: " + para);
//                                                                    break;
//                                                                }
//                                                            }
//                                                            catch (FormatException)
//                                                            {
//                                                                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                                            }
//                                                        }
//                                                    }
//                                                    else if (fatura == 6)
//                                                    {
//                                                        Console.WriteLine("Bir önceki menüye dönülüyor...");
//                                                        break;
//                                                    }
//                                                    else if (fatura == 7)
//                                                    {
//                                                        Console.WriteLine("Ana menüye dönülüyor...");
//                                                        goto anamenü;
//                                                    }
//                                                    else if (fatura == 8)
//                                                    {
//                                                        Console.WriteLine("Çıkış yapılıyor...");
//                                                        return;
//                                                    }
//                                                    else
//                                                    {
//                                                        Console.WriteLine("Geçersiz işlem. Lütfen tekrar deneyin.");
//                                                    }
//                                                }
//                                                catch (FormatException)
//                                                {
//                                                    Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                                }
//                                            }
//                                        }
//                                    }
//                                }
//                                else
//                                {
//                                    hak--;
//                                    Console.WriteLine("Yanlış şifre. Kalan deneme hakkı: " + hak);
//                                    if (hak == 0)
//                                    {
//                                        Console.WriteLine("Kartınız bloke edilmiştir.");
//                                        int lupi = 0;
//                                        while (lupi < 100)
//                                        {
//                                            Console.WriteLine("Kartınız bloke edilmiştir. Lütfen bankanızla iletişime geçin.");
//                                            Thread.Sleep(1000);  // delayın yerine 1 saniye bekliyor. thread.sleep(1000); 1000 demek 1 saniye demek.
//                                            lupi++;
//                                        }

//                                        return;
//                                    }

//                                }
//                            }
//                        }
//                        catch (FormatException)
//                        {
//                            Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                        }
//                        break;
//                    case 2:
//                    anamenü2:
//                        {
//                            while (true)
//                            {
//                                try
//                                {
//                                    Console.WriteLine("****** Kartsız İşlem Menüsü *******");
//                                    Console.WriteLine("Cepbank para çekmek için 1 tuşuna basınız");
//                                    Console.WriteLine("Para yatırmak için 2 tuşuna basınız");
//                                    Console.WriteLine("Kredi Kartı ödeme 3 tuşuna basınız");   // yapmadım sanırım unuttum ne yapıp yapmadığımı
//                                    Console.WriteLine("Egitim ödemeleri için 4 tuşuna basınız.");
//                                    Console.WriteLine("Ödemeler için 5 tuşuna basınız.");
//                                    int kartsızsecim = Convert.ToInt32(Console.ReadLine());

//                                    if (kartsızsecim == 1)
//                                    {
//                                        int hak2 = 3;
//                                        while (hak2 > 0)
//                                        {
//                                            try
//                                            {
//                                                int para = 2500;
//                                                Console.WriteLine("TC kimlik numaranızı giriniz. ");
//                                                string tcKimlik1 = Console.ReadLine();
//                                                Console.WriteLine("Telefon numarasınız giriniz");
//                                                string telefonNumarası1 = Console.ReadLine();
//                                                if (tcKimlik1.Length == 11 && telefonNumarası1.Length == 10) // &&  and işareti olarak kayıtlara geçsin
//                                                {
//                                                    Console.WriteLine("TC kimlik ve telefon numarası doğrulandı.");
//                                                    int Para = para + 1000;
//                                                    Console.WriteLine("Mevcut paranız: " + para + " 1000 TL ödeme aldınız: " + Para);
//                                                    break;
//                                                }
//                                                else
//                                                {
//                                                    Console.WriteLine("TC kimlik numarası 11 haneli ve telefon numarası 10 haneli olmalıdır.");
//                                                    hak2--;
//                                                    Console.WriteLine("Kalan deneme hakkı: " + hak2);
//                                                    if (hak2 == 0)
//                                                    {
//                                                        int lupi2 = 0;
//                                                        while (lupi2 < 100)
//                                                        {
//                                                            Console.WriteLine("Hesabınız kitlendi iletişime geçin birileriyle.");
//                                                            Thread.Sleep(1000);  // delayın yerine 1 saniye bekliyor. thread.sleep(1000); 1000 demek 1 saniye demek.
//                                                            lupi2++;
//                                                        }
//                                                        return;
//                                                    }
//                                                }
//                                            }
//                                            catch (FormatException)
//                                            {
//                                                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                            }
//                                        }
//                                    }
//                                    else if (kartsızsecim == 2)
//                                    {

//                                        while (true)
//                                        {
//                                            try
//                                            {


//                                                Console.WriteLine("1  Para Yatırma");
//                                                Console.WriteLine("2  Para Çekme");
//                                                Console.WriteLine("3  Para Çekme");
//                                                Console.WriteLine("9  Ana menüye dön");
//                                                Console.WriteLine("8  atmden çıkış");
//                                                Console.WriteLine("7  EN BAŞA GİDİYOZ");
//                                                int işlem = Convert.ToInt32(Console.ReadLine());
//                                                int para = 2000;
//                                                if (işlem == 1)    // 8 ve 9 u koycam unutma 
//                                                {
//                                                    Console.WriteLine("Hesap numaranızı giriniz");
//                                                    string hesapNumarası = Console.ReadLine();
//                                                    if (hesapNumarası.Length == 10)
//                                                    {
//                                                        while (true)
//                                                        {
//                                                            try
//                                                            {
//                                                                Console.WriteLine("Yatırmak istediğiniz tutarı giriniz. \nmevcut paranız:  " + para + "TL " + "\nAnaMenü için 9 tusuna basın. \n Çıkış için 8 tuşuna basın. \n Bir önceki menü için 7.");
//                                                                int yatir = Convert.ToInt32(Console.ReadLine());
//                                                                if (yatir == 0)
//                                                                {
//                                                                    Console.WriteLine("Para tutarı 0 olamaz");
//                                                                }
//                                                                else if (yatir < 0)
//                                                                {
//                                                                    Console.WriteLine("Negatif değer olamaz.");
//                                                                }
//                                                                else if (yatir == 8)
//                                                                {
//                                                                    Console.WriteLine("Ane Menüye Dönülüyor");
//                                                                    goto anamenü2;
//                                                                }
//                                                                else if (yatir == 9)
//                                                                {
//                                                                    Console.WriteLine("Atmden çıkış yapılıyıor");
//                                                                    return;
//                                                                }
//                                                                else if (yatir == 7)
//                                                                {
//                                                                    Console.WriteLine("Bir önceki menüye dönülüyor");
//                                                                    break;
//                                                                }

//                                                                else
//                                                                {
//                                                                    para += yatir;
//                                                                    Console.WriteLine("Para yatırma işlemi başarılı. Yeni bakiye: " + para);
//                                                                    break;
//                                                                }
//                                                            }
//                                                            catch (FormatException)
//                                                            {
//                                                                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                                            }
//                                                        }
//                                                    }
//                                                    else
//                                                    {
//                                                        Console.WriteLine("Hesap numarası 10 haneli olmalıdır.");
//                                                    }
//                                                }
//                                                else if (işlem == 8)
//                                                {
//                                                    Console.WriteLine("atmden çıkılıyor....");
//                                                    return;
//                                                }
//                                                else if (işlem == 7)
//                                                {
//                                                    Console.WriteLine("taa en basa gidiyoz....");
//                                                    goto yukarı; // BURDAKİ GARİPLİK CASE 2 DEKİ GOTO NASIL OLUYORSA CASE 1 İN İÇİNDEKİ ETİKETE GİDEMİYOR . GARİP anamenü
//                                                }
//                                                else if (işlem == 9)

//                                                {
//                                                    Console.WriteLine("Önceki menüye dönülüyor...");
//                                                    break;
//                                                }
//                                                else if (işlem == 2)
//                                                {
//                                                    Console.WriteLine("Hesap numaranızı giriniz");
//                                                    string hesapNumarası = Console.ReadLine();
//                                                    if (hesapNumarası.Length == 10)
//                                                    {
//                                                        while (true)
//                                                        {
//                                                            try
//                                                            {
//                                                                Console.WriteLine("Çekmek istediğiniz tutarı giriniz. \nmevcut paranız:  " + para + "TL " + "\nAnaMenü için 9 tusuna basın. \n Çıkış için 8 tuşuna bas");
//                                                                int cek = Convert.ToInt32(Console.ReadLine());
//                                                                if (cek == 0)
//                                                                {
//                                                                    Console.WriteLine("Para tutarı 0 olamaz");
//                                                                }
//                                                                else if (cek < 0)
//                                                                {
//                                                                    Console.WriteLine("Negatif değer olamaz.");
//                                                                }
//                                                                else if (cek > para)
//                                                                {
//                                                                    Console.WriteLine("Bu kadar paranız yok. Kalan bakiye: " + para);
//                                                                }
//                                                                else if (cek == 8)
//                                                                {
//                                                                    Console.WriteLine("Kart iade ediliyor...");
//                                                                    return;
//                                                                }
//                                                                else if (cek == 9)
//                                                                {
//                                                                    Console.WriteLine("Ana menüye dönülüyor...");
//                                                                    goto yukarı;
//                                                                }
//                                                                else
//                                                                {
//                                                                    para -= cek;
//                                                                    Console.WriteLine("Para çekme işlemi başarılı. Yeni bakiye: " + para);
//                                                                    break;
//                                                                }
//                                                            }
//                                                            catch (FormatException)
//                                                            {
//                                                                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                                            }
//                                                        }

//                                                    }
//                                                    else
//                                                    {
//                                                        Console.WriteLine("❌ Geçersiz hesap numarası! 10 haneli bir numara giriniz.");
//                                                    }
//                                                }

//                                            }
//                                            catch (FormatException)
//                                            {
//                                                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                            }
//                                        }
//                                    }
//                                    else if (kartsızsecim == 3)       // burdayızzzzzzzzzzzzzz
//                                    {
//                                        while (true)
//                                        {
//                                            try
//                                            {
//                                                Console.WriteLine("Kimlik numarası ile para gönderme secenegi için 1 tuşuna basın");
//                                                Console.WriteLine("kredi kartı numarası ile para gönderme secenegi için 2 tuşuna basın");
//                                                Console.WriteLine("Eft numarası ile para gönderme secenegi için 3 tuşuna basın");
//                                                Console.WriteLine("cıkıs için 9 tuşuna basın");
//                                                Console.WriteLine("Geri dönmek için 8 tuşuna basın");
//                                                int krediSecim = Convert.ToInt32(Console.ReadLine());
//                                                int kpara = 2000;
//                                                if (krediSecim == 1) 
//                                                {
//                                                    while (true)
//                                                    {
//                                                        try
//                                                        {
//                                                            Console.WriteLine("Kimlik numaranızı girin 11 hane olmak zorunda.");
//                                                            string kimlikNumarası = Console.ReadLine();
//                                                            if (kimlikNumarası.Length == 11)
//                                                            {
//                                                                try
//                                                                {
//                                                                    Console.WriteLine("Kimlik numarası doğrulandı.");
//                                                                    Console.WriteLine("Göndermek istediğiniz tutarı girin");
//                                                                    int ktutar = Convert.ToInt32(Console.ReadLine());
//                                                                    if (ktutar == 0)
//                                                                    {
//                                                                        Console.WriteLine("Para tutarı 0 olamaz");
//                                                                    }
//                                                                    else if (ktutar < 0)
//                                                                    {
//                                                                        Console.WriteLine("Negatif değer olamaz.");
//                                                                    }
//                                                                    else if (kpara < ktutar)
//                                                                    {
//                                                                        Console.WriteLine("Bu kadar paranız yok. Kalan bakiye: " + kpara);
//                                                                    }
//                                                                    else if (kpara == 8)
//                                                                    {
//                                                                        Console.WriteLine("Kart iade ediliyor...");
//                                                                        return;
//                                                                    }
//                                                                    else if (kpara == 9)
//                                                                    {
//                                                                        Console.WriteLine("Ana menüye dönülüyor...");
//                                                                        goto anamenü2;
//                                                                    }
//                                                                    else
//                                                                    {
//                                                                        kpara -= ktutar;
//                                                                        Console.WriteLine("Para gönderme işlemi başarılı. Kalan bakiye: " + kpara);
//                                                                        break;
//                                                                    }
//                                                                }
//                                                                catch (FormatException)
//                                                                {
//                                                                    Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                                                }
//                                                            }
//                                                            else
//                                                            {
//                                                                Console.WriteLine("Kimlik numarası 11 haneli olmalıdır.");
//                                                            }
//                                                        }
//                                                        catch
//                                                        {

//                                                        }
//                                                    }
//                                                }
//                                                else if (krediSecim == 3)
//                                                {
//                                                    while (true)
//                                                    {
//                                                        Console.WriteLine("EFT numaranızı girin 10 hane olmak zorunda.");
//                                                        string eftNumarası = Console.ReadLine().ToLower();
//                                                        if (eftNumarası.Length == 10 && eftNumarası.StartsWith("tr"))
//                                                        {
//                                                            Console.WriteLine("EFT numarası doğrulandı.");
//                                                            Console.WriteLine("Göndermek istediğiniz tutarı girin");
//                                                            int ktutar = Convert.ToInt32(Console.ReadLine());
//                                                            if (ktutar == 0)
//                                                            {
//                                                                Console.WriteLine("Para tutarı 0 olamaz");
//                                                            }
//                                                            else if (ktutar < 0)
//                                                            {
//                                                                Console.WriteLine("Negatif değer olamaz.");
//                                                            }
//                                                            else if (kpara < ktutar)
//                                                            {
//                                                                Console.WriteLine("Bu kadar paranız yok. Kalan bakiye: " + kpara);
//                                                            }
//                                                            else if (kpara == 8)
//                                                            {
//                                                                Console.WriteLine("Kart iade ediliyor...");
//                                                                return;
//                                                            }
//                                                            else if (kpara == 9)
//                                                            {
//                                                                Console.WriteLine("Ana menüye dönülüyor...");
//                                                                goto anamenü2;
//                                                            }
//                                                            else
//                                                            {
//                                                                kpara -= ktutar;
//                                                                Console.WriteLine("Para gönderme işlemi başarılı. Kalan bakiye: " + kpara);
//                                                                break;
//                                                            }
//                                                        }
//                                                        else
//                                                        {
//                                                            Console.WriteLine("EFT numarası 10 haneli olmalıdır. ve tr ile baslamalıdır");
//                                                        }
//                                                            ;
//                                                    }
//                                                }
//                                                else if (krediSecim == 9)
//                                                {
//                                                    Console.WriteLine("Ana menüye dönülüyor...");
//                                                    goto anamenü2;
//                                                }
//                                                else if (krediSecim == 8)
//                                                {
//                                                    Console.WriteLine("Bir önceki menüye dönülüyor...");
//                                                    break;
//                                                }
//                                                else if (krediSecim == 2)
//                                                {
//                                                    while (true)
//                                                    {
//                                                        Console.WriteLine("Kredi kartı numaranızı girin 16 hane olmak zorunda.");
//                                                        string krediKartıNumarası = Console.ReadLine();
//                                                        if (krediKartıNumarası.Length == 16)
//                                                        {
//                                                            Console.WriteLine("Kredi kartı numarası doğrulandı.");
//                                                            Console.WriteLine("Göndermek istediğiniz tutarı girin");
//                                                            int ktutar = Convert.ToInt32(Console.ReadLine());
//                                                            if (ktutar == 0)
//                                                            {
//                                                                Console.WriteLine("Para tutarı 0 olamaz");
//                                                            }
//                                                            else if (ktutar < 0)
//                                                            {
//                                                                Console.WriteLine("Negatif değer olamaz.");
//                                                            }
//                                                            else if (kpara < ktutar)
//                                                            {
//                                                                Console.WriteLine("Bu kadar paranız yok. Kalan bakiye: " + kpara);
//                                                            }
//                                                            else if (kpara == 8)
//                                                            {
//                                                                Console.WriteLine("Kart iade ediliyor...");
//                                                                return;
//                                                            }
//                                                            else if (kpara == 9)
//                                                            {
//                                                                Console.WriteLine("Ana menüye dönülüyor...");
//                                                                goto anamenü2;
//                                                            }
//                                                            else
//                                                            {
//                                                                kpara -= ktutar;
//                                                                Console.WriteLine("Para gönderme işlemi başarılı. Kalan bakiye: " + kpara);
//                                                                break;
//                                                            }
//                                                        }
//                                                        else
//                                                        {
//                                                        Console.WriteLine("Kredi kartı numarası 16 haneli olmalıdır.");
//                                                        }
//                                                    }
//                                                    }
//                                                else
//                                                {
//                                                    Console.WriteLine("Bir hata oldu ne sen sor ne ben söyliyim.");
//                                                }
//                                                }

//                                            catch (FormatException)
//                                            {
//                                                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                            }
//                                        }
//                                    }
//                                    else if (kartsızsecim == 5)
//                                    {
//                                        while (true)
//                                        {
//                                            Console.WriteLine("Elektrik faturasını ödemek için 1 tuşuna basın.");
//                                            Console.WriteLine("Telefon faturasını ödemek için 2 tuşuna basın.");
//                                            Console.WriteLine("İnternet faturasını ödemek için 3 tuşuna basın.");
//                                            Console.WriteLine("Su faturasını ödemek için 4 tuşuna basın.");
//                                            Console.WriteLine("Ogs Ödemeleri için 5 tuşuna basın.");
//                                            int ödeme = Convert.ToInt32(Console.ReadLine());
//                                            int öpara = 2000;
//                                            if (ödeme == 1)
//                                            {
//                                                while (true)
//                                                {
//                                                    try
//                                                    {
//                                                        Console.WriteLine("Elektrik tutarını giriniz. \nmevcut paranız:  " + öpara + "TL " + "\nAnaMenü için 9 tusuna basın. \n Çıkış için 8 tuşuna basın.");
//                                                        int elektrik = Convert.ToInt32(Console.ReadLine());
//                                                        if (elektrik == 0)
//                                                        {
//                                                            Console.WriteLine("Fatura tutarı 9 olamaz");
//                                                        }
//                                                        else if (elektrik < 0)
//                                                        {
//                                                            Console.WriteLine("Negatif değer olamaz.");
//                                                        }
//                                                        else if (elektrik > öpara)
//                                                        {
//                                                            Console.WriteLine("Bu kadar paranız yok. Kalan bakiye: " + öpara);
//                                                        }
//                                                        else if (elektrik == 8)
//                                                        {
//                                                            Console.WriteLine("Kart iade ediliyor...");
//                                                            return;
//                                                        }
//                                                        else if (elektrik == 9)
//                                                        {
//                                                            Console.WriteLine("anamenüye dönüyoz...");
//                                                            goto anamenü2;
//                                                        }
//                                                        else
//                                                        {
//                                                            öpara -= elektrik;
//                                                            Console.WriteLine("Fatura ödendi. Kalan bakiye: " + öpara);
//                                                            break;
//                                                        }
//                                                    }
//                                                    catch (FormatException)
//                                                    {
//                                                        Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                                    }
//                                                }
//                                            }
//                                            else if (ödeme == 2)
//                                            {
//                                                while (true)
//                                                {
//                                                    try
//                                                    {
//                                                        Console.WriteLine("Telefon tutarını giriniz. \nmevcut paranız:  " + öpara + "TL " + "\nAnaMenü için 9 tusuna basın. \n Çıkış için 8 tuşuna basın.");
//                                                        int telefon = Convert.ToInt32(Console.ReadLine());
//                                                        if (telefon == 0)
//                                                        {
//                                                            Console.WriteLine("Fatura tutarı 9 olamaz");
//                                                        }
//                                                        else if (telefon < 0)
//                                                        {
//                                                            Console.WriteLine("Negatif değer olamaz.");
//                                                        }
//                                                        else if (telefon > öpara)
//                                                        {
//                                                            Console.WriteLine("Bu kadar paranız yok. Kalan bakiye: " + öpara);
//                                                        }
//                                                        else if (telefon == 8)
//                                                        {
//                                                            Console.WriteLine("Kart iade ediliyor...");
//                                                            return;
//                                                        }
//                                                        else if (telefon == 9)
//                                                        {
//                                                            Console.WriteLine("en basa gidiyon...");
//                                                            goto yukarı;
//                                                        }
//                                                        else
//                                                        {
//                                                            öpara -= telefon;
//                                                            Console.WriteLine("Fatura ödendi. Kalan bakiye: " + öpara);
//                                                            break;
//                                                        }
//                                                    }
//                                                    catch (FormatException)
//                                                    {
//                                                        Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                                    }
//                                                }
//                                            }
//                                            else if (ödeme == 3)
//                                            {
//                                                while (true)
//                                                {
//                                                    try
//                                                    {
//                                                        Console.WriteLine("İnternet tutarını giriniz. \nmevcut paranız:  " + öpara + "TL " + "\nAnaMenü için 9 tusuna basın. \n Çıkış için 8 tuşuna basın.");
//                                                        int internet = Convert.ToInt32(Console.ReadLine());
//                                                        if (internet == 0)
//                                                        {
//                                                            Console.WriteLine("Fatura tutarı 9 olamaz");
//                                                        }
//                                                        else if (internet < 0)
//                                                        {
//                                                            Console.WriteLine("Negatif değer olamaz.");
//                                                        }
//                                                        else if (internet > öpara)
//                                                        {
//                                                            Console.WriteLine("Bu kadar paranız yok. Kalan bakiye: " + öpara);
//                                                        }
//                                                        else if (internet == 8)
//                                                        {
//                                                            Console.WriteLine("Kart iade ediliyor...");
//                                                            return;
//                                                        }
//                                                        else if (internet == 9)
//                                                        {
//                                                            Console.WriteLine("anamenüye dönüyoz...");
//                                                            goto anamenü2;
//                                                        }
//                                                        else
//                                                        {
//                                                            öpara -= internet;
//                                                            Console.WriteLine("Fatura ödendi. Kalan bakiye: " + öpara);
//                                                            break;
//                                                        }
//                                                    }
//                                                    catch (FormatException)
//                                                    {
//                                                        Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                                    }
//                                                }
//                                            }
//                                            else if (ödeme == 4)
//                                            {
//                                                while (true)
//                                                {
//                                                    try
//                                                    {
//                                                        Console.WriteLine("Su fatura tutarını giriniz. \nmevcut paranız: " + öpara + "TL" + "\nAnamenü için 9 tuşuna basın. \n Çıkış için 8 tuşuna basın");
//                                                        int su = Convert.ToInt32(Console.ReadLine());
//                                                        if (su == 0)
//                                                        {
//                                                            Console.WriteLine("Fatura tutarı 0 olamaz");
//                                                        }
//                                                        else if (su < 0)
//                                                        {
//                                                            Console.WriteLine("Negatif değer olamaz.");
//                                                        }
//                                                        else if (su > öpara)
//                                                        {
//                                                            Console.WriteLine("Bu kadar paranız yok. Kalan bakiye: " + öpara);
//                                                        }
//                                                        else if (su == 8)
//                                                        {
//                                                            Console.WriteLine("Kart iade ediliyor...");
//                                                            return;
//                                                        }
//                                                        else if (su == 9)
//                                                        {
//                                                            Console.WriteLine("anamenüye dönüyoz...");
//                                                            goto anamenü2;
//                                                        }
//                                                        else
//                                                        {
//                                                            öpara -= su;
//                                                            Console.WriteLine("Fatura ödendi. Kalan bakiye: " + öpara);
//                                                            break;
//                                                        }
//                                                    }
//                                                    catch (FormatException)
//                                                    {
//                                                        Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                                    }
//                                                }
//                                            }
//                                            else if (ödeme == 5)
//                                            {
//                                                while (true)
//                                                {
//                                                    try
//                                                    {
//                                                        Console.WriteLine("Ogs tutarını giriniz. \nmevcut paranız:  " + öpara + "TL " + "\nAnaMenü için 9 tusuna basın. \n Çıkış için 8 tuşuna basın.");
//                                                        int ogs = Convert.ToInt32(Console.ReadLine());
//                                                        if (ogs == 0)
//                                                        {
//                                                            Console.WriteLine("Fatura tutarı 0 olamaz");
//                                                        }
//                                                        else if (ogs < 0)
//                                                        {
//                                                            Console.WriteLine("Negatif değer olamaz.");
//                                                        }
//                                                        else if (ogs > öpara)
//                                                        {
//                                                            Console.WriteLine("Bu kadar paranız yok. Kalan bakiye: " + öpara);
//                                                        }
//                                                        else if (ogs == 8)
//                                                        {
//                                                            Console.WriteLine("Kart iade ediliyor...");
//                                                            return;
//                                                        }
//                                                        else if (ogs == 9)
//                                                        {
//                                                            Console.WriteLine("anamenüye dönüyoz...");
//                                                            goto anamenü2;
//                                                        }
//                                                        else
//                                                        {
//                                                            öpara -= ogs;
//                                                            Console.WriteLine("Fatura ödendi. Kalan bakiye: " + öpara);
//                                                            break;
//                                                        }
//                                                    }
//                                                    catch (FormatException)
//                                                    {
//                                                        Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                                    }
//                                                }
//                                            }
//                                        }
//                                    }
//                                    else if (kartsızsecim == 4)
//                                    {
//                                        Console.WriteLine("Ödeme sayfamız şuanda arızalıdır. \nTuşa basarak çıkış yapabilir 8. \n tuşa basarak geri dönebilirsiniz 7 ");
//                                        {
//                                            while (true)
//                                            {
//                                                try
//                                                {
//                                                    int arıza = Convert.ToInt32(Console.ReadLine());
//                                                    if (arıza == 7)
//                                                    {
//                                                        Console.WriteLine("Bir önceki menüye dönülüyor...");
//                                                        break;
//                                                    }
//                                                    else
//                                                    {
//                                                        Console.WriteLine("Atmden çıkılıyor....");
//                                                        return;
//                                                    }
//                                                }
//                                                catch (FormatException)
//                                                {
//                                                    Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                                }
//                                            }
//                                        }

//                                    }
//                                    else if (kartsızsecim == 9)
//                                    {
//                                        Console.WriteLine("Ana menüye dönülüyor...");
//                                        goto anamenü2;
//                                    }


//                                    else if (kartsızsecim == 8)
//                                    {
//                                        Console.WriteLine("Atmden çıkılıyor....");
//                                        return;
//                                    }

//                                }


//                                catch (FormatException)
//                                {
//                                    Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                                }


//                            }
//                        }
//                        break;  // bu niye söndü fikrim yok.
//                }
//            }
//            catch (FormatException)
//            {
//                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
//                goto yukarı;
//            }






//            while (true)
//            {


//                Console.WriteLine("Kütüphaneye Hoş Geldiniz, yapmak istediğiniz işlemi seçin. ");
//                Console.WriteLine("1. Kitap Ödünç Al");
//                Console.WriteLine("2. Kitap İade Et");
//                Console.WriteLine("3. Mevcut Kitapları Görüntüle");
//                Console.WriteLine("4. Çıkış");
//                int secim1 = Convert.ToInt32(Console.ReadLine());
//                while (true)
//                {

//                    if (secim1 == 1)
//                    {
//                        while (true)
//                        {
//                            Console.WriteLine("ödünç almak istediği kitabın adını yaz. // \nMevcut: buffalo, yemek kitabı, ders notları, kırmızı kitap, tarih sahnesi, \nAnaMenü için 2 tuşuna basın. ");
//                            string kitapAdi = Console.ReadLine().ToLower();
//                            if (kitapAdi == "buffalo" || kitapAdi == "yemek kitabı" || kitapAdi == "ders notları" || kitapAdi == "kırmızı kitap" || kitapAdi == "tarih sahnesi")
//                            {
//                                Console.WriteLine("Kitap Ödünç Alındı: " + kitapAdi);
//                                break;
//                            }
//                            else if (kitapAdi == "2")
//                            {
//                                Console.WriteLine("Çıkış Yapılıyor...");
//                                break;
//                            }
//                            else
//                            {
//                                Console.WriteLine("Bu kitap mevcut değil.");
//                            }
//                        }
//                    }
//                    else if (secim1 == 2)
//                    {
//                        while (true)
//                        {
//                            Console.WriteLine("İade edeceğiniz kitabın ismini giriniz. \nAnaMenü için 2 tuşuna basın. ");
//                            string iadeKitap = Console.ReadLine().ToLower();
//                            if (iadeKitap == "buffalo" || iadeKitap == "yemek kitabı" || iadeKitap == "ders notları" || iadeKitap == "kırmızı kitap" || iadeKitap == "tarih sahnesi")
//                            {
//                                Console.WriteLine("Kitap İade Edildi: " + iadeKitap);
//                                break;
//                            }
//                            else if (iadeKitap == "2")
//                            {
//                                Console.WriteLine("Çıkış Yapılıyor...");
//                                break;
//                            }
//                            else
//                            {
//                                Console.WriteLine("Bu kitap mevcut değil veya zaten iade edilmiş.");
//                            }
//                        }

//                    }
//                    else if (secim1 == 3)
//                    {
//                        while (true)
//                        {
//                            Console.WriteLine("Mevcut Kitapları Görüntüle \nAnaMenü için 2 tuşuna basın. ");
//                                Console.WriteLine("1. Buffalo");
//                                Console.WriteLine("2. Yemek Kitabı");
//                                Console.WriteLine("3. Ders Notları");
//                                Console.WriteLine("4. Kırmızı Kitap");
//                                Console.WriteLine("5. Tarih Sahnesi");
//                            string mevcutKitaplar = Console.ReadLine().ToLower();
//                            if (mevcutKitaplar == "2")
//                            {
//                                Console.WriteLine("Çıkış Yapılıyor...");
//                                break;

//                            }
//                            else
//                            {
//                                Console.WriteLine("hatalı işlem: ");
//                            }
//                        }

//                    }
//                    else if (secim1 == 4)
//                    {
//                        Console.WriteLine("Çıkış Yapılıyor...");
//                        Environment.Exit(0);
//                    }
//                    else
//                    {
//                        Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyin.");

//                    }


//                    break;
//                }


//            }





//        }

//    }
//}








using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Threading.Thread; // geciktirme kodu

//namespace OTOMAT_PROJESİ
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] fiyatlar = { 10, 14, 15, 25, 36, 55, 44, 66 };
//            string[] tümicecekler = { "su", "kahve", "fincan cay", "bardak cay", "cafe latte", "salep", "ıhlamur", "americano" };
//            string[] kullanıcıadları = new string[10];
//            string[] şifreler = new string[10];
//            int kayıtsırası = 0;
//            string yenikullanıcıadi = "";
//            string yenisifre = "";
//            int paramız = 70;

//            while (true)
//            {


//                Console.WriteLine("OTOMAT PROJESİ");
//                Console.WriteLine("çıkış için 9 tuşuna basın: ");
//                Console.WriteLine("Kayıt olmak için 1 tuşuna basın: ");
//                Console.WriteLine("Giriş yapmak için 2 tuşuna basın: ");
//                Console.WriteLine("Admin girişi yapmak için 3 tuşuna basın");
//                string secim = Console.ReadLine();

//                if (secim == "1")
//                {
//                    Console.WriteLine("Kayıt olma işlemi başlatılıyor...");
//                    for (int i = 0; i <= 2; i++)
//                    {
//                        Console.WriteLine(i + " ");
//                        Sleep(1000);
//                    }

//                    Console.Write("Lütfen yeni kullanıcı adınızı giriniz: ");
//                    yenikullanıcıadi = Console.ReadLine();
//                    Console.Write("Lütfen yeni şifrenizi giriniz: ");
//                    yenisifre = Console.ReadLine();
//                    bool kayitliMi = false;

//                    for (int i = 0; i < kayıtsırası; i++)
//                    {
//                        if (kullanıcıadları[i] == yenikullanıcıadi)
//                        {
//                            kayitliMi = true;
//                            Console.WriteLine("Bu kullanıcı adı zaten kayıtlı, lütfen farklı bir kullanıcı adı giriniz.");
//                            break;
//                        }
//                    }
//                    if (!kayitliMi)
//                    {
//                        kullanıcıadları[kayıtsırası] = yenikullanıcıadi;
//                        şifreler[kayıtsırası] = yenisifre;
//                        kayıtsırası++;
//                        Console.WriteLine("Kayıt işlemi başarılı!");
//                    }
//                }
//                else if (secim == "2")
//                {
//                    int Hak = 3;
//                    bool girisBasarili = false;
//                    while (Hak > 0)
//                    {


//                        Console.WriteLine("Giriş yapma işlemi başlatılıyor...");
//                        for (int i = 0; i <= 2; i++)
//                        {
//                            Console.WriteLine(i + " ");
//                            Sleep(1000);
//                        }
//                        Console.Write("Lütfen kullanıcı adınızı giriniz: ");
//                        string kullaniciadi = Console.ReadLine();
//                        Console.Write("Lütfen şifrenizi giriniz: ");
//                        string sifre = Console.ReadLine();

//                        for (int i = 0; i < kayıtsırası; i++)
//                        {
//                            if (kullanıcıadları[i] == kullaniciadi && şifreler[i] == sifre)
//                            {
//                                girisBasarili = true;
//                                Console.WriteLine("Giriş başarılı! Hoş geldiniz, " + kullaniciadi + "!");
//                                break;
//                            }
//                        }
//                        if (girisBasarili)
//                        {
//                            break;
//                        }
//                        Hak--;
//                        if (Hak > 0)
//                        {
//                            Console.WriteLine("Kullanıcı adı veya şifre yanlış, lütfen tekrar deneyin." + Hak);

//                        }
//                        else
//                        {
//                            Console.WriteLine("Giriş hakkınız kalmadı, program sonlandırıldı");
//                            return;
//                        }
//                    }

//                    if (girisBasarili)
//                    {
//                        Console.WriteLine("Menüyü Görmek için 1 tuşuna basın.");
//                        int menüsecim = Convert.ToInt32(Console.ReadLine());
//                        if (menüsecim == 1)
//                            Console.Clear();
//                        {
//                            for (int i = 0; i < tümicecekler.Length; i++)
//                            {

//                                Console.WriteLine((i + 1) + ". " + tümicecekler[i] + " : " + fiyatlar[i] + " Tl");

//                            }

//                            while (true)
//                            {
//                                Console.WriteLine("Lütfen almak istediğiniz ürünün numarasını giriniz (1-7): ");
//                                int secim2 = Convert.ToInt32(Console.ReadLine());
//                                if (secim2 == 1)
//                                {
//                                    Console.WriteLine("su secildi. Satın alma başlatıldı.");
//                                    for (int i = 0; i <= 2; i++)
//                                    {
//                                        Console.WriteLine(i + " ");
//                                        Sleep(2000);
//                                    }
//                                    if (fiyatlar[0] <= paramız)
//                                    {
//                                        Console.WriteLine("Ödeme başarılı, ürün alındı.");
//                                        paramız -= fiyatlar[0];
//                                        Console.WriteLine("Kalan bakiyeniz: " + paramız + " TL");

//                                    }
//                                    else
//                                    {
//                                        Console.WriteLine("Yetersiz bakiye, lütfen tekrar deneyin.");

//                                    }
//                                    break;
//                                }
//                                else if (secim2 == 2)
//                                {
//                                    Console.WriteLine("kahve secildi. Satın alma başlatıldı.");
//                                    for (int i = 0; i <= 2; i++)
//                                    {
//                                        Console.WriteLine(i + " ");
//                                        Sleep(2000);
//                                    }
//                                    if (fiyatlar[1] <= paramız)
//                                    {
//                                        Console.WriteLine("Ödeme başarılı, ürün alındı.");
//                                        paramız -= fiyatlar[0];
//                                        Console.WriteLine("Kalan bakiyeniz: " + paramız + " TL");

//                                    }
//                                    else
//                                    {
//                                        Console.WriteLine("Yetersiz bakiye, lütfen tekrar deneyin.");

//                                    }
//                                    break;
//                                }
//                                else if (secim2 == 3)
//                                {
//                                    Console.WriteLine("fincan cay secildi. Satın alma başlatıldı.");
//                                    for (int i = 0; i <= 2; i++)
//                                    {
//                                        Console.WriteLine(i + " ");
//                                        Sleep(2000);
//                                    }
//                                    if (fiyatlar[2] <= paramız)
//                                    {
//                                        Console.WriteLine("Ödeme başarılı, ürün alındı.");
//                                        paramız -= fiyatlar[2];
//                                        Console.WriteLine("Kalan bakiyeniz: " + paramız + " TL");
//                                    }
//                                    else
//                                    {
//                                        Console.WriteLine("Yetersiz bakiye, lütfen tekrar deneyin.");
//                                    }
//                                    break;
//                                }
//                                else if (secim2 == 4)
//                                {
//                                    Console.WriteLine("bardak cay secildi. Satın alma başlatıldı.");
//                                    for (int i = 0; i <= 2; i++)
//                                    {
//                                        Console.WriteLine(i + " ");
//                                        Sleep(2000);
//                                    }
//                                    if (fiyatlar[3] <= paramız)
//                                    {
//                                        Console.WriteLine("Ödeme başarılı, ürün alındı.");
//                                        paramız -= fiyatlar[3];
//                                        Console.WriteLine("Kalan bakiyeniz: " + paramız + " TL");
//                                    }
//                                    else
//                                    {
//                                        Console.WriteLine("Yetersiz bakiye, lütfen tekrar deneyin.");
//                                    }
//                                    break;
//                                }
//                                else if (secim2 == 5)
//                                {
//                                    Console.WriteLine("cafe latte secildi. Satın alma başlatıldı.");
//                                    for (int i = 0; i <= 2; i++)
//                                    {
//                                        Console.WriteLine(i + " ");
//                                        Sleep(2000);
//                                    }
//                                    if (fiyatlar[4] <= paramız)
//                                    {
//                                        Console.WriteLine("Ödeme başarılı, ürün alındı.");
//                                        paramız -= fiyatlar[4];
//                                        Console.WriteLine("Kalan bakiyeniz: " + paramız + " TL");
//                                    }
//                                    else
//                                    {
//                                        Console.WriteLine("Yetersiz bakiye, lütfen tekrar deneyin.");
//                                    }
//                                    break;
//                                }
//                                else if (secim2 == 6)
//                                {
//                                    Console.WriteLine("salep secildi. Satın alma başlatıldı.");
//                                    for (int i = 0; i <= 2; i++)
//                                    {
//                                        Console.WriteLine(i + " ");
//                                        Sleep(2000);
//                                    }
//                                    if (fiyatlar[5] <= paramız)
//                                    {
//                                        Console.WriteLine("Ödeme başarılı, ürün alındı.");
//                                        paramız -= fiyatlar[5];
//                                        Console.WriteLine("Kalan bakiyeniz: " + paramız + " TL");
//                                    }
//                                    else
//                                    {
//                                        Console.WriteLine("Yetersiz bakiye, lütfen tekrar deneyin.");
//                                    }
//                                    break;
//                                }
//                                else if (secim2 == 7)
//                                {
//                                    Console.WriteLine("ıhlamur secildi. Satın alma başlatıldı.");
//                                    for (int i = 0; i <= 2; i++)
//                                    {
//                                        Console.WriteLine(i + " ");
//                                        Sleep(2000);
//                                    }
//                                    if (fiyatlar[6] <= paramız)
//                                    {
//                                        Console.WriteLine("Ödeme başarılı, ürün alındı.");
//                                        paramız -= fiyatlar[6];
//                                        Console.WriteLine("Kalan bakiyeniz: " + paramız + " TL");
//                                    }
//                                    else
//                                    {
//                                        Console.WriteLine("Yetersiz bakiye, lütfen tekrar deneyin.");
//                                    }
//                                    break;
//                                }
//                                else if (secim2 == 8)
//                                {
//                                    Console.WriteLine("americano secildi. Satın alma başlatıldı.");
//                                    for (int i = 0; i <= 2; i++)
//                                    {
//                                        Console.WriteLine(i + " ");
//                                        Sleep(2000);
//                                    }
//                                    if (fiyatlar[7] <= paramız)
//                                    {
//                                        Console.WriteLine("Ödeme başarılı, ürün alındı.");
//                                        paramız -= fiyatlar[7];
//                                        Console.WriteLine("Kalan bakiyeniz: " + paramız + " TL");
//                                    }
//                                    else
//                                    {
//                                        Console.WriteLine("Yetersiz bakiye, lütfen tekrar deneyin.");
//                                    }
//                                    break;
//                                }
//                                else if (secim2 == 9)
//                                {
//                                    Console.WriteLine("Çıkış yapılıyor...");
//                                    Environment.Exit(0);
//                                }
//                                else
//                                {
//                                    Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyin.");
//                                }
//                            }
//                        }
//                    }

//                }
//                else if (secim == "3")
//                {
//                    Console.WriteLine("Admin girişi yapılıyor...");
//                    for (int i = 0; i <= 2; i++)
//                    {
//                        Console.WriteLine(i + " ");
//                        Sleep(1000);
//                    }
//                    Console.Write("Lütfen admin kullanıcı adınızı giriniz: ");
//                    string adminKullaniciAdi = Console.ReadLine();
//                    Console.Write("Lütfen admin şifrenizi giriniz: ");
//                    string adminSifre = Console.ReadLine();
//                    adminKullaniciAdi = "123";
//                    adminSifre = "123";
//                    if (adminKullaniciAdi == "123" && adminSifre == "123")
//                    {
//                        Console.WriteLine("Admin girişi başarılı! Hoş geldiniz " + adminKullaniciAdi);
//                        Console.WriteLine("Ürün eklemek için 1 tuşuna basın");
//                        Console.WriteLine("Ürün silmek için 2 tuşuna basın");
//                        Console.WriteLine("Ürün güncellemek için 3 tuşuna basın.");
//                        string adminSecim = Console.ReadLine();
//                        Console.Clear();

//                        while (true)
//                        {


//                            if (adminSecim == "1")

//                            {
//                                for (int i = 0; i < tümicecekler.Length; i++)
//                                {
//                                    Console.WriteLine((i + 1) + ". " + tümicecekler[i] + " : " + fiyatlar[i] + " Tl");
//                                }
//                                Console.WriteLine("Geri Dönmek icin 9 tuşuna basınz.");
//                                Console.WriteLine("ürün eklemek icin 1 tuşuna basınz.");
//                                int ekleme = Convert.ToInt32(Console.ReadLine());
//                                while (true)
//                                {
//                                    if (ekleme == 1)
//                                    {
//                                        Console.WriteLine("Lütfen eklemek istediğiniz ürünün adını giriniz: ");
//                                        string yeniUrun = Console.ReadLine();


//                                        Console.WriteLine("Lütfen eklemek istediğiniz ürünün fiyatını giriniz: ");
//                                        string giris = Console.ReadLine();
//                                        if (int.TryParse(giris, out int yeniFiyat))
//                                        {

//                                            Console.WriteLine("Yeni ürün: " + yeniUrun + " - Fiyat: " + yeniFiyat + " TL");
//                                            if (yeniFiyat < 0)
//                                            {
//                                                Console.WriteLine("Fiyat negatif olamaz, lütfen geçerli bir fiyat giriniz.");
//                                                continue;
//                                            }
//                                            else if (yeniFiyat == 0)
//                                            {
//                                                Console.WriteLine("Fiyat sıfır olamaz, lütfen geçerli bir fiyat giriniz.");

//                                            }
//                                            Array.Resize(ref tümicecekler, tümicecekler.Length + 1); // dizinin boyutunu artırdık
//                                            Array.Resize(ref fiyatlar, fiyatlar.Length + 1); // dizinin boyutunu artırdık
//                                            tümicecekler[tümicecekler.Length - 1] = yeniUrun; // dizinin sonuna ekledki
//                                            fiyatlar[fiyatlar.Length - 1] = yeniFiyat; // dizinin sonuna ekledik
//                                            Console.WriteLine("Yeni ürün eklendi: " + yeniUrun + " - " + yeniFiyat + " TL");
//                                            break;

//                                        }
//                                        else
//                                        {
//                                            Console.WriteLine("Lütfen geçerli bir fiyat giriniz.");

//                                        }
//                                    }


//                                    else if (ekleme == 9)
//                                    {
//                                        Console.WriteLine("Çıkış yapılıyor...");
//                                        break;
//                                    }
//                                    else
//                                    {
//                                        Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyin.");
//                                    }
//                                }
//                            }
//                            else if (adminSecim == "2")
//                            {
//                                for (int i = 0; i < tümicecekler.Length; i++)
//                                {
//                                    Console.WriteLine((i + 1) + ": " + tümicecekler[i] + ": " + fiyatlar[i] + " Tl");
//                                }
//                                Console.WriteLine("Geri Dönmek icin 9 tuşuna basınz.");
//                                Console.WriteLine("Silinecek ürün numarasını giriniz. ");
//                                string giris = Console.ReadLine();
//                                int silinecekUrun = Convert.ToInt32(giris);
//                                if (silinecekUrun >= 0 && silinecekUrun < tümicecekler.Length)
//                                {
//                                    string silinenad = tümicecekler[silinecekUrun];
//                                    int silinenfiyat = fiyatlar[silinecekUrun];
//                                    for (int i = silinecekUrun; i < tümicecekler.Length - 1; i++)
//                                    {
//                                        tümicecekler[i] = tümicecekler[i + 1];
//                                        fiyatlar[i] = fiyatlar[i + 1];
//                                    }
//                                    Array.Resize(ref tümicecekler, tümicecekler.Length - 1);
//                                    Array.Resize(ref fiyatlar, fiyatlar.Length - 1);
//                                    Console.WriteLine("Ürün silindi: " + tümicecekler[silinecekUrun] + " - " + fiyatlar[silinecekUrun] + " TL");
//                                }
//                                else if (silinecekUrun == 9)
//                                {
//                                    Console.WriteLine("geri dönülüyor...");
//                                    break;
//                                }
//                            }
//                            else if (adminSecim == "3")
//                            {
//                                for (int i = 0; i < tümicecekler.Length; i++)
//                                {
//                                    Console.WriteLine((i + 1) + ": " + tümicecekler[i] + ": " + fiyatlar[i] + " Tl");
//                                }
//                                Console.WriteLine("Geri Dönmek icin 9 tuşuna basınz.");
//                                Console.WriteLine("Fiyatı değiştirecek ürünün numarasını giriniz: ");
//                                string giris2 = Console.ReadLine();
//                                int yenifiyat = Convert.ToInt32(giris2) - 1;
//                                if (yenifiyat > 0 && yenifiyat < tümicecekler.Length)
//                                {
//                                    Console.WriteLine("Lütfen yeni fiyatı giriniz: ");
//                                    string yeniFiyatGiris = Console.ReadLine();
//                                    fiyatlar[yenifiyat] = Convert.ToInt32(yeniFiyatGiris);
//                                    Console.WriteLine("Ürün fiyatı güncellendi: " + tümicecekler[yenifiyat] + " - " + fiyatlar[yenifiyat] + " TL");
//                                }
//                                else if (giris2 == "9")
//                                {
//                                    Console.WriteLine("geri dönülüyor...");
//                                    break;
//                                }
//                                else
//                                {
//                                    Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyin.");
//                                }
//                            }

//                        }

//                    }
//                }
//                else if (secim == "9")
//                {
//                    Console.WriteLine("Programdan çıkılıyor...");
//                    Environment.Exit(0);
//                }
//            }
namespace manav_projesi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList toptancımeyve = new ArrayList()
            { "Elma", "Armut", "Muz", "Çilek", "Kiraz", "Erik", "Şeftali", "Kayısı", "Karpuz", "Kavun",
              "Üzüm", "Nar", "İncir", "Dut", "Ayva", "Ananas", "Portakal", "Mandalina", "Greyfurt", "Limon" };

            ArrayList toptancımeyvekilo = new ArrayList()
            { 2.5, 1.8, 3.2, 1.0, 0.75, 1.4, 2.0, 1.3, 5.0, 4.5,
              2.2, 1.7, 0.9, 0.6, 2.1, 1.6, 3.0, 2.4, 2.8, 1.9 };
            ArrayList maanavmeyvekilo = new ArrayList();
            ArrayList manavmeyve = new ArrayList();


            ArrayList toptancısebze = new ArrayList()  {"Domates", "Salatalık", "Biber", "Patlıcan", "Kabak", "Havuç", "Ispanak", "Marul", "Lahana", "Karnabahar",
    "Brokoli", "Pırasa", "Soğan", "Sarımsak", "Bezelye", "Fasulye", "Mısır", "Patates", "Turp", "Roka" };
            ArrayList toptancısebzekilo = new ArrayList() {
                1.0, 0.5, 0.75, 1.2, 1.0, 0.8, 0.4, 0.3, 2.0, 1.5,
    0.9, 1.0, 1.0, 0.2, 0.6, 0.7, 1.0, 2.5, 0.9, 0.2
};
            ArrayList manavsebze = new ArrayList();
            ArrayList manavkilo = new ArrayList();
            ArrayList müsterialınan = new ArrayList();
            ArrayList müsterialınankilo = new ArrayList();




            while (true)
            {
                Console.WriteLine("Manava hoş geldiniz!");
                Console.Write("Manav için (M), Müşteri için (E) tuşuna basın: ");
                string secim = Console.ReadLine().ToUpper();
                if (secim == "M")
                {
                    Console.WriteLine("Manava giriliyor edildi.");
                }
                else if (secim == "E")
                {
                    Console.WriteLine("Sebze almak için (S) tuşuna basın. Meyve almak için (M) tuşuna basın ");
                    string secim3 = Console.ReadLine().ToUpper();
                    while (true)
                    {


                        if (secim3 == "S")
                        {
                            Console.WriteLine("Manav Sebze bölümüne gidiliyor...");

                            manavsebze.Sort();
                            for (int i = 0; i < manavsebze.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {manavsebze[i]} - {manavkilo[i]} kg");
                            }
                            while (true)
                            {


                                Console.WriteLine("Hangi sebzeyi almak istiyorsunuz.");
                                int secilenindex = -1;
                                string sebzesecim2 = Console.ReadLine();
                                for (int i = 0; i < manavsebze.Count; i++)
                                {
                                    if (manavsebze[i].ToString().Equals(sebzesecim2, StringComparison.OrdinalIgnoreCase))
                                    {
                                        secilenindex = i;
                                        break;
                                    }
                                }
                                if (secilenindex == -1)
                                {
                                    Console.WriteLine("Bu isimde bir sebze bulunamadı.");
                                    continue;
                                }
                                double stokKilo = Convert.ToDouble(manavkilo[secilenindex]);
                                Console.WriteLine($"{manavsebze[secilenindex]} için kaç kilo almak istiyorsunuz?: ");
                                string kiloGirdi = Console.ReadLine();
                                if (!double.TryParse(kiloGirdi, out double alinacakKilo) || alinacakKilo <= 0)
                                {
                                    Console.WriteLine("Geçersiz kilo girdiniz.");
                                    continue;
                                }
                                if (alinacakKilo > stokKilo)
                                {
                                    Console.WriteLine($"Yetersiz stok! Sadece {stokKilo} kg mevcut.");
                                }
                                else
                                {
                                    double yeniStok = stokKilo - alinacakKilo;
                                    manavkilo[secilenindex] = yeniStok;
                                    müsterialınan.Add(manavsebze[secilenindex]);
                                    müsterialınankilo.Add(alinacakKilo);
                                    for (int i = 0; i < müsterialınan.Count; i++)
                                    {
                                        Console.WriteLine($"Alınan ürünler: {müsterialınan[i]} - {müsterialınankilo[i]} kg");
                                        Console.WriteLine($"Kalan stok: {yeniStok} kg");
                                    }
                                    if (yeniStok == 0)
                                    {
                                        müsterialınan.RemoveAt(secilenindex);
                                        müsterialınankilo.RemoveAt(secilenindex);

                                    }
                                    Console.WriteLine(" Güncel Sebze Listesi:");
                                    for (int i = 0; i < manavsebze.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}. {manavsebze[i]} - {manavkilo[i]} kg");
                                    }
                                }
                                Console.Write("Başka bir sebze almak istiyor musunuz? (Evet için E, Hayır için H): ");
                                string devam = Console.ReadLine().ToUpper();
                                if (devam != "E")
                                {
                                    foreach (var sebze in müsterialınan)
                                    {
                                        Console.Write($"Alınan ürünler: {sebze}");
                                        Console.WriteLine();
                                    }
                                    break;
                                }
                            }
                        }
                        else if (secim3 == "M")
                        {
                            Console.WriteLine("Manav Meyve bölümüne gidiliyor...");
                            manavmeyve.Sort();
                            for (int i = 0; i < manavmeyve.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {manavmeyve[i]} - {maanavmeyvekilo[i]} kg");
                            }
                            while (true)
                            {
                                Console.WriteLine("Hangi meyveyi almak istiyorsunuz.");
                                int secilenindex = -1;
                                string meyvesecim2 = Console.ReadLine();
                                for (int i = 0; i < manavmeyve.Count; i++)
                                {
                                    if (manavmeyve[i].ToString().Equals(meyvesecim2, StringComparison.OrdinalIgnoreCase))
                                    {
                                        secilenindex = i;
                                        break;
                                    }
                                }
                                if (secilenindex == -1)
                                {
                                    Console.WriteLine("Bu isimde bir meyve bulunamadı.");
                                    continue;
                                }
                                double stokKilo = Convert.ToDouble(maanavmeyvekilo[secilenindex]);
                                Console.WriteLine($"{manavmeyve[secilenindex]} için kaç kilo almak istiyorsunuz?: ");
                                string kiloGirdi = Console.ReadLine();
                                if (!double.TryParse(kiloGirdi, out double alinacakKilo) || alinacakKilo <= 0)
                                {
                                    Console.WriteLine("Geçersiz kilo girdiniz.");
                                    continue;
                                }
                                if (alinacakKilo > stokKilo)
                                {
                                    Console.WriteLine($"Yetersiz stok! Sadece {stokKilo} kg mevcut.");
                                }
                                else
                                {
                                    double yeniStok = stokKilo - alinacakKilo;
                                    maanavmeyvekilo[secilenindex] = yeniStok;
                                    müsterialınan.Add(manavmeyve[secilenindex]);
                                    müsterialınankilo.Add(alinacakKilo);
                                    for (int i = 0; i < müsterialınan.Count; i++)
                                    {
                                        Console.WriteLine($"Alınan ürünler: {müsterialınan[i]} - {müsterialınankilo[i]} kg");
                                        Console.WriteLine($"Kalan stok: {yeniStok} kg");
                                    }
                                    if (yeniStok == 0)
                                    {
                                        müsterialınan.RemoveAt(secilenindex);
                                        müsterialınankilo.RemoveAt(secilenindex);
                                    }
                                    Console.WriteLine(" Güncel Meyve Listesi:");
                                    for (int i = 0; i < manavmeyve.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}. {manavmeyve[i]} - {maanavmeyvekilo[i]} kg");
                                    }
                                    Console.Write("Başka bir meyve almak istiyor musunuz? (Evet için E, Hayır için H): ");
                                    string devam = Console.ReadLine().ToUpper();
                                    if (devam != "E")
                                    {
                                        foreach (var meyve in müsterialınan)
                                        {
                                            Console.Write($"Alınan ürünler: {meyve}");
                                            Console.WriteLine();
                                        }
                                        break;
                                    }
                                }

                            }

                            break;
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Geçersiz tuşlama. Lütfen M veya E tuşuna basınız.");
                    continue;
                }
                while (true)
                {
                    Console.WriteLine("Meyve bölümü için M tuşuna basın. Sebze bölümü için S tuşuna basın...\n");
                    string secim2 = Console.ReadLine().ToUpper();
                    if (secim2 == "M")
                    {
                        Console.WriteLine("Manav Meyve bölümüne gidiliyor....\n");

                        toptancımeyve.Sort();
                        for (int i = 0; i < toptancımeyve.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {toptancımeyve[i]} - {toptancımeyvekilo[i]} kg");
                        }
                        while (true)
                        {


                            Console.Write("\nHangi meyveyi istiyorsunuz?: ");
                            string meyvesecim = Console.ReadLine();

                            int secilenindex = -1;
                            for (int i = 0; i < toptancımeyve.Count; i++)
                            {
                                if (toptancımeyve[i].ToString().Equals(meyvesecim, StringComparison.OrdinalIgnoreCase))
                                {
                                    secilenindex = i;
                                    break;
                                }
                            }

                            if (secilenindex == -1)
                            {
                                Console.WriteLine("Bu isimde bir meyve bulunamadı.");
                                continue;
                            }

                            double stokKilo = Convert.ToDouble(toptancımeyvekilo[secilenindex]);

                            Console.Write($"{toptancımeyve[secilenindex]} için kaç kilo almak istiyorsunuz?: ");
                            string kiloGirdi = Console.ReadLine();

                            if (!double.TryParse(kiloGirdi, out double alinacakKilo) || alinacakKilo <= 0)
                            {
                                Console.WriteLine("Geçersiz kilo girdiniz.");
                                continue;
                            }

                            if (alinacakKilo > stokKilo)
                            {
                                Console.WriteLine($"Yetersiz stok! Sadece {stokKilo} kg mevcut.");
                            }
                            else
                            {

                                double yeniStok = stokKilo - alinacakKilo;
                                toptancımeyvekilo[secilenindex] = yeniStok;
                                manavmeyve.Add(toptancımeyve[secilenindex]);
                                maanavmeyvekilo.Add(alinacakKilo);

                                Console.WriteLine($"{alinacakKilo} kg {toptancımeyve[secilenindex]} başarıyla alındı.");
                                Console.WriteLine($"Kalan stok: {yeniStok} kg");
                                if (yeniStok == 0)
                                {
                                    toptancımeyve.RemoveAt(secilenindex);
                                    toptancımeyvekilo.RemoveAt(secilenindex);
                                }
                                Console.WriteLine(" Güncel Meyve Listesi:");
                                for (int i = 0; i < toptancımeyve.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {toptancımeyve[i]} - {toptancımeyvekilo[i]} kg");
                                }
                            }

                            Console.Write("Başka bir meyve almak istiyor musunuz? (Evet için E, Hayır için H): ");
                            string devam = Console.ReadLine().ToUpper();
                            if (devam != "E")
                            {
                                foreach (var meyve in manavmeyve)
                                {
                                    Console.Write($"Alınan ürünler: {meyve}");
                                    Console.WriteLine();
                                }
                                break;
                            }

                        }
                        break;
                    }
                    else if (secim2 == "S")
                    {
                        Console.WriteLine("Manav Sebze bölümüne gidiliyor....\n");
                        toptancısebze.Sort();
                        for (int i = 0; i < toptancısebze.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {toptancısebze[i]} - {toptancısebzekilo[i]} kg");
                        }
                        while (true)
                        {
                            Console.Write("Hangi sebzeyi istiyorsunuz?: ");
                            string sebzesecim = Console.ReadLine();
                            int secilenindex = -1;
                            for (int i = 0; i < toptancısebze.Count; i++)
                            {
                                if (toptancısebze[i].ToString().Equals(sebzesecim, StringComparison.OrdinalIgnoreCase))
                                {
                                    secilenindex = i;
                                    break;
                                }
                            }
                            if (secilenindex == -1)
                            {
                                Console.WriteLine("Bu isimde bir sebze bulunamadı.");
                                continue;
                            }
                            double stokKilo = Convert.ToDouble(toptancısebzekilo[secilenindex]);
                            Console.Write($"{toptancısebze[secilenindex]} için kaç kilo almak istiyorsunuz?: ");
                            string kiloGirdi = Console.ReadLine();
                            if (!double.TryParse(kiloGirdi, out double alinacakKilo) || alinacakKilo <= 0)
                            {
                                Console.WriteLine("Geçersiz kilo girdiniz.");
                                continue;
                            }
                            if (alinacakKilo > stokKilo)
                            {
                                Console.WriteLine($"Yetersiz stok! Sadece {stokKilo} kg mevcut.");
                            }
                            else
                            {
                                double yeniStok = stokKilo - alinacakKilo;
                                toptancısebzekilo[secilenindex] = yeniStok;
                                manavsebze.Add(toptancısebze[secilenindex]);
                                manavkilo.Add(alinacakKilo);
                                Console.WriteLine($"{alinacakKilo} kg {toptancısebze[secilenindex]} başarıyla alındı.");
                                Console.WriteLine($"Kalan stok: {yeniStok} kg");
                                if (yeniStok == 0)
                                {
                                    toptancısebze.RemoveAt(secilenindex);
                                    toptancısebzekilo.RemoveAt(secilenindex);
                                }
                                Console.WriteLine(" Güncel Sebze Listesi:");
                                for (int i = 0; i < toptancısebze.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {toptancısebze[i]} - {toptancısebzekilo[i]} kg");
                                }
                            }
                            Console.Write("Başka bir sebze almak istiyor musunuz? (Evet için E, Hayır için H): ");
                            string devam = Console.ReadLine().ToUpper();
                            if (devam != "E")
                            {
                                foreach (var sebze in manavsebze)
                                {
                                    Console.Write($"Alınan ürünler: {sebze}");
                                    Console.WriteLine();
                                }
                                break;
                            }
                        }
                        break;

                    }
                    else
                    {
                        Console.WriteLine("Geçersiz tuşlama. M veya E tuşuna basınız.");

                    }
                }
            }
        }
    }
}

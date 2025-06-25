using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.Metrics;

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


         Console.WriteLine("İsminizi giriniz: ");
            string isim = Console.ReadLine();
        Console.WriteLine("Yaşınızı giriniz: ");
            int yas = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Maaşınızı giriniz: ");
            double maas = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Çocuk sayınızı giriniz: ");
            int cocukSayisi = Convert.ToInt32(Console.ReadLine());
        double eklenenMaaş = 2000;
        double ekpara = 5000;

            if (yas < 45 && cocukSayisi < 3)
            {
                double yenimaas = maas + cocukSayisi * 2500;
                Console.WriteLine(yenimaas + "Maasınız: ");
            }
            else if (yas < 45 && cocukSayisi >= 3)
            {
                double yenimaas2 = maas + cocukSayisi * eklenenMaaş;
                Console.WriteLine(eklenenMaaş + "Maasınız: ");
            }
            else
            {
                double ekmaas2 = maas + ekpara;
                Console.WriteLine(ekmaas2 + "Maasınız: ");
            }




        }
}
}
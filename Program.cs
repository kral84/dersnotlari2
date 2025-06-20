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













        }
    }
}

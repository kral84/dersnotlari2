using System;
using System.Security.Cryptography.X509Certificates;

namespace metotlar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("aaa");
            double giris1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("bbbbb");
            double giris2 = Convert.ToDouble(Console.ReadLine());
            dortislem toplama = new dortislem();
            double toplam = toplama.topla(giris1, giris2);
            Console.WriteLine($"{toplam}");


        }
        class dortislem()
        {
            public double topla (double a, double b)
            {
                return (a + b);
            }

        }

       
    }
}


/*
Private: Yanlızca metodun yazıldığı sınıfta kullanılır.
Public: Metot programın tamamında kullanır.
Static: Private ve Public ifadesinden sonra eklenirse, metot doğrudan kullanılır,
ancak eklenmezse metodun bulunduğu sınıftan nesne türetilerek kullanılması gerekir.

Parametre:  ()
Metoda dışardan değer göndermeyeceksek parantez içini boş bırak.
Değer gönderilecek ise gönderilen degiskenleri araya  , koyarak ekle.
örnek: (int x , int y) uzun kenar ve kısa kenar mesela.

Parametre göndermeli örnek:

Ana main clası programın calısıtğı yer
{
Console.Writeline("uzun kenar girin);
double uk = Convert.ToDouble(Console.ReadLine());
Console.Writeline("kısa kenar girin);
double kk = Convert.ToDouble(Console.ReadLine());
double dikdörtgenalan = alanhesapla.alan(kk, kk);
double dikdörtgenalan = alanhesapla.cevre(kk, kk);
}
Class alanhesapla{

public static double alanhesapla(double uzunkenar, double kısakenar)
{
double alan = kısakenar * uzunkenar;
return(alan);
}
public static double cevrehesapla(double uzunkenar, double kısakenar)
double cevre = 2 * (uzunkenar + kısakenar);
return(cevre);
}

Static kullanmassak ne olur ?  ozaman nesne üretmemiz gerekiyor ve onun üzerinden çağırmak lazım.

ana main
metotlar metot1 = new metotlar (); //  metotlar sınıfının tüm özelliklerini metot1 e koy dedik..
int sonuc = metot1.topla(5,8);
class metotlar
{
public int topla(int s1, int s2)
return (s1+s2);  // topla gönder geri dedik.
}




*/
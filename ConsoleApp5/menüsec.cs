using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class menüsec
    {
        static int müsteripara = 2000;
        static int secim;
        static int girilenmiktar;
        static int tutar;
        static menü secilenYemek;
        internal static bool müsteriparahesap()
        {
            tutar = girilenmiktar * secilenYemek.fiyat;
            if (tutar > müsteripara || girilenmiktar > secilenYemek.stokmiktari)
            {
                Console.WriteLine("alım imkansız");
                return false;
            }
            secilenYemek.stokmiktari -= girilenmiktar;
            müsteripara -= tutar;
            kasa.kasamız(tutar);
            return true;
        }
        public static void menüsecelim()
        {
            menü.menügöster();
            Console.WriteLine("hangi ürünü secmek istersiniz.");
            secim = Convert.ToInt32(Console.ReadLine());
            if (secim < 1 || secim > menü.menüler.Count)
            {
                Console.WriteLine("hata");
                return;
            } 
            secilenYemek = menü.menüler[secim - 1];
            Console.WriteLine($"{secilenYemek.icecekadi} {secilenYemek.yemekadi}");
            Console.WriteLine("kaç adet");
            girilenmiktar = Convert.ToInt32(Console.ReadLine());
            müsteriparahesap();
            Console.WriteLine($"girilen miktar {girilenmiktar} senin paran {müsteripara} son stok durumu {secilenYemek.stokmiktari} kasadaki para {kasa.kasaa}");

        }
    }
}

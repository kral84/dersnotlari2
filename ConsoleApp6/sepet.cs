using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    
    internal class sepet
    {
        public string ürünadı;
        public string fiyatı;
        public static List<sepet> sepets = new List<sepet>();
    
    public static void menüalım()
        {
            Console.WriteLine("Menüyü veriyorum istediğinizi seçebilirsiniz...");
            menü.menügöster();
            int secim = Convert.ToInt32(Console.ReadLine());
            //int index = secim - 1;

            
            
                if (secim > 0 && secim <= menü.kategori.Count)
                {
                menü secilen = menü.yemekler[secim];
                sepets.Add (new sepet { ürünadı = secilen.yemekadı, fiyatı = secilen.fiyat });
                Console.WriteLine($"{secilen.yemekadı} sepete eklendi.");
            }
                else
                {
                    Console.WriteLine("hatalı secim");
                }
            



        }
}
}


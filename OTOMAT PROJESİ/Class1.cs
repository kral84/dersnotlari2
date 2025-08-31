using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTOMAT_PROJESİ
{
    internal class Class1
    {
        public Class1() { 


        ArrayList sayılar = new ArrayList();
        ArrayList ciftsayılar = new ArrayList();
        ArrayList tekSayılar = new ArrayList();

        Random rastgele = new Random();

            for (int i = 0; i < 100; i++)
        {
            int rastgeleSayı = rastgele.Next(1, 1001); // 1 ile 1000 arasında rastgele sayı üret
            sayılar.Add(rastgeleSayı); // Sayıyı sayılar listesine ekle
            if (rastgeleSayı % 2 == 0)
            {
                ciftsayılar.Add(rastgeleSayı); // Çift sayıları ciftsayılar listesine ekle
            }
            else
            {
                tekSayılar.Add(rastgeleSayı); // Tek sayıları tekSayılar listesine ekle
            }
            }
            Console.WriteLine("Rastgele Sayılar: " + ciftsayılar + tekSayılar);


        }
}
}

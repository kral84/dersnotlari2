using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class kasa
    {
        public static double kasamız = 5000;
        public static void kasagöster()
        {
            Console.WriteLine($"Kasadaki toplam tutar: {kasamız} TL");
        }
        public static void parageliyor(double tutar)
        {
            kasamız += tutar;
        }
        public static void paracıkıyor(double tutar)
        {
            if (tutar > kasamız)
            {
                Console.WriteLine("Kasada yeterli para yok.");
                return;
            }
            kasamız -= tutar;
        }
    }
}

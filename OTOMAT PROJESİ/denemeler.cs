using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTOMAT_PROJESİ
{
    public static class denemeler
    {

        public static int mat(int x, int y)
        {
            int toplam = x + y;
            return toplam;
        }
        public static int carp(int x, int y)
        {
            int carpim = x * y;
            Console.WriteLine("Çarpım: " + carpim);
            return carpim;
        }


    }
}

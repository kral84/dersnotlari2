using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class musteriler
    {
        public string musterisayısı;
        //public string ;
        //public string ;

        public static void musterisay(List<musteriler> liste)
        {
            musteriler uye = new musteriler();
            Console.WriteLine("Kaç kişi olacaksınız?");
            uye.musterisayısı = Console.ReadLine();
           liste.Add(uye);
        }
    }
}

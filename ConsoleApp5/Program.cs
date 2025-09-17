using ConsoleApp5;
using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("sec");
            string secim = Console.ReadLine();
            if (secim == "1")
            {
                menüsec.menüsecelim();
                //menü.menüekleme2(); iptal
               
            }
            else if (secim == "0")
            {
                menü.menügöster();
            }
            else if (secim == "2")
            {
                menü.yemeksilindex();
            }
            else if (secim == "3")
            {
                menü.yemeksilid();
            }
            else if (secim == "4")
            {
                menü.yemeksilismegöre();
            }
            else if (secim == "5")
            {
                menü.yemeksilhepsi();
            }
            else if (secim == "6")
            {
                menü.yemekekle();
            }

        }
    }
}
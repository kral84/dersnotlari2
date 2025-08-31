using System;

class Program
{
    static void Main(string[] args)
    {


        //int sayı;
        //while (true)
        //{
        //    Console.WriteLine("sayı gir ");
        //    string input = Console.ReadLine();
        //    if (int.TryParse(input, out  sayı)) 
        //    {
        //        break;
        //    }
        //    Console.WriteLine("düzgün sayı gir");

        //}
        //if (sayı == 1)
        //{
        //    Console.WriteLine("sayı 1 e eşit");
        //}
        List<string> isimler = new List<string>();
        isimler.Add("Ali");
        isimler.Add("Ahmet");
        isimler.Add("Mehmet");
        isimler.Add("Kemal");
        isimler.ForEach(isim => Console.WriteLine(isim));




    }
}

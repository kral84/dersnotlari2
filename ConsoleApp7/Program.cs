using Microsoft.VisualBasic;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {


            while (true)
            {
                Console.WriteLine("Restauranto hoş geldiniz.");
                Console.WriteLine("girmek icin 1 tuşuna basın");
                Console.WriteLine("menü görmek icin 2 tuşuna basın");
                string input1 = Console.ReadLine();
                if (!int.TryParse(input1, out int secim))
                {
                    Console.WriteLine("Geçersiz giriş. Lütfen bir sayı girin.");
                    continue;
                }
                switch (secim)

                {
                    case 1:
                        
                        break;
                    case 2:
                        menüler.yemekmenügöster();
                        break;

                    case 3:
                        while (true)
                        {
                            Console.WriteLine("yemek silmek icin 1 tuşuna basın. \nYemek eklemek için 2 tuşuna basın. \nToplu silmek için 3 tuşuna basın. \nYemek Güncellemek için 4 tuşuna basın \nÇıkış için 9 tusuna basın.");
                            string input = Console.ReadLine();
                            if (!int.TryParse(input, out int secim1))
                            {
                                Console.WriteLine("Geçersiz giriş. Lütfen bir sayı girin.");
                                continue;
                            }
                            if (secim1 == 9)
                            {
                                break;
                            }
                            else if (secim1 == 1)
                            {
                                menüler.yemeksil();
                            }
                            else if (secim1 == 2)
                            {
                                menüler.yemekekle();                         
                            }
                            else if (secim1 == 3)
                            {
                                menüler.topluyemeksil();
                            }
                            else if (secim1 == 4)
                            {
                                menüler.yemekgüncelle();
                            }
                        }
                        break;
                    case 4:
                        
                        break;
                };
            }
        }
    }
}

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {



            //int bosluk = 0;

            //for (int yildizSayisi = 1; yildizSayisi < 15; yildizSayisi -= 2)
            //{
            //    for (int k = bosluk; k >= 0; k++)
            //    {
            //        Console.Write(" ");
            //    }
            //    for (int yildiz = yildizSayisi; yildiz > 0; yildiz--)
            //    {
            //        Console.Write("*");
            //    }
            //    bosluk++;
            //    Console.WriteLine();


            //int sayı;
            //int toplam = 0;
            //do
            //{
            //    Console.Write("Lütfen bir sayı giriniz (0-100): ");
            //    sayı = Convert.ToInt32(Console.ReadLine());
            //    if (sayı < 0 || sayı > 100)
            //    {
            //        Console.WriteLine("Lütfen 0 ile 100 arasında bir sayı giriniz.");
            //    }
            //    else
            //    {
            //        toplam += sayı;
            //    }

            //} while (sayı != 0);

            //Console.WriteLine("Toplam:" + toplam);

            int sayı = 200;
            for (int i = 1; i<sayı; i++)
                {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i + " çift sayıdır.");
                }
                else
                {
                    Console.WriteLine(i + " tek sayıdır.");
                }
            }




        }
    }
}

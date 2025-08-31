namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int secim;
            while (true)
            {
                Console.WriteLine("Restauranta Hoş Geldiniz....");
                Console.WriteLine("Ne yapmak istiyorsunuz ?");
                Console.WriteLine("Masaya oturmak için 1 Tuşuna Basınız. \nMenüyü Görmek için 2 Tuşuna Basınız...");
                Console.WriteLine("Yönetici Girişi için 3 Tuşuna Basınız...");
                string input = Console.ReadLine();
                if (int.TryParse(input, out secim))
                {
                    switch (secim)
                    {
                        case 1:                      
                            masa.gelenmüsteriler();
                            sepet.menüalım();
                            break;
                        case 2: // Müsteri geldiğinde menü listesini oturmadan kapıda görebilir.
                            menü.menügöster();
                            break;
                        case 3: // Admin menüsü yemek ekliyebilir, silebilir
                            try
                            {
                                giris.admingiris();
                                Console.WriteLine("Yemek Eklemek icin 1 tuşuna basın \nSilmek icin 2 Tuşuna basın");
                                input = Console.ReadLine();
                                if (int.TryParse(input, out secim))
                                {
                                    if (secim == 1)
                                    {
                                     
                                        menü.yemekekle();
                                    }
                                    else if (secim == 2)
                                    {
                                       
                                        menü.yemeksil();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("hatalı secim");
                                }
                            }
                            catch (UnauthorizedAccessException)
                            {
                                Console.Clear();
                                Console.WriteLine("Ana menüye dönülüyor...");
                            }
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Yanlış Seçim.");
                }
            }





        }
    }
}

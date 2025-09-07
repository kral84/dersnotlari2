using ConsoleApp7;
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
                Console.WriteLine("Restoya girmek icin 1 tuşuna basın");
                Console.WriteLine("Menü görmek icin 2 tuşuna basın");
                Console.WriteLine("admin giriş yemek icin 3 tuşuna basın");
                Console.WriteLine("admin giriş masa icin 4 tuşuna basın");
                Console.WriteLine("Rapor ve pazar işlemleri için 5 tuşuna basın");
                string input1 = Console.ReadLine();
                if (!int.TryParse(input1, out int secim))
                {
                    Console.WriteLine("Geçersiz giriş. Lütfen bir sayı girin.");
                    continue;
                }
                switch (secim)

                {
                    case 1:
                        pazar.pazaryiyecekal();
                        //masalar.gelenmüsteriler();
                        //menüler.menüsec();
                        break;
                    case 2:
                        menüler.yemekmenügöster();
                        menüler.icecekmenügöster();
                        break;

                    case 3:
                        admin.admingiris();
                        while (true)
                        {
                            Console.WriteLine("yemek silmek icin 1 tuşuna basın. \nYemek eklemek için 2 tuşuna basın. \nToplu silmek için 3 tuşuna basın. \nYemek Güncellemek için 4 tuşuna basın. \nİcecek ekle için 5 tuşuna basın. \nİcecek sil için 6 tuşuna basın. \nİcecek toplu sil için 7 tuşuna basın. \nİcecek güncelle için 8 tuşuna basın \nÇıkış için 9 tusuna basın.");
                            Console.WriteLine("icecek eklemek için 5 tuşuna basın.");
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
                            else if (secim1 == 5)
                            {
                                menüler.içecekekle();
                            }
                            else if (secim1 == 6)
                            {
                                menüler.iceceksilme();
                            }
                            else if (secim1 == 7)
                            {
                                menüler.icecektoplusil();
                            }
                            else if (secim1 == 8)
                            {
                                menüler.icecektgüncelle();
                            }
                        }
                        break;
                    case 4:
                        admin.admingiris();
                        while (true)
                        {
                            Console.WriteLine("masa silmek icin 1 tuşuna basın. \nMasa eklemek için 2 tuşuna basın. \nMasa silmek için 3 tuşuna basın. \nToplu masa sil için 4 tuşuna basın. \nMasa güncelle için 5 tuşuna basın. \nMasa bosalt için 6 tuşuna basın. \nToplu masa bosalt için 7 tuşuna basın \nÇıkış için 9 tusuna basın.");
                            string input = Console.ReadLine();
                            if (input == "9")
                            {
                                break;
                            }
                            if (!int.TryParse(input, out int secim2))
                            {
                                Console.WriteLine("Geçersiz giriş. Lütfen bir sayı girin.");
                                continue;
                            }
                            if (secim2 == 1)
                            {
                                masalar.masagöster();
                            }
                            else if (secim2 == 2)
                            {
                                masalar.masaekle();
                            }
                            else if (secim2 == 3)
                            {
                                masalar.masasil();
                            }
                            else if (secim2 == 4)
                            {
                                masalar.toplumasasil();
                            }
                            else if (secim2 == 5)
                            {
                                masalar.masagüncelle();
                            }

                            else if (secim2 == 6)
                            {
                                masalar.masabosalt();
                            }

                            else if (secim2 == 7)
                            {
                                masalar.toplumasabosalt();
                            }
                            else
                            {
                                Console.WriteLine("Geçersiz seçim.");
                            }
                            break;
                        }
                        break;
                    case 5:
                        admin.admingiris();
                        while (true)
                        {
                            Console.WriteLine("Rapor için 1 tuşuna basın. \nPazardan yiyecek almak için 2 tuşuna basın. \npazardan içecek almak için 3 tuşuna basın. \nÇıkış için 9 tusuna basın.");
                            string input = Console.ReadLine();
                            if (input == "9")
                            {
                                break;
                            }
                            if (!int.TryParse(input, out int secim3))
                            {
                                Console.WriteLine("Geçersiz giriş. Lütfen bir sayı girin.");
                                continue;
                            }
                            if (secim3 == 1)
                            {
                                menüler.SatilanlariYazdir();
                            }
                            if (secim3 == 2)
                            {
                                pazar.pazaryiyecekal();
                            }
                            if (secim3 == 3)
                            {
                                pazar.pazaricecekal();
                            }
                        }
                        break;
                }
            }
        }
    }
}

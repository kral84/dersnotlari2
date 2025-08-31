using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

//namespace manav
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {

//            ArrayList halmeyve = new ArrayList()  {
//    "Elma", "Armut", "Muz", "Çilek", "Kiraz",
//    "Portakal", "Karpuz", "Kavun", "Üzüm", "Erik"
//};
//            ArrayList halmeyvekilo = new ArrayList() {
//    5.0, 3.0, 4.5, 2.0, 1.5,
//    3.2, 10.0, 6.5, 2.8, 1.0
//};


//            ArrayList halsebze = new ArrayList()  {
//                "Domates", "Biber", "Salatalık", "Patlıcan", "Soğan",
//                "Sarımsak", "Lahana", "Karnabahar", "Havuç", "Ispanak"
//            };

//            ArrayList halsebzekilo = new ArrayList() {
//                2.0, 1.5, 3.0, 0.5, 1.2,
//                0.3, 2.5, 1.8, 1.0, 2.3
//            };
//            ArrayList manavsebze = new ArrayList();
//            ArrayList manavsebzekilo = new ArrayList();
//            ArrayList manavmeyve = new ArrayList();
//            ArrayList manavmeyvekilo = new ArrayList();

//            while (true)
//            {

//                Console.WriteLine("Manav uygulamasına hoş geldiniz.");
//                Console.WriteLine("Manav için (M) Hal için (H) ");
//                string secim = Console.ReadLine().ToLower();
//                if (secim == "h")
//                {
//                    while (true)
//                    {
//                        Console.WriteLine("hale hoş geldiniz. Meyve Reyonu için (M) Tuşuna basın. Sebze için (S) Tuşuna basın.");
//                        string secim2 = Console.ReadLine().ToLower();
//                        if (secim2 == "s")
//                        {
//                            Console.WriteLine("Sebze Reyonu");

//                            halsebze.Sort();
//                            for (int i = 0; i < halsebze.Count; i++)
//                            {
//                                Console.WriteLine($"{i + 1} . {halsebze[i]} - {halsebzekilo[i]}");
//                            }
//                            while (true)
//                            {
//                                Console.WriteLine("Hangi Sebzeyi almak istiyorsunuz, ismini yazarak seçiniz.");
//                                string meyveSecim = Console.ReadLine();
//                                int secilenindex = -1;
//                                for (int i = 0; i < halsebze.Count; i++)
//                                {
//                                    if (halsebze[i].ToString().ToLower() == meyveSecim.ToLower())
//                                    {
//                                        secilenindex = i;
//                                        break;
//                                    }
//                                }
//                                if (secilenindex == -1)
//                                {
//                                    Console.WriteLine("Lütfen geçerli bir sebze ismi giriniz.");
//                                    continue;
//                                }
//                                double secilenkilo = Convert.ToDouble(halsebzekilo[secilenindex]);
//                                Console.WriteLine($"Seçilen {halsebze[secilenindex]} - {halsebzekilo[secilenindex]} kaç kilo almak istiyorsunuz? ");
//                                string kilo = Console.ReadLine();
//                                if (!double.TryParse(kilo, out double alınankilo) || alınankilo <= 0)
//                                {
//                                    Console.WriteLine("Lütfen geçerli bir kilo giriniz.");
//                                }
//                                else if (secilenkilo < alınankilo)
//                                {
//                                    Console.WriteLine($"Üzgünüz, {halsebze[secilenindex]} için yeterli stok yok. Mevcut stok: {secilenkilo} kilo.");
//                                }
//                                else
//                                {
//                                    double yenidurum = secilenkilo - alınankilo;
//                                    halsebzekilo[secilenindex] = yenidurum;
//                                    Console.WriteLine($"alınan ürün {halsebze[secilenindex]}, alınan kilo {alınankilo} ");
//                                    Console.WriteLine($"Kalan stok: {halsebzekilo[secilenindex]} kilo.");
//                                    manavsebze.Add(halsebze[secilenindex]);
//                                    manavsebzekilo.Add(alınankilo);
//                                    if (yenidurum == 0)
//                                    {
//                                        halsebze.RemoveAt(secilenindex);
//                                        halsebzekilo.RemoveAt(secilenindex);
//                                    }
//                                    Console.WriteLine("güncel meyve listesi");
//                                    for (int j = 0; j < halsebze.Count; j++)
//                                    {
//                                        Console.WriteLine($"{j + 1} . {halsebze[j]} - {halsebzekilo[j]}");
//                                    }
//                                }
//                                string devam;
//                                do
//                                {
//                                    Console.WriteLine("Başka bir sebze almak istiyor musunuz? (E/H)");
//                                    devam = Console.ReadLine().ToLower();
//                                    if (devam != "e" && devam != "h")
//                                    {
//                                        Console.WriteLine("Lütfen sadece 'E' veya 'H' giriniz.");
//                                    }
//                                } while (devam != "e" && devam != "h");
//                                if (devam != "e")
//                                {
//                                    Console.WriteLine("Aldığınız Meyveler:");
//                                    for (int i = 0; i < manavsebze.Count; i++)
//                                    {
//                                        Console.WriteLine($"- {manavsebze[i]}: {manavsebzekilo[i]} kg");
//                                    }
//                                    break;
//                                }
//                            }
//                        }
//                        else if (secim2 == "m")
//                        {
//                            Console.WriteLine("Meyve Reyonu");
//                            halmeyve.Sort();
//                            for (int i = 0; i < halmeyve.Count; i++)
//                            {
//                                Console.WriteLine($"{i + 1} . {halmeyve[i]} - {halmeyvekilo[i]} kilo ");
//                            }
//                            while (true)
//                            {
//                                Console.WriteLine("Hangi Meyveyi almak istiyorsunuz, ismini yazarak seçiniz.");
//                                string meyveSecim = Console.ReadLine();
//                                int secilenindex = -1;
//                                for (int i = 0; i < halmeyve.Count; i++)
//                                {
//                                    if (halmeyve[i].ToString().ToLower() == meyveSecim.ToLower())
//                                    {
//                                        secilenindex = i;
//                                        break;
//                                    }
//                                }
//                                if (secilenindex == -1)
//                                {
//                                    Console.WriteLine("Geçerli meyme ismi girin.");
//                                    continue;
//                                }
//                                double yenistok = Convert.ToDouble(halmeyvekilo[secilenindex]);
//                                Console.WriteLine($"seçilen ürün {halmeyve[secilenindex]} kaç kilo istiyorsunuz ?");
//                                string kilo = Console.ReadLine();
//                                if (!double.TryParse(kilo, out double girilenkilo) || girilenkilo <= 0)
//                                {
//                                    Console.WriteLine("Lütfen geçerli bir kilo giriniz.");
//                                }
//                                else if (girilenkilo > yenistok)
//                                {
//                                    Console.WriteLine($"Üzgünüz, {halmeyve[secilenindex]} için yeterli stok yok. Mevcut stok: {yenistok} kilo.");
//                                }
//                                else
//                                {
//                                    double yenidurum = yenistok - girilenkilo;
//                                    halmeyvekilo[secilenindex] = yenidurum;
//                                    Console.WriteLine($"alınan ürün {halmeyve[secilenindex]} - {girilenkilo} kg ");
//                                    Console.WriteLine($"Kalan stok: {halmeyve[secilenindex]} - {halmeyvekilo[secilenindex]} kilo.");
//                                    manavmeyve.Add(halmeyve[secilenindex]);
//                                    manavmeyvekilo.Add(girilenkilo);
//                                    if (yenidurum == 0)
//                                    {
//                                        halmeyve.RemoveAt(secilenindex);
//                                        halmeyvekilo.RemoveAt(secilenindex);
//                                    }
//                                    for (int j = 0; j < halmeyve.Count; j++)
//                                    {
//                                        Console.WriteLine($"{j + 1} . {halmeyve[j]} - {halmeyvekilo[j]} kilo ");
//                                    }
//                                }
//                                string devam;
//                                do
//                                {
//                                    Console.WriteLine("Başka bir meyve almak istiyor musunuz? (E/H)");
//                                    devam = Console.ReadLine().ToLower();

//                                    if (devam != "e" && devam != "h")
//                                    {
//                                        Console.WriteLine("Lütfen sadece 'E' veya 'H' giriniz.");
//                                    }

//                                } while (devam != "e" && devam != "h");

//                                if (devam == "h")
//                                {
//                                    Console.WriteLine("Aldığınız Meyveler:");
//                                    for (int i = 0; i < manavmeyve.Count; i++)
//                                    {
//                                        Console.WriteLine($"- {manavmeyve[i]}: {manavmeyvekilo[i]} kg");
//                                    }
//                                    break;
//                                }

//                            }

//                        }
//                        else
//                        {
//                            Console.WriteLine("Lütfen geçerli bir seçim yapınız.");
//                        }
//                        break;
//                    }

//                }

//                else if (secim == "m")
//                {
//                    Console.WriteLine("Manava hoş geldiniz.");
//                }
//                else
//                {
//                    Console.WriteLine("Lütfen geçerli bir seçim yapınız.");
//                }

//            }



using OTOMAT_PROJESİ;


namespace manav
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sayi1;
            while (true)
            {
                Console.Write("1. sayıyı gir: ");
                string girdi = Console.ReadLine();
                if (int.TryParse(girdi, out sayi1))
                    break;

                Console.WriteLine("Geçerli bir tam sayı gir.");
            }

            int sayi2;
            while (true)
            {
                Console.Write("2. sayıyı gir: ");
                string girdi = Console.ReadLine();
                if (int.TryParse(girdi, out sayi2))
                    break;

                Console.WriteLine("Geçerli bir tam sayı gir.");
            }

            int sonuc = denemeler.mat(sayi1, sayi2);

            Console.WriteLine("Toplam: " + sonuc);
        }
    }
}

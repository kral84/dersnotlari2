using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class masalar
    {
        public int masano;
        public bool dolumu = false;
        public int kisisayisi;
        public string örnek;

        public static List<masalar> masa = new List<masalar>()
        {
            new masalar {masano = 1, kisisayisi = 1 , dolumu =false, örnek = "örnek1"},
            new masalar {masano = 2, kisisayisi = 2 , dolumu =false,örnek = "örnek2"},
            new masalar {masano = 3, kisisayisi = 3 , dolumu =false,örnek = "örnek3"},
            new masalar {masano = 4, kisisayisi = 4 , dolumu =false,örnek = "örnek4"},
        };

        public static void masagöster()
        {
            Console.WriteLine("masalar");

            foreach (masalar m in masa)
            {
                Console.WriteLine($"Masa Numarası {m.masano} Kişi sayısı {m.kisisayisi} Masa dolumu {m.dolumu} örneksilmekicin {m.örnek}");
            }
        }
        public static void müsterininmasası()
        {
            Console.WriteLine("kaç kişisiniz");
            string input = Console.ReadLine();
            if (input == "9")
            {
                return;
            }
            if (int.TryParse(input, out int secim))
            {
                masalar masauygunmu = null;
                for (int i = 0; i < masa.Count; i++)
                {
                    if (masa[i].kisisayisi >= secim && masa[i].dolumu == false)
                    {
                        if (masauygunmu == null || masauygunmu.kisisayisi > masa[i].kisisayisi)
                        {
                            masauygunmu = masa[i];
                        }
                    }
                }
                if (masauygunmu != null)
                {
                    Console.WriteLine($"masaya gec {masauygunmu.masano} kapasitesi {masauygunmu.kisisayisi}");
                    masauygunmu.dolumu = true;
                    return;
                }

            }

        }
        public static void masaekle()
        {
            masagöster();
            masalar yenimasa = new masalar();
            Console.WriteLine("Kaç kişilik masa eklencek");
            string input = Console.ReadLine();
            if (input == "9")
            {
                return;
            }
            if (int.TryParse(input, out int secim))
            {
                yenimasa.kisisayisi = secim;
                int cak = masa.Count + 1; 
                while (true)
                {

                    bool cakısmavar = false;
                    foreach (masalar m in masa)
                    {
                        if (m.masano == cak)
                        {
                            cakısmavar = true;
                            cak++;
                            break;
                        }
                    }
                    if (!cakısmavar) break;                  
                }
                yenimasa.masano = cak;
                masa.Add(yenimasa);
                Console.WriteLine($"masa eklendi {yenimasa.masano} sayısı {yenimasa.kisisayisi}");
            }
        }
        public static void masagüncelle()
        {
            int secim = 0;
            masagöster();
            Console.WriteLine("hangi masa no sectin");
            string input = Console.ReadLine();
            if (input == "9")
            {
                return;
            }
            if (!string.IsNullOrEmpty(input))
            {
                if (int.TryParse(input, out secim))
                {
                    if (secim > 0 && secim <= masa.Count)
                    {
                        Console.WriteLine("numara ne olsun");
                        string yeninoo = Console.ReadLine();
                        if (string.IsNullOrEmpty(yeninoo))
                        {
                            Console.WriteLine("Numara değiştirilmedi.");
                        }
                        else if (int.TryParse(yeninoo, out int yenino))
                        {

                            masa[secim - 1].masano = yenino;
                            Console.WriteLine($"masa numarası {yenino} olarak güncellendi");
                        }

                    }
                    else
                    {
                        Console.WriteLine("hata");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("hata");
                }
                Console.WriteLine("kac kisilik masa olcak");
                int yenikisi = Convert.ToInt32(Console.ReadLine());
                masa[secim - 1].kisisayisi = yenikisi;
                Console.WriteLine($"yeni masa kişi sayısı{yenikisi}");
            }
            else
            {
                Console.WriteLine("degisiklik yapılmadı.");
                return;
            }
        }
        public static void masasil()
        {
            masagöster();
            Console.WriteLine("hangi masayı sileceksiniz.");
            string input = Console.ReadLine();
            if (input == "9")
            {
                return;
            }
            if (!string.IsNullOrEmpty(input))
            {
                if (int.TryParse(input, out int masasil))
                {
                    masa.RemoveAt(masasil - 1);
                    Console.WriteLine("masa silindi.");

                }
            }
            else
            {
                Console.WriteLine("degisiklik yapılmaıd");
                return;
            }
        }
        public static void masasilisim()
        {
            masagöster();
            Console.WriteLine("silinecek masa no nedir");
            string input = Console.ReadLine();
            if (input == "9")
            {
                return;
            }
            if (int.TryParse(input, out int input1))
            {
                for (int i = 0; i < masa.Count; i++)
                {
                    if (masa[i].masano == input1)
                    {
                        masa.Remove(masa[i]);
                        Console.WriteLine($"silindi.{input1}");
                        return;
                    }
                }
            }
        }
        public static void masasilkisisayisi()
        {
            masagöster();
            Console.WriteLine("örneklerden silmeye calıs");
            string input = Console.ReadLine();
            for (int i = 0; i < masa.Count; i++)
            {
                if (masa[i].örnek == input)
                {
                    masa.Remove(masa[i]);
                    Console.WriteLine($"silindi.{input}");
                    return;
                }
            }
            Console.WriteLine("slinmedi");
        }

    }

}

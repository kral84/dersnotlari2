using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Threading; 

namespace ConsoleApp6
{
    internal class giris
    {
        public static string kullanıcı_adı = "resto";
        public static string sifre = "123";
        public static int Hak=3;

        public static void admingiris()
        {
            bool ok = giris1();
            if (ok)
            {
                Console.WriteLine("Giris basarılı");
            }
            else
            {
                Console.WriteLine("Giriş başarısız. Ana menüye dönülüyor...");
                throw new UnauthorizedAccessException("Giriş başarısız");
            }
        }
        public static bool giris1()
        {
            while (Hak >0)
            {
                Console.WriteLine("Giriş yapmak için kullanıcı adını yazınız.");
                string giris = Console.ReadLine();
                
                if (giris != kullanıcı_adı)
                {
                    Hak--;
                    Console.WriteLine("Kullanıcı adı hatalı");                  
                    Console.WriteLine($"Kullanıcı adı hatalı. Kalan hak: {Hak}");
                    continue;

                }
                Console.WriteLine("Giriş yapmak için şifrenizi yazınız.");
                string kullanıcı_sifre = Console.ReadLine();
                if (kullanıcı_sifre != sifre)
                {
                    Hak--; 
                    Console.WriteLine("Sifre hatalı");
                    continue;
                    
                }
                else if (kullanıcı_adı == giris && sifre == kullanıcı_sifre)
                {
                    Console.WriteLine("Giriş başarılı");
                    Console.Clear();
                    return true;
                   
                }
                else
                {
                    Console.WriteLine("Bilinmeyen hata");
                    break;
                }
            }
            if (Hak == 0) 
            {
                Console.WriteLine("Hesap kilitlendi. 10 saniye");
                Thread.Sleep(10000);
               
                
            }
            Console.Clear();
            return false;

        }
    }
}


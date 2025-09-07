using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp7.menüler;

namespace ConsoleApp7
{
    internal class admin
    {
        public static string kullanıcıadı = "resto";
        public static int kullanıcısifre = 123;

        public static void admingiris()
        {
            bool girisbasarılı = giris1();
            if (girisbasarılı)
            {
                Console.WriteLine("Giriş başarılı");
            }
            else
            {
                Console.WriteLine("Giriş başarısız. Ana menüye dönülüyor...");
                return;
            }
        }
        public static bool giris1()
        {
            Console.WriteLine("Kullanıcı adını giriniz:");
            string kullanıcıadı1 = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(kullanıcıadı1))
            {
                Console.WriteLine("Kullanıcı adı boş olamaz.");
                return false;
            }
            if (kullanıcıadı1 != kullanıcıadı)
            {
                Console.WriteLine("Kullanıcı adı hatalı");
                return false;
            }
            Console.WriteLine("Şifreyi giriniz:");
            string sifre = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(sifre))
            {
                Console.WriteLine("Şifre boş olamaz.");
                return false;
            }
            if (!int.TryParse(sifre, out int dogrusifre))
            {
                Console.WriteLine("sayıdan oluşur");
            }
;           if (dogrusifre != kullanıcısifre)
            {
                Console.WriteLine("Şifre hatalı");
                return false;
            }
            return true;


        }
}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rado = new Random();
            int fr1 = 0;
            int fr2 = 0;
            int fr3 = 0;
            int fr4 = 0;
            int fr5 = 0;
            int fr6 = 0;

            for (int i = 0; i < 60000000; i++)
            {
                int yüz = rado.Next(1, 7); // 1 dahil 7 dahil değil
                switch (yüz)
                {
                    case 1:
                        ++fr1;
                        break;
                    case 2:
                        ++fr2;
                        break;
                    case 3:
                        ++fr3;
                        break;
                    case 4:
                        ++fr4;      
                        break;
                    case 5:
                        ++fr5;
                        break;
                    case 6:
                        ++fr6;
                        break;
                }
            }
            Console.WriteLine("1 gelme sayısı: " + fr1);
            Console.WriteLine("2 gelme sayısı: " + fr2);
            Console.WriteLine("3 gelme sayısı: " + fr3);
            Console.WriteLine("4 gelme sayısı: " + fr4);
            Console.WriteLine("5 gelme sayısı: " + fr5);
            Console.WriteLine("6 gelme sayısı: " + fr6);
            
        }
    }
}

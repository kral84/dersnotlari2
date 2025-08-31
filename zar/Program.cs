using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zar
{
    internal class Program
    {
        public static void zarhesabırandaom()

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
                int yüz = new Random().Next(1, 7); // 1 dahil 7 dahil değil
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
        }
}
}
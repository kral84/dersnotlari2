using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class masa
    {
        public int masaNo;
        public int kapasite;
        public bool doluMu;
        public static List<masa> varsayilan = new List<masa>
        {
            new masa { masaNo = 1, kapasite = 1, doluMu = false },
            new masa { masaNo = 2, kapasite = 2, doluMu = false },
            new masa { masaNo = 3, kapasite = 3, doluMu = false },
            new masa { masaNo = 4, kapasite = 4, doluMu = false },
            new masa { masaNo = 5, kapasite = 5, doluMu = false }
        };
        public static void MasalariListele()
        {
            Console.WriteLine("\n--- MASALAR ---");
            foreach (var m in varsayilan)
            {
                Console.WriteLine($"Masa {m.masaNo} | Kapasite: {m.kapasite} | Dolu mu: {m.doluMu}");
            }
        }
        public static void gelenmüsteriler()
        {
            while (true)
            {
                masa.MasalariListele();
                Console.WriteLine("kaç kişisiniz ????");
                int kisisayısı = Convert.ToInt32(Console.ReadLine());                
                masa enuygunmasa = null;
                for (int i = 0; i < varsayilan.Count; i++)
                {
                    if (!varsayilan[i].doluMu && varsayilan[i].kapasite >= kisisayısı)
                    {
                        if (enuygunmasa == null || varsayilan[i].kapasite < enuygunmasa.kapasite)
                        {
                            enuygunmasa = varsayilan[i];
                        }
                    }
                }
                if (enuygunmasa != null)
                {
                    Console.WriteLine($"masa {enuygunmasa.masaNo} size verildi. Kapasiste {enuygunmasa.kapasite}");
                    enuygunmasa.doluMu = true;
                    break;
                }
                else
                {
                    Console.WriteLine($"uygun masa bulunamadı. {kisisayısı}");
                }
            }
        }

    }


}

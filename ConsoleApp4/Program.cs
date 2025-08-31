using System.Collections;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList sayılar = new ArrayList();
            ArrayList ciftsayılar = new ArrayList();
            ArrayList tekSayılar = new ArrayList();

            Random rastgele = new Random();

            for (int i = 0; i < 15; i++)
            {
                int rastgeleSayı = rastgele.Next(1, 1001); // 1 ile 1000 arasında rastgele sayı üret
                sayılar.Add(rastgeleSayı); // Sayıyı sayılar listesine ekle
                foreach (int s in sayılar)
                {
                    if (s % 2 == 0)
                        ciftsayılar.Add(s);
                    else
                        tekSayılar.Add(s);
                }
            }
            Console.WriteLine("Rastgele Sayılar: " + string.Join(", ", sayılar.ToArray()));
        }
    }
}

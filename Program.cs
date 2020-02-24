using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szallitmanyozas
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rendszamok = { "ABC-123", "ABC-124", "ABC-125", "ABC-126", "ABC-127", "ABC-128", "ABC-129", "ABC-130", "ABC-131", "ABC-132" };
            List<string> bent = new List<string>();
            string valasztas;
            do
            {
                Console.WriteLine("---------------------/*-M-E-N-Ü-*/--------------------");
                Console.WriteLine("Kimegy (K)");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Bejön (B)");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Kilépés (Q)");
                Console.WriteLine("----------------------------------------------");
                //A választási lehetőségek
                valasztas = Console.ReadLine();
                //A választás bekérés
                switch (valasztas)
                {
                    case "K": kimegy(rendszamok, bent); break;
                    case "B": bejon(rendszamok, bent); break;
                    case "Q": kilepes(); break;
                    default: Console.WriteLine("Nem megfelelő választás!"); break;
                }
            } while (valasztas != "Q");
            Console.ReadKey();
        }

        private static void kimegy(string[] rendszamok, List<string> bent)
        {
            if (bent.Count == 0)
            {
                Console.WriteLine("Nincs autó a telepen");
            }
            else
            {
                Console.Write($"Jelenleg {bent.Count} autó van a telepen. Ezek a következők:(");
                foreach (var item in bent)
                {
                    Console.Write($"{item}, ");
                }
                Console.Write(" )");
                Console.WriteLine(" Kérem a kiléptetendő autó rendszámát");

                string kilepo = Console.ReadLine();
                string nagybetus = kilepo.ToUpper();
                bool bentvan = false;
                for (int i = 0; i < bent.Count; i++)
                {
                    if (bent.Contains(kilepo))
                    {
                        bentvan = true;
                        break;
                    }
                }
                if (bentvan)
                {
                    bent.Remove(kilepo);
                    Console.WriteLine($"Sikeresen kiléptette a(z) {kilepo} rendszámú autót!");
                }
                else
                {
                    Console.WriteLine($"Sikertelen kilépés! A(z) {kilepo} rendszámú autó nincs bent a cégen belül!");

                }
            }

        }

        private static void kilepes()
        {
            Console.WriteLine("Köszönöm, hogy használta a programot. Viszlát!");
        }

        static void bejon(string[] rendszamok, List<string> bent)
        {
            Console.WriteLine($"Jelenleg {bent.Count} autó van a telepen.");
            foreach (var item in bent)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
            Console.WriteLine("Adja meg a rendszámot:");
            bool tartalmaz = false;
            bool bentvan = false;
            string megadott = Console.ReadLine();
            if (rendszamok.Contains(megadott))
            {
                tartalmaz = true;
                Console.WriteLine("A rendszám bent van az adatbázisban");
            }
            else
            {
                Console.WriteLine("Nincs bent az adatbázisban");
            }
            for (int i = 0; i < bent.Count; i++)
            {
                if (megadott == rendszamok[i])
                {
                    bentvan = true;
                    Console.WriteLine("Az autó bent van a telepen nem jöhet be!");
                    break;
                }
            }
            if (tartalmaz && !bentvan)
            {
                bent.Add(megadott);
                Console.WriteLine("Hozzáadva a bent lévő autókhoz.");
            }
        }
    }
}

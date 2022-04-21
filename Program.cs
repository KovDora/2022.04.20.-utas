using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace _2022._04._20.utas
{
    class Program
    {
        class Adat
        {
            public string sorszam;
            public DateTime felszallas;
            public string kartya;
            public string tipus;
            public DateTime berlet_ervenyesseg;
            public int jegy_db;

            public Adat(string[] sortömb)
            {
                this.sorszam = sortömb[0];
                string[] ehn_op = sortömb[1].Split('-');
                string ehn = ehn_op[0];
                string op = ehn_op[1];

                this.felszallas = new DateTime(
                    int.Parse(ehn.Substring(0, 4)),
                    int.Parse(ehn.Substring(4, 2)),
                    int.Parse(ehn.Substring(6, 2)),
                    int.Parse(op.Substring(0, 2)),
                    int.Parse(op.Substring(2, 2)),
                    0 // ez itt a másodperc
                    );
                this.kartya = sortömb[2];
                this.tipus = sortömb[3];

                if (int.Parse(sortömb[4])>10)
                {
                    ehn = sortömb[4];
                    this.berlet_ervenyesseg = new DateTime(
                        int.Parse(ehn.Substring(0, 4)),
                        int.Parse(ehn.Substring(4, 2)),
                        int.Parse(ehn.Substring(6, 2)));
                    this.jegy_db = -1;
                }
                else
                {
                    this.jegy_db = int.Parse(sortömb[4]);
                }
                //innen folytatjuk
            }
        }
        static int nincsjegy(List<Adat>lista)
        {
            int db = 0;
            foreach (Adat elem in lista)
            {
                if (elem.jegy_db == 0)
                {
                    db++;
                }

            }
            return db;
        }

        static int lejartberlet(Adat a)
        {
            if (a.tipus!="JGY")
            {
                if (a.felszallas.CompareTo(a.berlet_ervenyesseg)==1)
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            // beolvasás
            string[] sorok = File.ReadAllLines("utasadat.txt", Encoding.UTF8);
            List<Adat> lista = new List<Adat>();
            foreach (string sor in sorok)
            {
                string[] sortömb = sor.Split(' ');
                Adat t = new Adat(sortömb);
                lista.Add(t);
            }
            Console.WriteLine("1. feladat");
            Console.WriteLine(lista.Count);
            /*
            {
                Console.WriteLine("1,5 feladat(nem hivatalos) Kik utaznak jeggyel és kik bérlettel?");
                foreach (Adat elem in lista)
                {
                    if (elem.jegy_db != -1)
                    {
                        Console.WriteLine($"{elem.kartya} utas ennyi jeggyel utazott{elem.jegy_db}");
                    }
                }
                Console.WriteLine("1,75 Kik utaznak bérlettel?");
                foreach (Adat elem in lista)
                {
                    if (elem.berlet_ervenyesseg != new DateTime(1, 1, 1, 0, 0, 0))
                    {
                        Console.WriteLine($"{elem.kartya} utas ennyi bérlettel utazott{elem.berlet_ervenyesseg}");
                    }
                }
            }
            */
            //Dictionary<string, int> szotar = new Dictionary<string, int>();
            {
                Console.WriteLine("3. feladat");
                Console.WriteLine("Hány esetben volt, hogy nem mehetett, mert nem volt jegye vagy mert lejárt a bérlete. Az aznapi nap is számít jónak a bérletnél.");
                int db = 0;
                foreach (Adat elem in lista)
                {
                    if (elem.jegy_db == 0)
                    {
                        db++;
                    }

                }
                int db2 = 0;
                foreach (Adat elem in lista)
                {
                    if (elem.berlet_ervenyesseg == new DateTime())
                    {
                        db++;
                    }

                }
            }



            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Program
    {
        static void Main(string[] args)
        {
            //TestOpdracht2();
            //TestOpdracht3();
            TestOpdracht8();
          
        }

        private static void TestOpdracht8()
        {
            var waterskibaan = new Waterskibaan();
            var sp = new Sporter() { Skies = new Skies(), Zwemvest = new Zwemvest() };

            try
            {
                waterskibaan.SporterStart(sp);
            }
            catch (Exception e)
            {
                throw new Exception($"Een sporter behoort een Zwemvest EN Skies te hebben!{ e.Message}");
            }
        }


        /* private static void TestOpdracht2()
         {
             Kabel kabel = new Kabel();

             if (kabel.IsStartPositieLeeg())
             {
                 kabel.NeemLijnInGebruik(new Lijn());
                 Console.WriteLine(kabel);
                 kabel.VerschuifLijnen();
                 Console.WriteLine(kabel);
                 kabel.NeemLijnInGebruik(new Lijn());
                 Console.WriteLine(kabel);
                 kabel.VerschuifLijnen();
                 kabel.NeemLijnInGebruik(new Lijn());
                 kabel.VerschuifLijnen();
                 kabel.NeemLijnInGebruik(new Lijn());
                 kabel.VerschuifLijnen();
                 Console.WriteLine(kabel);
                 kabel.VerschuifLijnen();
                 kabel.VerschuifLijnen();
                 kabel.NeemLijnInGebruik(new Lijn());
                 kabel.VerschuifLijnen();
                 Console.WriteLine(kabel);
                 kabel.VerschuifLijnen();
                 kabel.VerschuifLijnen();
                 Console.WriteLine(kabel);
                 kabel.VerschuifLijnen();
                 Console.WriteLine(kabel);
             }
         }*/
        /*private static void TestOpdracht3()
        {
            LijnenVoorraad queue = new LijnenVoorraad();
            queue.LijnToevoegenAanRij(new Lijn { PositieOpDeKabel = 1 });
            queue.LijnToevoegenAanRij(new Lijn { PositieOpDeKabel = 2 });
            queue.LijnToevoegenAanRij(new Lijn { PositieOpDeKabel = 3 });
            queue.LijnToevoegenAanRij(new Lijn { PositieOpDeKabel = 4 });
            queue.LijnToevoegenAanRij(new Lijn { PositieOpDeKabel = 5 });
            queue.LijnToevoegenAanRij(new Lijn { PositieOpDeKabel = 6 });
            Console.WriteLine(queue.GetAantalLijnen());
            queue.VerwijderEersteLijn();
            Console.WriteLine(queue.GetAantalLijnen());
        }*/
      
    }
}

/*
 * Waterskibaan Project
 * Door: Maaike van der Jagt
 * ICTSE1a
 * 2019
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan.Games
{
    public class VerplaatsLijnenArgs : Game
    {
        public readonly LinkedList<Lijn> Lijnen;

        public readonly LijnenVoorraad LijnenVoorraad;

        public int SportersKlaarVoorStart { get; set; }

        public VerplaatsLijnenArgs(LinkedList<Lijn> lijnen, LijnenVoorraad lijnenVoorraad)
        {
            Lijnen = lijnen;
            LijnenVoorraad = lijnenVoorraad;
        }

    }
}

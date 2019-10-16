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


namespace Waterskibaan
{
    public class Kabel
    {
        internal LinkedList<Lijn> _lijnen = new LinkedList<Lijn>() { };

        public bool IsStartPositieLeeg()
        {
            return _lijnen.First == null || _lijnen.First.Value.PositieOpDeKabel != 0;

        }

        public void NeemLijnInGebruik(Lijn lijn)
        {
            if (IsStartPositieLeeg())
            {
                _lijnen.AddFirst(lijn);
                lijn.PositieOpDeKabel = 0;
            }

        }

        public void VerschuifLijnen()
        {
            var laatsteLijnTerugNaarStart = false;
            foreach (var lijn in _lijnen)
            {
                lijn.PositieOpDeKabel++;

                if (lijn.PositieOpDeKabel == 10)
                {
                    lijn.PositieOpDeKabel = 0;
                    laatsteLijnTerugNaarStart = true;
                    // ronde eraf
                    lijn.Sporter.AantalRondenNogTeGaan--;


                }
            }
            //terug naar af omdat lijnen in volgorde van positie moeten staan
            if (laatsteLijnTerugNaarStart)
            {
                var laaststelijn = _lijnen.Last.Value;
                _lijnen.RemoveLast();
                _lijnen.AddFirst(laaststelijn);
            }

        }

        public Lijn VerwijderLijnVanKabel()
        {
            var laatstelijn = _lijnen.Last;

            if (laatstelijn != null && laatstelijn.Value.PositieOpDeKabel == 9 && laatstelijn.Value.Sporter.AantalRondenNogTeGaan == 1)
            {
                var verwijderdelijn = _lijnen.Last.Value;
                verwijderdelijn.Sporter = null;


                _lijnen.RemoveLast();
                return verwijderdelijn;
            }

            return null;
        }


        private string printLijst()
        {
            string kabellijst = "";
            foreach (Lijn lijn in _lijnen)
            {
                kabellijst = kabellijst + lijn.PositieOpDeKabel + "|";
            }
            if (kabellijst.Length > 0)
            {
                kabellijst = kabellijst.Remove(kabellijst.Length - 1);
            }
            return kabellijst;

        }



        public override string ToString()
        {
            return printLijst();
        }
    }
}

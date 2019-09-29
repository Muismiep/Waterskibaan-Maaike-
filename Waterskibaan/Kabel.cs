using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Waterskibaan
{
    public class Kabel
    {
        private LinkedList<Lijn> _lijnen = new LinkedList<Lijn>() { };

        public bool IsStartPositieLeeg()
        {
            bool appel = true;
            foreach (Lijn lijn in _lijnen)
            {
                if (lijn.PositieOpDeKabel == 0)
                {
                    appel = false;
                }
                else
                {
                    appel = true;
                }
            }
            return appel;

        }
        public void NeemLijnInGebruik(Lijn lijn)
        {
            if (IsStartPositieLeeg() == true)
            {
                _lijnen.AddFirst(lijn);
                lijn.PositieOpDeKabel = 0;
            }

        }
        public void VerschuifLijnen()
        {
            foreach (Lijn lijn in _lijnen)
            {
                lijn.PositieOpDeKabel += 1;

                if (lijn.PositieOpDeKabel == 10)
                {
                    lijn.PositieOpDeKabel = 0;
                    lijn.Sporter.AantalRondenNogTeGaan--;
                }
            }
            /*if (_lijnen.Last.Value.PositieOpDeKabel == 10)
            {
                //TODO chance last to positie op de kabel 10 als het nodig is.
                _lijnen.Last.Value.PositieOpDeKabel = 0;
                _lijnen.AddFirst(_lijnen.Last.Value);
                _lijnen.RemoveLast();
            }*/
        }
        public Lijn VerwijderLijnVanKabel()
        {
            
                foreach (Lijn lijn in _lijnen)
                {
                    if (lijn.PositieOpDeKabel == 10 && lijn.Sporter.AantalRondenNogTeGaan == 1)
                    {
                        _lijnen.Remove(lijn);
                        return lijn;
                    }
                }
                return null;
            

            /*if (_lijnen.Last.Value.PositieOpDeKabel == 9)
            {
                //TODO chance last to positie op de kabel 10 als het nodig is.
                Lijn lijn = _lijnen.Last.Value;
                _lijnen.RemoveLast();
                return lijn;
            }
            else
            {
                return null;
            }*/
        }


        private string printLijst()
        {
            String banaan = "";
            foreach (Lijn lijn in _lijnen)
            {
                banaan = banaan + lijn.PositieOpDeKabel + "|";
            }
            banaan = banaan.Remove(banaan.Length - 1);
            return banaan;

        }



        public override string ToString()
        {
            return printLijst();
        }
    }
}

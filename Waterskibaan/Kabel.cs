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
            foreach (Lijn lijn in _lijnen)
            {
                if (lijn.PositieOpDeKabel == 0)
                {
                    return false;
                }
            }
            return true;

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
        }
        public Lijn VerwijderLijnVanKabel()
        {
            
                foreach (Lijn lijn in _lijnen)
                {
                    if (lijn.PositieOpDeKabel == 0 && lijn.Sporter.AantalRondenNogTeGaan == 1)
                    {
                        _lijnen.Remove(lijn);
                        return lijn;
                    }
                }
                return null;
        }


        private string printLijst()
        {
            string banaan = "";
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

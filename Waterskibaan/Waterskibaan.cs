using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Waterskibaan
    {
        private LijnenVoorraad _lijnenVoorraad;
        public Kabel _kabel;

        public Waterskibaan()
        {
            Lijn lijn = new Lijn();

            _lijnenVoorraad = new LijnenVoorraad();

            for (int i = 0; i < 15; i++)
            {
                _lijnenVoorraad.LijnToevoegenAanRij(new Lijn());
            }
        }

        public void SporterStart(Sporter sp)
        {
            if (_kabel.IsStartPositieLeeg() == true)
            {
                var rand = new Random();
                int aantalRondjes = rand.Next(1, 2);
                sp.AantalRondenNogTeGaan = aantalRondjes;
                var getLijn = _lijnenVoorraad.VerwijderEersteLijn();

                getLijn.Sporter = sp;


                _kabel.NeemLijnInGebruik(getLijn);
            }
            else
            {
                return;
            }

        }

        public void VerplaatsKabel()
        {
            _kabel.VerschuifLijnen();
            _lijnenVoorraad.LijnToevoegenAanRij(new Lijn());
        }

        public override string ToString()
        {
            return $"Lijnvoorraad: {_lijnenVoorraad.ToString()}\nKabelbezetting: {_kabel.ToString()}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Waterskibaan
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

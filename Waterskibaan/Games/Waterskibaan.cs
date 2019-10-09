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
        public Kabel _kabel = new Kabel();
        private Random _random = new Random();

        public Waterskibaan()
        {
            _lijnenVoorraad = new LijnenVoorraad();

            for (int i = 0; i < 15; i++)
            {
                _lijnenVoorraad.LijnToevoegenAanRij(new Lijn());
            }
        }

        public void SporterStart(Sporter sp)
        {
            if (sp.Zwemvest == null || sp.Skies == null)
            {
                throw new Exception("Een sporter behoort een Zwemvest EN Skies te hebben!");
            }

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
            var verwijderdelijn = _kabel.VerwijderLijnVanKabel();
            if (verwijderdelijn != null)
            {
                _lijnenVoorraad.LijnToevoegenAanRij(verwijderdelijn);
            }
        }
        public void MoveUitvoeren()
        {
            foreach (var lijn in _kabel._lijnen)
            {
                var sporter = lijn.Sporter;

                if (sporter.Moves.Count > 0 && _random.Next(100) > 75)
                {
                    sporter.HuidigeMove = sporter.Moves.Last();
                    IMoves temp = sporter.HuidigeMove;
                    sporter.AantalbehaaldePunten = sporter.AantalbehaaldePunten + temp.Move();
                    sporter.Moves.RemoveAt(sporter.Moves.Count - 1);
                }
            }
        }

        public override string ToString()
        {
            return $"Lijnvoorraad: {_lijnenVoorraad.ToString()}\nKabelbezetting: {_kabel.ToString()}";
        }
    }
}

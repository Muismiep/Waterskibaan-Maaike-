using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Waterskibaan.Games
{
    public class Logger
    {
        public Sporter SP { get; set; }
        public Kabel _kabellogger { get; set; }
        public List<Sporter> Logging = new List<Sporter>() { };
        public Color Kledingkutding;
        public int AantalRondjesTotaal { get; set; }

        public Logger(/*Kabel kabel*/)
        {
            //_kabellogger = kabel;
        }

        public void PleurtroepInMijnLijst(Sporter sp)
        {
            Logging.Add(sp);
        }

        public int AantalBezoekersInTotaal()
        {
            return Logging.Count;
        }
        public String HoogsteScoreMoves()
        {
            string tostingdingens = "";
            Sporter temp = new Sporter { AantalbehaaldePunten = 0 };
            foreach (var kutsporter in Logging)
            {
                if (kutsporter.AantalbehaaldePunten > temp.AantalbehaaldePunten)
                {
                    temp = kutsporter;
                }
            }
            return temp.ToString();
        }
        public int TelrodeUitslovers()
        {
            int koekjes = 0;
            Kledingkutding =  Color.FromArgb(0, 255, 0);
            foreach (var kleurtje in Logging)
            {
                if (kleurtje.Kledingkleur == Kledingkutding)
                {
                    koekjes++;
                }
            }
            return koekjes;

        }
        public int AantaluitsloverRondjes(int rondjes)
        {
            AantalRondjesTotaal += rondjes;
            return AantalRondjesTotaal;
        }

        public string PrintGedeelte()
        {
            String pruim = "";
            foreach (var pitje in Logging)
            {
                pruim += pitje.ToString();
            }
            return pruim;
        }

    }
}

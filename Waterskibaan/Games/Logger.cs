/*
 * Waterskibaan Project
 * Door: Maaike van der Jagt
 * ICTSE1a
 * 2019
 */

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
        private Kabel _kabellogger;
        public List<Sporter> Logging = new List<Sporter>() { };
        public int AantalRondjesTotaal { get; set; }

        public Logger(Kabel kabel)
        {
            _kabellogger = kabel;
        }

        public void PleurtroepInMijnLijst(Sporter sp)
        {
            Logging.Add(sp);
            AantalRondjesTotaal += sp.AantalRondenNogTeGaan;
        }

        public int AantalBezoekersInTotaal()
        {
            return Logging.Count;
        }
        public int HoogsteScoreMoves()
        {
            return Logging.Max(s => s.AantalbehaaldePunten);
        }
        public int TelrodeUitslovers()
        {
            return Logging.Count(b => IsColorRed(b.Kledingkleur));

        }
        public int AantaluitsloverRondjes()
        {
            return AantalRondjesTotaal;
        }

        public List<Color> TienLichtsteKleurendinges()
        {
            return Logging.OrderByDescending(s => GetColorSize(s.Kledingkleur)).Select(s => s.Kledingkleur).Take(10).ToList();
        }

        public List<string> UniekeMoves()
        {
            return (from lijn in _kabellogger._lijnen
                    from move in lijn.Sporter.Moves
                    select move.Naam())
                   .Distinct()
                   .ToList();
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
        private static bool IsColorRed(Color a)
        {
            return ColorsAreClose(a, Color.Red);
        }

        private static bool ColorsAreClose(Color a, Color z, int threshold = 100) //  was 50, 100 van gemaakt om meer rode sporters te krijgen, was diep triest weinig
        {
            int r = a.R - z.R,
                g = a.G - z.G,
                b = a.B - z.B;
            return (r * r + g * g + b * b) <= threshold * threshold;
        }

        private long GetColorSize(Color color)
        {
            return color.R * color.R + color.G * color.G + color.B * color.B;
        }

    }
}

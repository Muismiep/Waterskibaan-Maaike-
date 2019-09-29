using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Waterskibaan
{
    abstract class Sporter
    {
        public int AantalRondenNogTeGaan { get; set; }
        public Zwemvest Zwemvest { get; set; }
        public Skies Skies { get; set; }
        public Color KledingKleur { get; set; }
        public List<IMoves> Moves { get; set; }
        public int AantalBehaaldePunten { get; set; } // TODO private maken

        public Sporter()
        {
            Moves = MoveCollection.GetWillekeurigeMoves();
            var rand = new Random();
            
            // tijdelijke oplossing, word vervangen in opdracht 13
            KledingKleur = Color.FromRgb((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));

        }
    }
}

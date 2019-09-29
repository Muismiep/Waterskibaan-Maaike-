using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Waterskibaan
{
    public class Sporter // abstract weg gehaald, blijkbaar moest het toch niet....
    {
        private int aantalRondenNogTeGaan;
        private Zwemvest zwemvest;
        private Skies skies;
        private Color kledingKleur;
        private List<IMoves> moves;
        private int aantalBehaaldePunten;

        public Zwemvest Zwemvest
        {
            get => zwemvest;
            set => zwemvest = value;
        }

        public int AantalRondenNogTeGaan
        {
            get => aantalRondenNogTeGaan;
            set => aantalRondenNogTeGaan = value;
        }

        public Skies Skies
        {
            get => skies;
            set => skies = value;
        }

        public Color Kledingkleur
        {
            get => kledingKleur;
            set => kledingKleur = value;
        }

        public List<IMoves> Moves
        {
            get => moves;
            set => moves = value;
        }


        public Sporter()
        {
            Moves = MoveCollection.GetWillekeurigeMoves();
            var rand = new Random();

            // tijdelijke oplossing, word vervangen in opdracht 13
            Kledingkleur = Color.FromRgb((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));

        }
    }
}


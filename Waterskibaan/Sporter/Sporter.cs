/*
 * Waterskibaan Project
 * Door: Maaike van der Jagt
 * ICTSE1a
 * 2019
 */

using System;
using System.Collections.Generic;
using System.Drawing;


namespace Waterskibaan
{
    public class Sporter
    {
        private int aantalRondenNogTeGaan;
        private Zwemvest zwemvest;
        private Skies skies;
        private Color kledingKleur;
        private List<IMoves> moves;
        private int aantalBehaaldePunten;
        public IMoves HuidigeMove;

        public int AantalbehaaldePunten
        {
            get => aantalBehaaldePunten;
            set => aantalBehaaldePunten = value;
        }

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
           Kledingkleur = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Waterskibaan
{
    class Game
    {
        private static Timer gameTimer;
        private Waterskibaan waterskiBaan;
        private WachtrijInstructie wachtrijInstructie;
        //TODO voeg andere wachtrijn toe

        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
        public event NieuweBezoekerHandler NieuweBezoeker;

        public void Initialize()
        {
            waterskiBaan = new Waterskibaan();
            gameTimer = new Timer(3000);
            gameTimer.Elapsed += VoegSporterToe;
            gameTimer.AutoReset = true;
            gameTimer.Enabled = true;
            Console.ReadLine();

            //Thread.sleep
            // maar beter: System.Timers.Timer

            /* elke seconde:
            -maak sporter aan
            -start sporter
            -verplaats kabel (waterskibaan)
            -roep tostrong waterskibaan aan
            */
        }
        private void VoegSporterToe(object source, ElapsedEventArgs e)
        {
            Sporter sp = new Sporter() { Skies = new Skies(), Zwemvest = new Zwemvest() };
            NieuweBezoeker(new NieuweBezoekerArgs { sp = sp });


            waterskiBaan.SporterStart(sp);
            waterskiBaan.VerplaatsKabel();
            Console.WriteLine(waterskiBaan);
        }
    }
}
//handler aanmaken

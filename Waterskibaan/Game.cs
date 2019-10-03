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
        public void Initialize()
        {
            waterskiBaan = new Waterskibaan();
            gameTimer = new Timer(1000);
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
            waterskiBaan.SporterStart(sp);
            waterskiBaan.VerplaatsKabel();
            Console.WriteLine(waterskiBaan);
        }
    }
}

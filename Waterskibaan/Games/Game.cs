using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Waterskibaan.Games;

namespace Waterskibaan.Games
{
    public class Game
    {
        //aanmaken private props
        private static Timer gameTimer;
        private int secondsSinceLastBezoeker;
        private int secondsSinceLastInstructie;
        private int secondsSinceLijnenVerplaatst;

        internal Waterskibaan waterskiBaan;
        internal WachtrijInstructie wachtrijInstructie;
        internal InstructieGroep instructiegroep;
        internal WachtrijStarten wachtrijStarten;
        public Logger loggerlijst { get; set; }

        //handlers
        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
        public event NieuweBezoekerHandler NieuweBezoeker;

        public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs args);
        public event InstructieAfgelopenHandler InstructieAfgelopen;

        public delegate void LijnenVerplaatsenHandler();
        public event LijnenVerplaatsenHandler LijnenVerplaatst;

        public Game()
        {
            waterskiBaan = new Waterskibaan();

            wachtrijInstructie = new WachtrijInstructie();
            instructiegroep = new InstructieGroep();
            wachtrijStarten = new WachtrijStarten();

            loggerlijst = new Logger();

            NieuweBezoeker += InstructieWachtrijHandler;
            InstructieAfgelopen += InstructieGroepHandler;
            LijnenVerplaatst += LijnVerplaatsHandler;
        }
        public void Initialize()
        {
            TimerBeheer();
        }
        private void TimerBeheer()
        {
            gameTimer = new Timer(1000);
            gameTimer.Elapsed += VoegSporterToe;
            gameTimer.AutoReset = true;
            gameTimer.Enabled = true;
        }

        private void StopDeTimer()
        {
            gameTimer.Stop();
            gameTimer.Dispose();
        }

        private void VoegSporterToe(object source, ElapsedEventArgs e)
        {
            if (secondsSinceLastBezoeker > 3) //elke 3 seconden nieuwe sporter
            {
                Sporter sporter = NieuweSporterbezoeker();
                secondsSinceLastBezoeker = 0;
                NieuweBezoeker?.Invoke(new NieuweBezoekerArgs { Sporter = sporter });
                
            }

            if (secondsSinceLastInstructie > 20) // elke 20 seconden nieuwe instructiegroep
            {
                secondsSinceLastInstructie = 0;
                InstructieAfgelopen.Invoke(new InstructieAfgelopenArgs
                {
                    Sporters = wachtrijInstructie.SportersVerlatenRij(5),
                    SportersInInstructie = instructiegroep.Queue.Count
                });

            }
            if (secondsSinceLijnenVerplaatst > 4)
            {
                secondsSinceLijnenVerplaatst = 0;
                LijnenVerplaatst.Invoke();
            }

            //secondes erbij, elke een losse anders heb je niet verschillende events, haalt de eerste het altijd terug naar 0
            secondsSinceLastBezoeker++;
            secondsSinceLastInstructie++;
            secondsSinceLijnenVerplaatst++;

            // print de waardes
            Console.WriteLine(waterskiBaan);
            Console.WriteLine(wachtrijInstructie);
            Console.WriteLine(instructiegroep);
            Console.WriteLine(wachtrijStarten);




        }
        // maakt een nieuwe sporter aan zonder zwemvest en skies
        private static Sporter NieuweSporterbezoeker()
        {
            return new Sporter();
        }
        //word toegevoegd aan de instructie wachtrij
        private void InstructieWachtrijHandler(NieuweBezoekerArgs args)
        {
            wachtrijInstructie.SporterNeemPlaatsInRij(args.Sporter);
            loggerlijst.PleurtroepInMijnLijst(args.Sporter);
        }
        //oude groep instructie eruit en naar start wachtrij en nieuwe groep erin
        private void InstructieGroepHandler(InstructieAfgelopenArgs args)
        {
            foreach (Sporter sport in instructiegroep.GetAlleSporters())
            {
                wachtrijStarten.SporterNeemPlaatsInRij(sport);
            }
            foreach (Sporter sport in args.Sporters)
            {
                instructiegroep.SporterNeemPlaatsInRij(sport);
            }
        }
        //lijnen worden verplaatst
        private void LijnVerplaatsHandler()
        {
            waterskiBaan.VerplaatsKabel();

            // nieuwe speler toevoegen daar waar nodig
            if (waterskiBaan._kabel.IsStartPositieLeeg())
            {
                var lijstSporter = wachtrijStarten.SportersVerlatenRij(1);
                if (lijstSporter.Count > 0)
                {
                    var sporter = lijstSporter[0];
                    sporter.Skies = new Skies();
                    sporter.Zwemvest = new Zwemvest();
                    waterskiBaan.SporterStart(sporter);
                    loggerlijst.AantaluitsloverRondjes(sporter.AantalRondenNogTeGaan);
                }
            }

            //Move na elke keer verplaatsen dus uit de startpositie leeg.
            waterskiBaan.MoveUitvoeren();
            //functie Move
            //

        }
        


    }
}


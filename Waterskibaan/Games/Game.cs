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
        private static Timer gameTimer;
        private int secondsSinceLastBezoeker;
        private int secondsSinceLastInstructie;
        private int secondsSinceLijnenVerplaatst;
        
        private Waterskibaan waterskiBaan;
        private WachtrijInstructie wachtrijInstructie;
        private InstructieGroep instructiegroep;
        private WachtrijStarten wachtrijStarten;

        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
        public event NieuweBezoekerHandler NieuweBezoeker;

        public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs args);
        public event InstructieAfgelopenHandler InstructieAfgelopen;

        public delegate void LijnenVerplaatsenHandler();
        public event LijnenVerplaatsenHandler LijnenVerplaatst;

        public void Initialize()
        {
            NieuweBezoeker += InstructieWachtrijHandler;
            InstructieAfgelopen += InstructieGroepHandler;
            LijnenVerplaatst += LijnVerplaatsHandler;

            waterskiBaan = new Waterskibaan();
            wachtrijInstructie = new WachtrijInstructie();
            instructiegroep = new InstructieGroep();
            wachtrijStarten = new WachtrijStarten();

            TimerBeheer();

            Console.ReadLine();

            StopDeTimer();
            
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
                    Sporters = wachtrijInstructie.SportersVerlatenRij(5)
                });

            }
            if (secondsSinceLijnenVerplaatst > 4)
            {
                secondsSinceLijnenVerplaatst = 0;
                LijnenVerplaatst.Invoke();
            }


            secondsSinceLastBezoeker++;
            secondsSinceLastInstructie++;
            secondsSinceLijnenVerplaatst++;

            Console.WriteLine(waterskiBaan);
            Console.WriteLine(wachtrijInstructie);
            Console.WriteLine(instructiegroep);
            Console.WriteLine(wachtrijStarten);
            


            
        }

        private static Sporter NieuweSporterbezoeker()
        {
            return new Sporter();
        }
        private void InstructieWachtrijHandler(NieuweBezoekerArgs args)
        {
            wachtrijInstructie.SporterNeemPlaatsInRij(args.Sporter);
        }
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
        private void LijnVerplaatsHandler()
        {
            waterskiBaan.VerplaatsKabel();
            if (waterskiBaan._kabel.IsStartPositieLeeg())
            {
                var lijstSporter = wachtrijStarten.SportersVerlatenRij(1);
                if (lijstSporter.Count > 0)
                {
                    var sporter = lijstSporter[0];
                    sporter.Skies = new Skies();
                    sporter.Zwemvest = new Zwemvest();
                    waterskiBaan.SporterStart(sporter);
                }
                

            }
        }


    }
}
//handler aanmaken

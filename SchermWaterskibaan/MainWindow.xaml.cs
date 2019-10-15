/*
* Waterskibaan Project
* Door: Maaike van der Jagt
* ICTSE1a
* 2019
*/

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using Waterskibaan;
using Waterskibaan.Games;

namespace SchermWaterskibaan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Logger _logger;
        public int InstructieWachtende { get; set; }
        public int Instructiehoeveelheid { get; set; }
        public int WachtenOpStarten { get; set; }
        public List<DisplayLijn> DisplayLijnen { get; set; }
        public IList<bool> LijnPositieZichtbaarheid { get; set; }
        public int TotaalAantalBezoekers { get; set; }

        public int HoogstBehaaldeScore { get; set; }

        public int BezoekersInRodeKleding { get; set; }

        public int AantalRondjesTotaal { get; set; }

        public IList<string> UniekeMoves { get; set; }

        public IList<Color> Kleurtjes { get; set; }



        public int Lijnenvoorraad { get; set; } = 15; //TODO if lijnenvoorraad < 5 color red, want kunnen niet meer dan 10 lijnen op de baan

        public MainWindow()
        {
            InitializeComponent();
            SetupDefaultLijnen();

            // functies aanroepen
            var game = new Game();
            game.NieuweBezoeker += WPF_NieuweBezoeker;
            game.LijnenVerplaatst += WPF_LijnenVerplaatst;
            game.InstructieAfgelopen += WPF_InstructieAfgelopen;
            _logger = game.loggerlijst;
            game.Initialize();

        }

        private void WPF_NieuweBezoeker(NieuweBezoekerArgs args)
        {
            InstructieWachtende++;
            UpdateStats();
        }
        private void WPF_LijnenVerplaatst(VerplaatsLijnenArgs args)
        {
            WachtenOpStarten = args.SportersKlaarVoorStart;
            UpdateLijnen(args.Lijnen);
            Lijnenvoorraad = args.LijnenVoorraad.GetAantalLijnen();

        }
        private void WPF_InstructieAfgelopen(InstructieAfgelopenArgs args)
        {
            var leavingsporters = args.Sporters.Count;
            InstructieWachtende -= leavingsporters;
            Instructiehoeveelheid = leavingsporters;
            WachtenOpStarten = args.SportersKlaarVoorStart;
        }
        private void UpdateLijnen(IEnumerable<Lijn> lijnen)
        {
            // in essentie is alles niet visible
            var zichtbaarheid = new List<bool>();
            for (var i = 0; i < 10; i++)
            {
                zichtbaarheid.Add(false);
            }
            // Maakt de lijnen aan, de kleur, move en tag zitten daar nog niet in maar komen er wel in
            var displayLijnen = new List<DisplayLijn>();
            for (var i = 0; i < 10; i++)
            {
                displayLijnen.Add(new DisplayLijn());
            }
            // spul word toegevoegd aan Display lijn
            foreach (var actieveLijn in lijnen)
            {
                // als er toch een lijn is word hij zichtbaar, anders niet
                var pos = actieveLijn.PositieOpDeKabel;
                zichtbaarheid[pos] = true;
                displayLijnen[pos] = new DisplayLijn
                {
                    LijnNummer = actieveLijn.LijnNummer,
                    HuidigeMove = actieveLijn.Sporter.HuidigeMove?.ToString() ?? string.Empty
                };
                var drawingColor = actieveLijn.Sporter.Kledingkleur;
                displayLijnen[pos].Kleur = new SolidColorBrush(Color.FromRgb(drawingColor.R, drawingColor.G, drawingColor.B));
                displayLijnen[pos].Kleur.Freeze();
            }

            // Override existing list to trigger PropertyOnChanged
            LijnPositieZichtbaarheid = zichtbaarheid;
            DisplayLijnen = displayLijnen;
        }
        private void SetupDefaultLijnen()
        {
            // Set 10 default zichtbaarheden to prevent NullReferenceExceptions
            LijnPositieZichtbaarheid = new List<bool>(10)
            {
                false, false, false, false, false,
                false, false, false, false, false
            };

            // Set 10 default displaylijnen to prevent NullReferenceExceptions
            DisplayLijnen = new List<DisplayLijn>(10)
            {
                new DisplayLijn(), new DisplayLijn(), new DisplayLijn(), new DisplayLijn(), new DisplayLijn(),
                new DisplayLijn(), new DisplayLijn(), new DisplayLijn(), new DisplayLijn(), new DisplayLijn()
            };
        }



        private void UpdateStats()
        {
            var totaalAantalBezoeker = _logger.AantalBezoekersInTotaal();
            if (totaalAantalBezoeker != TotaalAantalBezoekers)
            {
                TotaalAantalBezoekers = totaalAantalBezoeker;
            }

            var hoogstBehaaldeScore = _logger.HoogsteScoreMoves();
            if (hoogstBehaaldeScore != HoogstBehaaldeScore)
            {
                HoogstBehaaldeScore = hoogstBehaaldeScore;
            }

            var totaalBezoekersInRodeKleding = _logger.TelrodeUitslovers();
            if (totaalBezoekersInRodeKleding != BezoekersInRodeKleding)
            {
                BezoekersInRodeKleding = totaalBezoekersInRodeKleding;
            }

            var totaalAantalRondjes = _logger.AantaluitsloverRondjes();
            if (totaalAantalRondjes != AantalRondjesTotaal)
            {
                AantalRondjesTotaal = totaalAantalRondjes;
            }

            var uniekeMoves = _logger.UniekeMoves();
            if (uniekeMoves != UniekeMoves)
            {
                UniekeMoves = uniekeMoves;
            }

            

            var tienlichste = _logger.TienLichtsteKleurendinges();
            var nieuweKleuren = new List<Color>();
            foreach(var kleur in tienlichste)
            {
                nieuweKleuren.Add(Color.FromRgb(kleur.R, kleur.G, kleur.B));
            }
            Kleurtjes = nieuweKleuren;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

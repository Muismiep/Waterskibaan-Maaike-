using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Waterskibaan;
using Waterskibaan.Games;

namespace SchermWaterskibaan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        
        public int InstructieWachtende { get; set; }
        public int Instructiehoeveelheid { get; set; }
        public int WachtenOpStarten { get; set; }
        public List<DisplayLijn> DisplayLijnen { get; set; }
        public IList<bool> LijnPositieZichtbaarheid { get; set; }


        public int Lijnenvoorraad { get; set; } //TODO if lijnenvoorraad < 5 color red, want kunnen niet meer dan 10 lijnen op de baan

        public MainWindow()
        {
            InitializeComponent();
            SetupDefaultLijnen();

            // functies aanroepen
            var game = new Game();
            game.NieuweBezoeker += WPF_NieuweBezoeker;
            game.LijnenVerplaatst += WPF_LijnenVerplaatst;
            game.InstructieAfgelopen += WPF_InstructieAfgelopen;
            //Lijnenvoorraad = 
            game.Initialize();

        }

        private void WPF_NieuweBezoeker(NieuweBezoekerArgs args)
        {
            InstructieWachtende++;
        }
        private void WPF_LijnenVerplaatst( args)
        private void WPF_InstructieAfgelopen(InstructieAfgelopenArgs args)
        {
            var leavingsporters = args.Sporters.Count;
            InstructieWachtende -= leavingsporters;
            Instructiehoeveelheid = leavingsporters;
            WachtenOpStarten += args.SportersInInstructie;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

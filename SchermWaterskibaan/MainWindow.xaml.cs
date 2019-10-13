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

        public MainWindow()
        {
            InitializeComponent();

            // functies aanroepen
            var game = new Game();
            game.NieuweBezoeker += WPF_NieuweBezoeker;
            game.InstructieAfgelopen += WPF_InstructieAfgelopen;
            
            game.Initialize();

        }

        private void WPF_NieuweBezoeker(NieuweBezoekerArgs args)
        {
            InstructieWachtende++;
        }
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

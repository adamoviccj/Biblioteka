using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SIMS_Projekat.View
{
    /// <summary>
    /// Interaction logic for ClanProfil.xaml
    /// </summary>
    public partial class ClanProfil : Window
    {
        public ClanProfil()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void ShowIznajmljivanjaBtn_Click(object sender, RoutedEventArgs e)
        {
            var iznajmljivanjaTable = new PrikazIznajmljivanjaClan();
            iznajmljivanjaTable.Show();
        }

        private void KreirajRezervacijuBtn_Click(object sender, RoutedEventArgs e)
        {
            var kreirajRezervaciju = new KreiranjeRezervacijeClan(null);
            kreirajRezervaciju.Show();
        }

        private void ShowMojeRezervacijeBtn_Click(object sender, RoutedEventArgs e)
        {
            var mojeRezervacije = new PrikazRezervacijaClan();
            mojeRezervacije.Show();
        }

        private void ShowMojeZahteveBtn_Click(object sender, RoutedEventArgs e)
        {
            var mojiZahtevi = new PrikazZahtevaClan();
            mojiZahtevi.Show();
        }
    }
}

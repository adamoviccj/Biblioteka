using SIMS_Projekat.Model;
using SIMS_Projekat.Repository;
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
        private RezervacijaRepository _rezervacijaRepository { get; set; }
        public ClanProfil()
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;
            _rezervacijaRepository = app._rezervacijaRepository;
            ProveriRezervacije();
            
        }

        public void ProveriRezervacije()
        {
            List<Rezervacija> rezervacije = _rezervacijaRepository.GetAllRezervacijeNaCekanjuZaClana(LogIn.LoggedUser.jmbg);
            if (rezervacije.Count > 0)
            {
                foreach (Rezervacija rezervacija in rezervacije)
                {
                    MessageBox.Show("Primerak knjige " + rezervacija.IzdanjeKnjige.knjiga.nazivKnjige + " je slobodan i mozete ga preuzeti u naredna dva dana.", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void ShowIznajmljivanjaBtn_Click(object sender, RoutedEventArgs e)
        {
            var iznajmljivanjaTable = new PrikazIznajmljivanjaClan();
            iznajmljivanjaTable.Show();
        }

        private void KreirajRezervacijuBtn_Click(object sender, RoutedEventArgs e)
        {
            var kreirajRezervaciju = new KreiranjeRezervacijeClan();
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

        private void ShowTrenutnaIznajmljivanjaBtn_Click(object sender, RoutedEventArgs e)
        {
            PrikazTrenutnihIznajmljivanjaClan prikaz = new PrikazTrenutnihIznajmljivanjaClan();
            prikaz.Show();
        }

        private void OdjavaBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            for (int i = Application.Current.Windows.Count - 1; i >= 0; i--)
            {
                if (Application.Current.Windows[i] != mainWindow)
                {
                    Application.Current.Windows[i].Close();
                }
            }
        }

        private void ShowKazneBtn_Click(object sender, RoutedEventArgs e)
        {
            ClanKazne clanKazne = new ClanKazne();
            clanKazne.Show();
        }
    }
}
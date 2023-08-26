using SIMS_Projekat.Model;
using SIMS_Projekat.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for KreiranjeRezervacijeClan.xaml
    /// </summary>
    public partial class KreiranjeRezervacijeClan : Window
    {
        public ObservableCollection<Knjiga> Knjige { get; set; }
        public Knjiga SelectedKnjiga { get; set; }

        private KnjigaRepository _knjigaRepository { get; set; }
        private RezervacijaRepository _rezervacijaRepository { get; set; }
        public KreiranjeRezervacijeClan(Knjiga selectedKnjiga)
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;
            _knjigaRepository = app.KnjigaRepository;
            _rezervacijaRepository = app._rezervacijaRepository;
            SelectedKnjiga = selectedKnjiga;

            Knjige = new ObservableCollection<Knjiga>(_knjigaRepository.GetAllKnjige());
        }

        private void SubmitRezervacija_Click(object sender, RoutedEventArgs e)
        {
            Rezervacija rezervacija = new Rezervacija();
            rezervacija.datumRezervacije = DateTime.Now;
            rezervacija.clan = (Clan)LogIn.LoggedUser;
            rezervacija.knjiga = SelectedKnjiga;
            _rezervacijaRepository.Save();
            if (rezervacija == null)
            {
                MessageBox.Show("Greska u rezervaciji knjige!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            } else
            {
                _rezervacijaRepository.Rezervacije.Add(rezervacija);
                _rezervacijaRepository.Save();
                MessageBox.Show("Rezervacija uspesno obavljena!", "Uspeh!", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }
    }
}

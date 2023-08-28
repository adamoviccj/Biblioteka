using SIMS_Projekat.Model;
using SIMS_Projekat.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for KreiranjeRezervacijeBibliotekar.xaml
    /// </summary>
    public partial class KreiranjeRezervacijeBibliotekar : Window
    {
        public ObservableCollection<IzdanjeKnjige> Izdanja { get; set; }
        
        public ObservableCollection<Clan> Clanovi { get; set; }

        public IzdanjeKnjige SelectedIzdanje { get; set; }

        public Clan SelectedClan { get; set; }
        public ClanRepository _clanRepository;
        public IzdanjeKnjigeRepository _izdanjeRepository;
        public RezervacijaRepository _rezervacijaRepository;

        public KreiranjeRezervacijeBibliotekar()
        {
            InitializeComponent();
            this.DataContext = this;

            var app = Application.Current as App;
            _clanRepository = app._clanRepository;
            _izdanjeRepository = app.IzdanjeKnjigeRepository;
            _rezervacijaRepository = app._rezervacijaRepository;


            Izdanja = new ObservableCollection<IzdanjeKnjige>(_izdanjeRepository.GetAll());
            Clanovi = new ObservableCollection<Clan>(_clanRepository.GetAllClanovi());
        }

        private void SubmitRezervacija_Click(object sender, RoutedEventArgs e)
        {
            Rezervacija rezervacija = new Rezervacija();
            rezervacija.DatumRezervacije = DateTime.Now;
            rezervacija.IzdanjeKnjige = SelectedIzdanje;
            rezervacija.Clan = SelectedClan;
            _rezervacijaRepository.Create(rezervacija);
            if (rezervacija == null)
            {
                MessageBox.Show("Greska u rezervaciji knjige!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            } else
            {
                MessageBox.Show("Rezervacija uspesno obavljena!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


    }
}

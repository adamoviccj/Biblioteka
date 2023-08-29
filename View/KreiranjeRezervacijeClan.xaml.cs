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
        public ObservableCollection<IzdanjeKnjige> Izdanja { get; set; }
        public IzdanjeKnjige SelectedIzdanje { get; set; }

        private IzdanjeKnjigeRepository _izdanjeRepository { get; set; }
        private RezervacijaRepository _rezervacijaRepository { get; set; }
        private PrimerakRepository _primerakRepository { get; set; }
        public KreiranjeRezervacijeClan()
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;
            _izdanjeRepository = app.IzdanjeKnjigeRepository;
            _rezervacijaRepository = app._rezervacijaRepository;
            _primerakRepository = app.PrimerakRepository;

            Izdanja = new ObservableCollection<IzdanjeKnjige>(_izdanjeRepository.GetAll());
        }

        private void SubmitRezervacija_Click(object sender, RoutedEventArgs e)
        {
            Rezervacija rezervacija = new Rezervacija();
            rezervacija.DatumRezervacije = DateTime.Now;
            rezervacija.Clan = (Clan)LogIn.LoggedUser;
            rezervacija.IzdanjeKnjige = SelectedIzdanje;


            string isbn = SelectedIzdanje.isbn;
            Primerak primerak = _primerakRepository.FindSlobodanPrimerakZaIzdanje(isbn);
            if (primerak == null)
            {
                MessageBox.Show("Trenutno nema slobodnih primeraka!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Rezervacija uspesno obavljena, preuzmite knjigu u roku od dva dana!", "Uspeh!", MessageBoxButton.OK, MessageBoxImage.Information);
                primerak.dostupnost = enums.Dostupnost.NA_CEKANJU;
                _primerakRepository.Update(primerak);
            }

            rezervacija.StatusRezervacije = enums.StatusRezervacije.KREIRANA;
            _rezervacijaRepository.Create(rezervacija);


        }
    }
}
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
    /// Interaction logic for PrikazRezervacijaNaCekanjuBibliotekar.xaml
    /// </summary>
    public partial class PrikazRezervacijaNaCekanjuBibliotekar : Window
    {
        public ObservableCollection<Rezervacija> Rezervacije { get; set; }
        public Rezervacija SelectedRezervacija { get; set; }
        private RezervacijaRepository _rezervacijaRepository { get; set; }
        private ClanskaKartaRepository _clanskaKartaRepository { get; set; }
        private IznajmljivanjeRepository _iznajmljivanjeRepository { get; set; }
        private PrimerakRepository _primerakRepository { get; set; }
        
        public PrikazRezervacijaNaCekanjuBibliotekar()
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;
            _rezervacijaRepository = app._rezervacijaRepository;
            _clanskaKartaRepository = app._clanskaKartaRepository;
            _iznajmljivanjeRepository = app.IznajmljivanjeRepository;
            _primerakRepository = app.PrimerakRepository;

            Rezervacije = new ObservableCollection<Rezervacija>(_rezervacijaRepository.GetAllRezervacijeNaCekanju());
        }

        public void Refresh(List<Rezervacija> rezervacije)
        {
            Rezervacije.Clear();
            foreach(Rezervacija rezervacija in rezervacije)
            {
                Rezervacije.Add(rezervacija);
            }
        }

        private void RazresiRezervacijuBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedRezervacija == null)
            {
                MessageBox.Show("Morate odabrati red u tabeli!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            } else
            {
                Iznajmljivanje iznajmljivanje = new Iznajmljivanje();
                iznajmljivanje.datumIznajmljivanja = DateTime.Now;
                iznajmljivanje.datumVracanja = null;
                iznajmljivanje.rokVracanja = DateTime.Now.AddDays(_clanskaKartaRepository.GetMaxDanaByTipClanstva(SelectedRezervacija.Clan.brClanskeKarte));
                iznajmljivanje.brojZahtevaZaProduzavanje = 0;
                iznajmljivanje.clan = SelectedRezervacija.Clan;
                iznajmljivanje.primerak = _primerakRepository.FindSlobodanPrimerakZaIzdanje(SelectedRezervacija.IzdanjeKnjige.isbn);
                iznajmljivanje.primerak.dostupnost = enums.Dostupnost.IZNAJMLJENA;
                _primerakRepository.Update(iznajmljivanje.primerak);
                _iznajmljivanjeRepository.Create(iznajmljivanje);
                SelectedRezervacija.StatusRezervacije = enums.StatusRezervacije.RAZRESENA;
                SelectedRezervacija.DatumPrihvatanja = DateTime.Now;
                _rezervacijaRepository.Update(SelectedRezervacija);
                MessageBox.Show("Rezervacija uspesno razresena!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                Refresh(_rezervacijaRepository.GetAllRezervacijeNaCekanju());
            }
        }
    }
}

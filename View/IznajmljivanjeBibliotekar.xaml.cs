using Newtonsoft.Json;
using SIMS_Projekat.Model;
using SIMS_Projekat.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
using System.Windows.Shapes;

namespace SIMS_Projekat.View
{
    /// <summary>
    /// Interaction logic for IznajmljivanjeBibliotekar.xaml
    /// </summary>
    public partial class IznajmljivanjeBibliotekar : Window
    {
        public ObservableCollection<Knjiga> Knjige { get; set; }

        public List<Primerak> primerci;

        public ObservableCollection<Primerak> slobodniPrimerci;

        public ObservableCollection<Primerak> Slobodni { get; set; }
        public ObservableCollection<Clan> Clanovi { get; set; }

        public Knjiga SelectedKnjiga { get; set; }
        public Primerak SelectedPrimerak { get; set; }
        public Clan SelectedClan { get; set; }
        public ClanRepository _clanRepository;
        public ClanskaKartaRepository _clanskaKartaRepository;
        public KnjigaRepository _knjigaRepository;
        public IzdanjeKnjigeRepository _izdanjeKnjigeRepository;
        public PrimerakRepository _primerakRepository;
        public IznajmljivanjeRepository _iznajmljivanjeRepository;



        public bool CanSelect { get; set; }

        public IznajmljivanjeBibliotekar()
        {
            InitializeComponent();
            this.DataContext = this;

            var app = Application.Current as App;
            _clanRepository = app._clanRepository;
            _clanskaKartaRepository = app._clanskaKartaRepository;
            _knjigaRepository = app.KnjigaRepository;
            _izdanjeKnjigeRepository = app.IzdanjeKnjigeRepository;
            _primerakRepository = app.PrimerakRepository;
            _iznajmljivanjeRepository = app.IznajmljivanjeRepository;
            

            if (SelectedKnjiga == null)
            {
                CanSelect = true;
            }
            else
            {
                CanSelect = false;
            }

            Knjige = new ObservableCollection<Knjiga>(_knjigaRepository.GetAllKnjige());
            Clanovi = new ObservableCollection<Clan>(_clanRepository.GetAllClanovi());

        }


        private void SubmitIznajmljivanje_Click(object sender, RoutedEventArgs e)
        {
            if ((_iznajmljivanjeRepository.GetAllTrenutnaIznajmljivanjaForClan(SelectedClan.jmbg).Count) == (_clanskaKartaRepository.GetMaxBrojKnjiga(SelectedClan.brClanskeKarte)))
            {
                MessageBox.Show("Clan je dostigao maksimalan broj knjiga!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Iznajmljivanje iznajmljivanje = new Iznajmljivanje();
            iznajmljivanje.datumIznajmljivanja = DateTime.Now;
            iznajmljivanje.rokVracanja = DateTime.Now.AddDays(_clanskaKartaRepository.GetMaxDanaByTipClanstva(SelectedClan.brClanskeKarte));
            iznajmljivanje.datumVracanja = null;
            primerci = _primerakRepository.FindSlobodneZaKnjigu(SelectedKnjiga.nazivKnjige);
            if (primerci.Count == 0)
            {
                MessageBox.Show("Nema slobodnih primeraka odabrane knjige! Mozete izvrsiti rezervaciju!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            } else
            {
                iznajmljivanje.primerak = primerci.First();
                iznajmljivanje.primerak.dostupnost = enums.Dostupnost.IZNAJMLJENA;
                _primerakRepository.Update(iznajmljivanje.primerak);
            }
            
            iznajmljivanje.clan = SelectedClan;
            
            
            _iznajmljivanjeRepository.Create(iznajmljivanje);
            if (iznajmljivanje == null)
            {
                MessageBox.Show("Nema slobodnih primeraka odabrane knjige!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                MessageBox.Show("Iznajmljivanje uspesno obavljeno!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}

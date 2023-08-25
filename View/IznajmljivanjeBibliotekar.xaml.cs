using Newtonsoft.Json;
using SIMS_Projekat.Model;
using SIMS_Projekat.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Interaction logic for IznajmljivanjeBibliotekar.xaml
    /// </summary>
    public partial class IznajmljivanjeBibliotekar : Window
    {
        public ObservableCollection<Knjiga> Knjige { get; set; }
        public ObservableCollection<Primerak> Primerci { get; set; }
        public ObservableCollection<Primerak> Slobodni { get; set; }
        public ObservableCollection<Clan> Clanovi { get; set; }
        public Knjiga SelectedKnjiga { get; set; }
        public Primerak SelectedPrimerak { get; set; }
        public Clan SelectedClan { get; set; }
        public ClanRepository _clanRepository;
        public KnjigaRepository _knjigaRepository;
        public IzdanjeKnjigeRepository _izdanjeKnjigeRepository;
        public PrimerakRepository _primerakRepository;
        public IznajmljivanjeRepository _iznajmljivanjeRepository;
        public bool CanSelect { get; set; }

        public IznajmljivanjeBibliotekar(Knjiga selectedKnjiga, Clan selectedClan, Primerak selectedPrimerak)
        {
            InitializeComponent();
            this.DataContext = this;

            var app = Application.Current as App;
            _clanRepository = app._clanRepository;
            _knjigaRepository = app.KnjigaRepository;
            _izdanjeKnjigeRepository = app.IzdanjeKnjigeRepository;
            _primerakRepository = app.PrimerakRepository;
            _iznajmljivanjeRepository = app.IznajmljivanjeRepository;
            SelectedKnjiga = selectedKnjiga;
            SelectedPrimerak = selectedPrimerak;
            SelectedClan = selectedClan;


            if (SelectedKnjiga == null)
            {
                CanSelect = true;
            } else
            {
                CanSelect = false;
            }

            Knjige = new ObservableCollection<Knjiga>(_knjigaRepository.GetAllKnjige());
            if (selectedKnjiga == null)
            {
                Primerci = new ObservableCollection<Primerak>(_primerakRepository.GetAllPrimerci());
            } else
            {
                Primerci = new ObservableCollection<Primerak>(Primerci.Where(x=>x.izdanjeKnjige.knjiga.nazivKnjige == SelectedKnjiga.nazivKnjige));
            }
            Clanovi = new ObservableCollection<Clan>(_clanRepository.GetAllClanovi());
            
        }

        private void SubmitIznajmljivanje_Click(object sender, RoutedEventArgs e)
        {
            Iznajmljivanje iznajmljivanje = new Iznajmljivanje();
            iznajmljivanje.datumIznajmljivanja = DateTime.Now;
            iznajmljivanje.datumVracanja = null;
            iznajmljivanje.primerak = SelectedPrimerak;
            iznajmljivanje.clan = SelectedClan;
            Primerak primerak = _primerakRepository.FindPrimerakByInventarniBroj(iznajmljivanje.primerak.inventarniBroj);
            primerak.dostupnost = enums.Dostupnost.IZNAJMLJENA;
            _primerakRepository.Save();
            _iznajmljivanjeRepository.Iznajmljivanja.Add(iznajmljivanje);
            _iznajmljivanjeRepository.Save();
            if (iznajmljivanje == null)
            {
                MessageBox.Show("Nema slobodnih primeraka odabrane knjige!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            } else
            {
                MessageBox.Show("Iznajmljivanje uspesno obavljeno!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        


    }
}

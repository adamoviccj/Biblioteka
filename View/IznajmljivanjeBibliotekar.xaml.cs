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
    public partial class IznajmljivanjeBibliotekar : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Knjiga> Knjige { get; set; }

        public List<Primerak> primerci;

        public ObservableCollection<Primerak> slobodniPrimerci;

        public ObservableCollection<Primerak> Primerci
        {
            get { return slobodniPrimerci; }
            set { slobodniPrimerci = value; OnPropertyChanged(nameof(Primerci)); }
        }
        public ObservableCollection<Primerak> Slobodni { get; set; }
        public ObservableCollection<Clan> Clanovi { get; set; }

        private Knjiga _selectedKnjiga;
        public Knjiga SelectedKnjiga { get { return _selectedKnjiga; } set { _selectedKnjiga = value; fillPrimerci(); } }
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
            Primerci = new ObservableCollection<Primerak>();
            SelectedKnjiga = selectedKnjiga;
            SelectedPrimerak = selectedPrimerak;
            SelectedClan = selectedClan;
            primerci = _primerakRepository.GetAllPrimerci();
            

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

        private void fillPrimerci()
        {
            Primerci.Clear();
            if (SelectedKnjiga == null)
            {
                Primerci = new ObservableCollection<Primerak>(_primerakRepository.GetAllPrimerci());
            }
            else
            {
                Primerci = new ObservableCollection<Primerak>(primerci.Where(x => x.izdanjeKnjige.knjiga.nazivKnjige == SelectedKnjiga.nazivKnjige && x.dostupnost == enums.Dostupnost.SLOBODNA));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SubmitIznajmljivanje_Click(object sender, RoutedEventArgs e)
        {
            Iznajmljivanje iznajmljivanje = new Iznajmljivanje();
            iznajmljivanje.datumIznajmljivanja = DateTime.Now;
            iznajmljivanje.datumVracanja = null;
            iznajmljivanje.primerak = SelectedPrimerak;
            iznajmljivanje.clan = SelectedClan;
            Primerak primerak = new Primerak();
            try
            {
                primerak = _primerakRepository.FindPrimerakByInventarniBroj(iznajmljivanje.primerak.inventarniBroj);
                if (primerak == null)
                {
                    MessageBox.Show("Nema slobodnih primeraka odabrane knjige!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            } catch(Exception e1)
            {
                MessageBox.Show("Nema slobodnih primeraka odabrane knjige!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            primerak.dostupnost = enums.Dostupnost.IZNAJMLJENA;
            _primerakRepository.Save();
            _iznajmljivanjeRepository.Iznajmljivanja.Add(iznajmljivanje);
            _iznajmljivanjeRepository.Save();
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

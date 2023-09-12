using SIMS_Projekat.enums;
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
    /// Interaction logic for VracanjeKnjige.xaml
    /// </summary>
    public partial class VracanjeKnjige : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Iznajmljivanje> iznajmljivanja { get; set; }

        private IznajmljivanjeRepository _iznajmljivanjeRepository { get; set; }

        private KaznaRepository _kaznaRepository { get; set; }
        private RezervacijaRepository _rezervacijaRepository { get; set; }
        private PrimerakRepository _primerakRepository { get; set; }

        public Iznajmljivanje selectedIznajmljivanje { get; set; }
        public VracanjeKnjige()
        {
            LoadIznajmljivanja();
            InitializeComponent();
            DataContext = this;
        }

        public void LoadIznajmljivanja()
        {
            var app = Application.Current as App;
            _iznajmljivanjeRepository = app.IznajmljivanjeRepository;
            _kaznaRepository = app._kaznaRepository;
            _rezervacijaRepository = app._rezervacijaRepository;
            _primerakRepository = app.PrimerakRepository;
            iznajmljivanja = new ObservableCollection<Iznajmljivanje>(_iznajmljivanjeRepository.GetAllTrenutnaIznajmljivanja());

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (selectedIznajmljivanje == null)
            {
                MessageBox.Show("Niste izabrali izdanje knjige");
                return;
            }

            if (_iznajmljivanjeRepository.VracanjeKnjige(selectedIznajmljivanje.id))
            {
                MessageBox.Show("Uspesno vracanje knjige");
                OnPropertyChanged(nameof(iznajmljivanja));
                Primerak primerak = _primerakRepository.FindPrimerakByInventarniBroj(selectedIznajmljivanje.primerak.inventarniBroj);
                primerak.dostupnost = Dostupnost.SLOBODNA;
                primerak.datumRaspolaganja = DateTime.Now;
                _primerakRepository.Update(primerak);
                List<Rezervacija> rezervacije = _rezervacijaRepository.GetAllKreiraneRezervacijeZaIzdanje(selectedIznajmljivanje.primerak.izdanjeKnjige.isbn);
                if (rezervacije.Count > 0)
                {
                    Rezervacija rezervacija = rezervacije.First();
                    rezervacija.StatusRezervacije = StatusRezervacije.NA_CEKANJU;
                    _rezervacijaRepository.Update(rezervacija);
                }
                
            }
            else
            {
                MessageBox.Show("Knjiga nije uspesno vracena");
                return;
            }


            if ((bool)radioButton2.IsChecked)
            {
                _kaznaRepository.Kazne.Add(new Kazna((float)selectedIznajmljivanje.primerak.nabavnaCena/2, selectedIznajmljivanje.clan, TipKazne.KNJIGA_OSTECENA));
                _kaznaRepository.Save();
            }
            else if ((bool)radioButton3.IsChecked) 
            {
                _kaznaRepository.Kazne.Add(new Kazna((float)selectedIznajmljivanje.primerak.nabavnaCena, selectedIznajmljivanje.clan, TipKazne.KNJIGA_IZGUBLJENA));
                _kaznaRepository.Save();
                var app = Application.Current as App;
                PrimerakRepository primerakRepository = app.PrimerakRepository;
                primerakRepository.PromeniStanje(selectedIznajmljivanje.primerak.inventarniBroj,Dostupnost.IZGUBLJENA);
            }
            LoadIznajmljivanja();
            OnPropertyChanged(nameof(iznajmljivanja));
        }
    }
}

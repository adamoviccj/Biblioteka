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
    /// Interaction logic for PrikazZahtevaBibliotekar.xaml
    /// </summary>
    public partial class PrikazZahtevaBibliotekar : Window
    {
        public ObservableCollection<ZahtevZaProduzavanje> Zahtevi { get; set; }
        public ZahtevZaProduzavanje SelectedZahtev { get; set; }
        private ZahtevZaProduzavanjeRepository _zahtevZaProduzavanjeRepository { get; set; }
        private IznajmljivanjeRepository _iznajmljivanjeRepository { get; set; }
        private ClanskaKartaRepository _clanskaKartaRepository { get; set; }
        public PrikazZahtevaBibliotekar()
        {
            InitializeComponent();
            this.DataContext = this;


            var app = Application.Current as App;
            _zahtevZaProduzavanjeRepository = app._zahtevZaProduzavanjeRepository;
            _iznajmljivanjeRepository = app.IznajmljivanjeRepository;
            _clanskaKartaRepository = app._clanskaKartaRepository;

            Zahtevi = new ObservableCollection<ZahtevZaProduzavanje>(_zahtevZaProduzavanjeRepository.GetAllNaCekanju());
        }

        public void Refresh(List<ZahtevZaProduzavanje> zahtevi)
        {
            Zahtevi.Clear();
            foreach (ZahtevZaProduzavanje zahtev in zahtevi)
            {
                Zahtevi.Add(zahtev);
            }
        }

        private void OdobriZahtev_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedZahtev == null)
            {
                MessageBox.Show("Morate odabrati red u tabeli!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Iznajmljivanje iznajmljivanje = _iznajmljivanjeRepository.GetById(SelectedZahtev.Iznajmljivanje.id);

            iznajmljivanje.rokVracanja = iznajmljivanje.rokVracanja.AddDays(_clanskaKartaRepository.GetMaxDanaByTipClanstva(SelectedZahtev.Clan.brClanskeKarte));
            _iznajmljivanjeRepository.Update(iznajmljivanje);
            SelectedZahtev.StanjeZahteva = enums.StanjeZahteva.PRIHVACEN;
            _zahtevZaProduzavanjeRepository.Update(SelectedZahtev);
            MessageBox.Show("Zahtev za produzavanje uspesno odobren!", "Greska", MessageBoxButton.OK, MessageBoxImage.Information);
            Refresh(_zahtevZaProduzavanjeRepository.GetAllNaCekanju());
        }

        private void OdbijZahtev_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedZahtev == null)
            {
                MessageBox.Show("Morate odabrati red u tabeli!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            SelectedZahtev.StanjeZahteva = enums.StanjeZahteva.ODBIJEN;
            _zahtevZaProduzavanjeRepository.Update(SelectedZahtev);
            MessageBox.Show("Zahtev za produzavanje uspesno odbijen!", "Greska", MessageBoxButton.OK, MessageBoxImage.Information);
            Refresh(_zahtevZaProduzavanjeRepository.GetAllNaCekanju());
        }
    }
}
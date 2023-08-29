using SIMS_Projekat.enums;
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
    /// Interaction logic for PrikazTrenutnihIznajmljivanjaClan.xaml
    /// </summary>
    public partial class PrikazTrenutnihIznajmljivanjaClan : Window
    {
        public ObservableCollection<Iznajmljivanje> Iznajmljivanja { get; set; }
        public Iznajmljivanje SelectedIznajmljivanje { get; set; }
        private IznajmljivanjeRepository _iznajmljivanjeRepository { get; set; }
        private ZahtevZaProduzavanjeRepository _zahtevZaProduzavanjeRepository { get; set; }
        public PrikazTrenutnihIznajmljivanjaClan()
        {
            InitializeComponent();
            this.DataContext = this;

            var app = Application.Current as App;
            _iznajmljivanjeRepository = app.IznajmljivanjeRepository;
            _zahtevZaProduzavanjeRepository = app._zahtevZaProduzavanjeRepository;

            Iznajmljivanja = new ObservableCollection<Iznajmljivanje>(_iznajmljivanjeRepository.GetAllTrenutnaIznajmljivanjaForClan(LogIn.LoggedUser.jmbg));
        }

        public void Refresh(List<Iznajmljivanje> iznajmljivanja)
        {
            Iznajmljivanja.Clear();
            foreach(Iznajmljivanje iznajmljivanje in iznajmljivanja)
            {
                Iznajmljivanja.Add(iznajmljivanje);
            }
        }

        private void PodnesiZahtevBtn_Click(object sender, RoutedEventArgs e)
        {
            ZahtevZaProduzavanje zahtevZaProduzavanje = new ZahtevZaProduzavanje();
            zahtevZaProduzavanje.DatumSlanja = DateTime.Now;
            zahtevZaProduzavanje.Clan = (Clan)LogIn.LoggedUser;
            if (SelectedIznajmljivanje == null)
            {
                MessageBox.Show("Morate odabrati red u tabeli!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            zahtevZaProduzavanje.Iznajmljivanje = SelectedIznajmljivanje;
            SelectedIznajmljivanje.brojZahtevaZaProduzavanje += 1;
            _iznajmljivanjeRepository.Update(SelectedIznajmljivanje);

            zahtevZaProduzavanje.StanjeZahteva = enums.StanjeZahteva.NA_CEKANJU;
            _zahtevZaProduzavanjeRepository.Create(zahtevZaProduzavanje);
            if (SelectedIznajmljivanje != null)
            {
                MessageBox.Show("Zahtev za produzavanje uspesno podnet!", "Uspeh!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {

            }
            Refresh(_iznajmljivanjeRepository.GetAllIznajmljivanjaForClan(LogIn.LoggedUser.jmbg));
        }


    }
}
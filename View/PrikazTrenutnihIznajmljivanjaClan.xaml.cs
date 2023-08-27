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

        private void PodnesiZahtevBtn_Click(object sender, RoutedEventArgs e)
        {
            ZahtevZaProduzavanje zahtevZaProduzavanje = new ZahtevZaProduzavanje();
            zahtevZaProduzavanje.Iznajmljivanje = SelectedIznajmljivanje;
            Iznajmljivanje iznajmljivanje = _iznajmljivanjeRepository.GetById(SelectedIznajmljivanje.id);
            iznajmljivanje.brojZahtevaZaProduzavanje += 1;
            _iznajmljivanjeRepository.Save();
            zahtevZaProduzavanje.DatumSlanja = DateTime.Now;
            zahtevZaProduzavanje.StanjeZahteva = StanjeZahteva.NA_CEKANJU;
            zahtevZaProduzavanje.Clan = (Clan)LogIn.LoggedUser;
            _zahtevZaProduzavanjeRepository.Create(zahtevZaProduzavanje);
            MessageBox.Show("Zahtev za produzavanje uspesno kreiran!", "Uspeh!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        

    }
}
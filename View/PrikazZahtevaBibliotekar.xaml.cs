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
        public PrikazZahtevaBibliotekar()
        {
            InitializeComponent();
            this.DataContext = this;
            

            var app = Application.Current as App;
            _zahtevZaProduzavanjeRepository = app._zahtevZaProduzavanjeRepository;

            Zahtevi = new ObservableCollection<ZahtevZaProduzavanje>(_zahtevZaProduzavanjeRepository.GetAll());
        }

        public void Refresh(List<ZahtevZaProduzavanje> zahtevi)
        {
            Zahtevi.Clear();
            foreach(ZahtevZaProduzavanje zahtev in zahtevi)
            {
                zahtevi.Add(zahtev);
            }
        }

        private void OdobriZahtev_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OdbijZahtev_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

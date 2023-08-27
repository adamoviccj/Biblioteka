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
    /// Interaction logic for PrikazZahtevaClan.xaml
    /// </summary>
    public partial class PrikazZahtevaClan : Window
    {
        public ObservableCollection<ZahtevZaProduzavanje> Zahtevi { get; set; }
        public ZahtevZaProduzavanje SelectedZahtev { get; set; }

        private ZahtevZaProduzavanjeRepository _zahtevZaProduzavanjeRepository { get; set; }
        public PrikazZahtevaClan()
        {
            InitializeComponent();
            this.DataContext = this;

            var app = Application.Current as App;
            _zahtevZaProduzavanjeRepository = app._zahtevZaProduzavanjeRepository;

            Zahtevi = new ObservableCollection<ZahtevZaProduzavanje>(_zahtevZaProduzavanjeRepository.GetAllZahteviClana(LogIn.LoggedUser.jmbg));
        }
    }
}

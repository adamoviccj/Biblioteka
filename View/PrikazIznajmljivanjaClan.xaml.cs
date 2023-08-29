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
    /// Interaction logic for PrikazIznajmljivanjaClan.xaml
    /// </summary>
    public partial class PrikazIznajmljivanjaClan : Window
    {
        private IznajmljivanjeRepository _iznajmljivanjeRepository;
        public static ObservableCollection<Iznajmljivanje> Iznajmljivanja { get; set; }
        public Iznajmljivanje SelectedIznajmljivanje { get; set; }
        private ZahtevZaProduzavanjeRepository _zahtevZaProduzavanjeRepository { get; set; }
        public PrikazIznajmljivanjaClan()
        {
            InitializeComponent();
            this.DataContext = this;

            var app = Application.Current as App;
            _iznajmljivanjeRepository = app.IznajmljivanjeRepository;
            _zahtevZaProduzavanjeRepository = app._zahtevZaProduzavanjeRepository;

            Iznajmljivanja = new ObservableCollection<Iznajmljivanje>(_iznajmljivanjeRepository.GetProslaIznajmljivanjaClana(LogIn.LoggedUser.jmbg));

        }

        public void Refresh(List<Iznajmljivanje> iznajmljivanja)
        {
            Iznajmljivanja.Clear();
            foreach(Iznajmljivanje iznajmljivanje in iznajmljivanja)
            {
                Iznajmljivanja.Add(iznajmljivanje);
            }
        }

        
    }
}

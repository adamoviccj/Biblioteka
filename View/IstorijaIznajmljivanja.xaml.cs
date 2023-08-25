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
    /// Interaction logic for IstorijaIznajmljivanja.xaml
    /// </summary>
    public partial class IstorijaIznajmljivanja : Window
    {
        public ObservableCollection<Iznajmljivanje> Iznajmljivanja { get; set; }
        public Iznajmljivanje SelectedIznajmljivanje { get; set;}

        private IznajmljivanjeRepository _iznajmljivanjeRepository { get; set; }
        public IstorijaIznajmljivanja()
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;
            _iznajmljivanjeRepository = app.IznajmljivanjeRepository;

            Iznajmljivanja = new ObservableCollection<Iznajmljivanje>(_iznajmljivanjeRepository.GetAllIznajmljivanja());
        }

        
    }
}

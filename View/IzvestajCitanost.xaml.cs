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
    /// Interaction logic for IzvestajCitanost.xaml
    /// </summary>
    public partial class IzvestajCitanost : Window
    {
        public ObservableCollection<IzdanjeKnjige> Izdanja { get; set; }
        public IzdanjeKnjige SelectedIzdanje { get; set; }
        private IzdanjeKnjigeRepository _izdanjeKnjigeRepository { get; set; }
        public IzvestajCitanost()
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;
            _izdanjeKnjigeRepository = app.IzdanjeKnjigeRepository;

            Izdanja = new ObservableCollection<IzdanjeKnjige>(_izdanjeKnjigeRepository.SortirajPoCitanosti());
        }
    }
}

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
    /// Interaction logic for PrikazRezervacijaBibliotekar.xaml
    /// </summary>
    public partial class PrikazRezervacijaBibliotekar : Window
    {
        public ObservableCollection<Rezervacija> Rezervacije { get; set; }
        public Rezervacija SelectedRezervacija { get; set; }
        public RezervacijaRepository _rezervacijaRepository { get; set; }
        public PrikazRezervacijaBibliotekar()
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;
            _rezervacijaRepository = app._rezervacijaRepository;
            

            Rezervacije = new ObservableCollection<Rezervacija>(_rezervacijaRepository.GetAllRezervacije());
        }

        
    }
}

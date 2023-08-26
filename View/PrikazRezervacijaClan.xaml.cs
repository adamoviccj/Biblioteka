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
    /// Interaction logic for PrikazRezervacijaClan.xaml
    /// </summary>
    public partial class PrikazRezervacijaClan : Window
    {
        public static ObservableCollection<Rezervacija> Rezervacije { get; set; }
        private RezervacijaRepository _rezervacijaRepository { get; set; }
        public PrikazRezervacijaClan()
        {
            InitializeComponent();
            this.DataContext = this;

            var app = Application.Current as App;
            _rezervacijaRepository = app._rezervacijaRepository;

            Rezervacije = new ObservableCollection<Rezervacija>(_rezervacijaRepository.GetAllRezervacijeClana(LogIn.LoggedUser.jmbg));

        }

        private void dodajRezervacijuBtn_Click(object sender, RoutedEventArgs e)
        {
            KreiranjeRezervacijeClan kreiranjeRezervacijeClan = new KreiranjeRezervacijeClan(null);
            kreiranjeRezervacijeClan.Show();
        }

        public static void RefreshView(List<Rezervacija> rezervacije)
        {
            
            Rezervacije.Clear();
            foreach (Rezervacija rezervacija in rezervacije)
            {
                Rezervacije.Add(rezervacija);
            }
        }
    }
}

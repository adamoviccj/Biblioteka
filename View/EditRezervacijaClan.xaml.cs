using SIMS_Projekat.Model;
using SIMS_Projekat.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for EditRezervacijaClan.xaml
    /// </summary>
    public partial class EditRezervacijaClan : Window
    {
        public ObservableCollection<Knjiga> Knjige { get; set; }
        public Knjiga SelectedKnjiga { get; set; }
        private RezervacijaRepository _rezervacijaRepository { get; set; }
        private KnjigaRepository _knjigaRepository { get; set; }
        private Rezervacija rezervacijaForUpdate;

        public EditRezervacijaClan(Rezervacija rezervacija)
        {
            InitializeComponent();
            this.DataContext = this;

            var app = Application.Current as App;
            _knjigaRepository = app.KnjigaRepository;
            _rezervacijaRepository = app._rezervacijaRepository;
            rezervacijaForUpdate = rezervacija;

            Knjige = new ObservableCollection<Knjiga>(_knjigaRepository.GetAllKnjige());
        }
        
        private void EditRezervacijaBtn_Click(object sender, RoutedEventArgs e)
        {
            Rezervacija rezervacija = new Rezervacija();
            rezervacija.knjiga = rezervacijaForUpdate.knjiga;
            rezervacija.clan = (Clan)LogIn.LoggedUser;
            if(!_rezervacijaRepository.Edit(rezervacija))
            {
                MessageBox.Show("Greska u izmeni rezervacije!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            } else
            {
                MessageBox.Show("Rezervacija uspesno izvrsena!", "Uspeh!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}

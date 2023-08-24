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
    /// Interaction logic for BibliotekarProfil.xaml
    /// </summary>
    public partial class BibliotekarProfil : Window


    {
            public ObservableCollection<Clan> Clanovi { get; set; }



            
            private ClanRepository _clanRepository;

            public BibliotekarProfil()
            {
                InitializeComponent();
                this.DataContext = this;

                var app = Application.Current as App;
                _clanRepository = app._clanRepository;



            Clanovi = new ObservableCollection<Clan>(_clanRepository.GetAllClanovi());



            }

            private void DodajClana_Click(object sender, RoutedEventArgs e)
            {
                RegistracijaClana regClana = new RegistracijaClana();
                regClana.Show();
            }

            private void IzmeniClana_Click(object sender, RoutedEventArgs e)
            {

            }

            private void ObrisiClana_Click(object sender, RoutedEventArgs e)
            {

            }

            private void Odjava_Click(object sender, RoutedEventArgs e)

            {
                MainWindow main = new MainWindow();   //zatvoriti preth prozore
                main.Show();

            }

            private void IznajmiKnjigu_Click(object sender, RoutedEventArgs e)
            {
                IznajmljivanjeBibliotekar iznajmljivanjeBibliotekar = new IznajmljivanjeBibliotekar(null, null, null);
                iznajmljivanjeBibliotekar.Show();
            }


        }
    }

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
            public Clan SelectedClan { get; set; }





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
            ClanRepository clanRepository = new ClanRepository();

            // Get the selected item from the DataGrid
            Clan selectedClan = membersDataGrid.SelectedItem as Clan;

            if (selectedClan != null)
            {
                new EditClan(selectedClan).Show();
                // Refresh the DataGrid if necessary
                // membersDataGrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Niste izabrali clana za izmenu!");
            }
        }



        private void ObrisiClana_Click(object sender, RoutedEventArgs e)
        {
            ClanRepository clanRepository = new ClanRepository();
            ClanskaKartaRepository clanskaKartaRepository = new ClanskaKartaRepository();

            // Get the selected item from the DataGrid
            Clan selectedClan = membersDataGrid.SelectedItem as Clan;

            if (selectedClan != null)
            {
                ClanskaKarta clanskaKarta = clanskaKartaRepository.GetClanskaKartaByBr(selectedClan.brClanskeKarte);
                if (clanskaKarta != null)
                {
                    clanskaKartaRepository.ClanskeKarte.Remove(clanskaKarta);
                    clanskaKartaRepository.Save();
                }


                clanRepository.Clanovi.Remove(selectedClan);
                clanRepository.Save();
                MessageBox.Show("Clan uspesno obrisan!");

                // Refresh the DataGrid if necessary
                membersDataGrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Niste izabrali clana za brisanje!");
            }
        }


        private void Odjava_Click(object sender, RoutedEventArgs e)

            {
                MainWindow main = new MainWindow();   //zatvoriti preth prozore
                main.Show();

            }

            private void IznajmiKnjigu_Click(object sender, RoutedEventArgs e)
            {
                IznajmljivanjeBibliotekar iznajmljivanjeBibliotekar = new IznajmljivanjeBibliotekar(null,null,null);
                iznajmljivanjeBibliotekar.Show();
            }

            private void ShowIstorijaIznajmljivanja_Click(object sender, RoutedEventArgs e)
            {
                IstorijaIznajmljivanja istorijaIznajmljivanja = new IstorijaIznajmljivanja();
                istorijaIznajmljivanja.Show();
            }
        }
    }

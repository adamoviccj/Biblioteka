using SIMS_Projekat.Model;
using SIMS_Projekat.Repository;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        private KorisnikRepository korisnikRepository;
        private ClanRepository clanRepository;
        private ObicanBibliotekarRepository obicanBibliotekarRepository;
        private VisiBibliotekarRepository specijalizovanBibliotekarRepository;

        public static Korisnik LoggedUser { get; set; }

        public LogIn()
        {
            InitializeComponent();

            korisnikRepository = new KorisnikRepository();
            clanRepository = new ClanRepository();
            obicanBibliotekarRepository = new ObicanBibliotekarRepository();
            specijalizovanBibliotekarRepository = new VisiBibliotekarRepository();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;
            Korisnik korisnik = korisnikRepository.GetKorisnikByUsernameAndPassword(username, password);
            if (korisnik == null)
            {
                MessageBox.Show("Pogresno korisnicko ime ili lozinka!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            } else
            {
                LoggedUser = korisnik;
            }

            // Provjeri uneseno korisničko ime i lozinku u svim repozitorijumima
            //KorisnickiNalog nalog = TryLoginInRepositories(username, password);

            //if (nalog != null)
            //{
            /*
                if (nalog.GetType() == typeof(Clan))
                {
                    //ClanWindow clanWindow = new ClanWindow();
                    //clanWindow.Show();
                }
            */
                if (username.StartsWith("0"))
                {
                    MessageBox.Show("Ulogovali ste se na obicnog bibliotekara.", "Dobrodosli", MessageBoxButton.OK, MessageBoxImage.Information);
                
                    BibliotekarProfil obicanBibliotekarWindow = new BibliotekarProfil();
                    obicanBibliotekarWindow.Show();
                }


            else if (username.StartsWith("1"))
            {
                MessageBox.Show("Ulogovali ste se na viseg bibliotekara.", "Dobrodosli", MessageBoxButton.OK, MessageBoxImage.Information);

                //VisiBibliotekarWindow visiBibliotekarWindow = new VisiBibliotekarWindow();
                //visiBibliotekarWindow.Show();
            }
            /*
            else if (nalog.GetType() == typeof(VisiBibliotekar))
            {
                //VisiBibliotekarWindow visiBibliotekarWindow = new VisiBibliotekarWindow();
                //visiBibliotekarWindow.Show();
            }
            */
            else if(username.StartsWith("2"))
            {
                MessageBox.Show("Ulogovali ste se na clana.", "Dobrodosli", MessageBoxButton.OK, MessageBoxImage.Information);
                var clanProfil = new ClanProfil();
                clanProfil.Show();
            }
            else
            {
                MessageBox.Show("Nista.", "Nista", MessageBoxButton.OK, MessageBoxImage.Error);

            }

                Close();
            ///}
            //else
            //{
                //MessageBox.Show("Pogrešno korisničko ime ili lozinka.", "Greška pri prijavi", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }


        /*
        private KorisnickiNalog TryLoginInRepositories(string username, string password)
        {
            
            var clan = clanRepository.FindClanByUsername(username);
            if (clan != null && clan.nalog.password == password)
            {
                return clan.nalog;
            }

            var obicanBibliotekar = obicanBibliotekarRepository.FindObicanBibliotekarByUsername(username);
            if (obicanBibliotekar != null && obicanBibliotekar.nalog.password == password)
            {
                return obicanBibliotekar.nalog;
            }

            var visiBibliotekar = visiBibliotekarRepository.FindVisiBibliotekarByUsername(username);
            if (visiBibliotekar != null && visiBibliotekar.nalog.password == password)
            {
                return visiBibliotekar.nalog;
            }

            return null; 
        }
        */
    }

}

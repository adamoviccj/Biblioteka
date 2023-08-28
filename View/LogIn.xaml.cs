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
        private ObicanBibliotekarRepository obicanBibliotekarRepository { get; set; }
        private VisiBibliotekarRepository visiBibliotekarRepository;
        public KorisnickiNalog Nalog { get; set; }

        public static Korisnik LoggedUser { get; set; }
        public ObicanBibliotekar CheckObicanBibliotekarLogin()
        {
            return obicanBibliotekarRepository.ObicniBibliotekari.FirstOrDefault(bibl => bibl.nalog.username == LoggedUser.nalog.username && bibl.nalog.password == LoggedUser.nalog.password);
        }


        public VisiBibliotekar CheckVisiBibliotekarLogin()
        {
            return visiBibliotekarRepository.VisiBibliotekari.FirstOrDefault(visi => visi.nalog.username == LoggedUser.nalog.username && visi.nalog.password == LoggedUser.nalog.password);
        }

        public Clan CheckClanLogin()
        {
            return clanRepository.Clanovi.FirstOrDefault(clan => clan.nalog.username == LoggedUser.nalog.username && clan.nalog.password == LoggedUser.nalog.password);
        }

        public LogIn()
        {
            InitializeComponent();

            korisnikRepository = new KorisnikRepository();
            clanRepository = new ClanRepository();
            obicanBibliotekarRepository = new ObicanBibliotekarRepository();
            visiBibliotekarRepository = new VisiBibliotekarRepository();
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

            //if (Nalog != null && !string.IsNullOrEmpty(Nalog.username) && !string.IsNullOrEmpty(Nalog.password))
            //{
                if (CheckObicanBibliotekarLogin()!=null)
                {
                    
                    MessageBox.Show("Uspesno ulogovan obican bibliotekar.");
                    BibliotekarProfil obicanBibliotekarWindow = new BibliotekarProfil();
                    obicanBibliotekarWindow.Show();
                }

            else if (CheckVisiBibliotekarLogin() != null)
            {
                
                MessageBox.Show("Uspesno ulogovan visi bibliotekar.");
                //VisiBibliotekarWindow visiBibliotekarWindow = new VisiBibliotekarWindow();
                //visiBibliotekarWindow.Show();
            }

            else if (CheckClanLogin() != null)
            {
                
                MessageBox.Show("Uspesno ulogovan clan.");
                ClanProfil clanW = new ClanProfil();
                clanW.Show();
            }
            //}


            Close();
        }


    }

}

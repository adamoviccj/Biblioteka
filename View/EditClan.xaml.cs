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
    /// Interaction logic for EditClan.xaml
    /// </summary>
    public partial class EditClan : Window
    {
        public EditClan(Clan selectedClan)
        {
            InitializeComponent();
            comboBoxClanstvo.Items.Add("DECA");
            comboBoxClanstvo.Items.Add("ODRASLI");
            comboBoxClanstvo.Items.Add("STUDENTI");
            comboBoxClanstvo.Items.Add("PENZIONERI");
            comboBoxClanstvo.Items.Refresh();
            emailText.Text = selectedClan.email;
            imeText.Text = selectedClan.ime;
            prezimeText.Text = selectedClan.prezime;
            jmbgText.Text = selectedClan.jmbg;
            telefonText.Text = selectedClan.telefon;
            usernameText.Text = selectedClan.nalog.username;
            passwordText.Text = selectedClan.nalog.password;
            ClanskaKartaRepository clanskaKartaRepository = new ClanskaKartaRepository();
            ClanskaKarta clanskaKarta = clanskaKartaRepository.GetClanskaKartaByBr(selectedClan.brClanskeKarte);
            comboBoxClanstvo.Text = Enum.GetName(typeof(TipClanstva), clanskaKarta.clanstvo);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            ClanRepository clanRepository = new ClanRepository();
            Clan clan = clanRepository.FindClanByUsername(usernameText.Text);
            clan.email = emailText.Text;
            clan.ime = imeText.Text;
            clan.prezime = prezimeText.Text;
            clan.jmbg = jmbgText.Text;
            clan.telefon = telefonText.Text;
            clan.nalog.password = passwordText.Text;
            clanRepository.Save();
        }
    }
}

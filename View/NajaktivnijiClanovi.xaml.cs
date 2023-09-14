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
    /// Interaction logic for NajaktivnijiClanovi.xaml
    /// </summary>
    public partial class NajaktivnijiClanovi : Window
    {
        private List<Iznajmljivanje> iznajmljivanja { get; set; }
        private IznajmljivanjeRepository iznajmljivanjeRepository { get; set; }
        private ClanRepository ClanRepository { get; set; }
        private List<Clan> clanovi { get; set; }
        public NajaktivnijiClanovi()
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;
            iznajmljivanjeRepository = app.IznajmljivanjeRepository;
            ClanRepository = app._clanRepository;
            iznajmljivanja = iznajmljivanjeRepository.GetAll();
            clanovi = ClanRepository.GetAllClanovi();

            Izvestaj();
        }

        public void Izvestaj()
        {
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            foreach(Clan clan in clanovi)
            {
                int aktivnost = iznajmljivanjeRepository.GetProslaIznajmljivanjaClana(clan.jmbg).Count;
                keyValuePairs[clan.ime + " " + clan.prezime] = aktivnost;
            }

            List<KeyValuePair<string, int>> dataList = new List<KeyValuePair<string, int>>(keyValuePairs).Take(10).ToList();
            dataList = dataList.OrderByDescending(kvp => kvp.Value).ToList();
            izvestajCitanostDataGrid.ItemsSource = dataList;
        }
    }
}

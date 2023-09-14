using SIMS_Projekat.Model;
using SIMS_Projekat.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        private List<IzdanjeKnjige> izdanja { get; set; }
        public IzdanjeKnjige SelectedIzdanje { get; set; }
        private IzdanjeKnjigeRepository _izdanjeKnjigeRepository { get; set; }
        private IznajmljivanjeRepository _iznajmljivanjeRepository { get; set; }
        public int BrCitanja { get; set; }
        private string _period;
        public string period
        {
            get { return _period; }
            set
            {
                if (_period != value)
                {
                    _period = value;
                    OnPropertyChanged(nameof(period));
                    IzvestajZaPeriod();
                }
            }
        }
        public IzvestajCitanost()
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;
            _izdanjeKnjigeRepository = app.IzdanjeKnjigeRepository;
            _iznajmljivanjeRepository = app.IznajmljivanjeRepository;
            periodCombo.Items.Add("dan");
            periodCombo.Items.Add("nedelja");
            periodCombo.Items.Add("mesec");
            periodCombo.Items.Add("godina");

            Izdanja = new ObservableCollection<IzdanjeKnjige>(_izdanjeKnjigeRepository.SortirajPoCitanosti());
            izdanja = _izdanjeKnjigeRepository.GetAll();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void IzvestajZaPeriod()
        {
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            if (period == "dan")
            {

                foreach (IzdanjeKnjige izdanje in izdanja)
                {
                    int brojCitanja = _iznajmljivanjeRepository.GetAllIznajmljivanjaDan(izdanje.knjiga.nazivKnjige).Count();
                    keyValuePairs[izdanje.knjiga.nazivKnjige] = brojCitanja;

                }
            }
            else if (period == "nedelja")
            {
                foreach (IzdanjeKnjige izdanje in izdanja)
                {
                    int brojCitanja = _iznajmljivanjeRepository.GetAllIznajmljivanjaNedelja(izdanje.knjiga.nazivKnjige).Count();
                    keyValuePairs[izdanje.knjiga.nazivKnjige] = brojCitanja;

                }
            }
            else if (period == "mesec")
            {
                foreach (IzdanjeKnjige izdanje in izdanja)
                {
                    int brojCitanja = _iznajmljivanjeRepository.GetAllIznajmljivanjaMesec(izdanje.knjiga.nazivKnjige).Count();
                    keyValuePairs[izdanje.knjiga.nazivKnjige] = brojCitanja;

                }
            }
            else if (period == "godina")
            {
                foreach (IzdanjeKnjige izdanje in izdanja)
                {
                    int brojCitanja = _iznajmljivanjeRepository.GetAllIznajmljivanjaGodina(izdanje.knjiga.nazivKnjige).Count();
                    keyValuePairs[izdanje.knjiga.nazivKnjige] = brojCitanja;

                }
            }

            List<KeyValuePair<string, int>> dataList = new List<KeyValuePair<string, int>>(keyValuePairs).Take(10).ToList();
            dataList = dataList.OrderByDescending(kvp => kvp.Value).ToList();
            izvestajCitanostDataGrid.ItemsSource = dataList;


        }
    }
}

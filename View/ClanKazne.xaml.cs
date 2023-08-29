using SIMS_Projekat.enums;
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
    /// Interaction logic for ClanKazne.xaml
    /// </summary>
    public partial class ClanKazne : Window, INotifyPropertyChanged
    {


        public ObservableCollection<Kazna> Kazne { get; set; }
        private KaznaRepository _kaznaRepository { get; set; }

        private Kazna _selectedKazna;
        public Kazna selectedKazna
        {
            get { return _selectedKazna; }
            set
            {
                if (_selectedKazna != value)
                {
                    _selectedKazna = value;
                    OnPropertyChanged(nameof(selectedKazna));
                }
            }
        }

        public ClanKazne()
        {
            LoadKazne();
            InitializeComponent();
            DataContext = this;

        }

        public void LoadKazne()
        {
            var app = Application.Current as App;
            _kaznaRepository = app._kaznaRepository;
            Kazne = new ObservableCollection<Kazna>(_kaznaRepository.GetNeplaceneKazneByUsername(LogIn.LoggedUser.nalog.username));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
     

            if (selectedKazna == null)
            {
                MessageBox.Show("Izaberite kaznu");
                return;
            }

            if (_kaznaRepository.UplatiKaznu(selectedKazna.id))
            {
                MessageBox.Show("Uspesno uplacena kazna");
            }
            else
            {
                MessageBox.Show("Greska prilikom uplate kazne");
            }
            LoadKazne();
            OnPropertyChanged(nameof(Kazne));
            return;
        }
    }
}

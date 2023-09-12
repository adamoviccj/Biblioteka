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
    /// Interaction logic for PrikazKnjiga.xaml
    /// </summary>
    public partial class PrikazKnjiga : Window
    {
        public ObservableCollection<Knjiga> Knjige { get; set; }
        public string SearchParam { get; set; }
        private KnjigaRepository _knjigaRepository { get; set; }
        private string _kriterijum;
        public string kriterijum
        {
            get { return _kriterijum; }
            set
            {
                if (_kriterijum != value)
                {
                    _kriterijum = value;
                    OnPropertyChanged(nameof(kriterijum));
                }
            }
        }
        public PrikazKnjiga()
        {
            InitializeComponent();
            this.DataContext = this;

            var app = Application.Current as App;
            _knjigaRepository = app.KnjigaRepository;
            kriterijumCombo.Items.Add("naziv knjige");
            kriterijumCombo.Items.Add("ime autora");
            kriterijumCombo.Items.Add("prezime autora");

            Knjige = new ObservableCollection<Knjiga>(_knjigaRepository.GetAllKnjige());

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Refresh(List<Knjiga> knjige)
        {
            Knjige.Clear();
            foreach(Knjiga knjiga in knjige)
            {
                Knjige.Add(knjiga);
            }
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Knjiga> knjige = new List<Knjiga>();
            if (kriterijum == "naziv knjige")
            {
                knjige = _knjigaRepository.GetSearchedKnjigeByNaziv(SearchParam);
            } else if (kriterijum == "ime autora")
            {
                knjige = _knjigaRepository.GetSearchedKnjigeByImeAutora(SearchParam);
            } else if (kriterijum == "prezime autora")
            {
                knjige = _knjigaRepository.GetSearchedKnjigeByPrezimeAutora(SearchParam);
            }
            Refresh(knjige);
        }

        private void SortByNaziv_Click(object sender, RoutedEventArgs e)
        {
            List<Knjiga> knjige = _knjigaRepository.GetSortedByNaziv();
            Refresh(knjige);
        }

        private void SortByImeAutora_Click(object sender, RoutedEventArgs e)
        {
            List<Knjiga> knjige = _knjigaRepository.GetSortedByImeAutora();
            Refresh(knjige);
        }

        private void SortByPrezimeAutora_Click(object sender, RoutedEventArgs e)
        {
            List<Knjiga> knjige = _knjigaRepository.GetSortedByPrezimeAutora();
            Refresh(knjige);
        }
    }
}

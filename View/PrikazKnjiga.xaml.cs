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
    /// Interaction logic for PrikazKnjiga.xaml
    /// </summary>
    public partial class PrikazKnjiga : Window
    {
        public ObservableCollection<Knjiga> Knjige { get; set; }
        public string SearchParam { get; set; }
        private KnjigaRepository _knjigaRepository { get; set; }
        public PrikazKnjiga()
        {
            InitializeComponent();
            this.DataContext = this;

            var app = Application.Current as App;
            _knjigaRepository = app.KnjigaRepository;

            Knjige = new ObservableCollection<Knjiga>(_knjigaRepository.GetAllKnjige());

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
            List<Knjiga> knjige = _knjigaRepository.GetSearchedKnjige(SearchParam);
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

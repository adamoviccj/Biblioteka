using SIMS_Projekat.Repository;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SIMS_Projekat.View
{
    public partial class IzvestajSmene : Window, INotifyPropertyChanged
    {
        public double IznosClanarine { get; set; }
        public double IznosKazne { get; set; }
        public int DanasnjaIznajmljivanja { get; set; }
        public int DanasnjaVracanja { get; set; }

        private ClanskaKartaRepository _clanskaKartaRepository { get; set; }
        private KaznaRepository _kaznaRepository { get; set; }
        private IznajmljivanjeRepository _iznajmljivanjeRepository { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateProperties()
        {
            IznosClanarine = _clanskaKartaRepository.GetDanasnjeClanarine();
            IznosKazne = _kaznaRepository.GetDanasnjeKazne();
            DanasnjaIznajmljivanja = _iznajmljivanjeRepository.GetDanasnjaIznajmljivanja().Count();
            DanasnjaVracanja = _iznajmljivanjeRepository.GetDanasnjaVracanja().Count();

            // Notify the UI that properties have changed
            OnPropertyChanged(nameof(IznosClanarine));
            OnPropertyChanged(nameof(IznosKazne));
            OnPropertyChanged(nameof(DanasnjaIznajmljivanja));
            OnPropertyChanged(nameof(DanasnjaVracanja));
        }

        public IzvestajSmene()
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;
            _clanskaKartaRepository = app._clanskaKartaRepository;
            _kaznaRepository = app._kaznaRepository;
            _iznajmljivanjeRepository = app.IznajmljivanjeRepository;

            UpdateProperties();
        }
    }
}

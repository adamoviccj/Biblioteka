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
    /// Interaction logic for IzvestajSmene.xaml
    /// </summary>
    public partial class IzvestajSmene : Window
    {
        public double IznosClanarine { get; set; }
        public double IznosKazne { get; set; }
        public int DanasnjaIznajmljivanja { get; set; }
        public int DanasnjaVracanja { get; set; }
        private ClanskaKartaRepository _clanskaKartaRepository { get; set; }
        private KaznaRepository _kaznaRepository { get; set; }
        private IznajmljivanjeRepository _iznajmljivanjeRepository { get; set; }
        public IzvestajSmene()
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;
            _clanskaKartaRepository = app._clanskaKartaRepository;
            _kaznaRepository = app._kaznaRepository;
            _iznajmljivanjeRepository = app.IznajmljivanjeRepository;
            

            IznosClanarine = _clanskaKartaRepository.GetDanasnjeClanarine();
            IznosKazne = _kaznaRepository.GetDanasnjeKazne();
            DanasnjaIznajmljivanja = _iznajmljivanjeRepository.GetDanasnjaIznajmljivanja().Count();
            DanasnjaVracanja = _iznajmljivanjeRepository.GetDanasnjaVracanja().Count();
            
        }
    }
}

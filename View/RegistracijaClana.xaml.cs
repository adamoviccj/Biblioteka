using SIMS_Projekat.ViewModel;
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
    /// Interaction logic for RegistracijaClana.xaml
    /// </summary>
    public partial class RegistracijaClana : Window
    {
        public RegistracijaClana()
        {
            InitializeComponent();
            DataContext = new RegistracijaViewModel();
            comboBoxClanstvo.Items.Add("DECA");
            comboBoxClanstvo.Items.Add("ODRASLI");
            comboBoxClanstvo.Items.Add("STUDENTI");
            comboBoxClanstvo.Items.Add("PENZIONERI");
            comboBoxClanstvo.Items.Refresh();
        }
    }
}

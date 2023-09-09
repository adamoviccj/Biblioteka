using SIMS_Projekat.Model;
using SIMS_Projekat.Repository;
using System.Collections.Generic;
using System.Windows;

namespace SIMS_Projekat.View
{
    public partial class PremestiPrimerkeWindow : Window
    {
        public PremestiPrimerkeWindow()
        {
            InitializeComponent();

            PrimerakRepository primerakRepo = new PrimerakRepository();
            List<Primerak> sviPrimerci = primerakRepo.GetAllPrimerci();

            foreach (Primerak primerak in sviPrimerci)
            {
                primerciComboBox.Items.Add(primerak);
            }

            OgranakRepository ogranakRepo = new OgranakRepository();
            List<Ogranak> sviOgranci = ogranakRepo.GetAllOgranci();

            foreach (Ogranak ogranak in sviOgranci)
            {
                ogranciComboBox.Items.Add(ogranak);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (primerciComboBox.SelectedItem == null)
            {
                MessageBox.Show("Morate odabrati primerak!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ogranciComboBox.SelectedItem == null)
            {
                MessageBox.Show("Morate odabrati ogranak u koji zelite da premestite primerak!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            PrimerakRepository primerakRepo = new PrimerakRepository();
            List<Primerak> sviPrimerci = primerakRepo.GetAllPrimerci();

            Primerak updatedPrimerak = (Primerak)primerciComboBox.SelectedItem;
            sviPrimerci.RemoveAt(primerciComboBox.SelectedIndex);

            updatedPrimerak.ogranak = (Ogranak)ogranciComboBox.SelectedItem;

            sviPrimerci.Add(updatedPrimerak);
            primerakRepo.Primerci = sviPrimerci;
            primerakRepo.Save();

            MessageBox.Show("Uspesno premesten primerak!", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Information);

        }

    }
}

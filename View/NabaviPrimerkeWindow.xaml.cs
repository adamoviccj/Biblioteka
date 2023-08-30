using System.Collections.Generic;
using System.Windows;
using SIMS_Projekat.Model;
using SIMS_Projekat.Repository;

namespace SIMS_Projekat.View
{
    public partial class NabaviPrimerkeWindow : Window
    {
        public NabaviPrimerkeWindow()
        {
            InitializeComponent();

            KnjigaRepository knjigeRepo = new KnjigaRepository();
            List<Knjiga> books = knjigeRepo.GetAllKnjige();

            foreach (Knjiga book in books)
            {
                knjigaComboBox.Items.Add(book);
            }

            OgranakRepository ogranciRepo = new OgranakRepository();
            List<Ogranak> ogranci = ogranciRepo.GetAllOgranci();

            foreach (Ogranak ogranak in ogranci)
            {
                ogranakComboBox.Items.Add(ogranak);
            }
        }

        private void knjigaComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            izdanjeComboBox.Items.Clear();

            if(knjigaComboBox.SelectedItem == null)
            {
                MessageBox.Show("Morate prvo izabrati knjigu!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            IzdanjeKnjigeRepository izdanjaRepo = new IzdanjeKnjigeRepository();
            List<IzdanjeKnjige> allIzdanja = izdanjaRepo.GetAllIzdanjaKnjige();

            foreach (IzdanjeKnjige izdanje in allIzdanja)
            {
                if (!izdanje.PripadaKnjizi((Knjiga)knjigaComboBox.SelectedItem)) continue;
                izdanjeComboBox.Items.Add(izdanje);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (knjigaComboBox.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati knjigu!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (izdanjeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati izdanje!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (ogranakComboBox.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati ogranak!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (inventarniBrojTextBox.Text == "")
            {
                MessageBox.Show("Morate uneti inventani broj novog primerka!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            PrimerakRepository primerakRepo = new PrimerakRepository();
            List<Primerak> primerci = primerakRepo.GetAllPrimerci();

            foreach (Primerak primerak in primerci)
            {
                if (primerak.inventarniBroj == inventarniBrojTextBox.Text)
                {
                    MessageBox.Show("Ne mozete uneti inventarni broj koji vec postoji!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            Primerak noviPrimerak = new Primerak(inventarniBrojTextBox.Text, 1500, enums.Dostupnost.SLOBODNA, null,
                (IzdanjeKnjige)izdanjeComboBox.SelectedItem, (Ogranak)ogranakComboBox.SelectedItem);

            primerakRepo.Primerci.Add(noviPrimerak);
            primerakRepo.Save();

            MessageBox.Show("Uspesno nabavljen primerak!", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Information);

        }

    }
}

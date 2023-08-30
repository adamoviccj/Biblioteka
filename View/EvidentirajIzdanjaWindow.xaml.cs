using SIMS_Projekat.enums;
using SIMS_Projekat.Model;
using SIMS_Projekat.Repository;
using System.Collections.Generic;
using System.Windows;

namespace SIMS_Projekat.View
{
    public partial class EvidentirajIzdanjaWindow : Window
    {
        public EvidentirajIzdanjaWindow()
        {
            InitializeComponent();

            fillBooks();

            koricenjeComboBox.Items.Add(TipKoricenja.MEKO);
            koricenjeComboBox.Items.Add(TipKoricenja.TVRDO);
        }

        private void fillBooks()
        {
            knjigaComboBox.Items.Clear();

            KnjigaRepository knjigeRepo = new KnjigaRepository();
            List<Knjiga> books = knjigeRepo.GetAllKnjige();

            foreach (Knjiga book in books)
            {
                knjigaComboBox.Items.Add(book);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Knjiga knjiga;
            if (knjigaUSistemuRadioButton.IsChecked == true)
            {
                if (knjigaComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Morate odabrati knjigu!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                knjiga = (Knjiga)knjigaComboBox.SelectedItem;
            }
            else
            {
                if (nazivKnjigeTextBox.Text == "" || opisKnjigeTextBox.Text == "" || autorTextBox.Text == "")
                {
                    MessageBox.Show("Morate uneti knjigu!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                Autor autor;
                try
                {
                    autor = new Autor(autorTextBox.Text.Split(' ')[0], autorTextBox.Text.Split(' ')[1], autorTextBox.Text.Split(' ')[2]);
                }
                catch
                {
                    MessageBox.Show("Morate uneti podatke o autoru ispravno!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                knjiga = new Knjiga(nazivKnjigeTextBox.Text, opisKnjigeTextBox.Text, autor);
            }
            if (isbnTextBox.Text == "")
            {
                MessageBox.Show("Morate uneti ISBN izdanja!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (udkTextBox.Text == "")
            {
                MessageBox.Show("Morate uneti UDK izdanja!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (jezikTextBox.Text == "")
            {
                MessageBox.Show("Morate uneti jezik izdanja!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (formatTextBox.Text == "")
            {
                MessageBox.Show("Morate uneti format izdanja!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (izdavacNazivTextBox.Text == "" || izdavacDrzavaTextBox.Text == "")
            {
                MessageBox.Show("Morate uneti izdavaca!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (godIzdanjaTextBox.Text == "")
            {
                MessageBox.Show("Morate uneti godinu izdanja!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (koricenjeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Morate uneti tip koricenja!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            KnjigaRepository knjigaRepo = new KnjigaRepository();
            knjigaRepo.Knjige.Add(knjiga);
            knjigaRepo.Save();

            Izdavac izdavac = new Izdavac(izdavacNazivTextBox.Text, izdavacDrzavaTextBox.Text);

            IzdanjeKnjige izdanje = new IzdanjeKnjige(isbnTextBox.Text, udkTextBox.Text, jezikTextBox.Text, godIzdanjaTextBox.Text,
                formatTextBox.Text, (TipKoricenja)koricenjeComboBox.SelectedItem, 0, knjiga, izdavac);

            IzdanjeKnjigeRepository repository = new IzdanjeKnjigeRepository();
            repository.Izdanja.Add(izdanje);
            repository.Save();

            fillBooks();

            MessageBox.Show("Uspesno evidentirano novo izdanje!", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void knjigaUSistemuRadioButton_Click(object sender, RoutedEventArgs e)
        {
            knjigaComboBox.IsEnabled = true;
            nazivKnjigeTextBox.IsEnabled = false;
            opisKnjigeTextBox.IsEnabled = false;
            autorTextBox.IsEnabled = false;
        }

        private void knjigaNovaRadioButton_Click(object sender, RoutedEventArgs e)
        {
            nazivKnjigeTextBox.IsEnabled = true;
            opisKnjigeTextBox.IsEnabled = true;
            autorTextBox.IsEnabled = true;
            knjigaComboBox.SelectedIndex = -1;
            knjigaComboBox.IsEnabled = false;
        }

    }
}

using SIMS_Projekat.enums;
using SIMS_Projekat.Model;
using SIMS_Projekat.Repository;
using System.Collections.Generic;
using System.Windows;

namespace SIMS_Projekat.View
{
    public partial class ObrisiIzdanjaWindow : Window
    {
        public ObrisiIzdanjaWindow()
        {
            InitializeComponent();

            fillBooks();
        }

        private void fillBooks()
        {
            knjigeComboBox.Items.Clear();

            KnjigaRepository knjigeRepo = new KnjigaRepository();
            List<Knjiga> books = knjigeRepo.GetAllKnjige();

            foreach (Knjiga book in books)
            {
                knjigeComboBox.Items.Add(book);
            }
        }

        private void knjigeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            updateIzdanja();
        }

        private void updateIzdanja()
        {
            izdanjaComboBox.Items.Clear();

            if (knjigeComboBox.SelectedItem == null) return;

            IzdanjeKnjigeRepository izdanjaRepo = new IzdanjeKnjigeRepository();
            List<IzdanjeKnjige> allIzdanja = izdanjaRepo.GetAllIzdanjaKnjige();

            foreach (IzdanjeKnjige izdanje in allIzdanja)
            {
                if (!izdanje.PripadaKnjizi((Knjiga)knjigeComboBox.SelectedItem)) continue;
                izdanjaComboBox.Items.Add(izdanje);
            }
        }

        private void ObrisiKnjigu(object sender, RoutedEventArgs e)
        {
            if (knjigeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Morate prvo izabrati knjigu!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            IzdanjeKnjigeRepository izdanjaRepo = new IzdanjeKnjigeRepository();
            List<IzdanjeKnjige> allIzdanja = izdanjaRepo.GetAllIzdanjaKnjige();

            List<IzdanjeKnjige> ostalaIzdanja = izdanjaRepo.GetAllIzdanjaKnjige();
            PrimerakRepository primerciRepo = new PrimerakRepository();
            foreach (IzdanjeKnjige izdanje in allIzdanja)
            {
                if (izdanje.knjiga != knjigeComboBox.SelectedItem) continue;

                List<Primerak> sviPrimerci = primerciRepo.GetAllPrimerci();

                List<Primerak> ostaliPrimerci = primerciRepo.GetAllPrimerci();
                foreach (Primerak primerak in sviPrimerci)
                {
                    if (primerak.izdanjeKnjige != izdanje) continue;
                    if (primerak.dostupnost != Dostupnost.SLOBODNA || primerak.dostupnost != Dostupnost.IZGUBLJENA)
                    {
                        MessageBox.Show("Ne mozete obrisati izdanje jer su primerci tog izdanja trenutno iznajmljeni!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    ostaliPrimerci.Remove(primerak);
                }

                primerciRepo.Primerci = ostaliPrimerci;
                primerciRepo.Save();

                ostalaIzdanja.Remove(izdanje);
            }

            izdanjaRepo.Izdanja = ostalaIzdanja;
            izdanjaRepo.Save();

            KnjigaRepository knjigaRepo = new KnjigaRepository();
            List<Knjiga> sveKnjige = knjigaRepo.GetAllKnjige();

            foreach (Knjiga knjiga in sveKnjige)
            {
                if (knjiga != knjigeComboBox.SelectedItem) continue;
                knjigaRepo.Knjige.Remove(knjiga);
                knjigaRepo.Save();
                break;
            }

            fillBooks();
        }

        private void ObrisiIzdanje(object sender, RoutedEventArgs e)
        {
            if (izdanjaComboBox.SelectedItem == null)
            {
                MessageBox.Show("Morate prvo izabrati izdanje!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            PrimerakRepository primerciRepo = new PrimerakRepository();
            List<Primerak> sviPrimerci = primerciRepo.GetAllPrimerci();

            List<Primerak> ostaliPrimerci = primerciRepo.GetAllPrimerci();
            foreach (Primerak primerak in sviPrimerci)
            {
                if (primerak.izdanjeKnjige != izdanjaComboBox.SelectedItem) continue;
                if (primerak.dostupnost != Dostupnost.SLOBODNA || primerak.dostupnost != Dostupnost.IZGUBLJENA)
                {
                    MessageBox.Show("Ne mozete obrisati izdanje jer su primerci tog izdanja trenutno iznajmljeni!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                ostaliPrimerci.Remove(primerak);
            }

            primerciRepo.Primerci = ostaliPrimerci;
            primerciRepo.Save();

            IzdanjeKnjigeRepository izdanjaRepo = new IzdanjeKnjigeRepository();
            List<IzdanjeKnjige> allIzdanja = izdanjaRepo.GetAllIzdanjaKnjige();

            List<IzdanjeKnjige> ostalaIzdanja = izdanjaRepo.GetAllIzdanjaKnjige();
            foreach (IzdanjeKnjige izdanje in allIzdanja)
            {
                if (izdanje != izdanjaComboBox.SelectedItem) continue;
                ostalaIzdanja.Remove(izdanje);
            }

            izdanjaRepo.Izdanja = ostalaIzdanja;
            izdanjaRepo.Save();

            updateIzdanja();
        }

    }
}

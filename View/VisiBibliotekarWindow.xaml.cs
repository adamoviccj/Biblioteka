using System.Windows;

namespace SIMS_Projekat.View
{
    public partial class VisiBibliotekarWindow : Window
    {
        public VisiBibliotekarWindow()
        {
            InitializeComponent();
        }

        private void NabaviPrimerke(object sender, RoutedEventArgs e)
        {
            NabaviPrimerkeWindow window = new NabaviPrimerkeWindow();
            window.Show();
        }

        private void PremestiPrimerke(object sender, RoutedEventArgs e)
        {

        }

        private void EvidentirajIzdanja(object sender, RoutedEventArgs e)
        {
            EvidentirajIzdanjaWindow window = new EvidentirajIzdanjaWindow();
            window.Show();
        }

        private void ObrisiIzdanja(object sender, RoutedEventArgs e)
        {
            ObrisiIzdanjaWindow window = new ObrisiIzdanjaWindow();
            window.Show();
        }

        private void FunkcijeObicnog(object sender, RoutedEventArgs e)
        {
            BibliotekarProfil window = new BibliotekarProfil();
            window.Show();
        }
    }
}

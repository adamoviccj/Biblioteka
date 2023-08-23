using SIMS_Projekat.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows;

namespace SIMS_Projekat
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        

        public KorisnikRepository _korisnikRepository { get; set; }
        public ClanRepository _clanRepository { get; set; }
        public ObicanBibliotekarRepository ObicanBibliotekarRepository { get; set; }
        public VisiBibliotekarRepository VisiBibliotekarRepository { get; set; }



        public App()
        {
            KorisnikRepository korisnikRepository = new KorisnikRepository();
            _korisnikRepository = korisnikRepository;

            ClanRepository clanRepository = new ClanRepository();
            _clanRepository = clanRepository;
            ObicanBibliotekarRepository = new ObicanBibliotekarRepository();
            VisiBibliotekarRepository = new VisiBibliotekarRepository();



        }
    }
}

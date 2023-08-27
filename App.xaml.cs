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
        public KnjigaRepository KnjigaRepository { get; set; }
        public IzdanjeKnjigeRepository IzdanjeKnjigeRepository { get; set; }
        public PrimerakRepository PrimerakRepository { get; set; }
        public IznajmljivanjeRepository IznajmljivanjeRepository { get; set; }
        public RezervacijaRepository _rezervacijaRepository { get; set; }
        public ZahtevZaProduzavanjeRepository _zahtevZaProduzavanjeRepository { get; set; }



        public App()
        {
            KorisnikRepository korisnikRepository = new KorisnikRepository();
            _korisnikRepository = korisnikRepository;

            ClanRepository clanRepository = new ClanRepository();
            _clanRepository = clanRepository;
            ObicanBibliotekarRepository = new ObicanBibliotekarRepository();
            VisiBibliotekarRepository = new VisiBibliotekarRepository();
            KnjigaRepository = new KnjigaRepository();
            IzdanjeKnjigeRepository = new IzdanjeKnjigeRepository();
            PrimerakRepository = new PrimerakRepository();
            IznajmljivanjeRepository = new IznajmljivanjeRepository();
            _rezervacijaRepository = new RezervacijaRepository();
            _zahtevZaProduzavanjeRepository = new ZahtevZaProduzavanjeRepository();




        }
    }
}

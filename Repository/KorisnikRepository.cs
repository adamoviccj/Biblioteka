using Newtonsoft.Json;
using SIMS_Projekat.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.Repository
{
    public class KorisnikRepository
    {
        public List<Korisnik> Korisnici { get; set; }

        public KorisnikRepository()
        {
            InitializeKorisnici();
        }

        private void InitializeKorisnici()
        {
            ClanRepository clanRepository = new ClanRepository();
            ObicanBibliotekarRepository obicanBibliotekarRepository = new ObicanBibliotekarRepository();
            VisiBibliotekarRepository visiBibliotekarRepository = new VisiBibliotekarRepository();

            Korisnici = new List<Korisnik>();

            Korisnici.AddRange(clanRepository.Clanovi);
            Korisnici.AddRange(obicanBibliotekarRepository.ObicniBibliotekari);
            Korisnici.AddRange(visiBibliotekarRepository.VisiBibliotekari);
        }

        public Korisnik GetKorisnikByUsernameAndPassword(string username, string password)
        {
            return Korisnici.FirstOrDefault(korisnik => korisnik.nalog.username == username && korisnik.nalog.password == password);
        }
    }

}

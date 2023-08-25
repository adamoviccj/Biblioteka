using Newtonsoft.Json;
using SIMS_Projekat.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.Model
{
    public class Clan: Korisnik
    {
        [JsonProperty("broj clanske karte")]
        public string brClanskeKarte { get; set; }

        public Clan()
        {
        }

        public Clan(string email, string ime, string prezime, string jmbg, string telefon, KorisnickiNalog nalog, string brClanskeKarte)
            : base(email, ime, prezime, jmbg, telefon, nalog)
        {
            this.email = email;
            this.ime = ime;
            this.prezime = prezime; 
            this.jmbg = jmbg;   
            this.telefon = telefon;
            this.nalog = nalog;
            this.brClanskeKarte = brClanskeKarte;
        }

        public Clan(string email, string ime, string prezime, string jmbg, string telefon, string brClanskeKarte)
            : base(email, ime, prezime, jmbg, telefon)
        {
            this.brClanskeKarte = brClanskeKarte;
        }

        public Clan(string email, string ime, string prezime, string jmbg, string telefon, KorisnickiNalog nalog)
            : base(email, ime, prezime, jmbg, telefon, nalog)
        {
            this.brClanskeKarte = null;
        }

        public Clan(string email, string ime, string prezime, string jmbg, string telefon)
            : base(email, ime, prezime, jmbg, telefon)
        {
            this.brClanskeKarte = null;
        }

        public ClanskaKarta GetClanskaKarta()
        {
            if (brClanskeKarte == null)
            {
                return null;
            }

            ClanskaKartaRepository ckr = new ClanskaKartaRepository();

            foreach (ClanskaKarta clanskaKarta in ckr.GetClanskeKarte())
            {
                if (clanskaKarta.GetBrClanskeKarte() == brClanskeKarte)
                {
                    return clanskaKarta;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return $"Email: {email}, Ime: {ime}, Prezime: {prezime}, JMBG: {jmbg}, Telefon: {telefon}, Username: {nalog.username}, Password: {nalog.password} ,Broj Članske Karte: {brClanskeKarte}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Clan other = (Clan)obj;
            return email == other.email;
        }

        public override int GetHashCode()
        {
            return email.GetHashCode();
        }
    }
}


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.Model
{
    public class Korisnik
    {
        [JsonProperty("email")]
        public string email;

        [JsonProperty("ime")]
        public string ime { get; set; }

        [JsonProperty("prezime")]
        public string prezime { get; set; }

        [JsonProperty("jmbg")]
        public string jmbg { get; set; }

        [JsonProperty("telefon")]
        public string telefon { get; set; }

        [JsonProperty("korisnicki nalog")]
        public KorisnickiNalog nalog { get; set; }

        public Korisnik()
        {

        }
        public Korisnik(string email, string ime, string prezime, string jmbg, string telefon, KorisnickiNalog nalog)
        {
            this.email = email;
            this.ime = ime;
            this.prezime = prezime;
            this.jmbg = jmbg;
            this.telefon = telefon;
            this.nalog = nalog;
        }

        public Korisnik(string email, string ime, string prezime, string jmbg, string telefon)
        {
            this.email = email;
            this.ime = ime;
            this.prezime = prezime;
            this.jmbg = jmbg;
            this.telefon = telefon;
        }
    }
}

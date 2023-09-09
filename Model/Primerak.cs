using Newtonsoft.Json;
using SIMS_Projekat.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.Model
{
    public class Primerak
    {
        [JsonProperty("inventarniBroj")]
        public string inventarniBroj { get; set; }

        [JsonProperty("nabavnaCena")]
        public double nabavnaCena { get; set; }

        [JsonProperty("dostupnost")]
        public Dostupnost dostupnost { get; set; }

        [JsonProperty("datumRaspolaganja")]
        public DateTime? datumRaspolaganja { get;set; }

        [JsonProperty("izdanjeKnjige")]
        public IzdanjeKnjige izdanjeKnjige { get; set; }

        [JsonProperty("ogranak")]
        public Ogranak ogranak { get; set; }

        public Primerak()
        {
        }


        public Primerak(string inventarniBroj, double nabavnaCena, Dostupnost dostupnost, 
            DateTime? datumRaspolaganja, IzdanjeKnjige izdanjeKnjige, Ogranak ogranak)
        {
            this.inventarniBroj = inventarniBroj;
            this.nabavnaCena = nabavnaCena;
            this.dostupnost = dostupnost;
            this.datumRaspolaganja = datumRaspolaganja;
            this.izdanjeKnjige = izdanjeKnjige;
            this.ogranak = ogranak;
        }

        public override string ToString()
        {
            return inventarniBroj + " - " + izdanjeKnjige.knjiga.nazivKnjige;
        }

    }
}

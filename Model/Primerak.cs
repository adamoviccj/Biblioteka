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
        public string inventarniBroj;

        [JsonProperty("nabavnaCena")]
        public double nabavnaCena;

        [JsonProperty("dostupnost")]
        public Dostupnost dostupnost;

        [JsonProperty("datumRaspolaganja")]
        public DateTime datumRaspolaganja;

        [JsonProperty("izdanjeKnjige")]
        public IzdanjeKnjige izdanjeKnjige;

        public Primerak()
        {
        }


        public Primerak(string inventarniBroj, double nabavnaCena, Dostupnost dostupnost, 
            DateTime datumRaspolaganja, IzdanjeKnjige izdanjeKnjige)
        {
            this.inventarniBroj = inventarniBroj;
            this.nabavnaCena = nabavnaCena;
            this.dostupnost = dostupnost;
            this.datumRaspolaganja = datumRaspolaganja;
            this.izdanjeKnjige = izdanjeKnjige;
        }
    }
}

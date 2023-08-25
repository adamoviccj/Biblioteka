using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.Model
{
    public class Rezervacija
    {
        [JsonProperty("datumRezervacije")]
        public DateTime datumRezervacije;

        [JsonProperty("knjiga")]
        public Knjiga knjiga;

        [JsonProperty("primerak")]
        public Primerak primerak;

        [JsonProperty("clan")]
        public Clan clan;

        public Rezervacija()
        {
        }

        public Rezervacija(DateTime datumRezervacije, Knjiga knjiga, Primerak primerak, Clan clan)
        {
            this.datumRezervacije = datumRezervacije;
            this.knjiga = knjiga;
            this.primerak = primerak;
            this.clan = clan;
        }
    }
}

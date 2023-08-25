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
        public DateTime datumRezervacije { get; set; }

        [JsonProperty("knjiga")]
        public Knjiga knjiga { get; set; }

        [JsonProperty("primerak")]
        public Primerak primerak { get; set; }

        [JsonProperty("clan")]
        public Clan clan { get; set; }

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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.Model
{
    public class InventarnaKnjiga
    {
        [JsonProperty("nazivInventarneKnjige")]
        public string nazivInventarneKnjige { get; set; }

        [JsonProperty("primerak")]
        public Primerak primerak { get; set; }

        [JsonProperty("ogranak")]
        public Ogranak ogranak { get; set; }

        public InventarnaKnjiga()
        {
        }

        public InventarnaKnjiga(string nazivInventarneKnjige, Primerak primerak, Ogranak ogranak)
        {
            this.nazivInventarneKnjige = nazivInventarneKnjige;
            this.primerak = primerak;
            this.ogranak = ogranak;
        }
    }
}

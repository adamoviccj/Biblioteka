using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.Model
{
    public class Iznajmljivanje
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("datumIznajmljivanja")]
        public DateTime datumIznajmljivanja { get; set; }

        [JsonProperty("datumVracanja")]
        public DateTime? datumVracanja { get; set; }

        [JsonProperty("rokVracanja")]
        public DateTime rokVracanja { get; set; }

        [JsonProperty("brojZahtevaZaProduzavanje")]
        public int brojZahtevaZaProduzavanje { get; set; }

        [JsonProperty("clan")]
        public Clan clan { get; set; }

        [JsonProperty("primerak")]
        public Primerak primerak { get; set; }



        public Iznajmljivanje()
        {
            brojZahtevaZaProduzavanje = 0;
        }

        public Iznajmljivanje(int id, DateTime datumIznajmljivanja, DateTime? datumVracanja, DateTime rokVracanja, int brojZahtevaZaProduzavanje, Clan clan, Primerak primerak)
        {
            this.id = id;
            this.datumIznajmljivanja = datumIznajmljivanja;
            this.datumVracanja = datumVracanja;
            this.rokVracanja = rokVracanja;
            this.brojZahtevaZaProduzavanje = brojZahtevaZaProduzavanje;
            this.clan = clan;
            this.primerak = primerak;
        }
    }
}

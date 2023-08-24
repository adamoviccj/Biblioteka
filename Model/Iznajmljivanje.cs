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
        [JsonProperty("datumIznajmljivanja")]
        public DateTime datumIznajmljivanja;

        [JsonProperty("datumVracanja")]
        public DateTime? datumVracanja;

        [JsonProperty("brojZahtevaZaProduzavanje")]
        public int brojZahtevaZaProduzavanje;

        [JsonProperty("clan")]
        public Clan clan;

        [JsonProperty("primerak")]
        public Primerak primerak;



        public Iznajmljivanje()
        {
            brojZahtevaZaProduzavanje = 0;
        }

        public Iznajmljivanje(DateTime datumIznajmljivanja, DateTime datumVracanja, int brojZahtevaZaProduzavanje, Clan clan, Primerak primerak)
        {
            this.datumIznajmljivanja = datumIznajmljivanja;
            this.datumVracanja = datumVracanja;
            this.brojZahtevaZaProduzavanje = brojZahtevaZaProduzavanje;
            this.clan = clan;
            this.primerak = primerak;
        }
    }
}

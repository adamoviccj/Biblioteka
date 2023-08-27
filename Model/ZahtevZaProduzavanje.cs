using Newtonsoft.Json;
using SIMS_Projekat.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.Model
{
    public class ZahtevZaProduzavanje
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("iznajmljivanje")]
        public Iznajmljivanje Iznajmljivanje { get; set; }
        [JsonProperty("datum slanja")]
        public DateTime DatumSlanja { get; set; }
        [JsonProperty("stanje zahteva")]
        public StanjeZahteva StanjeZahteva { get; set; }
        [JsonProperty("clan")]
        public Clan Clan { get; set; }

        public ZahtevZaProduzavanje()
        {
        }

        public ZahtevZaProduzavanje(int id, Iznajmljivanje iznajmljivanje, DateTime datumSlanja, StanjeZahteva stanjeZahteva, Clan clan)
        {
            Id = id;
            Iznajmljivanje = iznajmljivanje;
            DatumSlanja = datumSlanja;
            StanjeZahteva = stanjeZahteva;
            Clan = clan;
        }
    }
}

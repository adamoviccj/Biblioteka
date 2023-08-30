using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.Model
{
    public class Ogranak
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("naziv")]
        public string naziv { get; set; }

        [JsonProperty("lokacija")]
        public string lokacija { get; set; }

        [JsonProperty("brTelefona")]
        public string brTelefona { get; set; }

        public Ogranak()
        {
        }

        public Ogranak(int id, string lokacija, string brTelefona)
        {
            this.id = id;
            this.lokacija = lokacija;
            this.brTelefona = brTelefona;
        }

        public override string ToString()
        {
            return naziv + " - " + lokacija;
        }

    }
}

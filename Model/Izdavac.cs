using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.Model
{
    public class Izdavac
    {
        [JsonProperty ("naziv")]
        public string naziv { get; set; }

        [JsonProperty ("drzava")]
        public string drzava { get; set; }

        public Izdavac()
        {
        }

        public Izdavac(string naziv, string drzava)
        {
            this.naziv = naziv;
            this.drzava = drzava;
        }

        public override string ToString()
        {
            return naziv;
        }

    }


}

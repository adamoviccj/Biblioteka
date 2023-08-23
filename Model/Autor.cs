using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.Model
{
    public class Autor
    {
        [JsonProperty("ime")]
        public string ime;

        [JsonProperty("prezime")]
        public string prezime;

        [JsonProperty ("drzava")]
        public string drzava;

        public Autor()
        {
        }

        public Autor(string ime, string prezime, string drzava)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.drzava = drzava;
        }
    }
}

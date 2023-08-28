using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.Model
{
    public class Biblioteka
    {
        [JsonProperty("nazivBiblioteke")]
        public string nazivBiblioteke { get; set; }

        [JsonProperty("brojClanova")]
        public int brojClanova { get; set; }

        public Biblioteka()
        {
        }

        public Biblioteka(string nazivBiblioteke, int brojClanova)
        {
            this.nazivBiblioteke = nazivBiblioteke;
            this.brojClanova = brojClanova;
        }
    }
}

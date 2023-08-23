using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.Model
{
    public class Knjiga
    {
        [JsonProperty ("nazivKnjige")]
        public string nazivKnjige;

        [JsonProperty ("opis")]
        public string opis;

        [JsonProperty ("autor")]
        public Autor autor;

        public Knjiga()
        {
        }

        public Knjiga(string nazivKnjige, string opis, Autor autor)
        {
            this.nazivKnjige = nazivKnjige;
            this.opis = opis;
            this.autor = autor;
        }
    }
}

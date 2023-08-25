using Newtonsoft.Json;
using SIMS_Projekat.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.Model
{
    public class IzdanjeKnjige
    {
        [JsonProperty("isbn")]
        public string isbn { get; set; }

        [JsonProperty("udk")]
        public string udk { get; set; }

        [JsonProperty("jezik")]
        public string jezik { get; set; }

        [JsonProperty("godinaIzdanja")]
        public string godinaIzdanja { get; set; }

        [JsonProperty("format")]
        public string format { get; set; }

        [JsonProperty("vrstaKoricenja")]
        public TipKoricenja vrstaKoricenja { get;set; }

        [JsonProperty("citanost")]
        public int citanost { get; set; }

        [JsonProperty("knjiga")]
        public Knjiga knjiga { get; set; }

        [JsonProperty("biblioteka")]
        public Biblioteka biblioteka { get; set; }

        [JsonProperty("izdavac")]
        public Izdavac izdavac { get; set; }

        public IzdanjeKnjige()
        {
        }

        public IzdanjeKnjige(string isbn, string udk, string jezik, string godinaIzdanja, 
            string format, TipKoricenja vrstaKoricenja, int citanost, Knjiga knjiga, 
            Biblioteka biblioteka, Izdavac izdavac)
        {
            this.isbn = isbn;
            this.udk = udk;
            this.jezik = jezik;
            this.godinaIzdanja = godinaIzdanja;
            this.format = format;
            this.vrstaKoricenja = vrstaKoricenja;
            this.citanost = citanost;
            this.knjiga = knjiga;
            this.biblioteka = biblioteka;
            this.izdavac = izdavac;
        }
    }
}

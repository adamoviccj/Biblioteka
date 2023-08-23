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
        public string isbn;

        [JsonProperty("udk")]
        public string udk;

        [JsonProperty("jezik")]
        public string jezik;

        [JsonProperty("godinaIzdanja")]
        public string godinaIzdanja;

        [JsonProperty("format")]
        public string format;

        [JsonProperty("vrstaKoricenja")]
        public TipKoricenja vrstaKoricenja;

        [JsonProperty("citanost")]
        public int citanost;

        [JsonProperty("knjiga")]
        public Knjiga knjiga;

        [JsonProperty("biblioteka")]
        public Biblioteka biblioteka;

        [JsonProperty("izdavac")]
        public Izdavac izdavac;

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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.Model
{
    public class Rezervacija
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("datumRezervacije")]
        public DateTime DatumRezervacije { get; set; }

        [JsonProperty("izdanje knjige")]
        public IzdanjeKnjige IzdanjeKnjige { get; set; }

        [JsonProperty("clan")]
        public Clan Clan { get; set; }

        public Rezervacija()
        {
        }

        public Rezervacija(int id, DateTime datumRezervacije, IzdanjeKnjige izdanjeKnjige, Clan clan)
        {
            Id = id;
            DatumRezervacije = datumRezervacije;
            IzdanjeKnjige = izdanjeKnjige;
            Clan = clan;
        }
    }
}
using Newtonsoft.Json;
using SIMS_Projekat.enums;
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
        [JsonProperty("datumPrihvatanja")]
        public DateTime? DatumPrihvatanja { get; set; }


        [JsonProperty("izdanje knjige")]
        public IzdanjeKnjige IzdanjeKnjige { get; set; }

        [JsonProperty("clan")]
        public Clan Clan { get; set; }
        [JsonProperty("statusRezervacije")]
        public StatusRezervacije StatusRezervacije { get; set; }

        public Rezervacija()
        {
        }

        public Rezervacija(int id, DateTime datumRezervacije, DateTime? datumPrihvatanja, IzdanjeKnjige izdanjeKnjige, Clan clan, StatusRezervacije statusRezervacije)
        {
            Id = id;
            DatumRezervacije = datumRezervacije;
            DatumPrihvatanja = datumPrihvatanja;
            IzdanjeKnjige = izdanjeKnjige;
            Clan = clan;
            StatusRezervacije = statusRezervacije;
        }
    }
}
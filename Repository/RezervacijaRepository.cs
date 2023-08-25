using Newtonsoft.Json;
using SIMS_Projekat.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.Repository
{
    public class RezervacijaRepository
    {
        public List<Rezervacija> Rezervacije { get; set; }
        public string FilePath = "../Data/rezervacije.json";

        public RezervacijaRepository()
        {
        }

        public List<Rezervacija> GetAllRezervacije()
        {
            string json = File.ReadAllText(FilePath);
            List<Rezervacija> rezervacije = JsonConvert.DeserializeObject<List<Rezervacija>>(json);
            return rezervacije;
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Rezervacije, Formatting.Indented));
        }
    }
}

using Newtonsoft.Json;
using SIMS_Projekat.Model;
using SIMS_Projekat.View;
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
        public string FilePath = "../../Data/rezervacije.json";

        public List<Rezervacija> RezervacijeClana { get; set; }

        public RezervacijaRepository()
        {
            Rezervacije = GetAllRezervacije();
            if (LogIn.LoggedUser != null)
            {
                RezervacijeClana = GetAllRezervacijeClana(LogIn.LoggedUser.jmbg);
            }
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

        public List<Rezervacija> GetAllRezervacijeClana(string jmbg)
        {
            List<Rezervacija> rezervacije = new List<Rezervacija>();
            foreach(Rezervacija rezervacija in GetAllRezervacije())
            {
                if (rezervacija.clan.jmbg == jmbg)
                {
                    rezervacije.Add(rezervacija);
                }
            }
            return rezervacije;
        }
    }
}

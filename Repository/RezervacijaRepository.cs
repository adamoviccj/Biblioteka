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
            foreach (Rezervacija rezervacija in GetAllRezervacije())
            {
                if (rezervacija.Clan.jmbg == jmbg)
                {
                    rezervacije.Add(rezervacija);
                }
            }
            return rezervacije;
        }

        private int GenerateId()
        {
            int maxId = 0;
            foreach (Rezervacija rezervacija in Rezervacije)
            {
                if (rezervacija.Id > maxId)
                {
                    maxId = rezervacija.Id;
                }
            }
            return maxId += 1;
        }

        public Rezervacija Create(Rezervacija rezervacija)
        {
            rezervacija.Id = GenerateId();
            Rezervacije.Add(rezervacija);
            Save();
            return rezervacija;
        }

        public Rezervacija GetById(int id)
        {
            return Rezervacije.Find(rezervacija => rezervacija.Id == id);
        }

        public bool Update(Rezervacija rezervacija)
        {
            Rezervacija forUpdate = GetById(rezervacija.Id);
            if (forUpdate == null)
            {
                return false;
            }
            else
            {
                forUpdate.DatumRezervacije = rezervacija.DatumRezervacije;
                forUpdate.IzdanjeKnjige = rezervacija.IzdanjeKnjige;
                forUpdate.Clan = rezervacija.Clan;
                Save();
                return true;
            }

        }

        public bool IsAbleToUpdate(Rezervacija rezervacija)
        {
            return (GetById(rezervacija.Id) == null);
        }

        public bool Edit(Rezervacija rezervacija)
        {
            if (!IsAbleToUpdate(rezervacija))
            {
                return false;
            }
            Update(rezervacija);
            return true;
        }
    }
}
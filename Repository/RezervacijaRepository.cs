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
        private PrimerakRepository _primerakRepository { get; set; }

        public RezervacijaRepository()
        {
            Rezervacije = GetAllRezervacije();
            if (LogIn.LoggedUser != null)
            {
                RezervacijeClana = GetAllRezervacijeClana(LogIn.LoggedUser.jmbg);
            }

            ProveriIstekaoRok();

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
                forUpdate.StatusRezervacije = rezervacija.StatusRezervacije;
                forUpdate.IzdanjeKnjige = rezervacija.IzdanjeKnjige;
                forUpdate.Clan = rezervacija.Clan;
                forUpdate.DatumPrihvatanja = rezervacija.DatumPrihvatanja;
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

        public List<Rezervacija> GetAllKreiraneRezervacijeZaIzdanje(string isbn)
        {
            List<Rezervacija> result = new List<Rezervacija>();
            foreach(Rezervacija rezervacija in GetAllRezervacije())
            {
                if(rezervacija.IzdanjeKnjige.isbn == isbn && rezervacija.StatusRezervacije == enums.StatusRezervacije.KREIRANA)
                {
                    result.Add(rezervacija);
                }
            }
            return result;
        }

        public List<Rezervacija> GetAllRezervacijeNaCekanjuZaClana(string jmbg)
        {
            List<Rezervacija> NaCekanju = new List<Rezervacija>();
            foreach(Rezervacija rezervacija in GetAllRezervacije())
            {
                if(rezervacija.Clan.jmbg == jmbg && rezervacija.StatusRezervacije == enums.StatusRezervacije.NA_CEKANJU)
                {
                    NaCekanju.Add(rezervacija);
                }
            }
            return NaCekanju;

        }

        public List<Rezervacija> GetAllRezervacijeNaCekanjuZaIzdanje(string isbn)
        {
            List<Rezervacija> rezervacije = new List<Rezervacija>();
            foreach(Rezervacija rezervacija in GetAllRezervacijeNaCekanju())
            {
                if(rezervacija.IzdanjeKnjige.isbn == isbn)
                {
                    rezervacije.Add(rezervacija);
                }
            }
            return rezervacije;
        }

        public List<Rezervacija> GetKreiraneRezervacijeZaIzdanje(string isbn)
        {
            List<Rezervacija> rezervacije = new List<Rezervacija>();
            foreach(Rezervacija rezervacija in GetAllRezervacije())
            {
                if (rezervacija.IzdanjeKnjige.isbn == isbn && rezervacija.StatusRezervacije == enums.StatusRezervacije.KREIRANA)
                {
                    rezervacije.Add(rezervacija);
                }
            }
            return rezervacije;
        }

        public List<Rezervacija> GetAllRezervacijeNaCekanju()
        {
            List<Rezervacija> rezervacije = new List<Rezervacija>();
            foreach(Rezervacija rezervacija in GetAllRezervacije())
            {
                if (rezervacija.StatusRezervacije == enums.StatusRezervacije.NA_CEKANJU)
                {
                    rezervacije.Add(rezervacija);
                }
            } 
            return rezervacije;
        }

        public void ProveriIstekaoRok()
        {
            
            
            foreach(Rezervacija rezervacija in GetAllRezervacijeNaCekanju())
            {
                if(rezervacija.DatumPrihvatanja.HasValue)
                {
                    if (rezervacija.DatumPrihvatanja.Value.AddDays(2) <= DateTime.Now)
                    {
                        rezervacija.StatusRezervacije = enums.StatusRezervacije.ISTEKAO_ROK;
                        Update(rezervacija);
                        Rezervacija sledeca = GetKreiraneRezervacijeZaIzdanje(rezervacija.IzdanjeKnjige.isbn).First();
                        sledeca.DatumPrihvatanja = DateTime.Now;
                        sledeca.StatusRezervacije = enums.StatusRezervacije.NA_CEKANJU;
                        Update(sledeca);
                    }
                }
                
            }
        }

        public List<Rezervacija> GetProsleRezervacije()
        {
            List<Rezervacija> rezervacije = new List<Rezervacija>();
            foreach(Rezervacija rezervacija in GetAllRezervacije())
            {
                if(rezervacija.DatumPrihvatanja != null)
                {
                    rezervacije.Add(rezervacija);
                }
            }

            return rezervacije;
        }


    }
}
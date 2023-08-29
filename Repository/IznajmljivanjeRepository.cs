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
    public class IznajmljivanjeRepository
    {
        public List<Iznajmljivanje> Iznajmljivanja { get; set; }
        public string FilePath = "../../Data/iznajmljivanja.json";
        public List<Iznajmljivanje> IznajmljivanjaClana { get; set; }

        public IznajmljivanjeRepository()
        {
            Iznajmljivanja = GetAllIznajmljivanja();
            if (LogIn.LoggedUser != null)
            {
                IznajmljivanjaClana = GetAllIznajmljivanjaForClan(LogIn.LoggedUser.jmbg);
            }

        }

        public List<Iznajmljivanje> GetAllIznajmljivanja()
        {
            string json = File.ReadAllText(FilePath);
            List<Iznajmljivanje> iznajmljivanja = JsonConvert.DeserializeObject<List<Iznajmljivanje>>(json);
            return iznajmljivanja;
        }

        public List<Iznajmljivanje> GetAll()
        {
            return Iznajmljivanja;
        }


        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Iznajmljivanja, Formatting.Indented));
        }

        public List<Iznajmljivanje> GetAllIznajmljivanjaForClan(string jmbg)
        {
            List<Iznajmljivanje> iznajmljivanja = new List<Iznajmljivanje>();
            foreach (Iznajmljivanje iznajmljivanje in GetAllIznajmljivanja())
            {
                if (iznajmljivanje.clan.jmbg == jmbg)
                {
                    iznajmljivanja.Add(iznajmljivanje);
                }
            }
            return iznajmljivanja;
        }

        private int GenerateId()
        {
            int maxId = 0;
            foreach (Iznajmljivanje iznajmljivanje in GetAllIznajmljivanja())
            {
                if (iznajmljivanje.id > maxId)
                {
                    maxId = iznajmljivanje.id;
                }
            }
            return maxId + 1;
        }

        public Iznajmljivanje Create(Iznajmljivanje iznajmljivanje)
        {
            iznajmljivanje.id = GenerateId();
            Iznajmljivanja.Add(iznajmljivanje);
            Save();
            return iznajmljivanje;
        }

        public Iznajmljivanje GetById(int id)
        {
            foreach(Iznajmljivanje iznajmljivanje in GetAll())
            {
                if (iznajmljivanje.id == id)
                {
                    return iznajmljivanje;
                }
            }
            return null;
        }

        public List<Iznajmljivanje> GetAllTrenutnaIznajmljivanjaForClan(string jmbg)
        {
            List<Iznajmljivanje> trenutna = new List<Iznajmljivanje>();
            foreach (Iznajmljivanje iznajmljivanje in GetAllIznajmljivanja())
            {
                if (iznajmljivanje.clan.jmbg == jmbg && iznajmljivanje.datumVracanja == null)
                {
                    trenutna.Add(iznajmljivanje);
                }
            }
            return trenutna;
        }

        public void Update(Iznajmljivanje iznajmljivanje)
        {
            Iznajmljivanje forUpdate = GetById(iznajmljivanje.id);
            if (forUpdate == null)
            {
                return;
            }
            forUpdate.datumIznajmljivanja = iznajmljivanje.datumIznajmljivanja;
            forUpdate.datumVracanja = iznajmljivanje.datumVracanja;
            forUpdate.rokVracanja = iznajmljivanje.rokVracanja;
            forUpdate.brojZahtevaZaProduzavanje = iznajmljivanje.brojZahtevaZaProduzavanje;
            forUpdate.clan = iznajmljivanje.clan;
            forUpdate.primerak = iznajmljivanje.primerak;
            Save();
        }

        public List<Iznajmljivanje> GetProslaIznajmljivanjaClana(string jmbg)
        {
            return GetAllIznajmljivanjaForClan(jmbg).Where(iznajmljivanje => iznajmljivanje.datumVracanja != null).ToList();
        } 
    }
}
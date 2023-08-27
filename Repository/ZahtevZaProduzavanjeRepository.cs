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
    public class ZahtevZaProduzavanjeRepository
    {
        public List<ZahtevZaProduzavanje> Zahtevi { get; set; }
        public string FilePath = "../../Data/zahtevi.json";
        public List<ZahtevZaProduzavanje> ZahteviClana { get; set; }

        public ZahtevZaProduzavanjeRepository()
        {
            Zahtevi = GetAllZahtevi();
            if (LogIn.LoggedUser != null)
            {
                ZahteviClana = GetAllZahteviClana(LogIn.LoggedUser.jmbg);
            }
        }

        public List<ZahtevZaProduzavanje> GetAllZahtevi()
        {
            string json = File.ReadAllText(FilePath);
            List<ZahtevZaProduzavanje> zahtevi = JsonConvert.DeserializeObject<List<ZahtevZaProduzavanje>>(json);
            return zahtevi;
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Zahtevi, Formatting.Indented));
        }

        private int GenerateId()
        {
            int maxId = 0;
            foreach (ZahtevZaProduzavanje zahtev in Zahtevi)
            {
                if (zahtev.Id > maxId)
                {
                    maxId = zahtev.Id;
                }
            }
            return maxId + 1;
        }

        public ZahtevZaProduzavanje Create(ZahtevZaProduzavanje zahtev)
        {
            zahtev.Id = GenerateId();
            Zahtevi.Add(zahtev);
            Save();
            return zahtev;
        }

        public ZahtevZaProduzavanje GetById(int id)
        {
            return Zahtevi.Find(zahtev => zahtev.Id == id);
        }

        public void Update(ZahtevZaProduzavanje zahtev)
        {
            ZahtevZaProduzavanje forUpdate = GetById(zahtev.Id);
            if (forUpdate == null)
            {
                return;
            }
            forUpdate.StanjeZahteva = zahtev.StanjeZahteva;
            Save();
        }

        public List<ZahtevZaProduzavanje> GetAllZahteviClana(string jmbg)
        {
            List<ZahtevZaProduzavanje> zahtevi = new List<ZahtevZaProduzavanje>();
            foreach (ZahtevZaProduzavanje zahtevZaProduzavanje in GetAllZahtevi())
            {
                if (zahtevZaProduzavanje.Clan.jmbg == jmbg)
                {
                    zahtevi.Add(zahtevZaProduzavanje);
                }
            }
            return zahtevi;
        }
    }
}

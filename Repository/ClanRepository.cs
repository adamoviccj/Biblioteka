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
    public class ClanRepository
    {
        public List<Clan> Clanovi { get; set; }
        private string FilePath = "../../Data/clanovi.json";

        public ClanRepository()
        {
            Clanovi = GetAllClanovi();
        }
        /*
        public void GetAllClanovi()
        {
            Clanovi = JsonConvert.DeserializeObject<List<Clan>>(File.ReadAllText(FilePath));
        }
        */

        public List<Clan> GetAllClanovi()
        {
            string json = File.ReadAllText(FilePath);
            List<Clan> clanovi = JsonConvert.DeserializeObject<List<Clan>>(json);    
            return clanovi;
        }


        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Clanovi, Formatting.Indented));
        }
        public Clan FindClanByUsername(string username) // ovde ?
        {
            foreach (Clan clan in Clanovi)
            {
                if (clan.nalog != null && clan.nalog.username == username)
                {
                    return clan;
                }
            }
            return null;
        }

        public Clan FindClanByJmbg(string jmbg)
        {
            foreach(Clan clan in Clanovi)
            {
                if (clan.jmbg == jmbg)
                {
                    return clan;
                }
            }
            return null;
        }

    }
}

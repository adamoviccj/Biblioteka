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
    public class ClanskaKartaRepository
    {
        public List<ClanskaKarta> ClanskeKarte { get; set; }
        private string FilePath = "../../Data/clanskeKarte.json";

        public ClanskaKartaRepository()
        {
            GetAllClanskeKarte();
        }
        public List<ClanskaKarta> GetClanskeKarte()
        {
            return ClanskeKarte;
        }
        public void GetAllClanskeKarte()
        {
            ClanskeKarte = JsonConvert.DeserializeObject<List<ClanskaKarta>>(File.ReadAllText(FilePath));
        }
        public ClanskaKarta GetClanskaKartaByBr(string brKarte)   //ovde ?
        {
            foreach (ClanskaKarta clanskaKarta in ClanskeKarte)
            {
                if (clanskaKarta.brClanskeKarte == brKarte)
                    return clanskaKarta;
            }
            return null;
        }
        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(ClanskeKarte, Formatting.Indented));
        }
    }
}

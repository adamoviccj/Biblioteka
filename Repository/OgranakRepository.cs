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
    public class OgranakRepository
    {
        public List<Ogranak> Ogranci { get; set; }
        public string FilePath = "../../Data/ogranci.json";

        public OgranakRepository()
        {
            Ogranci = GetAllOgranci();
        }

        public List<Ogranak> GetAllOgranci()
        {
            string json = File.ReadAllText(FilePath);
            List<Ogranak> izdanja = JsonConvert.DeserializeObject<List<Ogranak>>(json);
            return izdanja;
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Ogranci, Formatting.Indented));
        }
    }
}

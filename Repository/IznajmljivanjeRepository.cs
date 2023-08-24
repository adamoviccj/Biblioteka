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
    public class IznajmljivanjeRepository
    {
        public List<Iznajmljivanje> Iznajmljivanja { get; set; }
        public string FilePath = "../../Data/iznajmljivanja.json";

        public IznajmljivanjeRepository()
        {
            GetAllIznajmljivanja();
        }

        public List<Iznajmljivanje> GetAllIznajmljivanja()
        {
            string json = File.ReadAllText(FilePath);
            List<Iznajmljivanje> iznajmljivanja = JsonConvert.DeserializeObject<List<Iznajmljivanje>>(json);
            return iznajmljivanja;
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Iznajmljivanja, Formatting.Indented));
        }


    }
}

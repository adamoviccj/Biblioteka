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
    public class AutorRepository
    {
        public List<Autor> Autori { get; set; }
        private string FilePath = "../../Data/autori.json";

        public AutorRepository()
        {
            GetAllAutori();
        }

        public List<Autor> GetAllAutori()
        {
            string json = File.ReadAllText(FilePath);
            List<Autor> autori = JsonConvert.DeserializeObject<List<Autor>>(json);
            return autori;
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Autori, Formatting.Indented));
        }
    }
}

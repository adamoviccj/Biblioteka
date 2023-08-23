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
    public class KnjigaRepository
    {
        public List<Knjiga> Knjige { get;set; }
        private string FilePath = "../../Data/knjige.json";

        public KnjigaRepository()
        {
            GetAllKnjige();
        }

        public List<Knjiga> GetAllKnjige()
        {
            string json = File.ReadAllText(FilePath);
            List<Knjiga> knjige = JsonConvert.DeserializeObject<List<Knjiga>>(json);
            return knjige;
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Knjige, Formatting.Indented));
        }

        public Knjiga FindKnjigaByNaziv(string naziv)
        {
            foreach (Knjiga knjiga in Knjige)
            {
                if (knjiga.nazivKnjige != null && knjiga.nazivKnjige == naziv)
                {
                    return knjiga;
                }
            }
            return null;
        }
    }
}

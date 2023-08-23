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
    public class IzdanjeKnjigeRepository
    {
        public List<IzdanjeKnjige> Izdanja { get; set; }
        public string FilePath = "../../Data/izdanjaKnjige.json";

        public IzdanjeKnjigeRepository()
        {
            GetAllIzdanjaKnjige();
        }

        public List<IzdanjeKnjige> GetAllIzdanjaKnjige()
        {
            string json = File.ReadAllText(FilePath);
            List<IzdanjeKnjige> izdanja = JsonConvert.DeserializeObject<List<IzdanjeKnjige>>(json);
            return izdanja;
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Izdanja, Formatting.Indented));
        }

        public IzdanjeKnjige FindIzdanjeByIsbn(string isbn)
        {
            foreach (IzdanjeKnjige izdanje in Izdanja)
            {
                if (izdanje.isbn != null && izdanje.isbn == isbn)
                {
                    return izdanje;
                }
            }
            return null;
        }
    }
}

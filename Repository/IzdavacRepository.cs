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
    public class IzdavacRepository
    {
        public List<Izdavac> Izdavaci { get; set; }
        private string FilePath = "../../Data/izdavaci.json";

        public IzdavacRepository()
        {
            GetAllIzdavaci();
        }

        public List<Izdavac> GetAllIzdavaci()
        {
            string json = File.ReadAllText(FilePath);
            List<Izdavac> izdavaci = JsonConvert.DeserializeObject<List<Izdavac>>(json);
            return izdavaci;
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Izdavaci, Formatting.Indented));

        }

        public Izdavac FindIzdavacByNaziv(string naziv)
        {
            foreach (Izdavac izdavac in Izdavaci)
            {
                if (izdavac.naziv != null && izdavac.naziv == naziv)
                {
                    return izdavac;
                }
            }
            return null;
        }

    }
}

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
    public class VisiBibliotekarRepository
    {
        public List<VisiBibliotekar> VisiBibliotekari { get; set; }
        private string FilePath = "../../Data/visiBibliotekari.json";

        public VisiBibliotekarRepository()

        {
            GetAllVisiBibliotekari();
        }

        public void GetAllVisiBibliotekari()
        {
            VisiBibliotekari = JsonConvert.DeserializeObject<List<VisiBibliotekar>>(File.ReadAllText(FilePath));
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(VisiBibliotekari, Formatting.Indented));
        }


        public VisiBibliotekar FindVisiBibliotekarByUsername(string username)
        {
            foreach (VisiBibliotekar visiBibliotekar in VisiBibliotekari)
            {
                if (visiBibliotekar.nalog.username == username)
                {
                    return visiBibliotekar;
                }
            }
            return null;
        }
    }
}

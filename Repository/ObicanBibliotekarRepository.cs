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
    public class ObicanBibliotekarRepository
    {
        public List<ObicanBibliotekar> ObicniBibliotekari { get; set; }
        private string FilePath = "../../Data/obicniBibliotekari.json";

        public ObicanBibliotekarRepository()
        {
            GetAllBibliotekari();
        }

        public void GetAllBibliotekari()
        {
            ObicniBibliotekari = JsonConvert.DeserializeObject<List<ObicanBibliotekar>>(File.ReadAllText(FilePath));
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(ObicniBibliotekari, Formatting.Indented));
        }
        public ObicanBibliotekar FindObicanBibliotekarByUsername(string username)
        {
            foreach (ObicanBibliotekar obicanBibliotekar in ObicniBibliotekari)
            {
                if (obicanBibliotekar.nalog.username == username)
                {
                    return obicanBibliotekar;
                }
            }
            return null;
        }
    }
}

using Newtonsoft.Json;
using SIMS_Projekat.enums;
using SIMS_Projekat.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.Repository
{
    public class PrimerakRepository
    {
        public List<Primerak> Primerci { get; set; }
        public string FilePath = "../../Data/primerci.json";

        public PrimerakRepository()
        {
            GetAllPrimerci();
        }

        public List<Primerak> GetAllPrimerci()
        {
            string json = File.ReadAllText(FilePath);
            List<Primerak> primerci = JsonConvert.DeserializeObject<List<Primerak>>(json);
            return primerci;
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Primerci));
        }

        public Primerak FindPrimerakByInventarniBroj(string inventarniBroj)
        {
            foreach (Primerak primerak in Primerci)
            {
                if (primerak.inventarniBroj != null && primerak.inventarniBroj == inventarniBroj)
                {
                    return primerak;
                }
            }
            return null;
        }

        public List<Primerak> FindSlobodnePrimerke(string nazivKnjige)
        {
            List<Primerak> slobodni = new List<Primerak>();
            foreach (Primerak primerak in Primerci)
            {
                if (primerak.izdanjeKnjige.knjiga.nazivKnjige == nazivKnjige && primerak.dostupnost == Dostupnost.SLOBODNA)
                {
                    slobodni.Add(primerak);
                }
            }
            return slobodni;
        }
    }
}

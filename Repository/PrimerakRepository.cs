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
        public List<Primerak> SlobodniPrimerci { get; set; }
        public Knjiga SelectedKnjiga { get; set; }


        public PrimerakRepository()
        {
            Primerci = GetAllPrimerci();

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
        public void Update(Primerak primerak)
        {
            Primerak forUpdate = FindPrimerakByInventarniBroj(primerak.inventarniBroj);
            if (forUpdate == null)
            {
                return;
            }
            forUpdate.dostupnost = primerak.dostupnost;
            Save();
        }
        public List<Primerak> FindPrimerkeZaKnjigu(string nazivKnjige)
        {
            List<Primerak> primerci = new List<Primerak>();
            foreach (Primerak primerak in Primerci)
            {
                if (primerak.izdanjeKnjige.knjiga.nazivKnjige == nazivKnjige)
                {
                    primerci.Add(primerak);
                }
            }
            return primerci;
        }

        public List<Primerak> FindSlobodneZaKnjigu(string nazivKnjige)
        {
            List<Primerak> slobodni = new List<Primerak>();
            foreach (Primerak primerak in GetAllPrimerci())
            {
                if (primerak.izdanjeKnjige.knjiga.nazivKnjige == nazivKnjige && primerak.dostupnost == enums.Dostupnost.SLOBODNA)
                {
                    slobodni.Add(primerak);
                }
            }
            return slobodni;
        }
        public Primerak FindSlobodanPrimerakZaIzdanje(string isbn)
        {
            foreach (Primerak primerak in Primerci)
            {
                if (primerak.izdanjeKnjige.isbn == isbn && primerak.dostupnost == enums.Dostupnost.SLOBODNA)
                {
                    return primerak;
                }
            }
            return null;
        }

        public bool PromeniStanje(string inventarniBroj, Dostupnost dostupnost)
        {
            Primerak primerak = FindPrimerakByInventarniBroj(inventarniBroj);
            if (primerak == null)
            {
                return false;
            }
            primerak.dostupnost = dostupnost;
            Save();
            return true;
        }
    }
}

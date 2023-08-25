﻿using Newtonsoft.Json;
using SIMS_Projekat.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.Repository
{
    public class KorisnikRepository
    {
        public List<Korisnik> Korisnici { get; set; }
        private string FilePath = "../../Data/korisnici.json";

        public KorisnikRepository()
        {
            GetAllKorisnici();
        }

        public void GetAllKorisnici()
        {
            Korisnici = JsonConvert.DeserializeObject<List<Korisnik>>(File.ReadAllText(FilePath));
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Korisnici, Formatting.Indented));
        }

        public Korisnik GetKorisnikByUsernameAndPassword(string username, string password)
        {
            foreach (Korisnik korisnik in Korisnici)
            {
                if (korisnik.nalog.username == username && korisnik.nalog.password == password)
                {
                    return korisnik;
                }
            }
            return null;
        }
    }
}

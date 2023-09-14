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
    public class ClanskaKartaRepository
    {
        public List<ClanskaKarta> ClanskeKarte { get; set; }
        private string FilePath = "../../Data/clanskeKarte.json";
        public ClanRepository _clanRepository { get; set; }

        public ClanskaKartaRepository()
        {
            ClanskeKarte = GetAllClanskeKarte();
        }
        public List<ClanskaKarta> GetClanskeKarte()
        {
            return ClanskeKarte;
        }
        public List<ClanskaKarta> GetAllClanskeKarte()
        {
            string json = File.ReadAllText(FilePath);
            ClanskeKarte = JsonConvert.DeserializeObject<List<ClanskaKarta>>(json);
            return ClanskeKarte;
        }
        public ClanskaKarta GetClanskaKartaByBr(string brKarte)   //ovde ?
        {
            foreach (ClanskaKarta clanskaKarta in ClanskeKarte)
            {
                if (clanskaKarta.brClanskeKarte == brKarte)
                    return clanskaKarta;
            }
            return null;
        }
        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(ClanskeKarte, Formatting.Indented));
        }

        public double GetMaxDanaByTipClanstva(string brClanskeKarte)
        {
            ClanskaKarta clanskaKarta = GetClanskaKartaByBr(brClanskeKarte);
            if (clanskaKarta.clanstvo == TipClanstva.DECA)
            {
                return 4;
            } 
            else if (clanskaKarta.clanstvo == TipClanstva.ODRASLI)
            {
                return 5;
            }
            else if (clanskaKarta.clanstvo == TipClanstva.PENZIONERI)
            {
                return 7;
            }
            return 14;
        }

        public int GetMaxBrojKnjiga(string brClanskeKarte)
        {
            ClanskaKarta clanskaKarta = GetClanskaKartaByBr(brClanskeKarte);
            if (clanskaKarta.clanstvo == TipClanstva.DECA)
            {
                return 2;
            }
            else if (clanskaKarta.clanstvo == TipClanstva.ODRASLI)
            {
                return 5;
            }
            else if (clanskaKarta.clanstvo == TipClanstva.PENZIONERI)
            {
                return 7;
            }
            return 8;
        }

        public double GetIznosClanarine(string brClanskeKarte)
        {
            ClanskaKarta clanskaKarta = GetClanskaKartaByBr(brClanskeKarte);
            if (clanskaKarta.clanstvo == TipClanstva.DECA)
            {
                return 300;
            } else if(clanskaKarta.clanstvo == TipClanstva.ODRASLI)
            {
                return 1000;
            } else if (clanskaKarta.clanstvo == TipClanstva.PENZIONERI)
            {
                return 500;
            }
            return 600;
        }

        public double GetDanasnjeClanarine()
        {
            double iznos = 0;
            foreach(ClanskaKarta clanskaKarta in GetAllClanskeKarte())
            {
                if(clanskaKarta.datumPlacanja == DateTime.Today)
                {
                    iznos += GetIznosClanarine(clanskaKarta.brClanskeKarte);
                }
            }
            return iznos;
        }

        public List<ClanskaKarta> GetListaDanasnjeClanarine()
        {
            List<ClanskaKarta> danasnje = new List<ClanskaKarta>();
            foreach (ClanskaKarta clanskaKarta in GetAllClanskeKarte())
            {
                if (clanskaKarta.datumPlacanja == DateTime.Today)
                {
                    danasnje.Add(clanskaKarta);
                }
            }
            return danasnje;
        }
    }
}

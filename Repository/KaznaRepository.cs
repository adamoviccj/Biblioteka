using Newtonsoft.Json;
using SIMS_Projekat.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.Repository
{
    public class KaznaRepository
    {

        public List<Kazna> Kazne { get; set; }
        private string FilePath = "../../Data/kazne.json";
        public KaznaRepository() 
        {
            Kazne = GetAllKazne();
            if(Kazne == null) Kazne = new List<Kazna>();
        }



        private List<Kazna> GetAllKazne()
        {
            string json = File.ReadAllText(FilePath);
            List<Kazna> kazne = JsonConvert.DeserializeObject<List<Kazna>>(json);
            return kazne;
        }

        public List<Kazna> GetNeplaceneKazneByUsername(string username)
        {
            return Kazne.Where(x => x.clan.nalog.username.Equals(username) && x.datumUplate==null).ToList();
        }

        public bool UplatiKaznu(string kaznaID)
        {
            Kazna kazna = Kazne.Where(x => x.id.Equals(kaznaID)).FirstOrDefault();
            if (kazna != null)
            {
                kazna.datumUplate = DateTime.Now;
                Save();
                return true;
            }
            return false;
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Kazne, Formatting.Indented));
        }

        public double GetDanasnjeKazne()
        {
            double danasnjeKazne = 0;
            foreach(Kazna kazna in Kazne)
            {
                if (kazna.datumUplate == DateTime.Today)
                {
                    danasnjeKazne += kazna.iznos;
                }
            }
            return danasnjeKazne;
        }
    }
}

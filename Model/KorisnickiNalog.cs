using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.Model
{
    public class KorisnickiNalog
    {


        [JsonProperty("username")]
        public string username { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }

        public KorisnickiNalog() { }

        public KorisnickiNalog(string username, string password)
        {
            this.username = username;
            this.password = password;
        }


    }
}

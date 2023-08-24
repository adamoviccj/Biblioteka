using Newtonsoft.Json;
using SIMS_Projekat.enums;
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
        public string username;

        [JsonProperty("password")]
        public string password;

        public KorisnickiNalog() { }

        public KorisnickiNalog(string username, string password)
        {
            this.username = username;
            this.password = password;
        }


    }
}

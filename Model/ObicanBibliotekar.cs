﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.Model
{
    public class ObicanBibliotekar : Korisnik
    {
        [JsonProperty("naziv ogranka")]
        protected string nazivOgranka;

        public ObicanBibliotekar()
        {
        }

        public ObicanBibliotekar(string email, string ime, string prezime, string jmbg, string telefon, KorisnickiNalog nalog, string nazivOgranka)
            : base(email, ime, prezime, jmbg, telefon, nalog)
        {
            this.nazivOgranka = nazivOgranka;
        }

        public ObicanBibliotekar(string email, string ime, string prezime, string jmbg, string telefon, string nazivOgranka)
            : base(email, ime, prezime, jmbg, telefon)
        {
            this.nazivOgranka = nazivOgranka;
        }
    }
}

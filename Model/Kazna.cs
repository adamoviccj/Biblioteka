﻿using SIMS_Projekat.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.Model
{
    public class Kazna
    {
        public string id { get; set; }
        public float iznos { get; set; }
        public Clan clan { get; set; }
        public DateTime? datumUplate { get; set; }
        public TipKazne tipKazne { get; set; }

        public Kazna() { }
        public Kazna(float amount, Clan clan, TipKazne tipKazne)
        {
            this.id = Guid.NewGuid().ToString();
            this.iznos = amount;
            this.clan = clan;
            this.datumUplate = null;
            this.tipKazne = tipKazne;
        }

        public Kazna(float amount, Clan clan, DateTime datumUplate, TipKazne tipKazne)
        {
            this.id = Guid.NewGuid().ToString();
            this.iznos = amount;
            this.clan = clan;
            this.datumUplate = datumUplate;
            this.tipKazne = tipKazne;
        }

    }
}

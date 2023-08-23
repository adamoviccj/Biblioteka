using SIMS_Projekat.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SIMS_Projekat.ViewModel
{
    public class RegistracijaViewModel : BaseViewModel
    {
        public string Email { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Jmbg { get; set; }
        public string Telefon { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string TipClanstva { get; set; }
        public ICommand SubmitClanCommand { get; }
        public RegistracijaViewModel()
        {
            Email = "";
            Ime = "";
            Prezime = "";
            Jmbg = "";
            Telefon = "";
            Username = "";
            Password = "";
            TipClanstva = "";

            SubmitClanCommand = new SubmitClanCommand(this);
        }
    }
}

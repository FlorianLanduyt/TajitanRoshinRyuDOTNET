using PROJ20_G20_DOTNET.Models.Domain;
using System;


namespace PROJ20_G20_DOTNET.Models.ViewModels
{
    public class LidEditViewModel
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string RijksregisterNummer { get; set; }
        public string Nationaliteit { get; set; }
        public DateTime DatumEersteTraining { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public string GsmNr { get; set; }
        public string VasteTelefoonNr { get; set; }
        public string Stad { get; set; }
        public string Straat { get; set; }
        public string HuisNr { get; set; }
        public string Bus { get; set; }
        public string PostCode { get; set; }
        public string Email { get; set; }
        public string Wachtwoord { get; set; }
        public string EmailVader { get; set; }
        public string EmailMoeder { get; set; }
        public string GeboortePlaats { get; set; }
        public string Geslacht { get; set; }
        public string Beroep { get; set; }

        public Graad Graad { get; set; }
        public Functie Functie { get; set; }

        public LidEditViewModel()
        {
                
        }


        public LidEditViewModel(Lid lid)
        {
            Voornaam = lid.Voornaam;
            Achternaam = lid.Achternaam;
            RijksregisterNummer = lid.Achternaam;
            Nationaliteit = lid.Nationaliteit;
            DatumEersteTraining = lid.DatumEersteTraining;
            GeboorteDatum = lid.GeboorteDatum;
            GsmNr = lid.GsmNr;
            VasteTelefoonNr = lid.VasteTelefoonNr;
            Stad = lid.Stad;
            Straat = lid.Straat;
            HuisNr = lid.HuisNr;
            Bus = lid.Bus;
            PostCode = lid.PostCode;
            Email = lid.Email;
            Wachtwoord = lid.Wachtwoord;
            EmailVader = lid.EmailVader;
            EmailMoeder = lid.EmailMoeder;
            GeboortePlaats = lid.GeboortePlaats;
            Geslacht = lid.Geslacht;
            Beroep = lid.Beroep;
            Graad = lid.Graad;
            Functie = lid.Functie;
        }
    }
}

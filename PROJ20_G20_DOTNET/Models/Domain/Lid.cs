using System;

namespace PROJ2_G20_.NET.Models.Domain {
    public class Lid {

        #region Properties
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string RijksregisterNummer { get; set; }
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
        public int PuntenAantal { get; set; }

        public int Id { get; set; }
        public Graad Graad { get; set; }
        public Functie Functie { get; set; }


        #endregion

        #region Constructors
        public Lid(string voornaam, string achternaam, string rijksregisterNummer,
            DateTime datumEersteTraining, DateTime geboorteDatum, string gsmNr, string vasteTelefoonNr,
            string stad, string straat, string huisNr, string bus, string postCode, string email,
            string wachtwoord, string emailVader, string emailMoeder, string geboortePlaats,
            string geslacht, string beroep, int puntenAantal, Graad graad, Functie functie) {

            Voornaam = voornaam;
            Achternaam = achternaam;
            RijksregisterNummer = rijksregisterNummer;
            DatumEersteTraining = datumEersteTraining;
            GeboorteDatum = geboorteDatum;
            GsmNr = gsmNr;
            VasteTelefoonNr = vasteTelefoonNr;
            Stad = stad;
            Straat = straat;
            HuisNr = huisNr;
            Bus = bus;
            PostCode = postCode;
            Email = email;
            Wachtwoord = wachtwoord;
            EmailVader = emailVader;
            EmailMoeder = emailMoeder;
            GeboortePlaats = geboortePlaats;
            Geslacht = geslacht;
            Beroep = beroep;
            PuntenAantal = puntenAantal;
            Graad = graad;
            Functie = functie;
        }

        protected Lid() {
        }



        #endregion
    }
}

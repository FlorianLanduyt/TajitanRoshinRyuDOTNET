using System;

namespace PROJ20_G20_DOTNET.Models.Domain
{
    public class Lid
    {

        #region Properties
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
        public int PuntenAantal { get; set; }

        public int Id { get; set; }
        public Graad Graad { get; set; }
        public Functie Functie { get; set; }


        #endregion

        #region Constructors
        public Lid(string voornaam, string achternaam, DateTime geboortedatum,
            string rijksregisterNr,
            string gsmNr, string vasteTelefoonNr, string stad, string straat,
            string huisNr, string postcode, string email,
            string wachtwoord, string geboorteplaats, string geslacht,
            string nationaliteit, Graad graad, Functie functie)
        {

            Voornaam = voornaam;
            Achternaam = achternaam;
            RijksregisterNummer = rijksregisterNr;
            GeboorteDatum = geboortedatum;
            GsmNr = gsmNr;
            Nationaliteit = nationaliteit;
            VasteTelefoonNr = vasteTelefoonNr;
            Stad = stad;
            Straat = straat;
            HuisNr = huisNr;
            PostCode = postcode;
            Email = email;
            Wachtwoord = wachtwoord;
            GeboortePlaats = geboorteplaats;
            Geslacht = geslacht;
            Graad = graad;
            Functie = functie;
        }

        protected Lid()
        {
        }



        #endregion
    }
}

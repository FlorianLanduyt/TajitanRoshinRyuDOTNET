using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace PROJ20_G20_DOTNET.Models.Domain
{
    public class Lid
    {
        private string _voornaam;
        private string _achternaam;
        private string _rijksregisternummer;
        private string _nationaliteit;
        private DateTime _geboortedatum;
        private string _gsmNr;
        private string _vasteTelefoonNr;
        private string _stad;
        private string _straat;
        private string _huisnr;
        private string _postcode;
        private string _email;
        private string _emailVader;
        private string _emailMoeder;
        private string _geboorteplaats;
        private string _geslacht;


        #region Properties
        public string Voornaam {
            get {
                return _voornaam;
            }
            set {
                if (value != null)
                {
                    if (value.Equals(""))
                    {
                        throw new ArgumentException("Voornaam mag niet leeg zijn.");
                    }
                    if (value.Length > 50)
                    {
                        throw new ArgumentException("Voornaam mag maximum 50 karakters bevatten.");
                    }
                    if (value.Contains(' '))
                    {
                        string tempVoornaam = value.Replace(" ", "");
                        if (Regex.Match(tempVoornaam, ".*[\\d\\W].*").Success)
                        {
                            throw new ArgumentException("Voornaam mag enkel letters bevatten.");
                        }
                    }
                    else
                    {
                        if (Regex.Match(value, ".*[\\d\\W].*").Success)
                        {
                            throw new ArgumentException("Voornaam mag enkel letters bevatten.");
                        }
                    }
                    _voornaam = value;
                }
                else
                {
                    throw new ArgumentException("Voornaam mag niet leeg zijn.");
                }
            }
        }
        public string Achternaam {
            get {
                return _achternaam;
            }
            set {
                if (value != null)
                {
                    if (value.Equals(""))
                    {
                        throw new ArgumentException("Familienaam mag niet leeg zijn.");
                    }
                    if (value.Length > 50)
                    {
                        throw new ArgumentException("Familienaam mag maximum 50 karakters bevatten.");
                    }
                    if (value.Contains(' '))
                    {
                        string tempAchternaam = value.Replace(" ", "");
                        if (Regex.Match(tempAchternaam, ".*[\\d\\W].*").Success)
                        {
                            throw new ArgumentException("Familienaam mag enkel letters bevatten.");
                        }
                    }
                    else
                    {
                        if (Regex.Match(value, ".*[\\d\\W].*").Success)
                        {
                            throw new ArgumentException("Familienaam mag enkel letters bevatten.");
                        }
                    }
                    _achternaam = value;
                }
                else
                {
                    throw new ArgumentException("Familienaam mag niet leeg zijn!");
                }
            }
        }
        public string RijksregisterNummer {
            get {
                return _rijksregisternummer;
            }
            set {
                if (value != null)
                {
                    string nrZonderTekens = value.Replace(".", "").Replace("-", "");
                    string gebdatum = nrZonderTekens.Substring(0, 6);
                    string geslacht = nrZonderTekens.Substring(6, 3);
                    string controlegetal = nrZonderTekens.Substring(9, 2);

                    bool gebDatumCorrect = false;
                    bool controleCorrect = false;
                    //Geslacht checken
                    bool geslachtCorrect = Convert.ToInt32(geslacht) % 2 == 0 ? Geslacht.Equals("VROUW", StringComparison.InvariantCultureIgnoreCase) : Geslacht.Equals("MAN", StringComparison.InvariantCultureIgnoreCase);

                    //Checken of geboortedatumdeel correct is
                    string yearGeboor = Convert.ToString(GeboorteDatum.Year).Substring(2, 2);
                    string gebdatumjaar = gebdatum.Substring(0, 2);
                    if (Convert.ToString(GeboorteDatum.Year).Substring(2, 2).Equals(gebdatum.Substring(0, 2)))
                    {
                        switch (GeboorteDatum.Month)
                        {
                            case 10:
                            case 11:
                            case 12:
                                if (Convert.ToString(GeboorteDatum.Month).Equals(gebdatum.Substring(2, 2)))
                                {
                                    switch (GeboorteDatum.Month)
                                    {
                                        case 1:
                                        case 2:
                                        case 3:
                                        case 4:
                                        case 5:
                                        case 6:
                                        case 7:
                                        case 8:
                                        case 9:
                                            gebDatumCorrect = Convert.ToString(GeboorteDatum.Month).Equals(gebdatum.Substring(3, 1));
                                            break;
                                        default:
                                            gebDatumCorrect = Convert.ToString(GeboorteDatum.Month).Equals(gebdatum.Substring(2, 2));
                                            break;
                                    }
                                }
                                break;
                            default:
                                if (Convert.ToString(GeboorteDatum.Month).Equals(gebdatum.Substring(3, 1)))
                                {
                                    switch (GeboorteDatum.Month)
                                    {
                                        case 1:
                                        case 2:
                                        case 3:
                                        case 4:
                                        case 5:
                                        case 6:
                                        case 7:
                                        case 8:
                                        case 9:
                                            gebDatumCorrect = Convert.ToString(GeboorteDatum.Month).Equals(gebdatum.Substring(3, 1));
                                            break;
                                        default:
                                            gebDatumCorrect = Convert.ToString(GeboorteDatum.Month).Equals(gebdatum.Substring(4, 2));
                                            break;
                                    }
                                }
                                break;
                        }
                    }
                    //Controlegetal check
                    if (GeboorteDatum.Year < 2000)
                    {
                        controleCorrect = (97 - (Convert.ToInt32(String.Concat(gebdatum, geslacht)) % 97)) == Convert.ToInt32(controlegetal);
                    }
                    else
                    {
                        controleCorrect = (97 - (Convert.ToInt32(String.Concat("2", gebdatum, geslacht)) % 97)) == Convert.ToInt32(controlegetal);
                    }
                    //Alle booleans checken
                    if (gebDatumCorrect && geslachtCorrect && controleCorrect)
                    {
                        _rijksregisternummer = value;
                    }
                    else
                    {
                        throw new ArgumentException("Rijksregisternummer is niet correct.");
                    }
                }
            }
        }
        public string Nationaliteit {
            get {
                return _nationaliteit;
            }
            set {
                if (value != null)
                {
                    if (value.Contains(' '))
                    {
                        string tempAchternaam = value.Replace(" ", "");
                        if (Regex.Match(tempAchternaam, ".*[\\d\\W].*").Success)
                        {
                            throw new ArgumentException("Nationaliteit mag enkel letters bevatten.");
                        }
                    }
                    else
                    {
                        if (Regex.Match(value, ".*[\\d\\W].*").Success)
                        {
                            throw new ArgumentException("Nationaliteit mag enkel letters bevatten.");
                        }
                    }
                    _nationaliteit = value;
                }
            }
        }
        public DateTime DatumEersteTraining { get; set; }

        public DateTime GeboorteDatum {
            get {
                return _geboortedatum;
            }
            set {
                if (value != null)
                {
                    if (DateTime.Today.AddYears(-5).CompareTo(value) < 0)
                    {
                        throw new ArgumentException("Lid moet minstens 5 jaar oud zijn.");
                    }
                    _geboortedatum = value;
                }
                else
                {
                    throw new ArgumentException("Geboortedatum is verplicht");
                }
            }
        }
        public string GsmNr {
            get {
                return _gsmNr;
            }
            set {
                if (value != null)
                {
                    string gsmnr = value.Trim();
                    if (gsmnr.Contains(' '))
                    {
                        string gsmnrWithoutSpaces = gsmnr.Replace(" ", "");
                        char ee = gsmnrWithoutSpaces.ToCharArray()[0];
                        if (gsmnrWithoutSpaces.ToCharArray()[0] == '+')
                        {
                            string gsmrtemp = gsmnrWithoutSpaces.Replace("+", "");
                            if (Regex.Match(gsmrtemp, ".*[a-zA-Z\\W].*").Success)
                            {
                                throw new ArgumentException("GSM-nummer mag enkel cijfers of +32 gevolgd door cijfers bevatten");
                            }

                        }
                        else
                        {
                            throw new ArgumentException("GSM-nummer mag enkel cijfers of +32 gevolgd door cijfers bevatten");
                        }

                        if (!Regex.Match(gsmnrWithoutSpaces, "(([+]32){1}[0-9]{9})|([0-9]{10})").Success)
                        {
                            throw new ArgumentException("GSM-nummer is niet correct.");
                        }
                    }
                    else
                    {

                        if (gsmnr.ToCharArray()[0] == '+')
                        {
                            string gsmrtemp = gsmnr.Replace("+", "");
                            if (Regex.Match(gsmrtemp, ".*[a-zA-Z\\W].*").Success)
                            {
                                throw new ArgumentException("GSM-nummer mag enkel cijfers of +32 gevolgd door cijfers bevatten");
                            }

                        }
                        else
                        {
                            if (Regex.Match(gsmnr, ".*[a-zA-Z\\W].*").Success)
                            {
                                throw new ArgumentException("GSM-nummer mag enkel cijfers of +32 gevolgd door cijfers bevatten");
                            }

                        }

                        if (!Regex.Match(gsmnr, "(([+]32){1}[0-9]{9})|([0-9]{10})").Success)
                        {
                            throw new ArgumentException("GSM-nummer is niet correct.");
                        }
                    }
                    _gsmNr = value;
                }
            }
        }
        public string VasteTelefoonNr {
            get {
                return _vasteTelefoonNr;
            }
            set {
                if (value != null)
                {
                    if (Regex.Match(value, "[0-9]{9}").Success)
                    {
                        _vasteTelefoonNr = value;
                    }
                }
                _vasteTelefoonNr = "";

            }
        }
        public string Stad {
            get {
                return _stad;
            }
            set {
                if (value != null)
                {
                    if (value.Equals(""))
                    {
                        throw new ArgumentException("Stad mag niet leeg zijn.");
                    }
                    if (value.Length > 50)
                    {
                        throw new ArgumentException("Stad mag maximum 50 karakters bevatten.");
                    }
                    string stad = value.Trim();
                    if (value.Contains(' '))
                    {
                        string tempstad = stad.Replace(" ", "");
                        if (Regex.Match(tempstad, ".*[\\d\\W].*").Success)
                        {
                            throw new ArgumentException("Stad mag enkel letters bevatten.");
                        }
                    }
                    else
                    {
                        if (Regex.Match(stad, ".*[\\d\\W].*").Success)
                        {
                            throw new ArgumentException("Stad mag enkel letters bevatten.");
                        }
                    }
                    _stad = value;
                }
                else
                {
                    throw new ArgumentException("Stad is verplicht!");
                }
            }
        }
        public string Straat {
            get { return _straat; }
            set {
                if (value != null)
                {
                    if (value.Equals(""))
                    {
                        throw new ArgumentException("Straat mag niet leeg zijn.");
                    }
                    if (value.Length > 50)
                    {
                        throw new ArgumentException("Straat mag maximum 50 karakters bevatten.");
                    }
                    string straat = value.Trim();
                    if (value.Contains(' '))
                    {
                        string tempstraat = straat.Replace(" ", "");
                        if (Regex.Match(tempstraat, ".*[\\d\\W].*").Success)
                        {
                            throw new ArgumentException("Straat mag enkel letters bevatten.");
                        }
                    }
                    else
                    {
                        if (Regex.Match(straat, ".*[\\d\\W].*").Success)
                        {
                            throw new ArgumentException("Straat mag enkel letters bevatten.");
                        }
                    }
                    _straat = value;
                }
                else
                {
                    throw new ArgumentException("Straat mag niet leeg zijn!");
                }
            }
        }
        public string HuisNr {
            get {
                return _huisnr;
            }
            set {
                if (value != null)
                {
                    string huisnr = value.Trim();
                    if (!Regex.Match(huisnr, "\\d{1,5}").Success)
                    {
                        throw new ArgumentException("Huisnummer mag geen letters/symbolen bevatten.");
                    }
                    _huisnr = value;

                }
            }
        }
        public string Bus { get; set; } //alle nodige validatie wordt al gedaan in de viewmodel
        public string PostCode {
            get {
                return _postcode;
            }
            set {
                if (value != null)
                {
                    string postcode = value.Trim();
                    if (!Regex.Match(postcode, "[0-9]{4}").Success)
                    {
                        throw new ArgumentException("Postcode moet 4 cijfers bevatten.");
                    }
                    _postcode = value;
                }
            }
        }
        public string Email {
            get {
                return _email;
            }
            set {
                if (value != null)
                {
                    string email = value.Trim();
                    if (!Regex.Match(email, "\\b[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}\\b").Success)
                    {
                        throw new ArgumentException("Emailadres is niet correct.");
                    }
                    _email = value;
                }
            }
        }

        public string EmailVader {
            get { return _emailVader; }

            set {
                if (value != null)
                {
                    string emailVader = value.Trim();
                    if (!Regex.Match(emailVader, "\\b[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}\\b").Success)
                    {
                        throw new ArgumentException("Emailadres vader is niet correct.");
                    }
                    _emailVader = value;
                }
            }
        }
        public string EmailMoeder {
            get {
                return _emailMoeder;
            }
            set {
                if (value != null)
                {
                    string emailMoeder = value.Trim();
                    if (!Regex.Match(emailMoeder, "\\b[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}\\b").Success)
                    {
                        throw new ArgumentException("Emailadres moeder is niet correct.");
                    }
                    _emailMoeder = value;
                }

            }
        }
        public string Wachtwoord { get; set; }
        public string GeboortePlaats {
            get {
                return _geboorteplaats;
            }

            set {
                if (value != null)
                {
                    if (value.Contains(" "))
                    {
                        string geboorteplaats = value.Replace(" ", "");
                        if (geboorteplaats.Contains("-"))
                        {
                            geboorteplaats = geboorteplaats.Replace("-", "");
                            if (Regex.Match(geboorteplaats, ".*[\\d\\W].*").Success)
                            {
                                throw new ArgumentException("Geboorteplaats mag enkel letters bevatten.");
                            }

                        }
                    }
                    else
                    {
                        if (value.Contains("-"))
                        {
                            string geboorteplaats = value.Replace("-", "");
                            if (Regex.Match(geboorteplaats, ".*[\\d\\W].*").Success)
                            {
                                throw new ArgumentException("Geboorteplaats mag enkel letters bevatten.");
                            }

                        }
                        else
                        {
                            if (Regex.Match(value, ".*[\\d\\W].*").Success)
                            {
                                throw new ArgumentException("Geboorteplaats mag enkel letters bevatten.");
                            }
                        }
                        _geboorteplaats = value;
                    }
                }
            }
        }
        public string Geslacht {
            get { return _geslacht; }
            set {
                if (value != null)
                {
                    if (value.Equals("MAN", StringComparison.InvariantCultureIgnoreCase) || value.Equals("VROUW", StringComparison.InvariantCultureIgnoreCase))
                    {
                        _geslacht = value;
                    }
                    else
                    {
                        throw new ArgumentException("Geslacht is niet correct.");
                    }
                }

            }
        }
        public string LeeftijdsCategorieën {
            get {
                int leeftijd = DateTime.Now.Year - GeboorteDatum.Year;
                if (leeftijd <= 15)
                {
                    if (leeftijd < 10)
                    {
                        return "L6_15";
                    }
                    else
                    {
                        return "L6_15-L10-15";
                    }
                }
                else
                {
                    return "L15_PLUS";
                }
            }
        }
        public string Beroep { get; set; }
        public int PuntenAantal { get; set; }

        public int Id { get; set; }
        public Graad Graad { get; set; }
        public Functie Functie { get; set; }


        #endregion

        #region Constructors
        public Lid()
        {
        }

        public Lid(string voornaam, string achternaam, DateTime geboortedatum,
            string rijksregisterNr,
            string gsmNr, string vasteTelefoonNr, string stad, string straat,
            string huisNr, string postcode, string email,
            string wachtwoord, string geboorteplaats, string geslacht,
            string nationaliteit, Graad graad, Functie functie)
        {

            Voornaam = voornaam;
            Achternaam = achternaam;
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
            RijksregisterNummer = rijksregisterNr;
        }
        #endregion

    }
}

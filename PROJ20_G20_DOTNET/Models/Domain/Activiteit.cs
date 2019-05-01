using PROJ20_G20_DOTNET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PROJ20_G20_DOTNET.Models.Domain
{
    public class Activiteit
    {

        #region Fields
        private readonly int _maxLengteNaam = 25;
        private readonly int _maxLengteLocaties = 50;
        private readonly int _maxLengtePostcode = 4;
        private readonly int _maxLengteHuisnr = 5;

        private string _naam;
        private Formule _formule; //niet nodig
        private DateTime _beginDatum;
        private DateTime _eindDatum;
        private DateTime _uitersteInschrijving;
        private string _gsmNummer;
        private string _email;
        private string _naamLocatie;
        private string _straat;
        private string _stad;
        private string _postCode;
        private string _huisNummer;
        private string _busNummer;
        private int _maxAantalDeelnemers;
        private int _aantalDeelnemers;
        private bool _isVolzet;

        #endregion


        #region Properties
        public string Naam {
            get { return _naam; }
            set {
                if (value != null)
                {
                    string naam = value.Trim();
                    if(naam == "")
                    {
                        throw new ArgumentException("Naam mag niet leeg zijn");
                    }
                    if (naam.Length > _maxLengteNaam)
                    {
                        throw new ArgumentException($"Naam mag max. {_maxLengteNaam} karakters bevatten.");
                    }

                    naam = value.Replace(" ", "");
                    if (Regex.Match(naam, ".*[\\d\\W].*").Success) { 
                        throw new ArgumentException("Naam mag enkel letters bevatten.");
                    }
                    _naam = value;
                }
                else
                    throw new ArgumentException("Naam mag niet leeg zijn.");
            }
        }

        public Formule Formule {
            get { return _formule; }
            set {
                //if (!value.Equals(null))
                //    _formule = value;
                //else
                //    throw new ArgumentException("Formule mag niet leeg zijn");
                _formule = value;
            }
        }

        public DateTime BeginDatum {
            get { return _beginDatum; }
            set {
                if (!value.Equals(null))
                {
                    if(value < DateTime.Today)
                    {
                        throw new ArgumentException("Begingdatum mag niet in het verleden liggen");
                    }
                    _beginDatum = value;
                }
                else
                    throw new ArgumentException("Begindatum mag niet leeg zijn");
                
            }
        }

        public DateTime EindDatum {
            get { return _eindDatum; }
            set {
                if (!value.Equals(null))
                {
                    if (!BeginDatum.Equals(null))
                    {
                        if (value < DateTime.Today)
                        {
                            throw new ArgumentException("Einddatum mag niet in het verleden liggen.");
                        }
                        if (value < BeginDatum)
                            throw new ArgumentException("Einddatum mag niet voor begindatum liggen.");
                    }
                    _eindDatum = value;
                }
                else
                    throw new ArgumentException("Einddatum mag niet leeg zijn");
                //_eindDatum = value;
            }
        }

        public DateTime UitersteInschrijvingsDatum {
            get { return _uitersteInschrijving; }
            set {
                if (!value.Equals(null))
                {
                    if (value < DateTime.Today)
                    {
                        throw new ArgumentException("Uiterste datum van inschrijving mag niet in het verleden liggen.");
                    }
                    if (value > BeginDatum)
                    {
                        throw new ArgumentException("Uiterste inschrijving mag niet na de begindatum liggen.");
                    }
                    else
                    {
                        _uitersteInschrijving = value;
                    }
                }
                else
                    throw new ArgumentException("Uiterste inschrijvingsdatum mag niet leeg zijn");
               // _uitersteInschrijving = value;
            }
        }

        public string GsmNummer {
            get {
                return _gsmNummer;
            }
            set {
                if (value != null)
                {
                    string gsmnr = value.Trim();
                    if (gsmnr == "")
                    {
                        throw new ArgumentException("GSM-nummer mag niet leeg zijn");
                    }
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
                    _gsmNummer = value;
                }
                else
                {
                    throw new ArgumentException("GSM-nummer mag niet leeg zijn");
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
                    if (email.Contains(" "))
                    {
                        throw new ArgumentException("Email mag geen spaties bevatten");
                    }
                    if (email == "")
                    {
                        throw new ArgumentException("Email mag niet leeg zijn");
                    }
                    if (!Regex.Match(email, "\\b[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}\\b").Success)
                    {
                        throw new ArgumentException("Emailadres is niet correct.");
                    }
                    _email = value;
                }
                else
                {
                    throw new ArgumentException("Email mag niet leeg zijn");
                }
            }
        }

        public string NaamLocatie {
            get { return _naamLocatie; }
            set {
                //if (value != null) {
                //    string naamlocatie = value.Trim().Replace(@"\s+", "");
                //    if (NaamLocatie.Length > _maxLengteLocaties)
                //        throw new ArgumentException($"Naam locatie mag maximum {_maxLengteLocaties} karakters hebben.");
                //    if (Regex.Match(value, ".*[\\d\\W].*").Success)
                //        throw new ArgumentException("Naam locatie mag enkel letters bevatten.");
                //    _naamLocatie = value;
                //}
                //else
                //    throw new ArgumentException("Locatienaam mag niet leeg zijn.");
                _naamLocatie = value;
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

        public string HuisNummer {
            get {
                return _huisNummer;
            }
            set {
                if (value != null)
                {
                    if (value == "")
                    {
                        throw new ArgumentException("Huisnummer mag niet leeg zijn!");
                    }
                    if (value.Length > 5)
                    {
                        throw new ArgumentException("Huisnummer mag maximum 5 karakters bevatten");
                    }
                    string huisnr = value.Trim();
                    if (!Regex.Match(huisnr, "\\d{1,5}").Success)
                    {
                        throw new ArgumentException("Huisnummer mag geen letters/symbolen bevatten.");
                    }
                    _huisNummer = value;

                }
                else
                {
                    throw new ArgumentException("Huisnummer mag niet leeg zijn!");
                }
            }
        }
        public string BusNummer {
            get {
                return _busNummer;
            }
            set {
                if (value != null)
                {
                    if (value.Length > 5)
                    {
                        throw new ArgumentException("Bus mag max. 5 karakters bevatten");
                    }
                    _busNummer = value;
                }
            }
        } //alle nodige validatie wordt al gedaan in de viewmodel
        public string Postcode {
            get {
                return _postCode;
            }
            set {
                if (value != null)
                {
                    if (value == "")
                    {
                        throw new ArgumentException("Postcode mag niet leeg zijn");
                    }

                    string postcode = value.Trim();
                    if (postcode.Length > 4)
                    {
                        throw new ArgumentException("Postcode is te lang");
                    }
                    if (!Regex.Match(postcode, "[0-9]{4}").Success)
                    {
                        throw new ArgumentException("Postcode moet 4 cijfers bevatten.");
                    }
                    _postCode = value;
                }
                else
                {
                    throw new ArgumentException("Postcode mag niet leeg zijn");
                }
            }
        }
        public int MaxAantalDeelnemers {
            get { return _maxAantalDeelnemers; }
            set {
                //if (value.Equals(null))
                //    throw new ArgumentException("Max aantal deelnemers mag niet leeg zijn.");
                //else
                //{
                //    if (!Regex.Match(Convert.ToString(value), "\\d+").Success)
                //    {
                //        throw new ArgumentException("Max. aantal deelnemers mag enkel cijfers bevatten");
                //    }
                //    _maxAantalDeelnemers = value;
                //}
                    
                _maxAantalDeelnemers = value;
            }
        }

        public int AantalDeelnemers {
            get { return _aantalDeelnemers; }
            private set {
                _aantalDeelnemers = ActiviteitInschrijvingen.Count;
            }
        }
        public bool IsVolzet {
            get { return _isVolzet; }
            private set {
                _isVolzet = MaxAantalDeelnemers == AantalDeelnemers;
            }
        }
        public int Id { get; set; }

        public ICollection<ActiviteitInschrijving> ActiviteitInschrijvingen { get; set; }

        #endregion

        #region Constructors
        public Activiteit()
        {
            ActiviteitInschrijvingen = new List<ActiviteitInschrijving>();
        }

        public Activiteit(string naam,
            Formule formule, DateTime beginDatum, DateTime eindDatum, DateTime uitersteInschrijvingsDatum,
            string gsmNummer, string email, string naamLocatie, string straat, string stad, string postcode,
            string huisNummer, string busNummer, int maxAantalDeelnemers) : this()
        {
            ActiviteitInschrijvingen = new List<ActiviteitInschrijving>();
            Naam = naam;
            Formule = formule;
            BeginDatum = beginDatum;
            EindDatum = eindDatum;
            UitersteInschrijvingsDatum = uitersteInschrijvingsDatum;
            GsmNummer = gsmNummer;
            Email = email;
            NaamLocatie = naamLocatie;
            Straat = straat;
            Stad = stad;
            Postcode = postcode;
            HuisNummer = huisNummer;
            BusNummer = busNummer ?? null;
            MaxAantalDeelnemers = maxAantalDeelnemers;
            IsVolzet = MaxAantalDeelnemers == AantalDeelnemers;
        }
        #endregion

        #region Methods
        public void AddInschrijving(Inschrijving inschrijving)
        {
            ActiviteitInschrijving ai = new ActiviteitInschrijving(this, inschrijving);
            ActiviteitInschrijvingen.Add(ai);
        }
        #endregion
    }
}
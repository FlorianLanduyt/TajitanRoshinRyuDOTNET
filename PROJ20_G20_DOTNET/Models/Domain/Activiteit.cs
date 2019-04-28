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
        private Formule _formule;
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
                //if (value != null) {
                //    string naam = value.Trim();
                //    if (naam.Length > _maxLengteNaam)
                //        throw new ArgumentException($"Naam mag max. {_maxLengteNaam} karakters bevatten.");
                //    naam = value.Replace(" ", "");
                //    if (Regex.Match(naam, ".*[\\d\\W].*").Success)
                //        throw new ArgumentException("Naam mag enkel letters bevatten.");
                //    _naam = value;
                //}
                //else
                //    throw new ArgumentException("Naam mag niet leeg zijn.");
                _naam = value;
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
                //if (!value.Equals(null)) {
                //    if (!_eindDatum.Equals(null)) {
                //        if (DateTime.Compare(_beginDatum, _eindDatum) > 0)
                //            throw new ArgumentException("Begindatum mag niet na einddatum liggen.");
                //    }
                //    _beginDatum = value;
                //}
                //else
                //    throw new ArgumentException("Begindatum mag niet leeg zijn");
                _beginDatum = value;
            }
        }

        public DateTime EindDatum {
            get { return _eindDatum; }
            set {
                //if (!value.Equals(null)) {
                //    if (!_beginDatum.Equals(null)) {
                //        if (DateTime.Compare(_beginDatum, _eindDatum) < 0)
                //            throw new ArgumentException("Einddatum mag niet voor begindatum liggen.");
                //    }
                //    _eindDatum = value;
                //}
                //else
                //    throw new ArgumentException("Einddatum mag niet leeg zijn");
                _eindDatum = value;
            }
        }

        public DateTime UitersteInschrijvingsDatum {
            get { return _uitersteInschrijving; }
            set {
                //if (!value.Equals(null)) {
                //    if (DateTime.Compare(_uitersteInschrijving, DateTime.Now) < 0) {
                //        throw new ArgumentException("Uiterste datum van inschrijving mag niet in het verleden liggen.");
                //    }
                //    if (DateTime.Compare(_beginDatum, _uitersteInschrijving) < 0) {
                //        throw new ArgumentException("Uiterste inschrijving mag niet na de begindatum liggen.");
                //    }
                //    else {
                //        _uitersteInschrijving = value;
                //    }
                //}
                //else
                //    throw new ArgumentException("Uiterste inschrijvingsdatum mag niet leeg zijn");
                _uitersteInschrijving = value;
            }
        }

        public string GsmNummer {
            get { return _gsmNummer; }
            set {
                //if (value != null) {
                //    string gsm = value.Trim();
                //    if (gsm.Contains(" ")) {
                //        gsm = Regex.Replace(gsm, @"\s+", "");
                //        if (Regex.Match(gsm, ".*[a-zA-Z\\W].*").Success)
                //            throw new ArgumentException("Een gsm nummer mag enkel getallen bevatten.");
                //    }
                //    else {
                //        if (gsm.StartsWith("+")) {
                //            gsm = Regex.Replace(gsm, "+", "");
                //            if (Regex.Match(gsm, ".*[a-zA-Z\\W].*").Success)
                //                throw new ArgumentException("Een gsm nummer mag enkel getallen bevatten.");
                //        }
                //        else {
                //            if (Regex.Match(gsm, ".*[a-zA-Z\\W].*").Success)
                //                throw new ArgumentException("Een gsm nummer mag enkel getallen bevatten.");
                //        }
                //        if (Regex.Match(gsm, "([+]32){1}[0-9]{9}|[0-9]{10}").Success)
                //            throw new ArgumentException("Gsm nummer is niet correct.");
                //    }
                //    _gsmNummer = value;
                //}
                //else
                //    throw new ArgumentException("Gsm nummer mag niet leeg zijn.");
                _gsmNummer = value;
            }
        }

        public string Email {
            get { return _email; }
            set {
                //if (value != null) {
                //    string email = _email.Trim();
                //    if (Regex.Match(email, "\\b[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}\\b").Success)
                //        throw new ArgumentException("Email is niet correct.");
                //    _email = value;
                //}
                //else
                //    throw new ArgumentException("Email mag niet leeg zijn.");
                _email = value;
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
                //if (value != null) {
                //    string straat = value.Trim();
                //    if (straat.Length > _maxLengteLocaties)
                //        throw new ArgumentException($"De straat mag maximum {_maxLengteLocaties} karakters lang zijn.");
                //    straat = Regex.Replace(straat, @"\s+", "");
                //    if (Regex.Match(straat, ".*[\\d\\W].*").Success)
                //        throw new ArgumentException("De straat mag enkel uit letters bestaan.");
                //    _straat = value;
                //}
                //else
                //    throw new ArgumentException("Straat mag niet leeg zijn.");
                _straat = value;
            }
        }

        public string Stad {
            get { return _stad; }
            set {
                //if (value != null) {
                //    string stad = value.Trim();
                //    if (stad.Length > _maxLengteLocaties)
                //        throw new ArgumentException($"De stad mag maximum {_maxLengteLocaties} karakters bevatten.");
                //    stad = Regex.Replace(stad, @"\s+", "");
                //    if (Regex.Match(stad, ".*[\\d\\W].*").Success)
                //        throw new ArgumentException("De stad mag enkel letters bevatten.");
                //    _stad = value;
                //}
                //else
                //    throw new ArgumentException("Stad mag niet leeg zijn.");
                _stad = value;
            }
        }

        public string Postcode {
            get { return _postCode; }
            set {
                //if (value != null) {
                //    string pc = value.Trim();
                //    if (!Regex.Match(pc, "[0-9]{4}").Success)
                //        throw new ArgumentException($"Postcode mag maximum {_maxLengtePostcode} karakters bevatten.");
                //    _postCode = value;
                //}
                //else
                //    throw new ArgumentException("Postcode mag niet leeg zijn.");
                _postCode = value;
            }
        }

        public string HuisNummer {
            get { return _huisNummer; }
            set {
                //if (value != null) {
                //    string huisNr = value.Trim();
                //    if (huisNr.Length > 5)
                //        throw new ArgumentException($"Huisnummer max maximum {_maxLengteHuisnr} karakters lang zijn.");
                //    if (!Regex.Match(huisNr, "\\d{1,5}").Success)
                //        throw new ArgumentException("Huisnummer mag enkel cijfers bevatten.");
                //    _huisNummer = huisNr;
                //}
                //else
                //    throw new ArgumentException("Huisnummer mag niet leeg zijn.");
                _huisNummer = value;
            }
        }
        public string BusNummer {
            get { return _busNummer; }
            set {
                //if (value != null) {
                //    if (value.Trim().Length > _maxLengteHuisnr)
                //        throw new ArgumentException($"Busnummer max maximum {_maxLengteHuisnr} karkaters lang zijn.");
                //    _busNummer = value;
                //}
                //else
                //    _busNummer = null;
                _busNummer = value;
            }
        }
        public int MaxAantalDeelnemers {
            get { return _maxAantalDeelnemers; }
            set {
                //if (value.Equals(null))
                //    throw new ArgumentException("Max aantal deelnemers mag niet leeg zijn.");
                //else
                //    _maxAantalDeelnemers = value;
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
        protected Activiteit()
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
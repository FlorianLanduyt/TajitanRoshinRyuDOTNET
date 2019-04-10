using System;
using System.Collections.Generic;

namespace PROJ2_G20_.NET.Models.Domain {
    public class Activiteit {
        #region Fields
        private readonly int _id;
        private bool _isVolzet;
        private readonly IList<Inschrijving> _inschrijvingen;
        #endregion

        #region Properties
        public string Naam { get; set; }
        public Formule Formule { get; set; }
        public DateTime BeginDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public DateTime UitersteInschrijfDatum { get; set; }
        public string GsmNummer { get; set; }
        public string NaamLocatie { get; set; }
        public string Straat { get; set; }
        public string Stad { get; set; }
        public string Postcode { get; set; }
        public string HuisNummer { get; set; }
        public string BusNummer { get; private set; }
        public int MaxAantalDeelnemers { get; set; }
        public int AantalDeelnemers { get; set; }

        public int Id => _id;

        public IEnumerable<Inschrijving> Inschrijvingen { get => _inschrijvingen; }

        #endregion

        #region Constructors
        protected Activiteit() {

        }

        public Activiteit(string naam,
            Formule formule, DateTime beginDatum, DateTime eindDatum, DateTime uitersteInschrijfDatum,
            string gsmNummer, string naamLocatie, string straat, string stad, string postcode,
            string huisNummer, string busNummer, int maxAantalDeelnemers, int aantalDeelnemers,
            List<Inschrijving> inschrijvingen) {
            
            _inschrijvingen = inschrijvingen;
            Naam = naam;
            Formule = formule;
            BeginDatum = beginDatum;
            EindDatum = eindDatum;
            UitersteInschrijfDatum = uitersteInschrijfDatum;
            GsmNummer = gsmNummer;
            NaamLocatie = naamLocatie;
            Straat = straat;
            Stad = stad;
            Postcode = postcode;
            HuisNummer = huisNummer;
            BusNummer = busNummer ?? null;
            MaxAantalDeelnemers = maxAantalDeelnemers;
            AantalDeelnemers = aantalDeelnemers;
            _isVolzet = MaxAantalDeelnemers - AantalDeelnemers <= 0 ? true : false;
        } 
        #endregion
    }
}
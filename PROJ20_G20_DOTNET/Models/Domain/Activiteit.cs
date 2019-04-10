using PROJ20_G20_DOTNET.Models.Domain;
using System;
using System.Collections.Generic;

namespace PROJ2_G20_.NET.Models.Domain {
    public class Activiteit {

        #region Properties
        public string Naam { get; set; }
        public Formule Formule { get; set; }
        public DateTime BeginDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public DateTime UitersteInschrijvingsDatum { get; set; }
        public string GsmNummer { get; set; }
        public string Email { get; set; }
        public string NaamLocatie { get; set; }
        public string Straat { get; set; }
        public string Stad { get; set; }
        public string Postcode { get; set; }
        public string HuisNummer { get; set; }
        public string BusNummer { get; private set; }
        public int MaxAantalDeelnemers { get; set; }
        public int AantalDeelnemers { get; set; }
        public bool IsVolzet { get; set; }
        public int Id { get; set; }

        public ICollection<ActiviteitInschrijving> Inschrijvingen { get; private set; }

        #endregion

        #region Constructors
        protected Activiteit() {
            Inschrijvingen = new List<ActiviteitInschrijving>();
        }

        public Activiteit(string naam,
            Formule formule, DateTime beginDatum, DateTime eindDatum, DateTime uitersteInschrijvingsDatum,
            string gsmNummer, string email, string naamLocatie, string straat, string stad, string postcode,
            string huisNummer, string busNummer, int maxAantalDeelnemers, int aantalDeelnemers) : this() {
            
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
            AantalDeelnemers = aantalDeelnemers;
            IsVolzet = MaxAantalDeelnemers == AantalDeelnemers;
        } 
        #endregion
    }
}
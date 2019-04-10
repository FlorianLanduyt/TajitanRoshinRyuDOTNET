using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ2_G20_.NET.Models.Domain {
    public class Oefening {

        #region Properties
        public int Id { get; private set; }
        public string Titel { get; set; }
        public string UrlVideo { get; set; }
        public string Tekst { get; set; }
        public int AantalRaadplegingen { get; set; }
        public DateTime LaatsteRaadpleging { get; set; }

        public Graad Graad { get; set; }
        public Thema Thema { get; set; }
        #endregion

        #region Constructors
        protected Oefening() {

        }

        public Oefening(string titel, string urlVideo,
            string tekst, DateTime laatsteRaadpleging,
            Graad graad, Thema thema) {
            Titel = titel;
            UrlVideo = urlVideo;
            Tekst = tekst;
            AantalRaadplegingen = 0;
            LaatsteRaadpleging = laatsteRaadpleging;
            Graad = graad;
            Thema = thema;
        } 
        #endregion
    }
}

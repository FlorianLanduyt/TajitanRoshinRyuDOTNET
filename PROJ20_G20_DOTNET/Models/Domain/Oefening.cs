using System;

namespace PROJ20_G20_DOTNET.Models.Domain {
    public class Oefening {

        #region Properties
        public int Id { get; set; }
        public string Titel { get; set; }
        public string UrlVideo { get; set; }
        public string UrlAfbeelding { get; set; }
        public string Tekst { get; set; }
        public int AantalRaadplegingen { get; set; }
        public DateTime LaatsteRaadpleging { get; set; }

        public Graad Graad { get; set; }
        public Thema Thema { get; set; }
        public int ThemaId { get; set; } // enkel voor mapping nodig
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

using System;
using System.Text.RegularExpressions;

namespace PROJ20_G20_DOTNET.Models.Domain {
    public class Oefening {
        #region Fields
        // fields voor makkelijk aanpassing setters
        private readonly int _maxLengteTitel = 30;
        private readonly int _maxLengteTekst = 1000;
        private readonly int _maxLengteUrl = 100;

        private string _titel;
        private string _urlVideo;
        private string _urlAfbeelding;
        private string _tekst;
        private Graad _graad;
        private Thema _thema;
        #endregion

        #region Properties
        public int Id { get; set; }

        public string Titel {
            get { return _titel; }
            set {
                if (value != null) {
                    string titel = value.Trim();
                    if(titel == "")
                    {
                        throw new ArgumentException("Titel mag niet leeg zijn");
                    }
                    if (titel.Length > _maxLengteTitel)
                    {
                        throw new ArgumentException($"Titel mag maximum {_maxLengteTitel.ToString()} karakters lang zijn.");
                    }
                    if(value.Contains(" "))
                    {
                        string tempTitel = titel.Replace(" ", "");
                        if(Regex.Match(tempTitel, ".*[\\d\\W].*").Success)
                        {
                            throw new ArgumentException("Titel mag enkel letters bevatten.");
                        }

                    }else
                    {
                        if (Regex.Match(titel, ".*[\\d\\W].*").Success)
                        {
                            throw new ArgumentException("Titel mag enkel letters bevatten.");
                        }
                    }
                    _titel = value;
                } else
                    throw new ArgumentException("Titel mag niet leeg zijn.");
            }
        }

        public string UrlVideo {
            get { return _urlVideo; }
            set {
                if (value != null) {
                    if(value.Trim() == "")
                    {
                        throw new ArgumentException("Video url mag niet leeg zijn.");
                    }
                    if (value.Trim().Length > _maxLengteUrl)
                        throw new ArgumentException($"Vido url mag maximum {_maxLengteUrl.ToString()} karakters lang zijn.");
                    _urlVideo = value;
                } else
                    throw new ArgumentException("Video url mag niet leeg zijn.");
            }
        }

        public string UrlAfbeelding {
            get { return _urlAfbeelding; }
            set {
                if (value != null) {
                    if(value.Trim() == "")
                    {
                        throw new ArgumentException("Afbeelding url mag niet leeg zijn");
                    }
                    if (value.Trim().Length > _maxLengteUrl)
                        throw new ArgumentException($"Afbeelding url mag maximum {_maxLengteUrl.ToString()} karakters lang zijn.");
                    _urlAfbeelding = value;
                } else
                    throw new ArgumentException("Afbeelding url mag niet leeg zijn.");
            }
        }

        public string Tekst {
            get { return _tekst; }
            set {
                if(value != null) {
                    if(value.Trim().Length > _maxLengteTekst)
                        throw new ArgumentException($"Beschrijving mag maximum {_maxLengteTekst.ToString()} karakters lang zijn.");
                    _tekst = value;
                } else
                    throw new ArgumentException("Beschrijving mag niet leeg zijn.");
            }
        }

        public int AantalRaadplegingen { get; set; }
        public DateTime LaatsteRaadpleging { get; set; }

        public Graad Graad {
            get { return _graad; }
            set {
                if (!value.Equals(null))
                    _graad = value;
                else
                    throw new ArgumentException("Graad mag niet leeg zijn");
            }
        }

        public Thema Thema {
            get { return _thema; }
            set {
                if (value != null)
                    _thema = value;
                else
                    throw new ArgumentException("Thema mag niet leeg zijn");
            }
        }
        public int ThemaId { get; set; } // enkel voor mapping nodig
        #endregion

        #region Constructors
        public Oefening() {

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

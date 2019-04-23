using System;
using System.Text.RegularExpressions;

namespace PROJ20_G20_DOTNET.Models.Domain {
    public class Thema {

        private string _naam;

        #region Properties
        public string Naam {
            get {
                return _naam;
            }

            set {
                if (value != null) {
                    string naam = value.Trim();
                    if (naam.Length > 20) // 
                    {
                        throw new ArgumentException("Naam mag max. 20 karakters bevatten");
                    }
                    if (naam.Contains(" ")) {
                        string tempnaam = naam.Replace(" ", "");
                        if (Regex.Match(tempnaam, ".*[\\d\\W].*").Success) {
                            throw new ArgumentException("Naam mag enkel letters bevatten.");
                        }

                    } else {
                        if (Regex.Match(value, ".*[\\d\\W].*").Success) {
                            throw new ArgumentException("Naam mag enkel letters bevatten.");
                        }
                    }
                    _naam = value;
                } else {
                    throw new ArgumentException("Naam mag niet leeg zijn.");
                }
            }
        }
        public int Id { get; set; }
        #endregion

        #region Properties
        protected Thema() { }

        public Thema(string naam) {
            Naam = naam;
        }

        #endregion
    }
}
using System;

namespace PROJ20_G20_DOTNET.Models.Domain {
    public class Inschrijving {

        private Lid _lid;
        private DateTime _tijdstip;

        #region Properties
        public Lid Lid {
            get {
                return _lid;
            }
            set {
                _lid = value ?? throw new ArgumentException("Lid mag niet leeg zijn.");
            }
        }

        public int LidId { get; set; } // voor mapping met juiste column name

        public Formule Formule { get; set; }
        public DateTime Tijdstip {
            get {
                return _tijdstip;
            }
            set {
                if (value == null) {
                    throw new ArgumentException("Tijdstip mag niet leeg zijn.");
                }
                _tijdstip = value;
            }
        }
        public int Id { get; set; }
        #endregion

        #region Constructors
        protected Inschrijving() {
        }

        public Inschrijving(Lid lid, Formule formule, DateTime tijdstip) {
            Lid = lid;
            Formule = formule;
            Tijdstip = tijdstip;
        }
        #endregion
    }
}
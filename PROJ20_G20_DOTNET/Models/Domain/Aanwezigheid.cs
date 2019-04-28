using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROJ20_G20_DOTNET.Models.Domain {
    public class Aanwezigheid {
        #region Fields
        private int _puntenAantal;
        private Lid _lid;
        private Activiteit _activiteit; 
        #endregion

        #region Properties
        public Lid Lid {
            get { return _lid; }
            set {
                _lid = value ?? throw new ArgumentException("Lid mag niet leeg zijn");
            }
        }
        public int LidId { get; set; }

        public Activiteit Activiteit {
            get { return _activiteit;  }
            set {
                _activiteit = value ?? throw new ArgumentException("Activiteit mag niet leeg zijn.");
            } }
        public int ActiviteitId { get; set; }

        public int Id { get; set; }
        public int PuntenAantal {
            get { return _puntenAantal; }
            //private set => BerekenPuntenAantal();
            set { _puntenAantal = value; }
        }
        #endregion

        #region Constructors
        public Aanwezigheid(Lid lid, Activiteit activiteit) {
            PuntenAantal = 0;
            // In afwachting van PuntenAantal = BerekenPuntenAantal();
            Lid = lid;
            Activiteit = activiteit;
        }

        protected Aanwezigheid() {
        }
        #endregion

        #region Methods
        private void BerekenPuntenAantal() {
            switch (Activiteit.Formule) {
                case Formule.DI_DO:
                case Formule.DI_ZA:
                case Formule.WO_ZA:
                    _puntenAantal = 5;
                    break;
                case Formule.WO:
                case Formule.ZA:
                    _puntenAantal = 10;
                    break;
                case Formule.UITSTAP:
                case Formule.ACTIVITEIT:
                    _puntenAantal = 75;
                    break;
                case Formule.STAGE:
                    _puntenAantal = 150;
                    break;
                default:
                    _puntenAantal = 0;
                    break;
            }
        }
        #endregion
    }
}

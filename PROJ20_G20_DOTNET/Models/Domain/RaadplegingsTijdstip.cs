using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Models.Domain {
    public class RaadplegingsTijdstip {
        #region Fields
        private DateTime _tijdstip;
        #endregion
        #region Properties
        public int Id { get; set; }
        public DateTime Tijdstip {
            get {
                return _tijdstip;
            }
            set {
                if (value != null) {
                    if (DateTime.Today.AddYears(-5).CompareTo(value) < 0) {
                        throw new ArgumentException("Lid moet minstens 5 jaar oud zijn.");
                    }
                    _tijdstip = value;
                }
            }
        }
        #endregion
        #region Constructors
        protected RaadplegingsTijdstip() {
        }

        public RaadplegingsTijdstip(DateTime tijdstip) {
            Tijdstip = tijdstip;
        }
        #endregion

    }
}

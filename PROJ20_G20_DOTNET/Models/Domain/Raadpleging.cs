using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ2_G20_.NET.Models.Domain {
    public class Raadpleging {
        #region Fields
        private readonly int _id;
        private readonly int _aantalRaadplegingen;
        #endregion

        #region Properties
        public Lid Lid { get; set; }
        public Oefening Oefening { get; set; }
        public IList<DateTime> Tijdstippen { get; set; }
        #endregion

        #region Constructors
        protected Raadpleging() {

        }

        public Raadpleging(Lid lid, Oefening oefening) {
            Lid = lid;
            Oefening = oefening;
            Tijdstippen = new List<DateTime>();
            _aantalRaadplegingen = 0;
        } 
        #endregion

    }
}

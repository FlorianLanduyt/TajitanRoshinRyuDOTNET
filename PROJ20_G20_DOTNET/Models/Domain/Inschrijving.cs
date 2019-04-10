using System;

namespace PROJ2_G20_.NET.Models.Domain {
    public class Inschrijving {

        #region Properties
        public Lid Lid { get; set; }
        public int LidId { get; set; } // voor mapping met juiste column name
        public Formule Formule { get; set; }
        public DateTime Tijdstip { get; set; }
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
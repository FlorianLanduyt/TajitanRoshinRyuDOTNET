using System;

namespace PROJ2_G20_.NET.Models.Domain {
    public class Aanwezigheid {

        #region Fields
        private int _puntenAantal;

        #endregion

        #region Properties
        public Lid Lid { get; set; }
        public Activiteit Activiteit { get; set; }
        public int Id { get; set; }
        #endregion

        #region Constructors
        public Aanwezigheid(Lid lid, Activiteit activiteit) {
            _puntenAantal = BerekenPuntenAantal();
            Lid = lid;
            Activiteit = activiteit;
        }

        protected Aanwezigheid() {

        }
        #endregion

        #region Methods
        private int BerekenPuntenAantal() {
            throw new NotImplementedException();
        } 
        #endregion
    }
}

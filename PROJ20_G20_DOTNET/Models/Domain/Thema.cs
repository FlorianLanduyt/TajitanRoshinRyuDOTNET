namespace PROJ2_G20_.NET.Models.Domain {
    public class Thema {
        #region Fields
        private readonly int _id;

        #endregion

        #region Properties
        public string Naam { get; set; }
        #endregion

        #region Properties
        public Thema(string naam) {
            Naam = naam;
        }

        protected Thema() {

        } 
        #endregion
    }
}
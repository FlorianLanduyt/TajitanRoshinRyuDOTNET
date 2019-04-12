namespace PROJ20_G20_DOTNET.Models.Domain {
    public class Thema {

        #region Properties
        public string Naam { get; set; }
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
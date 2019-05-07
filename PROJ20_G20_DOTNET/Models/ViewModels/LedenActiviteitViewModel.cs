using PROJ20_G20_DOTNET.Models.Domain;
using System.Collections.Generic;


namespace PROJ20_G20_DOTNET.Models.ViewModels {
    public class LedenActiviteitViewModel {
        public int Test { get; set; }
        public IEnumerable<Lid> Leden { get; set; }
        public Activiteit Activiteit { get; set;  }

        public LedenActiviteitViewModel(Activiteit activiteit, IEnumerable<Lid> leden) {
            Leden = leden;
            Activiteit = activiteit;
        }
    }
}

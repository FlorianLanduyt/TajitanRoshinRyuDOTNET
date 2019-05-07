using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Models.Domain
{
    public class RaadplegingsTijdstip
    {
        #region Properties
        public int Id { get; set; }
        public DateTime Tijdstip { get; set; }
        public int RaadplegingId { get; set; }
        #endregion
        #region Constructors
        protected RaadplegingsTijdstip()
        {
        }

        public RaadplegingsTijdstip(DateTime tijdstip)
        {
            Tijdstip = tijdstip;
        }
        #endregion

    }
}

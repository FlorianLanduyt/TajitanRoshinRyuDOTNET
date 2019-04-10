using PROJ2_G20_.NET.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Models.Domain {
    public class ActiviteitInschrijving {

        public Activiteit Activiteit { get; set; }
        public int ActiviteitId { get; set; }

        public Inschrijving Inschrijving { get; set; }
        public int InschrijvingId { get; set; }

    }
}

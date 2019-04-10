using PROJ2_G20_.NET.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Models.Domain {
    [Table("ACTIVITEIT_INSCHRIJVING")]
    public class ActiviteitInschrijving {
        // Zoals in Java DB
        public Activiteit Activiteit { get; set; }
        [Column("Activiteit_ID")]
        public int ActiviteitId { get; set; }

        public Inschrijving Inschrijving { get; set; }
        [Column("inschrijvingen_ID")] 
        public int InschrijvingId { get; set; }

    }
}

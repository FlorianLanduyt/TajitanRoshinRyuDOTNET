using PROJ20_G20_DOTNET.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Models.ViewModels {
    public class AddGastOfProeflidViewModel {

        [Required(ErrorMessage = "Familienaam is verplicht")]
        [Display(Name = "Familienaam *")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Familienaam mag max. 50 karakters bevatten")]
        public string Achternaam { get; set; }

        [Required(ErrorMessage = "Voornaam is verplicht")]
        [Display(Name = "Voornaam *")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Voornaam mag max. 50 karakters bevatten")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "E-mailadres is verplicht")]
        [Display(Name = "E-mailadres *")]
        [DataType(DataType.Text)]
        public string Email { get; set; }

        [Required(ErrorMessage = "GSM-nr is verplicht")]
        [Display(Name = "GSM-nr *")]
        [DataType(DataType.Text)]
        [StringLength(12, ErrorMessage = "GSM-nr mag max. 12 cijfers bevatten")]
        public string Gsm { get; set; }
    }
}

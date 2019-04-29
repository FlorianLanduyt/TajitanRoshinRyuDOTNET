using PROJ20_G20_DOTNET.Models.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace PROJ20_G20_DOTNET.Models.ViewModels
{
    public class LidEditViewModel
    {
        [Required(ErrorMessage = "Voornaam is verplicht")]
        [Display(Name = "Voornaam*")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Voornaam mag max. 50 karakters bevatten")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Familienaam is verplicht")]
        [Display(Name = "Familienaam*")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Familienaam mag max. 50 karakters bevatten")]
        public string Achternaam { get; set; }

        [Required(ErrorMessage = "Rijksregisternummer is verplicht")]
        [Display(Name = "Rijksregisternummer*")]
        [DataType(DataType.Text)]
        [StringLength(15, ErrorMessage = "Rijksregisternummer mag max. 15 cijfers/karakters bevatten")]
        public string RijksregisterNummer { get; set; }

        [Required(ErrorMessage = "Nationaliteit is verplicht")]
        [Display(Name = "Nationaliteit*")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Nationaliteit mag max. 50 karakters bevatten")]
        public string Nationaliteit { get; set; }

        [Display(Name = "Datum eerste training")]
        [DataType(DataType.Date)]
        public DateTime DatumEersteTraining { get; set; }

        [Required(ErrorMessage = "Geboortedatum is verplicht")]
        [Display(Name = "Geboortedatum*")]
        [DataType(DataType.Date)]
        public DateTime GeboorteDatum { get; set; }

        [Required(ErrorMessage = "GSM-nr is verplicht")]
        [Display(Name = "GSM-nr*")]
        [DataType(DataType.Text)]
        [StringLength(12, ErrorMessage = "GSM-nr mag max. 12 cijfers bevatten")]
        public string GsmNr { get; set; }

        [Display(Name = "TEL-nr")]
        [DataType(DataType.Text)]
        [StringLength(10, ErrorMessage = "TEL-nr mag max. 10 cijfers bevatten")]
        public string VasteTelefoonNr { get; set; }

        [Required(ErrorMessage = "Stad is verplicht")]
        [Display(Name = "Stad*")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Stad mag max. 50 karakters bevatten")]
        public string Stad { get; set; }

        [Required(ErrorMessage = "Straat is verplicht")]
        [Display(Name = "Straat*")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Straat mag max. 50 karakters bevatten")]
        public string Straat { get; set; }

        [Required(ErrorMessage = "Huisnummer is verplicht")]
        [Display(Name = "Huisnummer*")]
        [DataType(DataType.Text)]
        [StringLength(5, ErrorMessage = "Huisnummer mag max. 5 cijfers bevatten")]
        public string HuisNr { get; set; }

        [Display(Name = "Bus")]
        [DataType(DataType.Text)]
        [StringLength(5, ErrorMessage = "Bus mag max. 5 cijfers/karakters bevatten")]
        public string Bus { get; set; }

        [Required(ErrorMessage = "Postcode is verplicht")]
        [Display(Name = "Postcode*")]
        [DataType(DataType.Text)]
        [StringLength(4, ErrorMessage = "Postcode moet 4 cijfers bevatten")]
        public string PostCode { get; set; }

        [Required(ErrorMessage = "E-mailadres is verplicht")]
        [Display(Name = "E-mailadres*")]
        [DataType(DataType.Text)]
        public string Email { get; set; }

        [Display(Name = "E-mailadres vader")]
        [DataType(DataType.Text)]
        public string EmailVader { get; set; }

        [Display(Name = "E-mailadres moeder")]
        [DataType(DataType.Text)]
        public string EmailMoeder { get; set; }

        [Required(ErrorMessage = "Geboorteplaats is verplicht")]
        [Display(Name = "Geboorteplaats*")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Geboorteplaats mag max. 50 karakters bevatten")]
        public string GeboortePlaats { get; set; }

        [Required(ErrorMessage = "Geslacht is verplicht")]
        [Display(Name = "Geslacht*")]
        [DataType(DataType.Text)]
        public string Geslacht { get; set; }

        [Display(Name = "Beroep")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Beroep mag max. 50 karakters bevatten")]
        public string Beroep { get; set; }

        public LidEditViewModel()
        {

        }

        public LidEditViewModel(Lid lid)
        {
            Voornaam = lid.Voornaam;
            Achternaam = lid.Achternaam;
            RijksregisterNummer = lid.RijksregisterNummer;
            Nationaliteit = lid.Nationaliteit;
            DatumEersteTraining = lid.DatumEersteTraining;
            GeboorteDatum = lid.GeboorteDatum;
            GsmNr = lid.GsmNr;
            VasteTelefoonNr = lid.VasteTelefoonNr;
            Stad = lid.Stad;
            Straat = lid.Straat;
            HuisNr = lid.HuisNr;
            Bus = lid.Bus;
            PostCode = lid.PostCode;
            Email = lid.Email;
            EmailVader = lid.EmailVader;
            EmailMoeder = lid.EmailMoeder;
            GeboortePlaats = lid.GeboortePlaats;
            Geslacht = lid.Geslacht;
            Beroep = lid.Beroep;
        }
    }
}

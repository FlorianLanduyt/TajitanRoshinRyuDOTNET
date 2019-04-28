namespace PROJ20_G20_DOTNET.Models.Domain
{
    public class ActiviteitInschrijving
    {

        public Activiteit Activiteit { get; set; }
        public int ActiviteitId { get; set; }

        public Inschrijving Inschrijving { get; set; }
        public int InschrijvingId { get; set; }

        public bool IsAanwezig { get; set; }

        public ActiviteitInschrijving()
        {

        }

        public ActiviteitInschrijving(Activiteit activiteit, Inschrijving inschrijving)
        {
            Activiteit = activiteit;
            Inschrijving = inschrijving;
            ActiviteitId = activiteit.Id;
            InschrijvingId = inschrijving.Id;
            IsAanwezig = false;
        }
    }
}

using PROJ20_G20_DOTNET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PROJ20_G20_DOTNET.Tests
{
    public class DummyJiuJitsuDbContext
    {
        public Lid Rob { get; }
        public Lid Tim { get; }
        public Lid Tybo { get; }
        public Activiteit Act1 { get; }
        public Activiteit Act2 { get; }
        public Inschrijving Inschrijving1 { get; }
        public Inschrijving Inschrijving2 { get; }
        public Inschrijving Inschrijving3 { get; }

        public IEnumerable<Lid> Leden { get; }
        public IEnumerable<Activiteit> Activiteiten { get; }
        public IEnumerable<Inschrijving> Inschrijvingen { get; }



        public DummyJiuJitsuDbContext()
        {
            int lidId = 1;
            int activiteitId = 1;

            #region Leden
            Rob = new Lid("Rob", "De Putter", new DateTime(1999, 5, 11), "99.05.11-313.16",
                    "0476456851", "053833670", "Kerksken", "Boekentstraat", "115", "9451", "robdeputter@hotmail.com",
                    "P@ssword1", "Aalst", "Man", "Belg", Graad.KYU6, Functie.BEHEERDER)
            { Id = lidId++ };
            Tim = new Lid("Tim", "Geldof", new DateTime(1997, 07, 17),
                   "97.07.17-001.23",
                   "0479330959", "051303050", "Izegem", "Winkelhoekstraat",
                   "52", "8870", "tim.geldof@outlook.com",
                   "P@ssword1", "Izegem", "Man",
                   "Belg", Graad.DAN5, Functie.BEHEERDER)
            { Id = lidId++ };

            Tybo = new Lid("Tybo", "Vanderstraeten", new DateTime(1999, 12, 8),
               "99.12.08-173.04", "0477441465", "051303054", "Gent", "Korenmarkt", "21", "9000", "tybo.vanderstraeten@outlook.com",
               "P@ssword1", "Gent", "Man", "Belg", Graad.DAN3, Functie.LID)
            { Id = lidId++ };

            Leden = new[] { Rob, Tim, Tybo };

            #endregion

            #region Activiteiten
             Act1 = new Activiteit("Testactiviteit een", Formule.EXAMEN, new DateTime(2020, 8, 12), new DateTime(2020, 8, 13),
                        new DateTime(2020, 7, 15), "0477441462", "act@act.act", "Rokerspaviljoen", "Korenmarkt", "Gent", "9000",
                        "20", "5", 50)
            { Id = activiteitId++ };
             Act2 = new Activiteit("Testactiviteit twee", Formule.UITSTAP, new DateTime(2020, 9, 12), new DateTime(2020, 9, 13),
               new DateTime(2020, 8, 15), "0477441462", "act@act.act", "Rokerspaviljoen", "Korenmarkt", "Gent", "9000",
               "20", "5", 50)
            { Id = activiteitId++ };

            Activiteiten = new[] { Act1, Act2 };
            #endregion

            #region Inschrijvingen
            Inschrijving1 = new Inschrijving(Rob, Act1.Formule, DateTime.Now);
            Inschrijving2 = new Inschrijving(Tim, Act2.Formule, DateTime.Now);
            Inschrijving3 = new Inschrijving(Tim, Act1.Formule, DateTime.Now);

            Inschrijvingen = new[] { Inschrijving1, Inschrijving2, Inschrijving3 };
            #endregion

            Act1.AddInschrijving(Inschrijving1);
            Act2.AddInschrijving(Inschrijving2);
            Act1.AddInschrijving(Inschrijving3);

        }

    }
}

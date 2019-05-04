using Microsoft.AspNetCore.Identity;
using PROJ20_G20_DOTNET.Models.Domain;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Data
{
    public class DbInitializer
    {

        private JiuJitsuDbContext _dbContext;
        private UserManager<IdentityUser> _userManager;

        public DbInitializer(JiuJitsuDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }


        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated()) {
                #region Leden
                Lid lid1 = new Lid("Tim", "Geldof", new DateTime(1997, 07, 17),
        "97.07.17-001.23",
        "0479330959", "051303050", "Izegem", "Winkelhoekstraat",
        "52", "8870", "tim.geldof@outlook.com",
        "P@ssword1", "Izegem", "Man",
        "Belg", Graad.DAN5, Functie.BEHEERDER);

                Lid lid2 = new Lid("Tybo", "Vanderstraeten", new DateTime(1999, 12, 8),
                    "99.12.08-173.04", "0477441465", "051303054", "Gent", "Korenmarkt", "21", "9000", "tybo.vanderstraeten@outlook.com",
                    "P@ssword1", "Gent", "Man", "Belg", Graad.DAN3, Functie.LID);

                Lid lid3 = new Lid("Paul", "Pieters", new DateTime(1990, 05, 3),
                    "90.05.03-001.88", "0477441465", "051303054", "Gent", "Korenmarkt", "21", "9000", "paul.pieters@outlook.com",
                    "P@ssword1", "Gent", "Man", "Belg", Graad.DAN3, Functie.LID);

                Lid lid4 = new Lid("Sarah", "De Bakker", new DateTime(1990, 04, 4),
                    "90.04.04-002.50", "0477441465", "051303054", "Gent", "Korenmarkt", "21", "9000", "sarah.pieters@outlook.com",
                    "P@ssword1", "Gent", "Vrouw", "Belg", Graad.DAN2, Functie.LID);

                Lid lid5 = new Lid("Thomas", "De Slager", new DateTime(1999, 06, 3),
                    "99.06.03-001.90", "0477441465", "051303054", "Gent", "Korenmarkt", "21", "9000", "thomas.pieters@outlook.com",
                    "P@ssword1", "Gent", "Man", "Belg", Graad.DAN4, Functie.LID);

                Lid lid6 = new Lid("Jasper", "Vandamme", new DateTime(1997, 06, 6),
                    "97.06.06-001.55", "0477441465", "051303054", "Gent", "Korenmarkt", "21", "9000", "jasper.pieters@outlook.com",
                    "P@ssword1", "Gent", "Man", "Belg", Graad.DAN2, Functie.LID);

                Lid lid7 = new Lid("Lisa", "Simpson", new DateTime(1994, 08, 8),
                    "94.08.08-002.42", "0477441465", "051303054", "Gent", "Korenmarkt", "21", "9000", "lisa.pieters@outlook.com",
                    "P@ssword1", "Gent", "Vrouw", "Belg", Graad.KYU3, Functie.LID);

                Lid lid8 = new Lid("Jonas", "Vangogh", new DateTime(1993, 02, 2),
                    "93.02.02-001.63", "0477441465", "051303054", "Gent", "Korenmarkt", "21", "9000", "jonas.pieters@outlook.com",
                    "P@ssword1", "Gent", "Man", "Belg", Graad.DAN3, Functie.LID);

                Lid lid9 = new Lid("Siska", "Schoeters", new DateTime(1998, 05, 2),
                    "98.05.02-002.91", "0477441465", "051303054", "Gent", "Korenmarkt", "21", "9000", "siska.pieters@outlook.com",
                    "P@ssword1", "Gent", "Vrouw", "Belg", Graad.KYU1, Functie.LID);





                _dbContext.Leden.Add(lid1);
                _dbContext.Leden.Add(lid2);
                _dbContext.Leden.Add(lid3);
                _dbContext.Leden.Add(lid4);
                _dbContext.Leden.Add(lid5);
                _dbContext.Leden.Add(lid6);
                _dbContext.Leden.Add(lid7);
                _dbContext.Leden.Add(lid8);
                _dbContext.Leden.Add(lid9);

                await CreateUser(lid1);
                await CreateUser(lid2);
                await CreateUser(lid3);
                await CreateUser(lid4);
                await CreateUser(lid5);
                await CreateUser(lid6);
                await CreateUser(lid7);
                await CreateUser(lid8);
                await CreateUser(lid9);

                #endregion

                #region Activiteiten
                Activiteit act1 = new Activiteit("Eindexamen", Formule.EXAMEN, new DateTime(2020, 8, 12), new DateTime(2020, 8, 13),
                    new DateTime(2020, 7, 15), "0477441462", "act@act.act", "Rokerspaviljoen", "Korenmarkt", "Gent", "9000",
                    "20", "5", 50);
                Activiteit act2 = new Activiteit("Bobejaanland", Formule.UITSTAP, new DateTime(2020, 9, 12), new DateTime(2020, 9, 12),
                   new DateTime(2020, 8, 15), "0477441462", "act@act.act", "Rokerspaviljoen", "Korenmarkt", "Gent", "9000",
                   "20", "5", 50);

                Activiteit act3 = new Activiteit("Stage Polen", Formule.STAGE, new DateTime(2020, 10, 09), new DateTime(2020, 10, 17),
                   new DateTime(2020, 9, 01), "0477441462", "act@act.act", "Rokerspaviljoen", "Korenmarkt", "Gent", "9000",
                   "20", "5", 50);

                Activiteit act4 = new Activiteit("Dinsdag Training", Formule.DI_DO, new DateTime(2019, 07, 09), new DateTime(2019, 07, 09),
                   new DateTime(2019, 07, 01), "0477441462", "act@act.act", "Rokerspaviljoen", "Korenmarkt", "Gent", "9000",
                   "20", "5", 50);

                Activiteit act5 = new Activiteit("Teambuilding Ardennen", Formule.UITSTAP, new DateTime(2019, 10, 09), new DateTime(2019, 10, 11),
                   new DateTime(2019, 09, 01), "0477441462", "act@act.act", "Rokerspaviljoen", "Korenmarkt", "Gent", "9000",
                   "20", "5", 50);

                _dbContext.Activiteiten.Add(act1);
                _dbContext.Activiteiten.Add(act2);
                _dbContext.Activiteiten.Add(act3);
                _dbContext.Activiteiten.Add(act4);
                _dbContext.Activiteiten.Add(act5);

                #endregion

                #region Inschrijvingen

                #region Activiteit 1
                Inschrijving inschrijving1 = new Inschrijving(lid2, act1.Formule, DateTime.Now);
                Inschrijving inschrijving3 = new Inschrijving(lid1, act1.Formule, DateTime.Now);
                Inschrijving inschrijving4 = new Inschrijving(lid3, act1.Formule, DateTime.Now);
                Inschrijving inschrijving13 = new Inschrijving(lid4, act1.Formule, DateTime.Now);
                Inschrijving inschrijving14 = new Inschrijving(lid5, act1.Formule, DateTime.Now);
                Inschrijving inschrijving15 = new Inschrijving(lid6, act1.Formule, DateTime.Now);
                Inschrijving inschrijving16 = new Inschrijving(lid7, act1.Formule, DateTime.Now);
                Inschrijving inschrijving17 = new Inschrijving(lid8, act1.Formule, DateTime.Now);
                Inschrijving inschrijving18 = new Inschrijving(lid9, act1.Formule, DateTime.Now);
                #endregion

                #region Activiteit 2
                Inschrijving inschrijving2 = new Inschrijving(lid2, act2.Formule, DateTime.Now);
                Inschrijving inschrijving5 = new Inschrijving(lid3, act2.Formule, DateTime.Now);
                Inschrijving inschrijving19 = new Inschrijving(lid5, act2.Formule, DateTime.Now);
                Inschrijving inschrijving20 = new Inschrijving(lid8, act2.Formule, DateTime.Now);
                Inschrijving inschrijving21 = new Inschrijving(lid9, act2.Formule, DateTime.Now);

                #endregion

                #region Activiteit 3
                Inschrijving inschrijving6 = new Inschrijving(lid1, act3.Formule, DateTime.Now);
                Inschrijving inschrijving7 = new Inschrijving(lid2, act3.Formule, DateTime.Now);
                #endregion

                #region Activiteit 4
                Inschrijving inschrijving8 = new Inschrijving(lid1, act4.Formule, DateTime.Now);
                Inschrijving inschrijving9 = new Inschrijving(lid3, act4.Formule, DateTime.Now);
                Inschrijving inschrijving22 = new Inschrijving(lid4, act4.Formule, DateTime.Now);
                Inschrijving inschrijving23 = new Inschrijving(lid5, act4.Formule, DateTime.Now);

                #endregion

                #region Activiteit 5
                Inschrijving inschrijving10 = new Inschrijving(lid3, act5.Formule, DateTime.Now);
                Inschrijving inschrijving11 = new Inschrijving(lid1, act5.Formule, DateTime.Now);
                Inschrijving inschrijving12 = new Inschrijving(lid2, act5.Formule, DateTime.Now);
                Inschrijving inschrijving24 = new Inschrijving(lid6, act5.Formule, DateTime.Now);
                Inschrijving inschrijving25 = new Inschrijving(lid7, act5.Formule, DateTime.Now);
                Inschrijving inschrijving26 = new Inschrijving(lid4, act5.Formule, DateTime.Now);

                #endregion




                _dbContext.Inschrijvingen.Add(inschrijving1);
                _dbContext.Inschrijvingen.Add(inschrijving2);
                _dbContext.Inschrijvingen.Add(inschrijving3);
                _dbContext.Inschrijvingen.Add(inschrijving4);
                _dbContext.Inschrijvingen.Add(inschrijving5);
                _dbContext.Inschrijvingen.Add(inschrijving6);
                _dbContext.Inschrijvingen.Add(inschrijving7);
                _dbContext.Inschrijvingen.Add(inschrijving8);
                _dbContext.Inschrijvingen.Add(inschrijving9);
                _dbContext.Inschrijvingen.Add(inschrijving10);
                _dbContext.Inschrijvingen.Add(inschrijving11);
                _dbContext.Inschrijvingen.Add(inschrijving12);

                act1.AddInschrijving(inschrijving1);
                act1.AddInschrijving(inschrijving3);
                act1.AddInschrijving(inschrijving4);
                act1.AddInschrijving(inschrijving13);
                act1.AddInschrijving(inschrijving14);
                act1.AddInschrijving(inschrijving15);
                act1.AddInschrijving(inschrijving16);
                act1.AddInschrijving(inschrijving17);
                act1.AddInschrijving(inschrijving18);

                act2.AddInschrijving(inschrijving2);
                act2.AddInschrijving(inschrijving5);
                act2.AddInschrijving(inschrijving19);
                act2.AddInschrijving(inschrijving20);
                act2.AddInschrijving(inschrijving21);

                act3.AddInschrijving(inschrijving6);
                act3.AddInschrijving(inschrijving7);

                act4.AddInschrijving(inschrijving8);
                act4.AddInschrijving(inschrijving9);
                act4.AddInschrijving(inschrijving22);
                act4.AddInschrijving(inschrijving23);

                act5.AddInschrijving(inschrijving10);
                act5.AddInschrijving(inschrijving11);
                act5.AddInschrijving(inschrijving12);
                act5.AddInschrijving(inschrijving24);
                act5.AddInschrijving(inschrijving25);
                act5.AddInschrijving(inschrijving26);
                #endregion

                #region Oefeningen
                Oefening oefening1 = new Oefening("Salto", "https://www.youtube.com/embed/dQw4w9WgXcQ", "Test tekst", DateTime.Now, Graad.KYU1, new Thema("Testthema"));
                Oefening oefening2 = new Oefening("Blokken", "https://www.youtube.com/embed/dQw4w9WgXcQ", "Test tekst", DateTime.Now, Graad.DAN5, new Thema("Testthema"));
                Oefening oefening3 = new Oefening("Vallen", "https://www.youtube.com/embed/dQw4w9WgXcQ", "Test tekst", DateTime.Now, Graad.DAN4, new Thema("Testthema"));
                Oefening oefening4 = new Oefening("Aanvallen", "https://www.youtube.com/embed/dQw4w9WgXcQ", "Test tekst", DateTime.Now, Graad.DAN1, new Thema("Testthema"));
                Oefening oefening5 = new Oefening("Verdedigen", "https://www.youtube.com/embed/dQw4w9WgXcQ", "Test tekst", DateTime.Now, Graad.DAN2, new Thema("Testthema"));
                Oefening oefening6 = new Oefening("Passieve agressieve aanval", "https://www.youtube.com/embed/dQw4w9WgXcQ", "Test tekst", DateTime.Now, Graad.DAN2, new Thema("Testthema"));
                Oefening oefening7 = new Oefening("noscopethreesixty", "https://www.youtube.com/embed/dQw4w9WgXcQ", "Test tekst", DateTime.Now, Graad.DAN2, new Thema("Testthema"));


                _dbContext.Oefeningen.Add(oefening1);
                _dbContext.Oefeningen.Add(oefening2);
                _dbContext.Oefeningen.Add(oefening3);
                _dbContext.Oefeningen.Add(oefening4);
                _dbContext.Oefeningen.Add(oefening5);
                _dbContext.Oefeningen.Add(oefening6);
                _dbContext.Oefeningen.Add(oefening7);
                #endregion

                _dbContext.SaveChanges();

            }
        }

        private async Task CreateUser(Lid lid)
        {
            IdentityUser user = new IdentityUser() {
                UserName = lid.Email,
                Email = lid.Email,
            };

            await _userManager.CreateAsync(user, lid.Wachtwoord);
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, lid.Functie.ToString().ToLower()));
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "viewPersonalDetails"));

            if (lid.Functie.Equals(Functie.BEHEERDER) || lid.Functie.Equals(Functie.TRAINER)) {
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "viewAttendings"));
            }

            _dbContext.SaveChanges();
        }
    }
}


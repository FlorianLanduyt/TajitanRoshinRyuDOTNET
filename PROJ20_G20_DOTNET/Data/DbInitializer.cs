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

                _dbContext.Leden.Add(lid1);
                _dbContext.Leden.Add(lid2);

                await CreateUser(lid1);
                await CreateUser(lid2);
                #endregion

                #region Activiteiten
                Activiteit act1 = new Activiteit("Testactiviteit een", Formule.EXAMEN, new DateTime(2020, 8, 12), new DateTime(2020, 8, 13),
                    new DateTime(2020, 7, 15), "0477441462", "act@act.act", "Rokerspaviljoen", "Korenmarkt", "Gent", "9000",
                    "20", "5", 50);
                Activiteit act2 = new Activiteit("Testactiviteit twee", Formule.UITSTAP, new DateTime(2020, 9, 12), new DateTime(2020, 9, 13),
                   new DateTime(2020, 8, 15), "0477441462", "act@act.act", "Rokerspaviljoen", "Korenmarkt", "Gent", "9000",
                   "20", "5", 50);

                _dbContext.Activiteiten.Add(act1);
                _dbContext.Activiteiten.Add(act2);
                #endregion

                #region Inschrijvingen
                Inschrijving inschrijving1 = new Inschrijving(lid2, act1.Formule, DateTime.Now);
                Inschrijving inschrijving2 = new Inschrijving(lid2, act2.Formule, DateTime.Now);
                Inschrijving inschrijving3 = new Inschrijving(lid1, act1.Formule, DateTime.Now);

                _dbContext.Inschrijvingen.Add(inschrijving1);
                _dbContext.Inschrijvingen.Add(inschrijving2);
                _dbContext.Inschrijvingen.Add(inschrijving3);
                act1.AddInschrijving(inschrijving1);
                act2.AddInschrijving(inschrijving2);
                act1.AddInschrijving(inschrijving3);
                #endregion

                #region Oefeningen
                Oefening oefening1 = new Oefening("Testoefening", "www.youtube.com/test", "Test tekst", DateTime.Now, Graad.KYU1, new Thema("Testthema"));
                _dbContext.Oefeningen.Add(oefening1);
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


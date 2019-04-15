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
                Lid lid1 = new Lid("Tim", "Geldof", DateTime.Now.Subtract(new TimeSpan(16500, 0, 0, 0, 0)),
                "97.07.17-001.23",
                "0479330959", "051303050", "Izegem", "Winkelhoekstraat",
                "52", "8870", "tim.geldof@outlook.com",
                "P@ssword1", "Izegem", "Man",
                "Belg", Graad.DAN5, Functie.BEHEERDER);

                Lid lid2 = new Lid("Tybo", "Vanderstraeten", DateTime.Now.Subtract(new TimeSpan(16500, 0, 0, 0, 0)),
                    "99.12.08-173.04", "0477441465", "051303054", "Gent", "Korenmarkt", "21", "9000", "tybo.vanderstraeten@outlook.com",
                    "P@ssword1", "Gent", "Man", "Belg", Graad.DAN3, Functie.LID);

                _dbContext.Leden.Add(lid1);
                _dbContext.Leden.Add(lid2);

                await CreateUser(lid1);
                await CreateUser(lid2);

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
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "lid"));

            _dbContext.SaveChanges();
        }
    }
}


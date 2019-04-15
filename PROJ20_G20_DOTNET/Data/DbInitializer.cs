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
                Lid lid = new Lid("Tim", "Geldof", DateTime.Now.Subtract(new TimeSpan(16500, 0, 0, 0, 0)),
                "97.07.17-001.23",
                "0479330959", "051303050", "Izegem", "Winkelhoekstraat",
                "52", "8870", "tim.geldof@outlook.com",
                "Wachtwoord", "Izegem", "Man",
                "Belg", Graad.DAN5, Functie.BEHEERDER);

                _dbContext.Leden.Add(lid);
                _dbContext.SaveChanges();

                //IdentityUser user = new IdentityUser() {
                //    UserName = lid.Email,
                //    Email = lid.Email,
                //    //SecurityStamp = Guid.NewGuid().ToString(),
                //    //Id = lid.Id.ToString()
                //};
                //await _userManager.CreateAsync(user, lid.Wachtwoord);
                //await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "lid"));
            }
        }
    }
}

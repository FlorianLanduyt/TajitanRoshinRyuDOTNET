using PROJ2_G20_.NET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Data {
    public class DbInitializer {

        private JiuJitsuDbContext _dbContext;

        public DbInitializer(JiuJitsuDbContext dbContext) {
            _dbContext = dbContext;
        }


        public void InitializeData() {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated()) {
                _dbContext.Leden.Add(new Lid("Tim", "Geldof", DateTime.Now.Subtract(new TimeSpan(16500, 0, 0, 0, 0)),
                "97.07.17-001.23",
                "0479330959", "051303050", "Izegem", "Winkelhoekstraat",
                "52", "8870", "tim.geldof@outlook.com",
                "Wachtwoord", "Izegem", "Man",
                "Belg", Graad.DAN5, Functie.BEHEERDER));
                _dbContext.SaveChanges();
            }
            /*
             
            new Lid("Tim", "Geldof", DateTime.Now.Subtract(new TimeSpan(16500, 0, 0, 0, 0)),
                "97.07.17-001.23",
                "0479330959", "051303050", "Izegem", "Winkelhoekstraat",
                "52", "8870", "tim.geldof@outlook.com",
                "Wachtwoord", "Izegem", "Man",
                "Belg", Graad.DAN5, Functie.BEHEERDER)

             */
        }
    }
}

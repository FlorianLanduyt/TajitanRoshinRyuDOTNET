using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Models.Domain {
    public interface IRaadplegingRepository {
        void Add(Raadpleging r);
        //IEnumerable<Raadpleging> GetAll();
        void SaveChanges();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Models.Domain
{
    public interface IRaadplegingRepository
    {
        IEnumerable<Raadpleging> GetAll();
        Raadpleging GetById(int id);
        void Add(Raadpleging raadpleging);
        void SaveChanges();
    }
}

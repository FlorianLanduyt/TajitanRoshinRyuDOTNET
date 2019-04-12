using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Models.Domain
{
    public interface IAanwezigheidRepository
    {
        IEnumerable<Aanwezigheid> GetAll();
        Aanwezigheid GetBy(int id);
        void Add(Aanwezigheid aanwezigheid);
        void Delete(Aanwezigheid aanwezigheid);
        void SaveChanges();
    }
}

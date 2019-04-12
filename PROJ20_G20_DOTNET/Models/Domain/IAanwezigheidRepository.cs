using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ2_G20_.NET.Models.Domain
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

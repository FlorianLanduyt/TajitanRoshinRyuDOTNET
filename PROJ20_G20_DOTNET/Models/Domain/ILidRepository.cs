using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Models.Domain
{
    public interface ILidRepository
    {
        IEnumerable<Lid> GetAll();
        Lid GetBy(int id);
        void Add(Lid lid);
        void Delete(Lid lid);
        void SaveChanges();
    }
}

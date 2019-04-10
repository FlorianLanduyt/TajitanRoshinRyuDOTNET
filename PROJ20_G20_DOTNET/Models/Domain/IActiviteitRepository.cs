using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ2_G20_.NET.Models.Domain {
    public interface IActiviteitRepository {
        IEnumerable<Activiteit> GetAll();
        Activiteit GetBy(int id);
        void Add(Activiteit activiteit);
        void Delete(Activiteit activiteit);
        void SaveChanges();
    }
}

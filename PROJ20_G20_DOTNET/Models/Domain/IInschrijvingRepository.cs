using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ2_G20_.NET.Models.Domain {
    public interface IInschrijvingRepository {
        IEnumerable<Inschrijving> GetAll();
        Inschrijving GetBy(int id);
        void Add(Inschrijving inschrijving);
        void Delete(Inschrijving inschrijving);
        void SaveChanges();
    }
}

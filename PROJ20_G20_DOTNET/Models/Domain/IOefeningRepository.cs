using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Models.Domain
{
    public interface IOefeningRepository
    {
        IEnumerable<Oefening> GetAll();
        IEnumerable<Oefening> GetAllByGraad(Graad graad);
        Oefening GetById(int id);
    }
}

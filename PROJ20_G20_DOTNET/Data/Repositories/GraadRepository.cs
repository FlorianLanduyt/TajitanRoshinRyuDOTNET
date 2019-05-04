using PROJ20_G20_DOTNET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Data.Repositories
{
    public class GraadRepository : IGraadRepository
    {
        public IEnumerable<Graad> GetAll()
        {
            return Enum.GetValues(typeof(Graad)).Cast<Graad>();
        }
    }
}

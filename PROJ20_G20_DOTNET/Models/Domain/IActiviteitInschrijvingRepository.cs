using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Models.Domain
{
    public interface IActiviteitInschrijvingRepository
    {
        IEnumerable<ActiviteitInschrijving> GetAll();
        ActiviteitInschrijving GetBy(int activiteitId,int inschrijvingId);
        void Add(ActiviteitInschrijving ai);
        void SaveChanges();
    }
}

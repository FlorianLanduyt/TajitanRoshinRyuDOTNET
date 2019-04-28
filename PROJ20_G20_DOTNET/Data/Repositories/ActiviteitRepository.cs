using Microsoft.EntityFrameworkCore;
using PROJ20_G20_DOTNET.Data;
using PROJ20_G20_DOTNET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Data.Repositories
{
    public class ActiviteitRepository : IActiviteitRepository
    {
        private readonly JiuJitsuDbContext _context;
        private readonly DbSet<Activiteit> _activiteiten;

        public ActiviteitRepository(JiuJitsuDbContext context)
        {
            _context = context;
            _activiteiten = context.Activiteiten;
        }

        public void Add(Activiteit activiteit)
        {
            _activiteiten.Add(activiteit);
        }

        public void Delete(Activiteit activiteit)
        {
            _activiteiten.Remove(activiteit);
        }

        public IEnumerable<Activiteit> GetAll()
        {
            return _activiteiten
                .Include(a => a.Inschrijvingen)
                .ToList();
        }

        public Activiteit GetBy(int id)
        {
            return _activiteiten
                .Include(a => a.Inschrijvingen)
                .SingleOrDefault(a => a.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

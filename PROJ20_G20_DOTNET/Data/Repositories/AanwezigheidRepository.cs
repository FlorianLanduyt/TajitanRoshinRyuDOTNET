using Microsoft.EntityFrameworkCore;
using PROJ20_G20_DOTNET.Data;
using PROJ20_G20_DOTNET.Models.Domain;
using System.Collections.Generic;
using System.Linq;

namespace PROJ20_G20_DOTNET.Data.Repositories
{
    public class AanwezigheidRepository : IAanwezigheidRepository
    {

        private readonly JiuJitsuDbContext _context;
        private readonly DbSet<Aanwezigheid> _aanwezigheden;

        public AanwezigheidRepository(JiuJitsuDbContext context)
        {
            _context = context;
            _aanwezigheden = context.Aanwezigheden;
        }

        public void Add(Aanwezigheid aanwezigheid)
        {
            _aanwezigheden.Add(aanwezigheid);
        }

        public void Delete(Aanwezigheid aanwezigheid)
        {
            _aanwezigheden.Remove(aanwezigheid);
        }

        public IEnumerable<Aanwezigheid> GetAll()
        {
            return _aanwezigheden.ToList();
        }

        public Aanwezigheid GetBy(int id)
        {
            return _aanwezigheden.SingleOrDefault(a => a.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

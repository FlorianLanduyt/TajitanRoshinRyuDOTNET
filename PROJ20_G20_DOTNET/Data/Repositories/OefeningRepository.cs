using Microsoft.EntityFrameworkCore;
using PROJ20_G20_DOTNET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Data.Repositories
{
    public class OefeningRepository : IOefeningRepository
    {
        private readonly JiuJitsuDbContext _context;
        private readonly DbSet<Oefening> _oefeningen;

        public OefeningRepository(JiuJitsuDbContext context)
        {
            _context = context;
            _oefeningen = context.Oefeningen;
        }

        public IEnumerable<Oefening> GetAll()
        {
            return _oefeningen.Include(o => o.Thema).ToList();
        }

        public IEnumerable<Oefening> GetAllByGraad(Graad graad)
        {
            return _oefeningen.Include(o => o.Thema).Where(o => o.Graad.Equals(graad)).ToList();
        }

        public Oefening GetById(int id)
        {
            return _oefeningen.Include(o => o.Thema).SingleOrDefault(o => o.Id == id);
        }
    }
}

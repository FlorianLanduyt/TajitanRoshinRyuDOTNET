using Microsoft.EntityFrameworkCore;
using PROJ20_G20_DOTNET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Data.Repositories
{
    public class RaadplegingRepository : IRaadplegingRepository
    {

        private readonly JiuJitsuDbContext _context;
        private readonly DbSet<Raadpleging> _raadplegingen;

        public RaadplegingRepository(JiuJitsuDbContext context)
        {
            _context = context;
            _raadplegingen = context.Raadplegingen;
        }

        public void Add(Raadpleging raadpleging)
        {
            _raadplegingen.Add(raadpleging);
        }

        public IEnumerable<Raadpleging> GetAll()
        {
            return _raadplegingen.Include(r => r.Tijdstippen).ToList();
        }

        public Raadpleging GetById(int id)
        {
            return _raadplegingen.Include(r => r.Tijdstippen).SingleOrDefault(r => r.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }


    }
}

using Microsoft.EntityFrameworkCore;
using PROJ2_G20_.NET.Models.Domain;
using PROJ20_G20_DOTNET.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ2_G20_.NET.Data.Repositories {
    public class ActiviteitRepository : IActiviteitRepository {
        private readonly JiuJitsuDbContext _context;
        private readonly DbSet<Activiteit> _activiteiten;

        public ActiviteitRepository(JiuJitsuDbContext context) {
            _context = context;
            //_activiteiten = _context.Activiteiten;
        }

        public void Add(Activiteit activiteit) {
            _activiteiten.Add(activiteit);
        }

        public void Delete(Activiteit activiteit) {
            _activiteiten.Remove(activiteit);
        }

        public IEnumerable<Activiteit> GetAll() {
            return _activiteiten.ToList();
        }

        public Activiteit GetBy(int id) {
            return _activiteiten.FirstOrDefault(a => a.Id == id);
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }
    }
}

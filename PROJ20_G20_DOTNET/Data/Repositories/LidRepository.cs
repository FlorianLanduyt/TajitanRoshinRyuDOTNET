using Microsoft.EntityFrameworkCore;
using PROJ2_G20_.NET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ2_G20_.NET.Data.Repositories {
    public class LidRepository : ILidRepository {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Lid> _leden;

        public LidRepository(ApplicationDbContext context) {
            _context = context;
            //_leden = _context.Leden;
        }

        public void Add(Lid lid) {
            _leden.Add(lid);
        }

        public void Delete(Lid lid) {
            _leden.Remove(lid);
        }

        public IEnumerable<Lid> GetAll() {
            return _leden.ToList();
        }

        public Lid GetBy(int id) {
            return _leden.SingleOrDefault(l => l.Id == id);
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }
    }
}

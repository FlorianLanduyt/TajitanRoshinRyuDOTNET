﻿using Microsoft.EntityFrameworkCore;
using PROJ20_G20_DOTNET.Data;
using PROJ20_G20_DOTNET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Data.Repositories
{
    public class InschrijvingRepository : IInschrijvingRepository
    {
        private readonly JiuJitsuDbContext _context;
        private readonly DbSet<Inschrijving> _inschrijvingen;

        public InschrijvingRepository(JiuJitsuDbContext context)
        {
            _context = context;
            _inschrijvingen = context.Inschrijvingen;

        }

        public void Add(Inschrijving inschrijving)
        {
            _inschrijvingen.Add(inschrijving);
        }

        public void Delete(Inschrijving inschrijving)
        {
            _inschrijvingen.Remove(inschrijving);
        }

        public IEnumerable<Inschrijving> GetAll()
        {
            return _inschrijvingen.ToList();
        }

        public Inschrijving GetBy(int id)
        {
            return _inschrijvingen.SingleOrDefault(i => i.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

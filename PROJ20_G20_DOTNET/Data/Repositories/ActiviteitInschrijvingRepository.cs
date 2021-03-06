﻿using Microsoft.EntityFrameworkCore;
using PROJ20_G20_DOTNET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Data.Repositories
{
    public class ActiviteitInschrijvingRepository : IActiviteitInschrijvingRepository
    {
        private readonly JiuJitsuDbContext _dbContext;
        private readonly DbSet<ActiviteitInschrijving> _activiteitInschrijvingen;

        public ActiviteitInschrijvingRepository(JiuJitsuDbContext dbContext)
        {
            _dbContext = dbContext;
            _activiteitInschrijvingen = dbContext.ActiviteitInschrijvingen;
        }

        public IEnumerable<ActiviteitInschrijving> GetAll()
        {
            return _activiteitInschrijvingen
                .ToList();
        }

        public ActiviteitInschrijving GetBy(int activiteitId, int inschrijvingId)
        {
            return _activiteitInschrijvingen
                .SingleOrDefault(ai => ai.ActiviteitId == activiteitId && ai.InschrijvingId == inschrijvingId);
        }

        public void Add(ActiviteitInschrijving ai) {
            _activiteitInschrijvingen.Add(ai);
        }
        public void SaveChanges() {
            _dbContext.SaveChanges();
        }
    }
}

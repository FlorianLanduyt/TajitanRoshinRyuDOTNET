using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PROJ20_G20_DOTNET.Data.Mapping;
using PROJ20_G20_DOTNET.Models.Domain;

namespace PROJ20_G20_DOTNET.Data
{
    public class JiuJitsuDbContext : IdentityDbContext {
        public DbSet<Aanwezigheid> Aanwezigheden { get; set; }
        public DbSet<Activiteit> Activiteiten { get; set; }
        public DbSet<ActiviteitInschrijving> ActiviteitInschrijvingen { get; set; }
        public DbSet<Inschrijving> Inschrijvingen { get; set; }
        public DbSet<Lid> Leden { get; set; }
        public DbSet<Oefening> Oefeneningen { get; set; }
        //public DbSet<Raadpleging> Raadplegingen { get; set; }
        public DbSet<Thema> Themas { get; set; }

        public JiuJitsuDbContext(DbContextOptions<JiuJitsuDbContext> options)
            : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AanwezigheidConfiguration());
            builder.ApplyConfiguration(new ActiviteitConfiguration());
            builder.ApplyConfiguration(new ActiviteitInschrijvingConfiguration());
            builder.ApplyConfiguration(new InschrijvingConfiguration());
            builder.ApplyConfiguration(new LidConfiguration());
            builder.ApplyConfiguration(new OefeningConfiguration());
            //builder.ApplyConfiguration(new RaadplegingConfiguration());
            builder.ApplyConfiguration(new ThemaConfiguration());
        }
    }
}

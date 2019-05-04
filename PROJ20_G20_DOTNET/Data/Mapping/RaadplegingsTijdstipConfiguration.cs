using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJ20_G20_DOTNET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Data.Mapping {
    public class RaadplegingsTijdstipConfiguration : IEntityTypeConfiguration<RaadplegingsTijdstip> {
        public void Configure(EntityTypeBuilder<RaadplegingsTijdstip> builder) {
            builder.ToTable("RAADPLEGINGSTIJDSTIP");
            builder.Property(rt => rt.Tijdstip).HasColumnName("TIJDSTIP");
            builder.HasKey(rt => rt.Id);
            builder.Property(rt => rt.Id).HasColumnName("ID");
            builder.Property(rt => rt.RaadplegingId).HasColumnName("RAADPLEGING_ID");
        }
    }
}

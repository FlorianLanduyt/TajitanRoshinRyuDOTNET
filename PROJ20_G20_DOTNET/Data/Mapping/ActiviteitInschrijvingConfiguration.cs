using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJ20_G20_DOTNET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Data.Mapping {
    public class ActiviteitInschrijvingConfiguration : IEntityTypeConfiguration<ActiviteitInschrijving> {
        public void Configure(EntityTypeBuilder<ActiviteitInschrijving> builder) {
            builder.ToTable("ACTIVITEIT_INSCHRIJVING");
            builder.Property(ai => ai.ActiviteitId).HasColumnName("Activiteit_ID");
            builder.Property(ai => ai.InschrijvingId).HasColumnName("inschrijven_ID"); // Lijkt raar, staat ook zo in java db
            builder.HasKey(ai => new { ai.ActiviteitId, ai.InschrijvingId });

            builder.HasOne(ai => ai.Activiteit).WithMany(a => a.Inschrijvingen).HasForeignKey(ai => ai.ActiviteitId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(ai => ai.Inschrijving).WithMany().HasForeignKey(ai => ai.InschrijvingId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

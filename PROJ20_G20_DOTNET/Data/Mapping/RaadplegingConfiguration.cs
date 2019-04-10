using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJ2_G20_.NET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Data.Mapping {
    public class RaadplegingConfiguration : IEntityTypeConfiguration<Raadpleging> {
        public void Configure(EntityTypeBuilder<Raadpleging> builder) {
            builder.ToTable("RAADPLEGING");

            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).HasColumnName("ID");
            builder.HasOne(r => r.Lid).WithMany().HasForeignKey(r => r.LidId);
            builder.HasOne(r => r.Oefening).WithMany().HasForeignKey(r => r.OefeningId);
            builder.Property(r => r.LidId).HasColumnName("LID_ID");
            builder.Property(r => r.OefeningId).HasColumnName("OEFENING_ID");
            builder.Property(r => r.AantalRaadplegingen).HasColumnName("AANTALRAADPLEGINGEN");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJ2_G20_.NET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Data.Mapping {
    public class InschrijvingConfiguration : IEntityTypeConfiguration<Inschrijving> {
        public void Configure(EntityTypeBuilder<Inschrijving> builder) {
            builder.ToTable("INSCHRIJVING");
            builder.HasKey(i => i.Id);
            builder.HasOne(i => i.Lid).WithMany().OnDelete(DeleteBehavior.Cascade).HasForeignKey(i => i.LidId);
            builder.Property(i => i.Id).HasColumnName("ID");
            builder.Property(i => i.Formule).HasColumnName("FORMULE");
            builder.Property(i => i.Tijdstip).HasColumnName("TIJDSTIP");
            builder.Property(i => i.LidId).HasColumnName("LID_ID");
            
        }
    }
}

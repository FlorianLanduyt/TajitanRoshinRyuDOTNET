using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJ2_G20_.NET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Data.Mapping {
    public class AanwezigheidConfiguration : IEntityTypeConfiguration<Aanwezigheid> {
        public void Configure(EntityTypeBuilder<Aanwezigheid> builder) {
            builder.HasKey(a => a.Id); // In Java DB
            builder.HasOne(a => a.Lid).WithMany().HasForeignKey(a=> a.LidId);
            builder.HasOne(a => a.Activiteit).WithMany().HasForeignKey(a => a.ActiviteitId);
        }
    }
}

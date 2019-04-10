using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJ2_G20_.NET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Data.Mapping {
    public class ActiviteitConfiguration : IEntityTypeConfiguration<Activiteit> {
        public void Configure(EntityTypeBuilder<Activiteit> builder) {
            builder.HasKey(a => a.Id);
        }
    }
}

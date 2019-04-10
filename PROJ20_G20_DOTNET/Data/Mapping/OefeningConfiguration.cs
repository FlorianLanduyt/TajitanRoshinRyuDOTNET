using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJ2_G20_.NET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Data.Mapping {
    public class OefeningConfiguration : IEntityTypeConfiguration<Oefening> {
        public void Configure(EntityTypeBuilder<Oefening> builder) {
            builder.HasKey(o => o.Id);
            builder.HasOne(o => o.Thema).WithMany();
        }
    }
}

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
            builder.ToTable("OEFENING");

            builder.HasKey(o => o.Id);
            builder.HasOne(o => o.Thema).WithMany().OnDelete(DeleteBehavior.Cascade).HasForeignKey(o => o.ThemaId);
            builder.Property(o => o.Id).HasColumnName("ID");
            builder.Property(o => o.AantalRaadplegingen).HasColumnName("AANTALRAADPLEGINGEN");
            builder.Property(o => o.Graad).HasColumnName("GRAAD");
            builder.Property(o => o.ThemaId).HasColumnName("THEMA_ID");
            builder.Property(o => o.LaatsteRaadpleging).HasColumnName("LAATSTERAADPLEGING");
            builder.Property(o => o.UrlAfbeelding).HasColumnName("AFBEELDING").HasMaxLength(512);
            builder.Property(o => o.Tekst).HasColumnName("TEKST");
            builder.Property(o => o.Titel).HasColumnName("TITEL");
            builder.Property(o => o.UrlVideo).HasColumnName("URLVIDEO").HasMaxLength(512);
        }
    }
}

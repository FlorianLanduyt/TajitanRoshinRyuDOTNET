using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJ2_G20_.NET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Data.Mapping {
    public class LidConfiguration : IEntityTypeConfiguration<Lid> {
        public void Configure(EntityTypeBuilder<Lid> builder) {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Achternaam).HasMaxLength(50).IsRequired();
            builder.Property(l => l.Voornaam).HasMaxLength(50).IsRequired();
            builder.Property(l => l.Beroep).HasMaxLength(50);
            builder.Property(l => l.Bus).HasMaxLength(5);
            builder.Property(l => l.Email).IsRequired();
            builder.Property(l => l.GeboortePlaats).HasMaxLength(50).IsRequired();
            builder.Property(l => l.Geslacht).IsRequired();
            builder.Property(l => l.GsmNr).HasMaxLength(12).IsRequired();
            builder.Property(l => l.HuisNr).HasMaxLength(5).IsRequired();
            builder.Property(l => l.PostCode).HasMaxLength(4).IsRequired();
            builder.Property(l => l.RijksregisterNummer).IsRequired().HasMaxLength(15);
            builder.Property(l => l.Stad).HasMaxLength(50).IsRequired();
            builder.Property(l => l.Straat).HasMaxLength(50).IsRequired();
            builder.Property(l => l.VasteTelefoonNr).HasMaxLength(10);
            builder.Property(l => l.Wachtwoord).IsRequired().HasMaxLength(11);
        }
    }
}

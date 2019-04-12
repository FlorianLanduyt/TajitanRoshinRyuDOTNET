using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJ20_G20_DOTNET.Models.Domain;

namespace PROJ20_G20_DOTNET.Data.Mapping {
    public class ActiviteitConfiguration : IEntityTypeConfiguration<Activiteit> {
        public void Configure(EntityTypeBuilder<Activiteit> builder) {
            builder.ToTable("ACTIVITEIT");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .HasColumnName("ID");
            builder.Property(a => a.AantalDeelnemers)
                .HasColumnName("AANTALDEELNEMERS");
            builder.Property(a => a.BeginDatum)
                .HasColumnName("BEGINDATUM");
            builder.Property(a => a.BusNummer)
                .HasColumnName("BUS");
            builder.Property(a => a.EindDatum)
                .HasColumnName("EINDDATUM");
            builder.Property(a => a.Email)
                .HasColumnName("EMAIL");
            builder.Property(a => a.Formule)
                .HasColumnName("FORMULE");
            builder.Property(a => a.GsmNummer)
                .HasColumnName("GSMNUMMER");
            builder.Property(a => a.HuisNummer)
                .HasColumnName("HUISNUMMER");
            builder.Property(a => a.IsVolzet)
                .HasColumnName("ISVOLZET");
            builder.Property(a => a.MaxAantalDeelnemers)
                .HasColumnName("MAXDEELNEMERS");
            builder.Property(a => a.Naam)
                .HasColumnName("NAAM");
            builder.Property(a => a.NaamLocatie)
                .HasColumnName("NAAMLOCATIE");
            builder.Property(a => a.Postcode)
                .HasColumnName("POSTCODE");
            builder.Property(a => a.Stad)
                .HasColumnName("STAD");
            builder.Property(a => a.Straat)
                .HasColumnName("STRAAT");
            builder.Property(a => a.UitersteInschrijvingsDatum)
                .HasColumnName("UITERSTEINSCHRIJVINGSDATUM");
        }
    }
}

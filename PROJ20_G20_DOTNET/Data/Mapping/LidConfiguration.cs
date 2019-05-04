using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJ20_G20_DOTNET.Models.Domain;


namespace PROJ20_G20_DOTNET.Data.Mapping {
    public class LidConfiguration : IEntityTypeConfiguration<Lid> {
        public void Configure(EntityTypeBuilder<Lid> builder) {
            builder.ToTable("LID");

            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).HasColumnName("ID");
            builder.Property(l => l.Achternaam)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("ACHTERNAAM");
            builder.Property(l => l.Voornaam)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("VOORNAAM");
            builder.Property(l => l.Beroep)
                .HasMaxLength(50)
                .HasColumnName("BEROEP");
            builder.Property(l => l.Bus)
                .HasMaxLength(5)
                .HasColumnName("BUS");
            builder.Property(l => l.Email)
                .IsRequired()
                .HasColumnName("EMAIL");
            builder.Property(l => l.EmailMoeder)
                .HasColumnName("EMAILMOEDER");
            builder.Property(l => l.EmailVader)
                .HasColumnName("EMAILVADER");
            builder.Property(l => l.GeboortePlaats)
                .HasMaxLength(50)
                .HasColumnName("GEBOORTEPLAATS");
            builder.Property(l => l.Nationaliteit)
                .HasMaxLength(50)
                .HasColumnName("NATIONALITEIT");
            builder.Property(l => l.Geslacht)
                .HasColumnName("GESLACHT");
            builder.Property(l => l.PuntenAantal)
                .HasColumnName("PUNTENAANTAL");
            builder.Property(l => l.GsmNr)
                .HasMaxLength(12)
                .IsRequired()
                .HasColumnName("GSMNR");
            builder.Property(l => l.HuisNr)
                .HasMaxLength(5)
                .HasColumnName("HUISNR");
            builder.Property(l => l.PostCode)
                .HasMaxLength(4)
                .HasColumnName("POSTCODE");
            builder.Property(l => l.RijksregisterNummer)
                .HasMaxLength(15)
                .HasColumnName("RIJKSREGISTERNR");
            builder.Property(l => l.Stad)
                .HasMaxLength(50)
                .HasColumnName("STAD");
            builder.Property(l => l.Straat)
                .HasMaxLength(50)
                .HasColumnName("STRAAT");
            builder.Property(l => l.VasteTelefoonNr)
                .HasMaxLength(12)
                .HasColumnName("VASTETELEFOONNR");
            builder.Property(l => l.Wachtwoord)
                .HasColumnName("WACHTWOORD");
            builder.Property(l => l.Graad)
                .HasColumnName("GRAAD");
            builder.Property(l => l.Functie)
                .HasColumnName("FUNCTIE")
                .IsRequired();
            builder.Ignore(l => l.LeeftijdsCategorieën);
        }
    }
}

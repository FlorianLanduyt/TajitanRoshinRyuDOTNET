using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJ20_G20_DOTNET.Models.Domain;

namespace PROJ20_G20_DOTNET.Data.Mapping {
    public class AanwezigheidConfiguration : IEntityTypeConfiguration<Aanwezigheid> {
        public void Configure(EntityTypeBuilder<Aanwezigheid> builder) {
            builder.ToTable("AANWEZIGHEID");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("ID");
            builder.Property(a => a.ActiviteitId).HasColumnName("ACTIVITEIT_ID");
            builder.Property(a => a.LidId).HasColumnName("LID_ID");
            builder.Property(a => a.PuntenAantal).HasColumnName("PUNTENAANTAL");
            builder.HasOne(a => a.Lid).WithMany()
                .HasForeignKey(a => a.LidId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
            builder.HasOne(a => a.Activiteit)
                .WithMany()
                .HasForeignKey(a => a.ActiviteitId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}

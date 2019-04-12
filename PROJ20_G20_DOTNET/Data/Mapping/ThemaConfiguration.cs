using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJ20_G20_DOTNET.Models.Domain;

namespace PROJ20_G20_DOTNET.Data.Mapping {
    public class ThemaConfiguration : IEntityTypeConfiguration<Thema> {
        public void Configure(EntityTypeBuilder<Thema> builder) {
            builder.ToTable("THEMA");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("ID");
            builder.Property(t => t.Naam).IsRequired().HasColumnName("NAAM");
        }
    }
}

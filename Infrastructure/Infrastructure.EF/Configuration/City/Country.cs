using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class Country : IEntityTypeConfiguration<Core.Entities.Country>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Country> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.Property(p => p.Id).ValueGeneratedNever();
            builder.Property(p => p.Name).IsRequired();
        }
    }
}
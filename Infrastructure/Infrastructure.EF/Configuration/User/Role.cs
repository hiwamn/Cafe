using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class Role : IEntityTypeConfiguration<Core.Entities.Role>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Role> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.Property(p => p.Name).ValueGeneratedNever();
            builder.Property(p => p.Name).IsRequired();
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class EntityStatus : IEntityTypeConfiguration<Core.Entities.EntityStatus>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.EntityStatus> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.Property(p => p.Id).ValueGeneratedNever();
 
        }
    }
}
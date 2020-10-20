using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class Update : IEntityTypeConfiguration<Core.Entities.Update>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Update> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Restricted).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.Version).IsRequired();
            builder.Property(p => p.Link).IsRequired();

        }
    }
}
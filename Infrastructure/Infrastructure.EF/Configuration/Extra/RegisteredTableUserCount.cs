using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class RegisteredTableUserCount : IEntityTypeConfiguration<Core.Entities.RegisteredTableUserCount>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.RegisteredTableUserCount> builder)
        {
            builder.HasKey(p => new { p.Id});
        }
    }
}
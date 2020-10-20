using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class RegisteredWorkTime : IEntityTypeConfiguration<Core.Entities.RegisteredWorkTime>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.RegisteredWorkTime> builder)
        {
            builder.HasKey(p => new { p.Id });
        }
    }
}
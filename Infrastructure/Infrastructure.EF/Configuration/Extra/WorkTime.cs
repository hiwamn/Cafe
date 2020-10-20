using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class WorkTime : IEntityTypeConfiguration<Core.Entities.WorkTime>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.WorkTime> builder)
        {
            builder.HasKey(p => new { p.Id });
        }
    }
}
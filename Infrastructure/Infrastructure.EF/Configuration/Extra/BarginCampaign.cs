using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class BarginCampaign : IEntityTypeConfiguration<Core.Entities.BarginCampaign>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.BarginCampaign> builder)
        {
            builder.HasKey(p => new { p.Id });
        }
    }
}
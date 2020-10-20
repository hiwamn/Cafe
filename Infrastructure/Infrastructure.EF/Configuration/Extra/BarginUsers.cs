using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class BarginUsers : IEntityTypeConfiguration<Core.Entities.BarginUsers>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.BarginUsers> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.HasOne(p => p.BarginCampaign).WithMany(p => p.BarginUsers).HasForeignKey(p => p.BarginCampaignId);
            builder.HasOne(p => p.User).WithMany(p => p.BarginUsers).HasForeignKey(p => p.UserId);
        }
    }
}
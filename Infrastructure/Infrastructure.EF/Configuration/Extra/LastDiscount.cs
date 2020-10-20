using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class LastDiscount : IEntityTypeConfiguration<Core.Entities.LastDiscount>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.LastDiscount> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.HasOne(p => p.User).WithMany(p=>p.LastDiscount).HasForeignKey(p=>p.UserId).OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
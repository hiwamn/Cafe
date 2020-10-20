using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class UserDiscount : IEntityTypeConfiguration<Core.Entities.UserDiscount>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.UserDiscount> builder)
        {
            builder.HasKey(p => new { p.Id });            
            builder.HasOne(p => p.User).WithMany(p => p.Discount).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class UserRole : IEntityTypeConfiguration<Core.Entities.UserRole>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.UserRole> builder)
        {
            builder.HasKey(p => new { p.Id });

            builder.HasOne(p => p.User).WithMany(p=>p.UserRole).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Role).WithMany(p=>p.UserRole).HasForeignKey(p => p.RoleId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
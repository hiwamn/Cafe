using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class Notification : IEntityTypeConfiguration<Core.Entities.Notification>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Notification> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.Image).IsRequired();
            builder.Property(p => p.Link).IsRequired();
            builder.HasOne(p => p.User).WithMany(b => b.Notification).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
           
        }
    }
}
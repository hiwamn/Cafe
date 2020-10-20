using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class Device : IEntityTypeConfiguration<Core.Entities.Device>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Device> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.Property(p => p.PushId).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.HasOne(p=>p.User).WithMany(b => b.Device).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
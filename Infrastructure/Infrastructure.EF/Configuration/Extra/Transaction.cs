using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class Transaction : IEntityTypeConfiguration<Core.Entities.Transaction>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Transaction> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.HasOne(p => p.User).WithMany(p=>p.Transaction).HasForeignKey(p=>p.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.NextUser).WithMany(p=>p.OtherTransaction).HasForeignKey(p=>p.NextUserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
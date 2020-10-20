using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class UserTransactionList : IEntityTypeConfiguration<Core.Entities.UserTransactionList>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.UserTransactionList> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.HasOne(p => p.Partner).WithMany(p => p.Partner).HasForeignKey(p => p.PartnerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.User).WithMany(p => p.UserTransactionList).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
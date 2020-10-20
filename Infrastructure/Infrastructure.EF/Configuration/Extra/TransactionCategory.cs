using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class TransactionCategory : IEntityTypeConfiguration<Core.Entities.TransactionCategory>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.TransactionCategory> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.Property(p => p.Id).ValueGeneratedNever();
        }
    }
}
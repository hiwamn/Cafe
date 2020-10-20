using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class GroupGameUsers : IEntityTypeConfiguration<Core.Entities.GroupGameUsers>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.GroupGameUsers> builder)
        {
            builder.HasKey(p => new { p.GroupGameId,p.UserId });
        }
    }
}
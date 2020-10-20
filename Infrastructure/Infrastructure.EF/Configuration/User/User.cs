using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class User : IEntityTypeConfiguration<Core.Entities.User>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.User> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.Property(p => p.CreatedAt).IsRequired();
            //builder.Property(p => p.Password).IsRequired();
            //builder.Property(p => p.Salt).IsRequired();
            builder.Property(p => p.Status).IsRequired();
            //builder.Property(p => p.Email).IsRequired();

            builder.HasOne(p => p.ProfileImage).WithMany(p=>p.UserProfiles).HasForeignKey(p => p.ProfileImageId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Reference).WithMany().HasForeignKey(p => p.ReferenceId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
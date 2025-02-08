using JobPortal.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Infrastructure.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(u => u.Fullname)
                .HasMaxLength(100);

            builder.Property(u => u.ProfileImageUrl)
                .HasMaxLength(500);

            builder.Property(u => u.Location)
                .HasMaxLength(200);

            builder.HasMany(u => u.UserSkills)
                .WithOne(us => us.User)
                .HasForeignKey(us  => us.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.JobApplications)
                .WithOne(ja => ja.User)
                .HasForeignKey(ja => ja.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

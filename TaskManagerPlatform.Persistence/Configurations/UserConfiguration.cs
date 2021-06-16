using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerPlatform.Domain.Entities;

namespace TaskManagerPlatform.Persistence.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.CreatedDate).IsRequired();
            builder.Property(u => u.Name).IsRequired().HasMaxLength(255);
            builder.Property(u => u.Surname).HasMaxLength(255);
            builder.Property(u => u.PhoneNumber).HasMaxLength(50);
            builder.Property(u => u.Address).HasMaxLength(255);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Salt).IsRequired().HasMaxLength(2500);
            builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(2500);

            builder.HasMany(u => u.UserToRoles)
                   .WithOne(utr => utr.User)
                   .HasForeignKey(utr => utr.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.UserToTasks)
                   .WithOne(utt => utt.User)
                   .HasForeignKey(utt => utt.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Organization)
                   .WithMany(o => o.Employees)
                   .HasForeignKey(e => e.OrganizationId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
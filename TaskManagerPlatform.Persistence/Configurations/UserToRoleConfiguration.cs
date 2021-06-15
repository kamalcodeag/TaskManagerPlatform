using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerPlatform.Domain.Entities;

namespace TaskManagerPlatform.Persistence.Configurations
{
    internal class UserToRoleConfiguration : IEntityTypeConfiguration<UserToRole>
    {
        public void Configure(EntityTypeBuilder<UserToRole> builder)
        {
            builder.HasKey(utr => utr.Id);
            builder.Property(utr => utr.CreatedDate).IsRequired();

            builder.HasOne(utr => utr.User)
                   .WithMany(u => u.UserToRoles)
                   .HasForeignKey(utr => utr.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(utr => utr.Role)
                   .WithMany(r => r.UserToRoles)
                   .HasForeignKey(utr => utr.RoleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
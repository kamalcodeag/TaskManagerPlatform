using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerPlatform.Domain.Entities;

namespace TaskManagerPlatform.Persistence.Configurations
{
    internal class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(255);

            builder.HasMany(p => p.RoleToPermissions)
                   .WithOne(rtp => rtp.Permission)
                   .HasForeignKey(rtp => rtp.PermissionId);
        }
    }
}
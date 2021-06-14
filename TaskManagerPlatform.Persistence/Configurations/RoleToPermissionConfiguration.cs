using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerPlatform.Domain.Entities;

namespace TaskManagerPlatform.Persistence.Configurations
{
    internal class RoleToPermissionConfiguration : IEntityTypeConfiguration<RoleToPermission>
    {
        public void Configure(EntityTypeBuilder<RoleToPermission> builder)
        {
            builder.HasKey(rtp => rtp.Id);
            builder.Property(rtp => rtp.CreatedDate).IsRequired();

            builder.HasOne(rtp => rtp.Role)
                   .WithMany(r => r.RoleToPermissions)
                   .HasForeignKey(rtp => rtp.RoleId);

            builder.HasOne(rtp => rtp.Permission)
                   .WithMany(p => p.RoleToPermissions)
                   .HasForeignKey(rtp => rtp.PermissionId);
        }
    }
}
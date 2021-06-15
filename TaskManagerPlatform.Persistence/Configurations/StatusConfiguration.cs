using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerPlatform.Domain.Entities;

namespace TaskManagerPlatform.Persistence.Configurations
{
    internal class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.CreatedDate).IsRequired();

            builder.HasMany(s => s.Tasks)
                   .WithOne(t => t.Status)
                   .HasForeignKey(t => t.StatusId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
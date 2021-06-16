using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerPlatform.Domain.Entities;

namespace TaskManagerPlatform.Persistence.Configurations
{
    internal class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.CreatedDate).IsRequired();
            builder.Property(t => t.Title).IsRequired().HasMaxLength(255);
            builder.Property(t => t.Description).HasMaxLength(2500);
            builder.Property(t => t.Deadline).IsRequired();

            builder.HasOne(t => t.Status)
                   .WithMany(s => s.Tasks)
                   .HasForeignKey(t => t.StatusId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(t => t.UserToTasks)
                   .WithOne(utt => utt.Task)
                   .HasForeignKey(utt => utt.TaskId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
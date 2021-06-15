using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerPlatform.Domain.Entities;

namespace TaskManagerPlatform.Persistence.Configurations
{
    internal class UserToTaskConfiguration : IEntityTypeConfiguration<UserToTask>
    {
        public void Configure(EntityTypeBuilder<UserToTask> builder)
        {
            builder.HasKey(utt => utt.Id);
            builder.Property(utt => utt.CreatedDate).IsRequired();

            builder.HasOne(utt => utt.User)
                   .WithMany(u => u.UserToTasks)
                   .HasForeignKey(utt => utt.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(utt => utt.Task)
                   .WithMany(t => t.UserToTasks)
                   .HasForeignKey(utt => utt.TaskId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
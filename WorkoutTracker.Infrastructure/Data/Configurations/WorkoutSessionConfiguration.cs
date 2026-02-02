using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Infrastructure.Data.Configurations
{
    public class WorkoutSessionConfiguration : IEntityTypeConfiguration<WorkoutSession>
    {
        public void Configure(EntityTypeBuilder<WorkoutSession> entity)
        {
            entity.ToTable("WorkoutSessions");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.PerformedAt)
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(e => e.Workout)
                  .WithMany(e => e.WorkoutSessions)
                  .HasForeignKey(e => e.WorkoutId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

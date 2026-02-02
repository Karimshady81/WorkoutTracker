using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Infrastructure.Data.Configurations
{
    public class WorkoutExerciseConfiguration : IEntityTypeConfiguration<WorkoutExercise>
    {
        public void Configure(EntityTypeBuilder<WorkoutExercise> entity)
        {
            entity.ToTable("WorkoutExercises");

            entity.HasKey(e => e.Id);

            //Prevent duplicate exercise in the same workout
            entity.HasIndex(e => new {e.WorkoutId, e.ExerciseId})
                    .IsUnique();

            entity.Property(e => e.OrderInWorkout)
                    .IsRequired();

            entity.Property(e => e.TargetSets)
                    .IsRequired();

            entity.Property(e => e.TargetReps)
                    .IsRequired();

            entity.Property(e => e.RestSeconds)
                    .IsRequired();

            entity.HasOne(e => e.Workout)
                    .WithMany(w => w.WorkoutExercises)
                    .HasForeignKey(e => e.WorkoutId)
                    .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Exercise)
                    .WithMany(ex => ex.WorkoutExercises)
                    .HasForeignKey(e => e.ExerciseId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

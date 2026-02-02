using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Infrastructure.Data.Configurations
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> entity)
        {
            entity.ToTable("Exercises");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            entity.Property(e => e.MuscleGroup)
                   .IsRequired()
                   .HasMaxLength(100);

            entity.Property(e => e.Equipment)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}

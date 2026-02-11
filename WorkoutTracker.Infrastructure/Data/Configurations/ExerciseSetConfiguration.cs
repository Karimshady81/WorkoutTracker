using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Infrastructure.Data.Configurations
{
    public class ExerciseSetConfiguration : IEntityTypeConfiguration<ExerciseSet>
    {
        public void Configure(EntityTypeBuilder<ExerciseSet> entity)
        {
            entity.ToTable("ExerciseSets");

            entity.HasKey(e => e.Id);


            entity.Property(e => e.SetNumber)
                    .IsRequired();

            entity.Property(e => e.Weight)
                    .IsRequired();

            entity.Property(e => e.Reps)
                    .IsRequired();

            // One set number per exercise per session
            entity.HasIndex(e => new { e.WorkoutSessionId, e.ExerciseId, e.SetNumber })
                  .IsUnique();

            entity.HasOne(e => e.WorkoutSession)
                    .WithMany(e => e.ExerciseSets)
                    .HasForeignKey(e => e.WorkoutSessionId)
                    .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Exercise)
                    .WithMany(e => e.ExerciseSets)
                    .HasForeignKey(e => e.ExerciseId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

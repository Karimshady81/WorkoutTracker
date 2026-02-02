using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("users");

            entity.HasKey(u => u.Id);

            entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

            entity.HasIndex(e => e.Email)
                  .IsUnique();

            entity.Property(e => e.UserName)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.PasswordHash)
                  .IsRequired()
                  .HasMaxLength(255);

            entity.Property(e => e.FirstName)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.LastName)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.CreatedAt)
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            //Relationship
            entity.HasMany(e => e.Workouts)
                  .WithOne(e => e.User)
                  .HasForeignKey(e => e.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

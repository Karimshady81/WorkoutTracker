using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Domain.Entities;
using WorkoutTracker.Domain.RepositoryInterface;
using WorkoutTracker.Infrastructure.Data;

namespace WorkoutTracker.Infrastructure.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly AppDbContext _context;

        public WorkoutRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Workout workout)
        {
            await _context.Workouts.AddAsync(workout);
        }
        public void UpdateAsync(Workout workout)
        {
            _context.Workouts.Update(workout);
        }

        public void DeleteAsync(Workout workout)
        {
            _context.Workouts.Remove(workout);
        }

        public async Task<IReadOnlyList<Workout>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Workouts.Where(w => w.UserId == userId)                                          
                                          .ToListAsync();
        }

        public async Task<Workout?> GetWorkoutByIdAsync(Guid id)
        {
            return await _context.Workouts.FirstOrDefaultAsync(w => w.Id == id);
        }

    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Domain.Entities;
using WorkoutTracker.Domain.RepositoryInterface;
using WorkoutTracker.Infrastructure.Data;

namespace WorkoutTracker.Infrastructure.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly AppDbContext _context;

        public ExerciseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Exercise exercise)
        {
            await _context.Exercises.AddAsync(exercise);
        }

        public void DeleteAsync(Exercise exercise)
        {
            _context.Exercises.Remove(exercise);
        }

        public async Task<IReadOnlyList<Exercise>> GetAllAsync()
        {
            return await _context.Exercises.AsNoTracking()
                                           .ToListAsync();
        }

        public async Task<Exercise?> GetByIdAsync(Guid id)
        {
            return await _context.Exercises.FindAsync(id);
        }

        public async Task<Exercise?> GetByNameAsync(string name)
        {
            return await _context.Exercises.FirstOrDefaultAsync(e => e.Name == name);
        }
    }
}

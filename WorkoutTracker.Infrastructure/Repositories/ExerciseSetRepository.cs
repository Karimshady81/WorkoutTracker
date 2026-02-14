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
    public class ExerciseSetRepository : IExerciseSetRepository
    {
        private readonly AppDbContext _context;

        public ExerciseSetRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ExerciseSet exerciseSet)
        {
            await _context.ExercisesSets.AddAsync(exerciseSet);
        }
    }
}

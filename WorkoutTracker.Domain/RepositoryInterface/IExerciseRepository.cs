using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Domain.RepositoryInterface
{
    public interface IExerciseRepository
    {
        Task<Exercise?> GetByIdAsync(Guid id);
        Task<Exercise?> GetByNameAsync(string name);
        Task<IReadOnlyList<Exercise>> GetAllAsync();

        Task AddAsync(Exercise exercise);
        void DeleteAsync(Exercise exercise);
    }
}

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
        Task<Exercise?> GetByIdAsync(Guid id); // get exercise by id
        Task<Exercise?> GetByNameAsync(string name); // lookup exercise by name
        Task<IReadOnlyList<Exercise>> GetAllAsync(); // list exercise catalog

        Task AddAsync(Exercise exercise); // add new exercise to catalog
        void DeleteAsync(Exercise exercise); // remove exercise from catalog
}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Domain.RepositoryInterface
{
    public interface IWorkoutRepository
    {
        Task<Workout?> GetWorkoutByIdAsync(Guid Id); // view workout details
        Task<IReadOnlyList<Workout>> GetByUserIdAsync(Guid userId); // list user workouts

        Task AddAsync(Workout workout); // create workout template
        void UpdateAsync(Workout workout); // edit workout template
        void DeleteAsync(Workout workout); // remove workout template
    }
}

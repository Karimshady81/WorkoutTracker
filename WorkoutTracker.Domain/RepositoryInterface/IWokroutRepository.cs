using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Domain.RepositoryInterface
{
    public interface IWokroutRepository
    {
        Task<Workout?> GetWorkoutByIdAsync(Guid Id);
        Task<IReadOnlyList<Workout>> GetByUserIdAsync(Guid userId);

        Task AddAsync(Workout workout);
        void UpdateAsync(Workout workout);
        void DeleteAsync(Guid id);
    }
}

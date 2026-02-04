using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Domain.RepositoryInterface
{
    public interface IWorkoutSessionRepository
    {
        Task<WorkoutSession?> GetByIdAsync(Guid id);
        Task<IReadOnlyList<WorkoutSession>> GetByUserIdAsync(Guid userId);
        Task AddAsync(WorkoutSession workoutSession);
        void Delete(WorkoutSession workoutSession);
    }
}

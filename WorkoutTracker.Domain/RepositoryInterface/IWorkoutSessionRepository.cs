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
        Task<WorkoutSession?> GetByIdAsync(Guid id); //View session 
        Task<WorkoutSession?> GetWithDetailsByIdAsync(Guid sessionId); //View session with exercises
        Task<IReadOnlyList<WorkoutSession>> GetByUserIdAsync(Guid userId); //Workout histroy
        Task AddAsync(WorkoutSession workoutSession); //start/log session
        void Delete(WorkoutSession workoutSession); //delete session
    }
}

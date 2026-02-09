using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Application.DTOs.Requests;
using WorkoutTracker.Application.DTOs.Response;

namespace WorkoutTracker.Application.Interfaces
{
    public interface IWorkoutService
    {
        Task<Guid> CreateWorkoutAsync(Guid userId, CreateWorkoutRequest request);
        Task<IReadOnlyList<WorkoutListResponse>> GetWorkoutsByUserAsync(Guid userId);
        Task<WorkoutDetailsResponse> GetWorkoutById(Guid workoutId);
    }
}

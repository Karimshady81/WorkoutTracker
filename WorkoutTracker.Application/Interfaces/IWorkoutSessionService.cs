using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Application.DTOs.Requests;
using WorkoutTracker.Application.DTOs.Response;

namespace WorkoutTracker.Application.Interfaces
{
    public interface IWorkoutSessionService
    {
        Task<Guid> StartWorkoutSessionAsync(Guid userId,StartWorkoutSessionRequest request);
        Task<Guid> AddExerciseSetAsync(Guid userId, AddExerciseRequest request);
        Task<Guid> EndWorkoutSessionAsync(Guid userId, EndWorkoutSessionRequest request);
        Task<WorkoutSessionDetailsResponse> GetSessionDetailsAsync(Guid userId, Guid sessionId);
        Task<IReadOnlyList<WorkoutSessionSummaryResponse>> GetWorkoutHistoryAsync(Guid userId);

        Task UpdateExerciseSetAsync(Guid userId, UpdateExerciseSetRequest request);
        Task DeleteExerciseSetAsync(Guid userId, DeleteExerciseSetRequest request);
    }
}

using WorkoutTracker.Application.DTOs.Requests;
using WorkoutTracker.Application.DTOs.Response;
using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Domain.Entities;
using WorkoutTracker.Domain.RepositoryInterface;

namespace WorkoutTracker.Application.Services
{
    public class WorkoutSessionService : IWorkoutSessionService
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IWorkoutSessionRepository _workoutSessionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public WorkoutSessionService(IWorkoutRepository workoutRepository, IWorkoutSessionRepository workoutSessionRepository, IUnitOfWork unitOfWork)
        {
            _workoutRepository = workoutRepository;
            _workoutSessionRepository = workoutSessionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> CreateWorkoutSession(Guid userId, StartWorkoutSessionRequest request)
        {
            var workout = await _workoutRepository.GetWorkoutByIdAsync(request.WorkoutId);

            //Validate
            if (workout is null)
                throw new InvalidOperationException("Workout not found");

            //Check if this workout belongs to the user
            if (workout.UserId != userId)
                throw new UnauthorizedAccessException("You do not have permission to start a session for this workout");

            //create session
            var session = new WorkoutSession
            {
                Id = Guid.NewGuid(),
                WorkoutId = workout.Id,
                PerformedAt = DateTime.UtcNow
            };

            //Save changes
            await _workoutSessionRepository.AddAsync(session);
            await _unitOfWork.SaveChangesAsync();

            //Return sessionId
            return session.Id;
        }
    }
}

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
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public WorkoutSessionService(IWorkoutRepository workoutRepository, 
                                    IWorkoutSessionRepository workoutSessionRepository, 
                                    IExerciseRepository exerciseRepository, 
                                    IUnitOfWork unitOfWork)
        {
            _workoutRepository = workoutRepository;
            _workoutSessionRepository = workoutSessionRepository;
            _exerciseRepository = exerciseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> StartWorkoutSessionAsync(Guid userId, StartWorkoutSessionRequest request)
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
                StartedAt = DateTime.UtcNow
            };

            //Save changes
            await _workoutSessionRepository.AddAsync(session);
            await _unitOfWork.SaveChangesAsync();

            //Return sessionId
            return session.Id;
        }

        public async Task<Guid> AddExerciseSetAsync(Guid userId, AddExerciseRequest request)
        {
            var session = await _workoutSessionRepository.GetByIdAsync(request.SessionId);

            //Validate
            if (session is null)
                throw new InvalidOperationException("Workout session not found");

            if (session.Workout.UserId != userId)
                throw new UnauthorizedAccessException("You do not have permission to add an exercise set to this session");


            var exercise = await _exerciseRepository.GetByIdAsync(request.ExerciseId);

            if (exercise is null)
                throw new InvalidOperationException("Exercise not found");

            //Create exercise set
            var exerciseSet = new ExerciseSet
            {
                Id = Guid.NewGuid(),
                WorkoutSessionId = session.Id,
                ExerciseId = exercise.Id,
                Reps = request.Reps,
                Weight = request.Weight,
                SetNumber = request.SetNumber
            };

            //Attach to session (aggregate root)
            session.ExerciesSets.Add(exerciseSet);

            //Persist changes
            await _unitOfWork.SaveChangesAsync();

            return exerciseSet.Id;
        }

        public async Task<Guid> EndWorkoutSessionAsync(Guid userId, EndWorkoutSessionRequest request)
        {
            var session = await _workoutSessionRepository.GetByIdAsync(request.SessionId);

            //Validate
            if (session is null)
                throw new InvalidOperationException("Workout session not found");

            //Validate ownership
            if (session.Workout.UserId != userId)
                throw new UnauthorizedAccessException("You do not have permission to end this session");

            if (session.EndedAt is not null)
                throw new InvalidOperationException("This session has already been ended");

            //End session
            session.EndedAt = DateTime.UtcNow;

            //Save
            await _unitOfWork.SaveChangesAsync();

            return session.Id;
        }
    }
}

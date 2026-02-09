using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Application.DTOs.Requests;
using WorkoutTracker.Application.DTOs.Response;
using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Domain.Entities;
using WorkoutTracker.Domain.RepositoryInterface;

namespace WorkoutTracker.Application.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IUnitOfWork _unitOfWork;

        public WorkoutService(IWorkoutRepository workoutRepository, IUnitOfWork unitOfWork)
        {
            _workoutRepository = workoutRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> CreateWorkoutAsync(Guid userId, CreateWorkoutRequest request)
        {
            //Map DTO to entity
            var workout = new Workout
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Name = request.Name,
                Description = request.Description
            };

            //Add to repository and save
            await _workoutRepository.AddAsync(workout);
            await _unitOfWork.SaveChangesAsync();

            //Return id for now - in a real app we might return the full workout or a DTO
            return workout.Id;
        }

        public async Task<IReadOnlyList<WorkoutListResponse>> GetWorkoutsByUserAsync(Guid userId)
        {
            var workouts = await _workoutRepository.GetByUserIdAsync(userId);

            var response = new List<WorkoutListResponse>();

            foreach (var workout in workouts)
            {
                response.Add(new WorkoutListResponse
                {
                    Id = workout.Id,
                    Name = workout.Name,
                    Description = workout.Description
                });
            }

            return response;
        }

        public async Task<WorkoutDetailsResponse> GetWorkoutById(Guid workoutId)
        {
            var workout = await _workoutRepository.GetWorkoutByIdAsync(workoutId);

            if (workout == null)
                throw new InvalidOperationException("Workout not found");

            return new WorkoutDetailsResponse
            {
                Id = workout.Id,
                Name = workout.Name,
                Description = workout.Description
            };
        }
    }
}

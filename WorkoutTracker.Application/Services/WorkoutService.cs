using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Application.DTOs;
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
    }
}

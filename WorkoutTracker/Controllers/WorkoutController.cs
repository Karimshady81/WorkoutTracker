using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Application.DTOs.Requests;
using WorkoutTracker.Application.Interfaces;

namespace WorkoutTracker.API.Controllers
{
    [Route("api/workout")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpPost("create-workout")]
        public async Task<IActionResult> CreateWorkout([FromQuery] Guid userId, [FromBody] CreateWorkoutRequest request)
        {
            var workoutId = await _workoutService.CreateWorkoutAsync(userId, request);

            return CreatedAtAction(
                nameof(GetWorkoutById),
                new { workoutId },
                workoutId);
        }

        [HttpGet("user-workouts")]
        public async Task<IActionResult> GetWorkouts([FromQuery] Guid userId)
        {
            var workouts = await _workoutService.GetWorkoutsByUserAsync(userId);

            return Ok(workouts);
        }

        [HttpGet("{workoutId}")]
        public async Task<IActionResult> GetWorkoutById(Guid workoutId)
        {
            var workout = await _workoutService.GetWorkoutById(workoutId);

            return Ok(workout);
        }

    }
}

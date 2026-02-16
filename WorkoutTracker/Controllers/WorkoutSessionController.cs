using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Application.DTOs.Requests;
using WorkoutTracker.Application.Interfaces;

namespace WorkoutTracker.API.Controllers
{
    [Route("api/workout-session")]
    [ApiController]
    public class WorkoutSessionController : ControllerBase
    {
        private readonly IWorkoutSessionService _workoutSession;

        public WorkoutSessionController(IWorkoutSessionService workoutSession)
        {
            _workoutSession = workoutSession;
        }

        [HttpPost("start")]
        public async Task<IActionResult> StartWorkoutSession([FromQuery]Guid userId, [FromBody] StartWorkoutSessionRequest request)
        {
            var session = await _workoutSession.StartWorkoutSessionAsync(userId, request);

            return Ok(session);
        }

        [HttpPost("add-exercises")]
        public async Task<IActionResult> AddExercises([FromQuery] Guid userId, [FromBody] AddExerciseRequest request)
        {
            var exercisesAdded = await _workoutSession.AddExerciseSetAsync(userId, request);

            return Ok(exercisesAdded);
        }

        [HttpPost("end")]
        public async Task<IActionResult> EndWorkoutSession(Guid userId, EndWorkoutSessionRequest request)
        {
            var endSession = await _workoutSession.EndWorkoutSessionAsync(userId, request);

            return Ok(endSession);
        }

        [HttpGet("session/{sessionId}")]
        public async Task<IActionResult> GetSessionDetails([FromQuery] Guid userId,Guid sessionId)
        {
            var session = await _workoutSession.GetSessionDetailsAsync(userId, sessionId);

            return Ok(session);
        }
    }
}

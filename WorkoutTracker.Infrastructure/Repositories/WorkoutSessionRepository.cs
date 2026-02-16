using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Domain.Entities;
using WorkoutTracker.Domain.RepositoryInterface;
using WorkoutTracker.Infrastructure.Data;

namespace WorkoutTracker.Infrastructure.Repositories
{
    public class WorkoutSessionRepository : IWorkoutSessionRepository
    {
        private readonly AppDbContext _context;

        public WorkoutSessionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(WorkoutSession workoutSession)
        {
            await _context.WorkoutSessions.AddAsync(workoutSession);
        }

        public void Delete(WorkoutSession workoutSession)
        {
            _context.WorkoutSessions.Remove(workoutSession);
        }

        //We want the session details
        public async Task<WorkoutSession?> GetByIdAsync(Guid id)
        {
            return await _context.WorkoutSessions.FirstOrDefaultAsync(ws => ws.Id == id);
        }
        public async Task<WorkoutSession?> GetWithDetailsByIdAsync(Guid sessionId)
        {
            return await _context.WorkoutSessions
                                            .Include(ws => ws.Workout)
                                            .Include(ws => ws.ExerciseSets)
                                                .ThenInclude(es => es.Exercise)
                                            .FirstOrDefaultAsync(ws => ws.Id == sessionId);
        }

        //We want the workout history (WorkoutSession → Workout → User)
        public async Task<IReadOnlyList<WorkoutSession>> GetByUserIdAsync(Guid userId)
        {
            return await _context.WorkoutSessions.Include(ws => ws.Workout)
                                                 .Where(ws => ws.Workout.UserId == userId)
                                                 .OrderByDescending(ws => ws.StartedAt)
                                                 .ToListAsync();
        }
    }
}

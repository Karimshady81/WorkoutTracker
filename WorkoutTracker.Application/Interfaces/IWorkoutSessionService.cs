using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Application.DTOs.Requests;

namespace WorkoutTracker.Application.Interfaces
{
    public interface IWorkoutSessionService
    {
        Task<Guid> CreateWorkoutSession(Guid userId,StartWorkoutSessionRequest request);
    }
}

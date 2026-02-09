using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Application.DTOs;

namespace WorkoutTracker.Application.Interfaces
{
    public interface IWorkoutService
    {
        Task<Guid> CreateWorkoutAsync(Guid userId, CreateWorkoutRequest request);
    }
}

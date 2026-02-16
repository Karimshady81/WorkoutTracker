using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Application.DTOs.Requests;
using WorkoutTracker.Application.DTOs.Response;

namespace WorkoutTracker.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterUserAsync(RegisterRequest request);
        Task<AuthResponse?> LoginUserAsync(LoginRequest request);
    }
}

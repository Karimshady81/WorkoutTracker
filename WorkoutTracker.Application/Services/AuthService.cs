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

using WorkoutTracker.Application.Security_Interface;

namespace WorkoutTracker.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUserRepository userRepository, 
                           IPasswordHasher passwordHasher, 
                           IJwtGenerator jwtGenerator, 
                           IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtGenerator = jwtGenerator;
            _unitOfWork = unitOfWork;
        }

        public async Task<AuthResponse> RegisterUserAsync(RegisterRequest request)
        {
            //Validate inputs first
            if (string.IsNullOrEmpty(request.Email))
                throw new InvalidOperationException("Email is required.");

            if (string.IsNullOrEmpty(request.Password))
                throw new InvalidOperationException("Password is required.");

            //Check if user already exists
            if (await _userRepository.GetUserByEmailAsync(request.Email) != null)
                throw new InvalidOperationException("User with this email already exists.");

            //Map
            var user = new User
            {
                Email = request.Email,
                PasswordHash = _passwordHasher.Hash(request.Password)
            };

            //Generate JWT token
            var token =  _jwtGenerator.GenerateToken(user.Id.ToString(), user.Email);

            //Save to database
            await _userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return new AuthResponse
            {
                userId = user.Id,
                Token = token
            };
        }

        public async Task<AuthResponse?> LoginUserAsync(LoginRequest request)
        {
            //Validate inputs first
            if (string.IsNullOrEmpty(request.Email))
                throw new InvalidOperationException("Email is required.");

            if (string.IsNullOrEmpty(request.Password))
                throw new InvalidOperationException("Password is required.");

            //Check if user exists
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            
            if (user == null || !_passwordHasher.Verify(request.Password, user.PasswordHash))
                throw new InvalidOperationException("Invalid email or password.");

            var token = _jwtGenerator.GenerateToken(user.Id.ToString(), user.Email);

            return new AuthResponse
            {
                Token = token,
                userId = user.Id
            };
            
        }

    }
}

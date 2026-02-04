using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Domain.RepositoryInterface
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(Guid Id); // find user by identifier
        Task<User?> GetUserByEmailAsync(string email); // find user by identifier
        Task AddAsync(User user);  // create new user account
    }
}

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
        Task<User?> GetUserByIdAsync(Guid Id); 
        Task<User?> GetUserByEmailAsync(string email);
        Task AddAsync(User user);
    }
}

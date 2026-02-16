using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker.Application.Security_Interface
{
    public interface IJwtGenerator
    {
        string GenerateToken(string userId, string email);
    }
}

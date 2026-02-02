using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }

        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        //represent the User → Workout (1-to-many) relationship
        public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
    }
}

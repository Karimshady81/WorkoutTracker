using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker.Domain.Entities
{
    public class Workout
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; } // FK (DB truth)
        public User User { get; set; } = null!; // Navigation (code truth)
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }



        //represent the Workout ↔ Exercise  (many-to-many) relationship, resolved by WorkoutExercise
        public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();

        //represent the Workout ↔ WorkoutSession (one-to-many) relationship
        public ICollection<WorkoutSession> WorkoutSessions { get; set; } = new List<WorkoutSession>();
    }
}

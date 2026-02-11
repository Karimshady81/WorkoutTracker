using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker.Domain.Entities
{
    public class WorkoutSession
    {
        public Guid Id { get; set; }
        public Guid WorkoutId { get; set; } // FK (DB truth)
        public Workout Workout { get; set; } = null!; // Navigation (code truth)

        public DateTime StartedAt { get; set; }

        public DateTime? EndedAt { get; set; }


        //represent the WorkoutSession -> WorkoutExercise  (one-to-many) relationship
        public ICollection<ExerciseSet> ExerciseSets { get; set; } = new List<ExerciseSet>();
    }
}

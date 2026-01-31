using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker.Domain.Entities
{
    public class ExerciseSet
    {
        public Guid Id { get; set; }

        public Guid WorkoutSessionId { get; set; } // FK to WorkoutSession
        public WorkoutSession WorkoutSession { get; set; } = null!; // Navigation to WorkoutSession

        public Guid ExerciseId { get; set; } // FK to Exercise
        public Exercise Exercise { get; set; } = null!; // Navigation to Exercise


        public int SetNumber { get; set; }
        public double Weight { get; set; }
        public int Reps { get; set; }
    }
}

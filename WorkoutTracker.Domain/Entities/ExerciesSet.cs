using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker.Domain.Entities
{
    public class ExerciesSet
    {
        public Guid Id { get; set; }

        public Guid WorkoutSessionId { get; set; } // FK to WorkoutSession
        public WorkoutSession WorkoutSession { get; set; } = null!; // Navigation to WorkoutSession


        public int SetNumber { get; set; }
        public double Weight { get; set; }
        public int Reps { get; set; }
    }
}

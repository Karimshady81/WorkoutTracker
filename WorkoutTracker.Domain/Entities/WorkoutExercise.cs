using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker.Domain.Entities
{
    public class WorkoutExercise
    {
        public Guid Id { get; set; }

        public Guid WorkoutId { get; set; } // FK to Workout
        public Workout Workout { get; set; } = null!; // Navigation to Workout

        public Guid ExerciseId { get; set; } // FK to Exercise
        public Exercise Exercise { get; set; } = null!; // Navigation to Exercise


        public int OrderInWorkout { get; set; }
        public int TargetSets { get; set; }
        public int TargetReps { get; set; }
        public int RestSeconds { get; set; }
    }
}

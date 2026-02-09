using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker.Application.DTOs.Requests
{
    public class AddExerciseRequest
    {
        public Guid SessionId { get; set; }
        public Guid ExerciseId { get; set; }

        public int SetNumber { get; set; }
        public int Reps { get; set; }
        public double Weight { get; set; }
    }
}

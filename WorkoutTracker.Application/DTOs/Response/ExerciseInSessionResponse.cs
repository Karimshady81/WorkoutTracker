using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker.Application.DTOs.Response
{
    public class ExerciseInSessionResponse
    {
        public Guid ExerciseId { get; set; }
        public string ExerciseName { get; set; } = null!;
        public List<ExerciseSetResponse> Sets { get; set; } = new();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker.Application.DTOs.Response
{
    public class WorkoutSessionDetailsResponse
    {
        public Guid SessionId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }

        public List<ExerciseInSessionResponse> Exercises { get; set; } = new();
    }
}

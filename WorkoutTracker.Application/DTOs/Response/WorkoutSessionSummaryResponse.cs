using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker.Application.DTOs.Response
{
    public class WorkoutSessionSummaryResponse
    {
        public Guid SessionId { get; set; }
        public string WorkoutName { get; set; } = string.Empty;
        public DateTime StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker.Application.DTOs.Requests
{
    public class EndWorkoutSessionRequest
    {
        public Guid SessionId { get; set; }
    }
}

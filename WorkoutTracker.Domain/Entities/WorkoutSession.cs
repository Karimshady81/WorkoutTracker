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
        public DateTime PerformedAt { get; set; }
    }
}

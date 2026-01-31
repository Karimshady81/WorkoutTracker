using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker.Domain.Entities
{
    public class WorkoutExercies
    {
        public Guid Id { get; set; }
        public int OrderInWorkout { get; set; }
        public int TargetSets { get; set; }
        public int TargetReps { get; set; }
        public int RestSeconds { get; set; }
    }
}

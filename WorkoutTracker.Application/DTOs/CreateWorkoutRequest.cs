using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker.Application.DTOs
{
    public class CreateWorkoutRequest
    {
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}

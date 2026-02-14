using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Domain.RepositoryInterface
{
    public interface IExerciseSetRepository
    {
        Task AddAsync(ExerciseSet exerciseSet);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Requests
{
    public class ExerciseEntriesEditRequest : BaseUserDelegatedRequest
    {
        public long ShiftToExerciseId { get; set; }
        public long ShiftFromExerciseId { get; set; }
        public int Minutes { get; set; }
        public DateTime DateUTC { get; set; }
    }

    public class ExerciseEntriesEditCustomRequest : BaseUserDelegatedRequest
    {
        public string CustomExerciseName { get; set; }
        public int CaloriesBurned { get; set; }
        public long ShiftFromExerciseId { get; set; }
        public int Minutes { get; set; }
        public DateTime DateUTC { get; set; }
    }
}

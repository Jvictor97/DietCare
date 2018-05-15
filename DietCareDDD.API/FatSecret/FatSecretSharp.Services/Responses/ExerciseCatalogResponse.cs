using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FatSecretSharp.Services;

namespace FatSecretSharp.Services.Responses
{
    /// <summary>
    /// Exercise details.
    /// </summary>
    public class ExerciseInfo
    {
        public long exercise_id { get; set; }
        public string exercise_name { get; set; }
    }

    /// <summary>
    /// A wrapper around the exercise details, because the FatSecret api response is formatted that way.
    /// </summary>
    public class ExerciseTypeWrapper
    {
        public List<ExerciseInfo> exercise { get; set; }
    }

    /// <summary>
    /// The exercise catalog response.  A list of exercises.
    /// </summary>
    public class ExerciseCatalogResponse
    {
        public ExerciseTypeWrapper exercises { get; set; }

        public bool HasResult
        {
            get
            {
                return exercises != null && exercises.exercise != null && exercises.exercise.Count > 0;
            }
        }
    }    
}




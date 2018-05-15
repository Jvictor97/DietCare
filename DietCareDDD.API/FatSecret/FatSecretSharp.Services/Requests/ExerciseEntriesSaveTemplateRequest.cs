using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Requests
{
    public class ExerciseEntriesSaveTemplateRequest : BaseUserDelegatedRequest
    {
        public DateTime DateUTC { get; set; }
        public List<DayOfWeek> Days { get; set; }

        public ExerciseEntriesSaveTemplateRequest()
        {
            Days = new List<DayOfWeek>();
        }
    }
}

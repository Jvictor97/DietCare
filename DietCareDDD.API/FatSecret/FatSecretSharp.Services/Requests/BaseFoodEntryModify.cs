using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Requests
{
    public enum MealType
    {
        breakfast = 0,
        lunch = 1,
        dinner = 2,
        other = 3
    }

    public class BaseFoodEntryModify : BaseUserDelegatedRequest
    {
        public string EntryName { get; set; }
        public long ServingId { get; set; }
        public double NumberOfServings { get; set; }
        public MealType Meal { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Requests
{
    public class SavedMealGetRequest : BaseUserDelegatedRequest
    {
        public bool MatchSpecificMeal { get; set; }
        public MealType SpecificMeal { get; set; }
    }
}

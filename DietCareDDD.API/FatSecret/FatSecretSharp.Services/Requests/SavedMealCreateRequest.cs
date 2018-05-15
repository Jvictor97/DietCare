using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Requests
{
    public class SavedMealCreateRequest : BaseUserDelegatedRequest
    {
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<MealType> SuitableMeals { get; set; }

        public SavedMealCreateRequest()
            : this(new MealType[] { })
        {

        }

        public SavedMealCreateRequest(params MealType[] meals)
        {
            SuitableMeals = new List<MealType>(meals);
        }
    }
}

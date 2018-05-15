using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Requests
{
    public class FoodEntryCopyRequest : BaseUserDelegatedRequest
    {
        public DateTime FromDateUTC { get; set; }
        public DateTime ToDateUTC { get; set; }

        public bool SpecifyMeal { get; set; }

        /// <summary>
        /// Optional
        /// </summary>
        public MealType Meal { get; set; }
    }
}

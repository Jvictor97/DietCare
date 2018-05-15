using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services
{
    using FatSecretSharp.Services.Requests;
    using FatSecretSharp.Services.Responses;
    using FatSecretSharp.Services.Common;

    public class SavedMealCreate : BaseFatSecretGetService<SavedMealCreateRequest, SavedMealCreateResponse>
    {
        public SavedMealCreate(string key, string secret)
            : base(key, secret, FatSecretAPIMethods.SavedMeal_Create)
        { }

        protected override string CreateRequestUrl(SavedMealCreateRequest request)
        {
            var parms = new Dictionary<string, string>(GenerateMethodAndFormatParmsDictionary())
            {
                { "saved_meal_name", request.MealName },
                { "saved_meal_description", request.MealDescription },
            };

            if (request.SuitableMeals != null && request.SuitableMeals.Count > 0)
            {
                var meals = String.Join(",", request.SuitableMeals.Select(x => x.ToString()).ToArray());
                parms.Add("meals", meals);
            }

            return builder.CreateRestAPIGETUrl(parms, request.UserToken, request.UserSecret);
        }
    }
}

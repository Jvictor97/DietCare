using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services
{
    using FatSecretSharp.Services.Requests;
    using FatSecretSharp.Services.Responses;
    using FatSecretSharp.Services.Common;

    public class SavedMealItemAdd : BaseFatSecretGetService<SavedMealItemAddRequest, SavedMealItemAddResponse>
    {
        public SavedMealItemAdd(string key, string secret)
            : base(key, secret, FatSecretAPIMethods.SavedMeal_AddItem)
        { }

        protected override string CreateRequestUrl(SavedMealItemAddRequest request)
        {
            var parms = new Dictionary<string, string>(GenerateMethodAndFormatParmsDictionary())
            {
                { "saved_meal_id", request.SavedMealId.ToString() },
                { "saved_meal_item_name", request.Name },
                { "food_id", request.FoodId.ToString() },
                { "serving_id", request.ServingId.ToString() },
                { "number_of_units", request.NumServings.ToString() },
            };

            return builder.CreateRestAPIGETUrl(parms, request.UserToken, request.UserSecret);
        }
    }
}

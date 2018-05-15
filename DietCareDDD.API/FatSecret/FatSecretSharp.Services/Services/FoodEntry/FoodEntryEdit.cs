using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services
{
    using FatSecretSharp.Services.Requests;
    using FatSecretSharp.Services.Responses;
    using FatSecretSharp.Services.Common;

    public class FoodEntryEdit : BaseFatSecretGetService<FoodEntryEditRequest, FoodEntryEditResponse>
    {
        public FoodEntryEdit(string key, string secret)
            : base(key, secret, FatSecretAPIMethods.FoodEntry_Edit)
        { }

        protected override string CreateRequestUrl(FoodEntryEditRequest request)
        {
            var parms = new Dictionary<string, string>(GenerateMethodAndFormatParmsDictionary())
            {
                { "food_entry_id", request.EntryId.ToString() },
                { "food_entry_name", request.EntryName },
                { "serving_id", request.ServingId.ToString() },
                { "number_of_units", request.NumberOfServings.ToString() },
                { "meal", request.Meal.ToString() }
            };

            return builder.CreateRestAPIGETUrl(parms, request.UserToken, request.UserSecret);
        }
    }
}

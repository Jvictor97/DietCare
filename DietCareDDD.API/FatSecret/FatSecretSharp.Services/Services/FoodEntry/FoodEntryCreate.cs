using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FatSecretSharp.Services.Common;
using FatSecretSharp.Services.Requests;
using FatSecretSharp.Services.Responses;

namespace FatSecretSharp.Services
{
    public class FoodEntryCreate : BaseFatSecretGetService<FoodEntryCreateRequest, FoodEntryCreateResponse>
    {
        public FoodEntryCreate(string key, string secret)
            : base(key, secret, FatSecretAPIMethods.FoodEntry_Create)
        {

        }

        protected override string CreateRequestUrl(FoodEntryCreateRequest request)
        {
            var parms = new Dictionary<string, string>(GenerateMethodAndFormatParmsDictionary())
            {
                { "food_id", request.FoodId.ToString() },
                { "food_entry_name", request.EntryName },
                { "serving_id", request.ServingId.ToString() },
                { "number_of_units", request.NumberOfServings.ToString() },
                { "meal", request.Meal.ToString() },
                { "date", request.DateUTC.ToDaysSinceJan11970().ToString() }
            };

            return builder.CreateRestAPIGETUrl(parms, request.UserToken, request.UserSecret);
        }
    }
}

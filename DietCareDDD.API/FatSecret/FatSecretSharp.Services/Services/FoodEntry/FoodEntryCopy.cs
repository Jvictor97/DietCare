using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services
{
    using FatSecretSharp.Services.Requests;
    using FatSecretSharp.Services.Responses;
    using FatSecretSharp.Services.Common;

    public class FoodEntryCopy : BaseFatSecretGetService<FoodEntryCopyRequest, FoodEntryCopyResponse>
    {
        public FoodEntryCopy(string key, string secret)
            : base(key, secret, FatSecretAPIMethods.FoodEntry_Copy)
        { }

        protected override string CreateRequestUrl(FoodEntryCopyRequest request)
        {
            var parms = new Dictionary<string, string>(GenerateMethodAndFormatParmsDictionary())
            {
                { "from_date", request.FromDateUTC.ToDaysSinceJan11970().ToString() },
                { "to_date", request.ToDateUTC.ToDaysSinceJan11970().ToString() },
            };

            if (request.SpecifyMeal)
            {
                parms.Add("meal", request.Meal.ToString());
            }

            return builder.CreateRestAPIGETUrl(parms, request.UserToken, request.UserSecret);
        }
    }
}

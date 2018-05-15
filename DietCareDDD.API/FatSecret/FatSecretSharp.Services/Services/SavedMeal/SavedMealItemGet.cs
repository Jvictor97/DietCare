using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services
{
    using FatSecretSharp.Services.Requests;
    using FatSecretSharp.Services.Responses;
    using FatSecretSharp.Services.Common;

    public class SavedMealItemGet : BaseFatSecretGetService<SavedMealItemGetRequest, SavedMealItemGetResponse>
    {
        public SavedMealItemGet(string key, string secret)
            : base(key, secret, FatSecretAPIMethods.SavedMeal_GetItems)
        { }

        protected override string CreateRequestUrl(SavedMealItemGetRequest request)
        {
            var parms = new Dictionary<string, string>(GenerateMethodAndFormatParmsDictionary())
            {
                { "saved_meal_id", request.saved_meal_id.ToString() },
            };

            return builder.CreateRestAPIGETUrl(parms, request.UserToken, request.UserSecret);
        }
    }
}

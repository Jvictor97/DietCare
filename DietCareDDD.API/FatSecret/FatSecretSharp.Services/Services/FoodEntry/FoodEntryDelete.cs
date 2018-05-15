using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FatSecretSharp.Services.Common;
using FatSecretSharp.Services.Requests;
using FatSecretSharp.Services.Responses;

namespace FatSecretSharp.Services
{
    public class FoodEntryDelete : BaseFatSecretGetService<FoodEntryDeleteRequest, FoodEntryDeleteResponse>
    {
        public FoodEntryDelete(string key, string secret)
            : base(key, secret, FatSecretAPIMethods.FoodEntry_Delete)
        {

        }

        protected override string CreateRequestUrl(FoodEntryDeleteRequest request)
        {
            var parms = new Dictionary<string, string>(GenerateMethodAndFormatParmsDictionary())
            {
                { "food_entry_id", request.food_entry_id.ToString() }
            };

            return builder.CreateRestAPIGETUrl(parms, request.UserToken, request.UserSecret);
        }
    }
}

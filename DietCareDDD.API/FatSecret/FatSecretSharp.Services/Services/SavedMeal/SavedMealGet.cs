using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services
{
    using FatSecretSharp.Services.Requests;
    using FatSecretSharp.Services.Responses;
    using FatSecretSharp.Services.Common;

    public class SavedMealGet : BaseFatSecretGetService<SavedMealGetRequest, SavedMealGetResponse>
    {
        public SavedMealGet(string key, string secret)
            : base(key, secret, FatSecretAPIMethods.SavedMeal_Get)
        { }

        protected override string CreateRequestUrl(SavedMealGetRequest request)
        {
            var parms = new Dictionary<string, string>(GenerateMethodAndFormatParmsDictionary())
            {

            };

            if (request.MatchSpecificMeal)
            {
                parms.Add("meal", request.SpecificMeal.ToString());
            }

            return builder.CreateRestAPIGETUrl(parms, request.UserToken, request.UserSecret);
        }
    }
}

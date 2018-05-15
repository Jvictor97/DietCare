using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services
{
    using FatSecretSharp.Services.Requests;
    using FatSecretSharp.Services.Responses;
    using FatSecretSharp.Services.Common;

    public class SavedMealDelete : BaseFatSecretGetService<SavedMealDeleteRequest, SavedMealDeleteResponse>
    {
        public SavedMealDelete(string key, string secret)
            : base(key, secret, FatSecretAPIMethods.SavedMeal_Delete)
        { }

        protected override string CreateRequestUrl(SavedMealDeleteRequest request)
        {
            var parms = new Dictionary<string, string>(GenerateMethodAndFormatParmsDictionary())
            {
                { "saved_meal_id", request.SavedMealId.ToString() },
            };

            return builder.CreateRestAPIGETUrl(parms, request.UserToken, request.UserSecret);
        }
    }
}

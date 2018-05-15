using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services
{
    using FatSecretSharp.Services.Requests;
    using FatSecretSharp.Services.Responses;
    using FatSecretSharp.Services.Common;

    public class SavedMealItemDelete : BaseFatSecretGetService<SavedMealItemDeleteRequest, SavedMealItemDeleteResponse>
    {
        public SavedMealItemDelete(string key, string secret)
            : base(key, secret, FatSecretAPIMethods.SavedMeal_DeleteItem)
        { }

        protected override string CreateRequestUrl(SavedMealItemDeleteRequest request)
        {
            var parms = new Dictionary<string, string>(GenerateMethodAndFormatParmsDictionary())
            {
                { "saved_meal_item_id", request.saved_meal_item_id.ToString() }
            };

            return builder.CreateRestAPIGETUrl(parms, request.UserToken, request.UserSecret);
        }
    }
}

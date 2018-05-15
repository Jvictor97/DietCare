using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services
{
    using FatSecretSharp.Services.Requests;
    using FatSecretSharp.Services.Responses;
    using FatSecretSharp.Services.Common;

    public class SavedMealItemEdit : BaseFatSecretGetService<SavedMealItemEditRequest, SavedMealItemEditResponse>
    {
        public SavedMealItemEdit(string key, string secret)
            : base(key, secret, FatSecretAPIMethods.SavedMeal_EditItem)
        { }

        protected override string CreateRequestUrl(SavedMealItemEditRequest request)
        {
            var parms = new Dictionary<string, string>(GenerateMethodAndFormatParmsDictionary())
            {
                { "saved_meal_item_id", request.SavedMealItemId.ToString() },
                { "saved_meal_item_name", request.SavedMealItemName },
                { "number_of_units", request.NumServings.ToString() },
            };

            return builder.CreateRestAPIGETUrl(parms, request.UserToken, request.UserSecret);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services
{
    using FatSecretSharp.Services.Requests;
    using FatSecretSharp.Services.Responses;
    using FatSecretSharp.Services.Common;

    public class FoodEntryGetMonth : BaseFatSecretGetService<FoodEntryGetMonthRequest, FoodEntryGetMonthResponse>
    {
        public FoodEntryGetMonth(string key, string secret)
            : base(key, secret, FatSecretAPIMethods.FoodEntry_GetMonth)
        { }

        protected override string CreateRequestUrl(FoodEntryGetMonthRequest request)
        {
            var parms = new Dictionary<string, string>(GenerateMethodAndFormatParmsDictionary())
            {

            };

            return builder.CreateRestAPIGETUrl(parms, request.UserToken, request.UserSecret);
        }
    }
}

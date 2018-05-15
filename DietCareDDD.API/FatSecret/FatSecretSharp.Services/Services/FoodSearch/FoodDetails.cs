using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FatSecretSharp.Services.Common;
using FatSecretSharp.Services.Requests;
using FatSecretSharp.Services.Responses;

namespace FatSecretSharp.Services
{
    public class FoodDetails : BaseFatSecretGetService<FoodDetailsRequest, FoodDetailsResponse>
    {
        public FoodDetails(string key, string secret)
            : base(key, secret, FatSecretAPIMethods.Food_Get)
        {

        }

        protected override string CreateRequestUrl(FoodDetailsRequest request)
        {
            var parms = new Dictionary<string, string>(GenerateMethodAndFormatParmsDictionary())
            {                
                { "food_id", request.FoodId.ToString() },
            };

            return builder.CreateRestAPIGETUrl(parms);
        }
    }
}

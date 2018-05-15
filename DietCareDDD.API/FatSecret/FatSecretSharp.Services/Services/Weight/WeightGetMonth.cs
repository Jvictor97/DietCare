using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FatSecretSharp.Services.Common;
using FatSecretSharp.Services.Requests;
using FatSecretSharp.Services.Responses;

namespace FatSecretSharp.Services
{
    public class WeightGetMonth : BaseFatSecretGetService<WeightGetMonthRequest, WeightGetMonthResponse>
    {
        public WeightGetMonth(string key, string secret)
            : base(key, secret, FatSecretAPIMethods.Weight_GetMonth)
        { }

        protected override string CreateRequestUrl(WeightGetMonthRequest request)
        {
            var parms = new Dictionary<string, string>(GenerateMethodAndFormatParmsDictionary())
            {
                { "date", request.MonthUTC.ToDaysSinceJan11970().ToString() }
            };

            return builder.CreateRestAPIGETUrl(parms, request.UserToken, request.UserSecret);
        }
    }
}

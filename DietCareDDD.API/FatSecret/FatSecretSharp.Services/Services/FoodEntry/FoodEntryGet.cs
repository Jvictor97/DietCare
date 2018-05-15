using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services
{
    using FatSecretSharp.Services.Requests;
    using FatSecretSharp.Services.Responses;
    using FatSecretSharp.Services.Common;

    public class FoodEntryGetDay : BaseFatSecretGetService<FoodEntryGetDayRequest, FoodEntryGetDayResponse>
    {
        public FoodEntryGetDay(string key, string secret)
            : base(key, secret, FatSecretAPIMethods.FoodEntry_Get)
        { }

        protected override string CreateRequestUrl(FoodEntryGetDayRequest request)
        {
            var parms = new Dictionary<string, string>(GenerateMethodAndFormatParmsDictionary())
            {
                { "date", request.DateUTC.ToDaysSinceJan11970().ToString() }
            };

            return builder.CreateRestAPIGETUrl(parms, request.UserToken, request.UserSecret);
        }
    }
	
	public class FoodEntryGetSingle : BaseFatSecretGetService<FoodEntryGetSingleRequest, FoodEntryGetSingleResponse>
    {
		public FoodEntryGetSingle(string key, string secret)
            : base(key, secret, FatSecretAPIMethods.FoodEntry_Get)
        { }
		
        protected override string CreateRequestUrl(FoodEntryGetSingleRequest request)
        {
            var parms = new Dictionary<string, string>(GenerateMethodAndFormatParmsDictionary())
            {
                { "food_entry_id", request.EntryId.ToString() }
            };

            return builder.CreateRestAPIGETUrl(parms, request.UserToken, request.UserSecret);
        }
    }
}

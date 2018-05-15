using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services
{
    using FatSecretSharp.Services.Requests;
    using FatSecretSharp.Services.Responses;
    using FatSecretSharp.Services.Common;

    public class ExerciseEntriesGetMonth : BaseFatSecretGetService<ExerciseEntriesGetMonthRequest, ExerciseEntriesGetMonthResponse>
    {
        public ExerciseEntriesGetMonth(string key, string secret)
            : base(key, secret, FatSecretAPIMethods.ExerciseEntries_GetMonth)
        { }

        protected override string CreateRequestUrl(ExerciseEntriesGetMonthRequest request)
        {
            var parms = new Dictionary<string, string>(GenerateMethodAndFormatParmsDictionary())
            {
                { "date", request.DateUTC.ToDaysSinceJan11970().ToString() }
            };

            return builder.CreateRestAPIGETUrl(parms, request.UserToken, request.UserSecret);
        }
    }
}

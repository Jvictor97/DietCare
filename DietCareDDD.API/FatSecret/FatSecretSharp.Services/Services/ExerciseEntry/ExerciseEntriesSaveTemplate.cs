using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services
{
    using FatSecretSharp.Services.Requests;
    using FatSecretSharp.Services.Responses;
    using FatSecretSharp.Services.Common;

    public class ExerciseEntriesSaveTemplate : BaseFatSecretGetService<ExerciseEntriesSaveTemplateRequest, ExerciseEntriesSaveTemplateResponse>
    {
        public ExerciseEntriesSaveTemplate(string key, string secret)
            : base(key, secret, FatSecretAPIMethods.ExerciseEntries_SaveTemplate)
        { }

        protected override string CreateRequestUrl(ExerciseEntriesSaveTemplateRequest request)
        {
            var parms = new Dictionary<string, string>(GenerateMethodAndFormatParmsDictionary())
            {
                { "date", request.DateUTC.ToDaysSinceJan11970().ToString() },
                { "days", request.Days.ToDaysIntMask().ToString() }
            };

            return builder.CreateRestAPIGETUrl(parms, request.UserToken, request.UserSecret);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services
{
    using FatSecretSharp.Services.Requests;
    using FatSecretSharp.Services.Responses;
    using FatSecretSharp.Services.Common;

    public class ExerciseEntriesEdit : BaseFatSecretGetService<ExerciseEntriesEditRequest, ExerciseEntriesEditResponse>
    {
        public ExerciseEntriesEdit(string key, string secret)
            : base(key, secret, FatSecretAPIMethods.ExerciseEntries_Edit)
        { }

        protected override string CreateRequestUrl(ExerciseEntriesEditRequest request)
        {
            var parms = new Dictionary<string, string>(GenerateMethodAndFormatParmsDictionary())
            {
                { "shift_to_id", request.ShiftToExerciseId.ToString() },
                { "shift_from_id", request.ShiftFromExerciseId.ToString() },
                { "minutes", request.Minutes.ToString() },
                { "date", request.DateUTC.ToDaysSinceJan11970().ToString() },
            };

            return builder.CreateRestAPIGETUrl(parms, request.UserToken, request.UserSecret);
        }
    }

    public class ExerciseEntriesEditCustom : BaseFatSecretGetService<ExerciseEntriesEditCustomRequest, ExerciseEntriesEditResponse>
    {
        public ExerciseEntriesEditCustom(string key, string secret)
            : base(key, secret, FatSecretAPIMethods.ExerciseEntries_Edit)
        { }

        protected override string CreateRequestUrl(ExerciseEntriesEditCustomRequest request)
        {
            var parms = new Dictionary<string, string>(GenerateMethodAndFormatParmsDictionary())
            {
                { "shift_to_id", "0" },
                { "shift_from_id", request.ShiftFromExerciseId.ToString() },
                { "shift_to_name", request.CustomExerciseName },
                { "kcal", request.CaloriesBurned.ToString() },
                { "minutes", request.Minutes.ToString() },
                { "date", request.DateUTC.ToDaysSinceJan11970().ToString() },
            };

            return builder.CreateRestAPIGETUrl(parms, request.UserToken, request.UserSecret);
        }
    }
}

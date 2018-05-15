using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FatSecretSharp.Services.Common;
using FatSecretSharp.Services.Requests;
using FatSecretSharp.Services.Responses;

namespace FatSecretSharp.Services
{
    public class WeightUpdate : BaseFatSecretGetService<WeightUpdateRequest, WeightUpdateResponse>
    {
        public WeightUpdate(string key, string secret)
            : base(key, secret, FatSecretAPIMethods.Weight_Update)
        {

        }

        protected override string CreateRequestUrl(WeightUpdateRequest request)
        {
            var parms = new Dictionary<string, string>(GenerateMethodAndFormatParmsDictionary())
            {
                { "date", request.UpdateDate.ToDaysSinceJan11970().ToString() },
                { "current_weight_kg", request.CurrentWeight_KG.ToString() },
                { "weight_type", request.WeightMeasurementType.ToString() },
                { "height_type", request.HeightMeasurementType.ToString() },
                { "goal_weight_kg", request.GoalWeight_KG.ToString() },
                { "current_height_cm", request.CurrentHeight_CM.ToString() },
                { "comment", request.Comment }
            };

            return builder.CreateRestAPIGETUrl(parms, request.UserToken, request.UserSecret);
        }
    }
}

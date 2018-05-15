using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FatSecretSharp.Services.Common;
using FatSecretSharp.Services.Common.Service4u2Lib.Json;

namespace FatSecretSharp.Services.Responses
{
    public class WeightUpdateInfo
    {
        public int date_int { get; set; }
        public string weight_comment { get; set; }
        public double weight_kg { get; set; }

        public DateTime DateUTC
        {
            get
            {
                return Helpers.FromDaysSinceJan11970(date_int);
            }
        }

        public double WeightPounds
        {
            get
            {
                return weight_kg.ToPounds();
            }
        }
    }

    public class MonthWrapper
    {
        public List<WeightUpdateInfo> day { get; set; }
    }

    public class WeightGetMonthResponse : IJSONMassager
    {
        public MonthWrapper month { get; set; }

        #region IJSONMassager Members

        public string MassageJSON(string json)
        {
            
            if (json.Contains("["))
                return json;

            // Sometimes the 'day' field is not a collection, we are going to add the [ and ] if they are not there.

            var startPos = json.LastIndexOf("{");
            var endPos = json.IndexOf("}");

            json = json.Insert(startPos, "[");
            json = json.Insert(endPos + 2, "]");

            return json;
        }

        #endregion
    }
}

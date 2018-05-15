using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FatSecretSharp.Services.Common;
using FatSecretSharp.Services.Common.Service4u2Lib.Json;
using Service4u2.Json;

namespace FatSecretSharp.Services.Responses
{
    public class EntryDayInfo
    {
        public int date_int { get; set; }
        public double calories { get; set; }
        public double carbohydrate { get; set; }
        public double protein { get; set; }
        public double fat { get; set; }

        public DateTime DateUTC
        {
            get
            {
                return Helpers.FromDaysSinceJan11970(date_int);
            }
        }
    }

    public class DayWrapper<T>
    {
        public int from_date_int { get; set; }
        public int to_date_int { get; set; }

        public T day { get; set; }

        public DateTime FromDateUTC
        {
            get
            {
                return Helpers.FromDaysSinceJan11970(from_date_int);
            }
        }

        public DateTime ToDateUTC
        {
            get
            {
                return Helpers.FromDaysSinceJan11970(to_date_int);
            }
        }
    }

    public class FoodEntryGetMonthResponse : IJSONSelfSerialize<FoodEntryGetMonthResponse>
    {
        public DayWrapper<List<EntryDayInfo>> month { get; set; }

        #region IJSONSelfSerialize<FoodEntryGetMonthResponse> Members

        public FoodEntryGetMonthResponse SelfSerialize(string json)
        {
            var single = JsonHelper.Deserialize<FoodEntryGetMonthSingleResponse>(json);
            if (single != null && single.HasValue)
            {
                return new FoodEntryGetMonthResponse()
                {
                    month = new DayWrapper<List<EntryDayInfo>>()
                    {
                        from_date_int = single.month.from_date_int,
                        to_date_int = single.month.to_date_int,
                        day = new List<EntryDayInfo>()
                        {
                            single.month.day
                        }
                    }
                };
            }

            return JsonHelper.Deserialize<FoodEntryGetMonthResponse>(json);
        }

        #endregion
    }

    public class FoodEntryGetMonthSingleResponse
    {
        public DayWrapper<EntryDayInfo> month { get; set; }

        public bool HasValue
        {
            get
            {
                return month != null
                        && month.day != null
                        && month.day.date_int != 0;
            }
        }
    }
}

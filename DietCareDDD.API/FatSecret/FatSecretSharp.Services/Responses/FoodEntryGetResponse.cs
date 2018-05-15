using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FatSecretSharp.Services.Common.Service4u2Lib.Json;
using Service4u2.Json;

namespace FatSecretSharp.Services.Responses
{
    public class FoodEntryInfo : NutrientInfo
    {
        public long food_entry_id { get; set; }
        public string food_entry_description { get; set; }
        public long date_int { get; set; }
        public string meal { get; set; }
        public long food_id { get; set; }
        public long serving_id { get; set; }
        public decimal number_of_units { get; set; }
        public string food_entry_name { get; set; }
    }

    public class EntryWrapper<T>
    {
        public T food_entry { get; set; }
    }

    public class FoodEntryGetDayResponse : IJSONSelfSerialize<FoodEntryGetDayResponse>
    {
        public EntryWrapper<List<FoodEntryInfo>> food_entries { get; set; }

        #region IJSONSelfSerialize<FoodEntryGetDayResponse> Members

        public FoodEntryGetDayResponse SelfSerialize(string json)
        {
            var singleTry = JsonHelper.Deserialize<FoodEntryGetSingleResponse>(json);
            if (singleTry != null && singleTry.HasResponse)
            {
                return new FoodEntryGetDayResponse()
                {
                    food_entries = new EntryWrapper<List<FoodEntryInfo>>()
                    {
                        food_entry = new List<FoodEntryInfo>()
                        {
                            singleTry.food_entries.food_entry
                        }
                    }
                };
            }            
            
            return JsonHelper.Deserialize<FoodEntryGetDayResponse>(json);
        }

        #endregion
    }

    public class FoodEntryGetSingleResponse
    { 
        public EntryWrapper<FoodEntryInfo> food_entries { get; set; }

        public bool HasResponse
        {
            get
            {
                return food_entries != null
                        && food_entries.food_entry != null
                        && food_entries.food_entry.food_entry_id != 0;
            }
        }
    }
}

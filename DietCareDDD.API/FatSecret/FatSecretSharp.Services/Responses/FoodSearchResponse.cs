using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FatSecretSharp.Services.Common.Service4u2Lib.Json;
using Service4u2.Json;

namespace FatSecretSharp.Services.Responses
{
    /// <summary>
    /// A wrapper for the food search result.
    /// </summary>
    public class FoodSearchResult<T>
    {
        public int max_results { get; set; }
        public int total_results { get; set; }
        public int page_number { get; set; }

        public T food { get; set; }
    }

    /// <summary>
    /// A wrapper for food search results.
    /// </summary>
    public class FoodSearchResponse : IJSONSelfSerialize<FoodSearchResponse>
    {
        public FoodSearchResult<List<FoodInfo>> foods { get; set; }
        public bool HasResults 
        {
            get 
            {
                return foods != null && foods.food != null && foods.food.Count > 0;
            }
        }

        #region IJSONSelfSerialize<FoodSearchResponse> Members

        public FoodSearchResponse SelfSerialize(string json)
        {
            var single = JsonHelper.Deserialize<FoodSearchSingleResponse>(json);
            if (single != null && single.HasValue)
            {
                return new FoodSearchResponse()
                {
                    foods = new FoodSearchResult<List<FoodInfo>>()
                    {
                        max_results = single.foods.max_results,
                        page_number = single.foods.page_number,
                        total_results = single.foods.total_results,
                        food = new List<FoodInfo>()
                        {
                            single.foods.food
                        }
                    }
                };
            }

            return JsonHelper.Deserialize<FoodSearchResponse>(json);
        }

        #endregion
    }

    public class FoodSearchSingleResponse
    {
        public FoodSearchResult<FoodInfo> foods { get; set; }

        public bool HasValue
        {
            get
            {
                return foods != null
                        && foods.food != null
                        && foods.food.food_id != 0;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FatSecretSharp.Services.Common.Service4u2Lib.Json;
using Service4u2.Json;

namespace FatSecretSharp.Services.Responses
{
    public class SavedMealItemInfo
    {
        public long food_id { get; set; }
        public long saved_meal_item_id { get; set; }
        public string saved_meal_item_name { get; set; }
        public long serving_id { get; set; }
        public double number_of_units { get; set; }
    }

    public class SavedMealItemWrapper<T>
    {
        public T saved_meal_item { get; set; }
    }

    public class SavedMealItemGetResponse : IJSONSelfSerialize<SavedMealItemGetResponse>
    {
        public SavedMealItemWrapper<List<SavedMealItemInfo>> saved_meal_items { get; set; }

        #region IJSONSelfSerialize<SavedMealItemGetResponse> Members

        public SavedMealItemGetResponse SelfSerialize(string json)
        {
            var single = JsonHelper.Deserialize<SavedMealItemSingleGetResponse>(json);
            if (single.HasValue)
            {
                return new SavedMealItemGetResponse()
                {
                    saved_meal_items = new SavedMealItemWrapper<List<SavedMealItemInfo>>()
                    {
                        saved_meal_item = new List<SavedMealItemInfo>()
                        {
                            single.saved_meal_items.saved_meal_item
                        }
                    }
                };
            }

            return JsonHelper.Deserialize<SavedMealItemGetResponse>(json);
        }

        #endregion
    }

    public class SavedMealItemSingleGetResponse
    {
        public SavedMealItemWrapper<SavedMealItemInfo> saved_meal_items { get; set; }

        public bool HasValue
        {
            get
            {
                return saved_meal_items != null
                        && saved_meal_items.saved_meal_item != null
                        && saved_meal_items.saved_meal_item.saved_meal_item_id != 0;
            }
        }
    }
}

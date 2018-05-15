using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FatSecretSharp.Services.Requests;
using FatSecretSharp.Services.Common.Service4u2Lib.Json;
using Service4u2.Json;

namespace FatSecretSharp.Services.Responses
{
    public class SavedMealInfo
    {
        public long saved_meal_id { get; set; }
        public string saved_meal_name { get; set; }
        public string saved_meal_description { get; set; }
        public string meals { get; set; }

        public List<MealType> MealsParsed
        {
            get
            {
                if (String.IsNullOrEmpty(meals))
                    return new List<MealType>();

                var mealNames = meals.Split(',');
                var parsedMeals = new List<MealType>();
                foreach (var mealName in mealNames)
                {
                    parsedMeals.Add((MealType)Enum.Parse(typeof(MealType), mealName.ToLower()));
                }

                return parsedMeals;
            }
        }
    }

    public class SavedMealsWrapper<T>
    {
        public T saved_meal { get; set; }
    }

    public class SavedMealGetResponse : IJSONSelfSerialize<SavedMealGetResponse>
    {
        public SavedMealsWrapper<List<SavedMealInfo>> saved_meals { get; set; }

        #region IJSONSelfSerialize<SavedMealGetResponse> Members

        public SavedMealGetResponse SelfSerialize(string json)
        {
            var single = JsonHelper.Deserialize<SavedMealSingleGetResponse>(json);
            if (single.HasValue)
            {
                return new SavedMealGetResponse()
                {
                    saved_meals = new SavedMealsWrapper<List<SavedMealInfo>>()
                    {
                        saved_meal = new List<SavedMealInfo>()
                        {
                            single.saved_meals.saved_meal
                        }
                    }
                };
            }

            return JsonHelper.Deserialize<SavedMealGetResponse>(json);
        }

        #endregion
    }

    public class SavedMealSingleGetResponse
    {
        public SavedMealsWrapper<SavedMealInfo> saved_meals { get; set; }

        public bool HasValue
        {
            get
            {
                return saved_meals != null
                        && saved_meals.saved_meal != null
                        && saved_meals.saved_meal.saved_meal_id != 0;
            }
        }

    }
}

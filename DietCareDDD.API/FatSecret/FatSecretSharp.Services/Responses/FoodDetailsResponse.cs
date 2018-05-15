using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FatSecretSharp.Services.Common.Service4u2Lib.Json;
using System.Runtime.Serialization;
using Service4u2.Json;

namespace FatSecretSharp.Services.Responses
{
    /// <summary>
    /// Nutritional information by serving for a food.
    /// </summary>
    public class ServingInfo : NutrientInfo
    {
        public string serving_id { get; set; }
        public string serving_description { get; set; }
        public string serving_url { get; set; }
        public double metric_serving_amount { get; set; }
        public string metric_serving_unit { get; set; }
        public double number_of_units { get; set; }
        public string measurement_description { get; set; }        
    }

    /// <summary>
    /// A holder for serving information, because the FatSecret API is a tad bit verbose.
    /// </summary>
    public class MultiServingHolder : ServingHolder<List<ServingInfo>>
    { }

    /// <summary>
    /// a holder for single serving information. eg, only one serving size specified.
    /// </summary>
    public class SingleServingHolder : ServingHolder<ServingInfo>
    { }

    public class ServingHolder<T>
    {
        public T serving { get; set; }
    }

    /// <summary>
    /// A wrapper around single servings details.
    /// </summary>
    public class MultiFoodServingsDetails : FoodServingsDetails<MultiServingHolder>
    { }

    /// <summary>
    /// A wrapper around single servings details.
    /// </summary>
    public class SingleFoodServingsDetails : FoodServingsDetails<SingleServingHolder>
    { }

    /// <summary>
    /// A wrapper around multiple servings details.
    /// </summary>
    public class FoodServingsDetails<T> : FoodInfo
    {
        public T servings { get; set; }
    }

    /// <summary>
    /// The food details response details.
    /// </summary>
    public class FoodDetailsResponse : IJSONSelfSerialize<FoodDetailsResponse>
    {
        /// <summary>
        /// Gets or sets the food.
        /// </summary>
        /// <value>The found food item.</value>
        public MultiFoodServingsDetails food { get; set; }

        public bool HasResponse
        {
            get { return food != null && food.servings != null; }
        }

        #region IJSONSelfSerialize Members

        public FoodDetailsResponse SelfSerialize(string json)
        {
            var singleTry = JsonHelper.Deserialize<FoodDetailsSingleResponse>(json);
            FoodDetailsResponse response;

            // Try to see if we had a single serving element, if so add it to list in original response.
            if (singleTry != null
                    && singleTry.food != null
                    && singleTry.food.servings != null
                    && singleTry.food.servings.serving != null
                    && singleTry.food.servings.serving.serving_id != null)
            {
                response = new FoodDetailsResponse()
                {
                    food = new MultiFoodServingsDetails()
                    {
                        food_description = singleTry.food.food_description,
                        food_id = singleTry.food.food_id,
                        food_name = singleTry.food.food_name,
                        food_type = singleTry.food.food_type,
                        food_url = singleTry.food.food_url,
                        servings = new MultiServingHolder()
                        {
                            serving = new List<ServingInfo>()
                            {
                                singleTry.food.servings.serving
                            }
                        }
                    }
                };
            }
            else
                response = JsonHelper.Deserialize<FoodDetailsResponse>(json);

            return response;
        }

        #endregion
    }

    /// <summary>
    /// This is a response type for single serving responses.
    /// </summary>
    public class FoodDetailsSingleResponse
    {
        public SingleFoodServingsDetails food { get; set; }
    }
    
}

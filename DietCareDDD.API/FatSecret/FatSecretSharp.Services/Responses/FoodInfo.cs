using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Responses
{
    /// <summary>
    /// Holds information about food search results.
    /// </summary>
    public class FoodInfo
    {
        /// <summary>
        /// Gets or sets the food_id.
        /// </summary>
        /// <value>The food_id.</value>
        public long food_id { get; set; }

        /// <summary>
        /// Gets or sets the food_name.
        /// </summary>
        /// <value>The food_name.</value>
        public string food_name { get; set; }
        
        /// <summary>
        /// Gets or sets the food_type.
        /// </summary>
        /// <value>The food_type.</value>
        public string food_type { get; set; }
        
        /// <summary>
        /// Gets or sets the food_url.
        /// </summary>
        /// <value>The food_url.</value>
        public string food_url { get; set; }
        
        /// <summary>
        /// The food description; sometimes this is not included.
        /// </summary>
        public string food_description { get; set; }
    }
}

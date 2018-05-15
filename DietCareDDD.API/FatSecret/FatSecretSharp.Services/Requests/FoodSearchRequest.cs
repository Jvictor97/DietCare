using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Requests
{
    public class FoodSearchRequest
    {
        /// <summary>
        /// Gets or sets the search expression.
        /// </summary>
        /// <value>The search expression.</value>
        public string SearchExpression { get; set; }

        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        /// <value>The page number.</value>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the max results. Cannot be larger than 50.
        /// </summary>
        /// <value>The max results.</value>
        public int MaxResults { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FoodSearchRequest"/> class.
        /// </summary>
        public FoodSearchRequest()
        {
            MaxResults = 20;
            PageNumber = 0;
            SearchExpression = string.Empty;
        }
    }
}

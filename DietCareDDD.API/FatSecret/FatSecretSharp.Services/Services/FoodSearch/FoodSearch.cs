using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FatSecretSharp.Services.Common;
using FatSecretSharp.Services.Responses;
using FatSecretSharp.Services.Requests;

namespace FatSecretSharp.Services
{
    public class FoodSearch : BaseFatSecretGetService<FoodSearchRequest, FoodSearchResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FoodSearch"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="secret">The secret.</param>
        public FoodSearch(string key, string secret)
            : base(key, secret, FatSecretAPIMethods.Food_Search)
        {

        }

        protected override string CreateRequestUrl(FoodSearchRequest request)
        {
            // TODO: check for empty search expression?

            var parms = new Dictionary<string, string>(GenerateMethodAndFormatParmsDictionary())
            {                
                { "search_expression", request.SearchExpression },
                { "page_number", request.PageNumber.ToString() },
                { "max_results", request.MaxResults.ToString() }
            };

            // Return the built url.
            return builder.CreateRestAPIGETUrl(parms);
        }
    }
}

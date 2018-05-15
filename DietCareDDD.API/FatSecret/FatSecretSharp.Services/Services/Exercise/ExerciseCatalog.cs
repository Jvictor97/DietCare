using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FatSecretSharp.Services.Common;
using FatSecretSharp.Services.Requests;
using FatSecretSharp.Services.Responses;

namespace FatSecretSharp.Services
{
    public class ExerciseCatalog : BaseFatSecretGetService<ExerciseCatalogRequest, ExerciseCatalogResponse>
    {
        public ExerciseCatalog(string key, string secret)
            : base(key, secret, FatSecretAPIMethods.Exercise_Catalog)
        {

        }

        protected override string CreateRequestUrl(ExerciseCatalogRequest request)
        {
            var parms = new Dictionary<string, string>(GenerateMethodAndFormatParmsDictionary());
            
            return builder.CreateRestAPIGETUrl(parms);
        }
    }
}

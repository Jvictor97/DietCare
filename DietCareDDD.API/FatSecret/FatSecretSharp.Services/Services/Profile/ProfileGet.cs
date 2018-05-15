using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FatSecretSharp.Services.Common;
using FatSecretSharp.Services.Responses;
using FatSecretSharp.Services.Requests;

namespace FatSecretSharp.Services
{
    public class ProfileGet : BaseFatSecretGetService<ProfileGetRequest, ProfileGetResponse>
    {
        public ProfileGet(string key, string secret)
            : base(key, secret, FatSecretAPIMethods.Profile_Get)
        {

        }

        protected override string CreateRequestUrl(ProfileGetRequest request)
        {
            var parms = new Dictionary<string, string>(GenerateMethodAndFormatParmsDictionary());
            
            return builder.CreateRestAPIGETUrl(parms, request.UserToken, request.UserSecret);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FatSecretSharp.Services.Common;
using FatSecretSharp.Services.Requests;
using FatSecretSharp.Services.Responses;

namespace FatSecretSharp.Services
{
    public class ProfileGetAuthInfo : BaseFatSecretGetService<ProfileGetAuthRequest, ProfileGetAuthResponse>
    {
        public ProfileGetAuthInfo(string key, string secret)
            : base(key, secret, FatSecretAPIMethods.Profile_Get_Auth)
        {

        }

        protected override string CreateRequestUrl(ProfileGetAuthRequest request)
        {
            var parms = new Dictionary<string, string>(GenerateMethodAndFormatParmsDictionary())
            {
                {"user_id", request.UserId}
            };

            return builder.CreateRestAPIGETUrl(parms);
        }
    }
}

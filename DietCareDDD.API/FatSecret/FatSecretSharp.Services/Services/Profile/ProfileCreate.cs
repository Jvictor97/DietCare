using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FatSecretSharp.Services.Common;
using FatSecretSharp.Services.Requests;
using FatSecretSharp.Services.Responses;

namespace FatSecretSharp.Services
{
    public class ProfileCreate : BaseFatSecretGetService<ProfileCreateRequest, ProfileCreateResponse>
    {
        public ProfileCreate(string key, string secret)
            : base(key, secret, FatSecretAPIMethods.Profile_Create)
        { }

        protected override string CreateRequestUrl(ProfileCreateRequest request)
        {
            var parms = new Dictionary<string, string>(GenerateMethodAndFormatParmsDictionary());

            if (!String.IsNullOrEmpty(request.UserId))
            {
                parms.Add("user_id", request.UserId);
            }

            return builder.CreateRestAPIGETUrl(parms);
        }
    }
}

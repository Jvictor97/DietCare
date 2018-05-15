using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Responses
{
    /// <summary>
    /// A holder for OAuth key and secret info.
    /// </summary>
    public class OAuthInfo
    {
        public string auth_secret { get; set; }
        public string auth_token { get; set; }
    }
}

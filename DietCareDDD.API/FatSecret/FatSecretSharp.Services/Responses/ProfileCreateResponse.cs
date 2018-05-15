using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Responses
{
    /// <summary>
    /// Contains the created profile information.
    /// </summary>
    public class ProfileCreateResponse
    {
        public OAuthInfo profile { get; set; }
    }
}

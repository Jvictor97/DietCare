using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Requests
{
    public class BaseUserDelegatedRequest
    {
        /// <summary>
        /// The "Auth Key" of the user profile to make this request on behalf of.
        /// </summary>
        /// <value>The user token.</value>
        public string UserToken { get; set; }

        /// <summary>
        /// The "Auth Secret" of the user profile to make this request on behalf of.
        /// </summary>
        /// <value>The user secret.</value>
        public string UserSecret { get; set; }
    }
}

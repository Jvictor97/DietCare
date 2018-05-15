using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Requests
{
    public class SavedMealDeleteRequest : BaseUserDelegatedRequest
    {
        public long SavedMealId { get; set; }
    }
}

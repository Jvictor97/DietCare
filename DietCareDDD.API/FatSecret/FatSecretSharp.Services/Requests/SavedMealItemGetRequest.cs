using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Requests
{
    public class SavedMealItemGetRequest : BaseUserDelegatedRequest
    {
        public long saved_meal_id { get; set; }
    }
}

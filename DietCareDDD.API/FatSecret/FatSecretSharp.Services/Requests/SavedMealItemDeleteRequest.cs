using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Requests
{
    public class SavedMealItemDeleteRequest : BaseUserDelegatedRequest
    {
        public long saved_meal_item_id { get; set; }
    }
}

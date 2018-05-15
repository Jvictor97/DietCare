using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Requests
{
    public class FoodEntryDeleteRequest : BaseUserDelegatedRequest
    {
        public long food_entry_id { get; set; }
    }
}

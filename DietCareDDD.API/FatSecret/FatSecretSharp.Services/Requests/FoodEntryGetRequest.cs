using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Requests
{
    public class FoodEntryGetDayRequest : BaseUserDelegatedRequest
    {
        public DateTime DateUTC { get; set; }
    }

    public class FoodEntryGetSingleRequest : BaseUserDelegatedRequest
    {
        public long EntryId { get; set; }
    }
}

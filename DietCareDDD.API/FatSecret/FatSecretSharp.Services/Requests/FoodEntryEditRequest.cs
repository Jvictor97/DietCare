using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Requests
{
    public class FoodEntryEditRequest : BaseFoodEntryModify
    {
        public long EntryId { get; set; }
    }
}

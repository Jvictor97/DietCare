using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Requests
{
    public class FoodEntryCreateRequest : BaseFoodEntryModify
    {
        public long FoodId { get; set; }
        public DateTime DateUTC { get; set; }
    }
}

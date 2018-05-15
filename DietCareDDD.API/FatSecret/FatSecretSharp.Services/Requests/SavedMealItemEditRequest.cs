using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Requests
{
    public class SavedMealItemEditRequest : BaseUserDelegatedRequest
    {
        public long SavedMealItemId { get; set; }
        public string SavedMealItemName { get; set; }
        public double NumServings { get; set; }
    }
}

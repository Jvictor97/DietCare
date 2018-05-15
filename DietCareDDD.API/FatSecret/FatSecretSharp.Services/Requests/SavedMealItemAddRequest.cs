using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Requests
{
    public class SavedMealItemAddRequest : BaseUserDelegatedRequest
    {
        public long SavedMealId { get; set; }
        public long FoodId { get; set; }
        public long ServingId { get; set; }
        public double NumServings { get; set; }
        public string Name { get; set; }
    }
}

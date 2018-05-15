using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Requests
{
    public class WeightGetMonthRequest : BaseUserDelegatedRequest
    {
        public DateTime MonthUTC { get; set; }

        public WeightGetMonthRequest()
        {
            MonthUTC = DateTime.UtcNow;
        }
    }
}

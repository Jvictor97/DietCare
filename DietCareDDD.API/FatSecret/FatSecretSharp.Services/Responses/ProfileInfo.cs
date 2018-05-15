using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Responses
{
    public class ProfileInfo
    {
        public string weight_measure { get; set; }
        public string height_measure { get; set; }
        public double last_weight_kg { get; set; }
        public int last_weight_date_int { get; set; }
        public string last_weight_comment { get; set; }
        public double goal_weight_kg { get; set; }
        public double height_cm { get; set; }
    }
}

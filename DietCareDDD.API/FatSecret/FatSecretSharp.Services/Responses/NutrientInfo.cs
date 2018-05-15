using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Responses
{
    public class NutrientInfo
    {
        public double calories { get; set; }
        public double carbohydrate { get; set; }
        public double protein { get; set; }
        public double fat { get; set; }
        public double saturated_fat { get; set; }
        public double polyunsaturated_fat { get; set; }
        public double monounsaturated_fat { get; set; }
        public double trans_fat { get; set; }
        public double cholesterol { get; set; }
        public double sodium { get; set; }
        public double potassium { get; set; }
        public double fiber { get; set; }
        public double sugar { get; set; }
        public int vitamin_a { get; set; }
        public int vitamin_c { get; set; }
        public int calcium { get; set; }
        public int iron { get; set; }
    }
}

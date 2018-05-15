using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Requests
{
    public enum WeightType
    {
        kg = 0,
        lb = 1
    }

    public enum HeightType
    {
        cm = 0,
        inch = 1
    }

    public class WeightUpdateRequest : BaseUserDelegatedRequest
    {
        public double CurrentWeight_KG { get; set; }
        public DateTime UpdateDate { get; set; }
        public WeightType WeightMeasurementType { get; set; }
        public HeightType HeightMeasurementType { get; set; }
        public double GoalWeight_KG { get; set; }
        public double CurrentHeight_CM { get; set; }
        public string Comment { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FatSecretSharp.Services.Common;

namespace FatSecretSharp.Services.Responses
{
    public class ExerciseEntryDayInfo
    {
        public int calories { get; set; }
        public int date_int { get; set; }

        public DateTime Date
        {
            get
            {
                return Helpers.FromDaysSinceJan11970(date_int);
            }
        }
    }

    public class DayWrapper
    {
        // There are no months with 1 day... That I know of at least.
        public List<ExerciseEntryDayInfo> day { get; set; }
    }

    public class ExerciseEntriesGetMonthResponse
    {
        public int from_date_int { get; set; }
        public int to_date_int { get; set; }
        public DayWrapper month { get; set; }
    }
}

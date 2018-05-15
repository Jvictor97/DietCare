using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatSecretSharp.Services.Common
{
    public static class Helpers
    {
        public static DateTime Jan11970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static Dictionary<DayOfWeek, int> DayValues = new Dictionary<DayOfWeek, int>()
        {
            { DayOfWeek.Sunday, 1 },
            { DayOfWeek.Monday, 2 },
            { DayOfWeek.Tuesday, 4 },
            { DayOfWeek.Wednesday, 8 },
            { DayOfWeek.Thursday, 16 },
            { DayOfWeek.Friday, 32 },
            { DayOfWeek.Saturday, 64 },
        };

        public static int ToDaysIntMask(this IEnumerable<DayOfWeek> days)
        {
            // Get the distinct days, orderered from sunday to saturday (in en-us culture).
            var distinctDays = days.Distinct();

            int value = 0;
            foreach ( var day in distinctDays )
            {
                value += DayValues[day];
            }

            return value;
        }

        /// <summary>
        /// Calculates the days since Jan 1, 1970.
        /// </summary>
        /// <param name="date">The date to calculate from (UTC).</param>
        /// <returns>The days since Jan 1, 1970</returns>
        public static int ToDaysSinceJan11970(this DateTime date)
        {
            var ts = date - Jan11970;

            return (int)Math.Floor(ts.TotalDays);
        }

        /// <summary>
        /// Froms the days since jan11970.
        /// </summary>
        /// <param name="totalDaysSince">The total days since.</param>
        /// <returns>The date since the specified number of days passed Jan 1, 1970</returns>
        public static DateTime FromDaysSinceJan11970(int totalDaysSince)
        {
            return Jan11970.AddDays(totalDaysSince);
        }

        /// <summary>
        /// Converts the kilograms to pounds.
        /// </summary>
        /// <param name="kilograms">The kilograms.</param>
        /// <returns>The pounds</returns>
        public static double ToPounds(this double kilograms)
        {
            return kilograms * 2.20462262;
        }

        /// <summary>
        /// Converts to feet.
        /// </summary>
        /// <param name="cm">The cm.</param>
        /// <returns>feet</returns>
        public static double ToFeet(this double cm)
        {
            return cm * 0.032808399;
        }
    }
}

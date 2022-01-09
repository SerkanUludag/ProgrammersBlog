using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Core.Utilities.Extensions
{
    public static class DateTimeExtensions          // extend classes are always static
    {
        public static string FullDateTimeStringWithUnderScore(this DateTime dateTime)           // for file naming
        {
            return $"{dateTime.Millisecond}_{dateTime.Second}_{dateTime.Minute}_{dateTime.Hour}_{dateTime.Day}_{dateTime.Month}_{dateTime.Year}";
        }
    }
}

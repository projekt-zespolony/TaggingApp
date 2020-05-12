using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;

namespace Tagging.Helpers
{
    public class SensorsConversionHelper : ISensorsConversionHelper
    {
        public long ConvertTextBoxTimeToUnixTimestamp(string time)
        {
            int hour = 0;
            int minute = 0;

            if (time.IsNullOrEmpty()) throw new ArgumentNullException();
            if (!time.Contains(':')) throw new ArgumentException("Wrong Format");
            if (!(time.Length == 5 || time.Length == 4 || time.Length == 3)) throw new ArgumentException("Wrong Format");

            for (int i = 0; i < time.Length; i++)
            {
                if (time[i] == ':')
                {
                    try
                    {
                        hour = i == 2 ? Int32.Parse(time.Substring(0, 2)) :
                            i == 1 ? Int32.Parse(time.Substring(0, 1)) : -1;

                        if (hour < 0 || hour > 23) throw new ArgumentException("Wrong Format");

                        minute = Int32.Parse(time.Substring(i + 1));

                        if (minute < 0 || minute > 59) throw new ArgumentException("Wrong Format");
                    }
                    catch (Exception e)
                    {
                        throw new ArgumentException(e.Message);
                    }
                }
            }

            var dateTime= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, 0);

            long ticks = dateTime.Ticks - DateTime.Parse("01/01/1970 00:00:00").Ticks;
            ticks /= 10000000;

            return ticks;
        }
    }
}

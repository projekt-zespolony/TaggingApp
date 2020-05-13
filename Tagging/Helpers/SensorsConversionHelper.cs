using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Castle.Core.Internal;

namespace Tagging.Helpers
{
    public class SensorsConversionHelper : ISensorsConversionHelper
    {
        public long ConvertTextBoxTimeToUnixTimestamp(string time)
        {
            int day = 0;
            int month = 0;
            int hour = 0;
            int minute = 0;

            if (time.IsNullOrEmpty()) throw new ArgumentNullException();
            if (time.Length>=7)
            {
                if (!time.Contains(':') || !time.Contains('/')) throw new ArgumentException("Wrong Format");

                for (int i = 0; i < time.Length; i++)
                {
                    if (time[i] == '/')
                    {
                        try
                        {
                            day = i == 2 ? Int32.Parse(time.Substring(0, 2)) :
                                i == 1 ? Int32.Parse(time.Substring(0, 1)) : -1;

                            if (day < 0 || day > 31) throw new ArgumentException("Wrong Format");

                            month = Int32.Parse(time.Substring(i + 1, time.IndexOf(' ') - i -1));

                            if (month < 0 || month > 12) throw new ArgumentException("Wrong Format");
                        }
                        catch (Exception e)
                        {
                            throw new ArgumentException(e.Message);
                        }

                    }
                    else if (time[i] == ':')
                    {
                        try
                        {
                            hour = Int32.Parse(time.Substring(time.IndexOf(' ') + 1, i - time.IndexOf(' ') - 1));

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

                var dateTime = new DateTime(DateTime.Now.Year, month, day, hour, minute, 0).ToUniversalTime();

                long ticks = dateTime.Ticks - DateTime.Parse("01/01/1970 00:00:00").Ticks;
                ticks /= 10000000;

                return ticks;
            }
            else if(time.Length>=3 && time.Length<=5)
            {
                if (!time.Contains(':')) throw new ArgumentException("Wrong Format");

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

                var dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, 0).ToUniversalTime();

                long ticks = dateTime.Ticks - DateTime.Parse("01/01/1970 00:00:00").Ticks;
                ticks /= 10000000;

                return ticks;
            }
            else
            {
                throw new ArgumentException("Wrong Format");
            }
        }

        public string ConvertTimestampToTextTimeFormat(long timestamp)
        {
            var dateTime = DateTime.Parse("01/01/1970 00:00:00");
            dateTime = dateTime.AddSeconds(timestamp).ToLocalTime();
            return dateTime.ToString();
        }
    }
}

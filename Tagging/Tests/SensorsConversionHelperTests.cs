using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tagging.Helpers;
using Xunit;

namespace Tagging.Tests
{
    public class SensorsConversionHelperTests
    {
        [Fact]
        public void ConvertTextBoxTimeToUnixTimestamp_ShouldReturnTimestamp_WhenArgumentsAreValid()
        {
            var time = "09:15";
            var conversionHelper = new SensorsConversionHelper();

            var timestamp =conversionHelper.ConvertTextBoxTimeToUnixTimestamp(time);
            var actual = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 15, 0).Ticks -
            DateTime.Parse("01/01/1970 00:00:00").Ticks)/ 10000000;

            Assert.True(timestamp == actual);
        }

        [Fact]
        public void ConvertTextBoxTimeToUnixTimestamp_ShouldThrowArgumentNullException_WhenArgumentIsNullOrWhitespace()
        {
            string time = null;
            var conversionHelper = new SensorsConversionHelper();

            Assert.Throws<ArgumentNullException>(() => conversionHelper.ConvertTextBoxTimeToUnixTimestamp(time));
        }

        [Fact]
        public void ConvertTextBoxTimeToUnixTimestamp_ShouldThrowArgumentException_WhenTimeHasWrongFormat()
        {
            string time = "12.611/4267";
            var conversionHelper = new SensorsConversionHelper();

            Assert.Throws<ArgumentException>(() => conversionHelper.ConvertTextBoxTimeToUnixTimestamp(time));
        }

        [Fact]
        public void ConvertTextBoxTimeToUnixTimestamp_ShouldThrowArgumentException_WhenTextHasWrongLenght()
        {
            string time = "21:555";
            var conversionHelper = new SensorsConversionHelper();

            Assert.Throws<ArgumentException>(() => conversionHelper.ConvertTextBoxTimeToUnixTimestamp(time));
        }

        [Fact]
        public void ConvertTimestampToTextTimeFormat_ShouldReturnDateTime()
        {
            long timestamp = 1589151900; // 10.05.2020 23:05 UTC
            var sensorsConversionHelper = new SensorsConversionHelper();

            var expected = DateTime.Parse("05/10/2020 23:05:00").ToLocalTime();
            var actual = sensorsConversionHelper.ConvertTimestampToTextTimeFormat(timestamp);

            Assert.True(actual.ToString() == expected.ToString());
        }
    }
}

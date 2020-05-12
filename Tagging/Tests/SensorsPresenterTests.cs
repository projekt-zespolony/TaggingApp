using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Moq;
using Tagging.Helpers;
using Tagging.Model;
using Tagging.Presenters;
using Tagging.Services;
using Xunit;

namespace Tagging.Tests
{
    public class SensorsPresenterTests
    {
        [Fact]
        public void LoadMeasurements_ShouldLoadAListOfSensors()
        {
            var startTime = "23:15";
            var endTime = "23:45";
            var dataRequestMock= new Mock<IDataRequestService>();
            var sensorsConversionMock = new Mock<ISensorsConversionHelper>();

            dataRequestMock.Setup(x => x.GetSensors(It.IsAny<int>()))
                .Returns(GetSensorsSample());
            sensorsConversionMock.Setup(x => x.ConvertTextBoxTimeToUnixTimestamp(startTime))
                .Returns(1589152500);
            sensorsConversionMock.Setup(x => x.ConvertTextBoxTimeToUnixTimestamp(endTime))
                .Returns(1589154300);

            var sensorsPresenter = new SensorsPresenter(dataRequestMock.Object, sensorsConversionMock.Object);
            sensorsPresenter.LoadMeasurements(startTime, endTime);

            Assert.True(sensorsPresenter.SensorsList.Count.Equals(2));

        }

        private List<Sensors> GetSensorsSample()
        {
            var sensorsList = new List<Sensors>();

            sensorsList.Add(new Sensors(1589151900,15,15,15,15)); // 10.05.2020 23:05 UTC
            sensorsList.Add(new Sensors(1589153520, 15, 15, 15, 15)); // 10.05.2020 23:32 UTC
            sensorsList.Add(new Sensors(1589153880, 15, 15, 15, 15)); // 10.05.2020 23:38 UTC

            return sensorsList;
        }
    }
}

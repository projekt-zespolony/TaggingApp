using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tagging.Model
{
    public class Sensors
    {
        private long Timestamp { get; }
        private float Temperature { get; }
        private float Pressure { get; }
        private float Humidity { get; }
        private float Gas { get; }

        public Sensors(long timestamp, float temperature, float pressure, float humidity, float gas)
        {
            Timestamp = timestamp;
            Temperature = temperature;
            Pressure = pressure;
            Humidity = humidity;
            Gas = gas;
        }

    }
}

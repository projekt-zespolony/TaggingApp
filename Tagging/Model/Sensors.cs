using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tagging.Model
{
    [Serializable]
    public class Sensors
    {
        public long Timestamp { get; set; }
        public float Temperature { get; set; }
        public float Pressure { get; set; }
        public float Humidity { get; set; }
        public float Gas { get; set; }
        public bool? WindowsOpened { get; set; }
        public bool? PeopleInTheRoom { get; set; }

        public Sensors()
        {

        }

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

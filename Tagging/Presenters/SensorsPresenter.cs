using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Castle.Components.DictionaryAdapter.Xml;
using Castle.Core.Internal;
using Tagging.Helpers;
using Tagging.Model;
using Tagging.ObserverPattern;
using Tagging.Services;
using Tagging.View;

namespace Tagging.Presenters
{
    public class SensorsPresenter : IObservable
    {
        private List<Sensors> _sensorsList;
        private List<IObserver> _observers;
        private IDataRequestService _dataRequestService;
        private ISensorsConversionHelper _conversionHelper;

        public SensorsPresenter(IDataRequestService dataRequestService,
            ISensorsConversionHelper conversionHelper)
        {
            _dataRequestService = dataRequestService;
            _conversionHelper = conversionHelper;
            _sensorsList = new List<Sensors>();
            _observers = new List<IObserver>();
        }

        public List<Sensors> SensorsList
        {
            get { return _sensorsList;}
            private set 
            { 
                _sensorsList = value;
                Notify();
            }

        }

        public async Task RemoveSensorsAsync(Sensors sensors)
        {
            await Task.Run(()=>_sensorsList.Remove(sensors));
            Notify();
        }

        public void TagRange(List<Sensors> sensorsList, bool? windowsOpened, bool? peopleInTheRoom)
        {
            foreach (var t in sensorsList)
            {
                var sensors = SensorsList.Find(x=>x.Equals(t));
                sensors.WindowsOpened = windowsOpened;
                sensors.PeopleInTheRoom = peopleInTheRoom;
            }

            Notify();
        }

        public void SaveToFile(List<Sensors> sensorsList)
        {
            XElement measurements;
            if (File.Exists("./Data.xml")) measurements=XElement.Load("./Data.xml");
            else measurements = new XElement("measurements");

            foreach (var t in sensorsList)
            {
                var values = new XElement("values", new XAttribute("timestamp", t.Timestamp), new XAttribute("temperature",t.Temperature), new XAttribute("airPressure", t.Pressure)
                    , new XAttribute("humidity", t.Humidity), new XAttribute("airQuality", t.Gas));

                var tags = new XElement("tags",
                    new XAttribute("windowsOpened",
                        t.WindowsOpened == true ? 1 :
                        t.WindowsOpened == false ? 0 : throw new ArgumentException("Tag not assigned to a value")),
                    new XAttribute("peopleInTheRoom",
                        t.PeopleInTheRoom == true ? 1 :
                        t.PeopleInTheRoom == false ? 0 : throw new ArgumentException("Tag not assigned to a value")));

                var measurement = new XElement("measurement", values, tags);
                measurements.Add(measurement);
            }

            using (var stream = new FileStream("Data.xml", FileMode.OpenOrCreate))
            {
                var streamWriter = new StreamWriter(stream);

                using (var xmlWriter = new XmlTextWriter(streamWriter))
                {
                    xmlWriter.Formatting = Formatting.Indented;
                    xmlWriter.Indentation = 4;
                    measurements.Save(xmlWriter);
                }
            }
        }

        /// <summary>
        /// Loads Measurements with timestamp between startTime and endTime
        /// </summary>
        /// <param name="startTime">start time of the measurements in the format of hours:minutes</param>
        /// <param name="endTime">end time of the measurements in the format of hours:minutes</param>
        public void LoadMeasurements(string startTime, string endTime)
        {
            long startTimestamp;
            long endTimestamp;

            try
            {
                startTimestamp = _conversionHelper.ConvertTextBoxTimeToUnixTimestamp(startTime);
                endTimestamp = _conversionHelper.ConvertTextBoxTimeToUnixTimestamp(endTime);
            }
            catch
            {
                return;
            }

            var sensorsList= _dataRequestService.GetSensors(24);

            foreach (Sensors t in sensorsList.ToList())
            {
                if (t.Timestamp < startTimestamp || t.Timestamp > endTimestamp) sensorsList.Remove(t);
            }

            SensorsList = sensorsList;
        }

        #region IObservable members

        public void Subscribe(IObserver observer)
        {
            if (observer != null) _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            if (observer != null) _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var t in _observers)
            {
                t.UpdateView();
            }
        }

        #endregion
    }
}

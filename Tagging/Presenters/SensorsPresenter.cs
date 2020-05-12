using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

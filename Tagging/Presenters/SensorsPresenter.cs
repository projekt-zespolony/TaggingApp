using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tagging.Helpers;
using Tagging.Model;
using Tagging.Services;
using Tagging.View;

namespace Tagging.Presenters
{
    public class SensorsPresenter
    {
        private MainForm _mainForm;
        private List<Sensors> _sensorsList;
        private DataRequestService _dataRequestService;
        private SensorsConversionHelper _conversionHelper;

        public SensorsPresenter(MainForm mainForm, DataRequestService dataRequestService,
            SensorsConversionHelper conversionHelper)
        {
            _mainForm = mainForm;
            _dataRequestService = dataRequestService;
            _conversionHelper = conversionHelper;
            _sensorsList = new List<Sensors>();
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

            var sensorsList= _dataRequestService.GetSensors(24).Result;

            foreach (Sensors t in sensorsList.ToList())
            {
                if (t.Timestamp < startTimestamp || t.Timestamp > endTimestamp) sensorsList.Remove(t);
            }

            _sensorsList = sensorsList;
        }
    }
}

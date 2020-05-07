using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tagging.Model;
using Tagging.View;

namespace Tagging.Presenters
{
    public class SensorsPresenter
    {
        private MainForm _mainForm;
        private List<Sensors> _sensorsList;

        public SensorsPresenter(MainForm mainForm)
        {
            _mainForm = mainForm;
            _sensorsList = new List<Sensors>();
        }


    }
}

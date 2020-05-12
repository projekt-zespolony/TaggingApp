using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tagging.Helpers;
using Tagging.ObserverPattern;
using Tagging.Presenters;
using Tagging.Services;
using Tagging.View;

namespace Tagging
{
    public partial class MainForm : Form, IObserver
    {
        private SensorsPresenter _sensorsPresenter;
        private ISensorsConversionHelper _conversionHelper;

        public MainForm()
        {
            _sensorsPresenter = new SensorsPresenter(new DataRequestService(), new SensorsConversionHelper());
            _sensorsPresenter.Subscribe(this);
            _conversionHelper = new SensorsConversionHelper();
            InitializeComponent();
        }

        private void LoadMesurementsButton_Click(object sender, EventArgs e)
        {
            new LoadMeasurementsForm(_sensorsPresenter).ShowDialog();
        }

        public void UpdateView()
        {
            foreach (var t in _sensorsPresenter.SensorsList)
            {
                string[] row =
                {
                    _conversionHelper.ConvertTimestampToTextTimeFormat(t.Timestamp), t.Temperature.ToString(), t.Pressure.ToString(), t.Humidity.ToString(),
                    t.Gas.ToString()
                };

                var listViewItem = new ListViewItem(row);
                this.MeasurementsListView.Items.Add(listViewItem);
            }
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem t in this.MeasurementsListView.Items)
            {
                t.Selected = true;
            }
        }
    }
}

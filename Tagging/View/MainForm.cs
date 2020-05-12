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
        private SensorsPresenter sensorsPresenter;

        public MainForm()
        {
            sensorsPresenter = new SensorsPresenter(new DataRequestService(), new SensorsConversionHelper());
            sensorsPresenter.Subscribe(this);
            InitializeComponent();
        }

        private void LoadMesurementsButton_Click(object sender, EventArgs e)
        {
            new LoadMeasurementsForm(sensorsPresenter).ShowDialog();
        }

        public void UpdateView()
        {
            foreach (var t in sensorsPresenter.SensorsList)
            {
                string[] row =
                {
                    t.Timestamp.ToString(), t.Temperature.ToString(), t.Pressure.ToString(), t.Humidity.ToString(),
                    t.Gas.ToString()
                };

                var listViewItem = new ListViewItem(row);
                this.MeasurementsListView.Items.Add(listViewItem);
            }
        }
    }
}

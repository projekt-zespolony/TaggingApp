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
using Tagging.Model;
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
            this.MeasurementsListView.Items.Clear();

            if(_sensorsPresenter.SensorsList.Count>0)
            foreach (var t in _sensorsPresenter.SensorsList)
            {

                string[] row =
                {
                    _conversionHelper.ConvertTimestampToTextTimeFormat(t.Timestamp), t.Temperature.ToString(),
                    t.Pressure.ToString(), t.Humidity.ToString(),
                    t.Gas.ToString(), "", ""
                };

                if (t.WindowsOpened != null) row[5] = t.WindowsOpened.ToString();
                if (t.PeopleInTheRoom != null) row[6] = t.PeopleInTheRoom.ToString();
                
                var listViewItem = new ListViewItem(row);
                listViewItem.Tag = t;
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

        private void RemoveSelectedButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem t in this.MeasurementsListView.Items)
            {
                if(t.Selected) _sensorsPresenter.RemoveSensorsAsync(t.Tag as Sensors);
            }
        }
    }
}

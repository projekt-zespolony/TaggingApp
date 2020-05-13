using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
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

        private void TagSelectedButton_Click(object sender, EventArgs e)
        {
            var selectedSensors = new List<Sensors>();

            foreach (ListViewItem t in MeasurementsListView.SelectedItems)
            {
                selectedSensors.Add(t.Tag as Sensors);
            }

            var tagMeasurementsDialog = new TagMeasurementsForm(_sensorsPresenter);
            tagMeasurementsDialog.ConfirmButton.Click += 
                new EventHandler(delegate(object s, EventArgs args)
                {
                    bool? windowsOpened=null;
                    bool? peopleInTheRoom=null;

                    if (tagMeasurementsDialog.WindowsOpenedComboBox.SelectedIndex == 0) windowsOpened = false;
                    else if (tagMeasurementsDialog.WindowsOpenedComboBox.SelectedIndex == 1) windowsOpened = true;

                    if (tagMeasurementsDialog.PeopleInTheRoomComboBox.SelectedIndex == 0) peopleInTheRoom = false;
                    else if (tagMeasurementsDialog.PeopleInTheRoomComboBox.SelectedIndex == 1) peopleInTheRoom = true;
                        
                    _sensorsPresenter.TagRange(selectedSensors,
                            windowsOpened,
                            peopleInTheRoom);

                    tagMeasurementsDialog.Close();
                    });

            tagMeasurementsDialog.Show();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var sensorsList = new List<Sensors>();

            foreach (ListViewItem t in MeasurementsListView.Items)
            {
                sensorsList.Add(t.Tag as Sensors);
            }

            _sensorsPresenter.SaveToFile(sensorsList);
        }
    }
}

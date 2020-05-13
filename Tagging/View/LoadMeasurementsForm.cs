using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tagging.Presenters;

namespace Tagging.View
{
    public partial class LoadMeasurementsForm : Form
    {
        private SensorsPresenter _sensorsPresenter;

        public LoadMeasurementsForm(SensorsPresenter sensorsPresenter)
        {
            _sensorsPresenter = sensorsPresenter;
            InitializeComponent();
        }

        private void EndTimeTextBox_Click(object sender, EventArgs e)
        {
            EndTimeTextBox.Text = "";
        }

        private void StartTimeTextBox_Click(object sender, EventArgs e)
        {
            StartTimeTextBox.Text = "";
        }

        private void StartTimeTextBox_Leave(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(StartTimeTextBox.Text)) StartTimeTextBox.Text = "dd/mm hours:minutes";
        }

        private void EndTimeTextBox_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(EndTimeTextBox.Text)) EndTimeTextBox.Text = "dd/mm hours:minutes";
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            _sensorsPresenter.LoadMeasurements(StartTimeTextBox.Text, EndTimeTextBox.Text);
            this.Close();
        }
    }
}

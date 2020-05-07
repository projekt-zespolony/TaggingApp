using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tagging.View
{
    public partial class LoadMeasurementsForm : Form
    {
        public LoadMeasurementsForm()
        {
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
            StartTimeTextBox.Text = "day.month/hours:minutes";
        }

        private void EndTimeTextBox_Leave(object sender, EventArgs e)
        {
            EndTimeTextBox.Text = "day.month/hours:minutes";
        }
    }
}

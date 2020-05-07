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
using Tagging.Presenters;
using Tagging.Services;
using Tagging.View;

namespace Tagging
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadMesurementsButton_Click(object sender, EventArgs e)
        {
            var sensorsPresenter = new SensorsPresenter(this, new DataRequestService(), new SensorsConversionHelper());
            new LoadMeasurementsForm(sensorsPresenter).ShowDialog();
        }
    }
}

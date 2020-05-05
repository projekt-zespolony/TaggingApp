namespace Tagging
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MeasurementsListView = new System.Windows.Forms.ListView();
            this.timeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.temperatureHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.airPressureHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.humidityHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.airQualityHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openWindowsTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.peopleInTheRoomTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // MeasurementsListView
            // 
            this.MeasurementsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.timeHeader,
            this.temperatureHeader,
            this.airPressureHeader,
            this.humidityHeader,
            this.airQualityHeader,
            this.openWindowsTag,
            this.peopleInTheRoomTag});
            this.MeasurementsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MeasurementsListView.HideSelection = false;
            this.MeasurementsListView.Location = new System.Drawing.Point(0, 0);
            this.MeasurementsListView.Name = "MeasurementsListView";
            this.MeasurementsListView.Size = new System.Drawing.Size(481, 728);
            this.MeasurementsListView.TabIndex = 0;
            this.MeasurementsListView.UseCompatibleStateImageBehavior = false;
            this.MeasurementsListView.View = System.Windows.Forms.View.Details;
            // 
            // timeHeader
            // 
            this.timeHeader.Text = "Time";
            this.timeHeader.Width = 39;
            // 
            // temperatureHeader
            // 
            this.temperatureHeader.Text = "Temperature";
            this.temperatureHeader.Width = 74;
            // 
            // airPressureHeader
            // 
            this.airPressureHeader.Text = "Air Pressure";
            this.airPressureHeader.Width = 69;
            // 
            // humidityHeader
            // 
            this.humidityHeader.Text = "Humidity";
            this.humidityHeader.Width = 53;
            // 
            // airQualityHeader
            // 
            this.airQualityHeader.Text = "Air Quality";
            this.airQualityHeader.Width = 59;
            // 
            // openWindowsTag
            // 
            this.openWindowsTag.Text = "OpenWindows";
            this.openWindowsTag.Width = 83;
            // 
            // peopleInTheRoomTag
            // 
            this.peopleInTheRoomTag.Text = "People in the room";
            this.peopleInTheRoomTag.Width = 113;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 728);
            this.Controls.Add(this.MeasurementsListView);
            this.Name = "MainForm";
            this.Text = "Tagging";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView MeasurementsListView;
        private System.Windows.Forms.ColumnHeader timeHeader;
        private System.Windows.Forms.ColumnHeader temperatureHeader;
        private System.Windows.Forms.ColumnHeader airPressureHeader;
        private System.Windows.Forms.ColumnHeader humidityHeader;
        private System.Windows.Forms.ColumnHeader airQualityHeader;
        private System.Windows.Forms.ColumnHeader openWindowsTag;
        private System.Windows.Forms.ColumnHeader peopleInTheRoomTag;
    }
}


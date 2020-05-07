﻿namespace Tagging
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.LoadMesurementsButton = new System.Windows.Forms.Button();
            this.SelectAllButton = new System.Windows.Forms.Button();
            this.RemoveSelectedButton = new System.Windows.Forms.Button();
            this.TagSelectedButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MeasurementsListView
            // 
            this.MeasurementsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.timeHeader,
            this.temperatureHeader,
            this.airPressureHeader,
            this.humidityHeader,
            this.airQualityHeader});
            this.MeasurementsListView.Dock = System.Windows.Forms.DockStyle.Top;
            this.MeasurementsListView.HideSelection = false;
            this.MeasurementsListView.Location = new System.Drawing.Point(0, 0);
            this.MeasurementsListView.Name = "MeasurementsListView";
            this.MeasurementsListView.Size = new System.Drawing.Size(481, 680);
            this.MeasurementsListView.TabIndex = 0;
            this.MeasurementsListView.UseCompatibleStateImageBehavior = false;
            this.MeasurementsListView.View = System.Windows.Forms.View.Details;
            // 
            // timeHeader
            // 
            this.timeHeader.Text = "Time";
            this.timeHeader.Width = 86;
            // 
            // temperatureHeader
            // 
            this.temperatureHeader.Text = "Temperature";
            this.temperatureHeader.Width = 89;
            // 
            // airPressureHeader
            // 
            this.airPressureHeader.Text = "Air Pressure";
            this.airPressureHeader.Width = 90;
            // 
            // humidityHeader
            // 
            this.humidityHeader.Text = "Humidity";
            this.humidityHeader.Width = 75;
            // 
            // airQualityHeader
            // 
            this.airQualityHeader.Text = "Air Quality";
            this.airQualityHeader.Width = 73;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.LoadMesurementsButton);
            this.flowLayoutPanel1.Controls.Add(this.SelectAllButton);
            this.flowLayoutPanel1.Controls.Add(this.RemoveSelectedButton);
            this.flowLayoutPanel1.Controls.Add(this.TagSelectedButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 680);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(481, 48);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // LoadMesurementsButton
            // 
            this.LoadMesurementsButton.Location = new System.Drawing.Point(3, 3);
            this.LoadMesurementsButton.Name = "LoadMesurementsButton";
            this.LoadMesurementsButton.Size = new System.Drawing.Size(138, 42);
            this.LoadMesurementsButton.TabIndex = 4;
            this.LoadMesurementsButton.Text = "Load Measurements";
            this.LoadMesurementsButton.UseVisualStyleBackColor = true;
            // 
            // SelectAllButton
            // 
            this.SelectAllButton.Location = new System.Drawing.Point(147, 3);
            this.SelectAllButton.Name = "SelectAllButton";
            this.SelectAllButton.Size = new System.Drawing.Size(97, 42);
            this.SelectAllButton.TabIndex = 5;
            this.SelectAllButton.Text = "Select All";
            this.SelectAllButton.UseVisualStyleBackColor = true;
            // 
            // RemoveSelectedButton
            // 
            this.RemoveSelectedButton.Location = new System.Drawing.Point(250, 3);
            this.RemoveSelectedButton.Name = "RemoveSelectedButton";
            this.RemoveSelectedButton.Size = new System.Drawing.Size(111, 42);
            this.RemoveSelectedButton.TabIndex = 6;
            this.RemoveSelectedButton.Text = "Remove Selected";
            this.RemoveSelectedButton.UseVisualStyleBackColor = true;
            // 
            // TagSelectedButton
            // 
            this.TagSelectedButton.Location = new System.Drawing.Point(367, 3);
            this.TagSelectedButton.Name = "TagSelectedButton";
            this.TagSelectedButton.Size = new System.Drawing.Size(110, 42);
            this.TagSelectedButton.TabIndex = 7;
            this.TagSelectedButton.Text = "Tag Selected";
            this.TagSelectedButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 728);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.MeasurementsListView);
            this.Name = "MainForm";
            this.Text = "Tagging";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView MeasurementsListView;
        private System.Windows.Forms.ColumnHeader timeHeader;
        private System.Windows.Forms.ColumnHeader temperatureHeader;
        private System.Windows.Forms.ColumnHeader airPressureHeader;
        private System.Windows.Forms.ColumnHeader humidityHeader;
        private System.Windows.Forms.ColumnHeader airQualityHeader;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button LoadMesurementsButton;
        private System.Windows.Forms.Button SelectAllButton;
        private System.Windows.Forms.Button RemoveSelectedButton;
        private System.Windows.Forms.Button TagSelectedButton;
    }
}

namespace Tagging.View
{
    partial class TagMeasurementsForm
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
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.PeopleInTheRoomLabel = new System.Windows.Forms.Label();
            this.WindowsOpenedLabel = new System.Windows.Forms.Label();
            this.WindowsOpenedComboBox = new System.Windows.Forms.ComboBox();
            this.PeopleInTheRoomComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmButton.Location = new System.Drawing.Point(109, 123);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(95, 37);
            this.ConfirmButton.TabIndex = 7;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            // 
            // PeopleInTheRoomLabel
            // 
            this.PeopleInTheRoomLabel.AutoSize = true;
            this.PeopleInTheRoomLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PeopleInTheRoomLabel.Location = new System.Drawing.Point(17, 79);
            this.PeopleInTheRoomLabel.Name = "PeopleInTheRoomLabel";
            this.PeopleInTheRoomLabel.Size = new System.Drawing.Size(177, 20);
            this.PeopleInTheRoomLabel.TabIndex = 6;
            this.PeopleInTheRoomLabel.Text = "People In The Room:";
            this.PeopleInTheRoomLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WindowsOpenedLabel
            // 
            this.WindowsOpenedLabel.AutoSize = true;
            this.WindowsOpenedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WindowsOpenedLabel.Location = new System.Drawing.Point(17, 36);
            this.WindowsOpenedLabel.Name = "WindowsOpenedLabel";
            this.WindowsOpenedLabel.Size = new System.Drawing.Size(153, 20);
            this.WindowsOpenedLabel.TabIndex = 5;
            this.WindowsOpenedLabel.Text = "Windows Opened:";
            this.WindowsOpenedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WindowsOpenedComboBox
            // 
            this.WindowsOpenedComboBox.FormattingEnabled = true;
            this.WindowsOpenedComboBox.Items.AddRange(new object[] {
            "False",
            "True"});
            this.WindowsOpenedComboBox.Location = new System.Drawing.Point(200, 35);
            this.WindowsOpenedComboBox.Name = "WindowsOpenedComboBox";
            this.WindowsOpenedComboBox.Size = new System.Drawing.Size(98, 21);
            this.WindowsOpenedComboBox.TabIndex = 8;
            // 
            // PeopleInTheRoomComboBox
            // 
            this.PeopleInTheRoomComboBox.FormattingEnabled = true;
            this.PeopleInTheRoomComboBox.Items.AddRange(new object[] {
            "False",
            "True"});
            this.PeopleInTheRoomComboBox.Location = new System.Drawing.Point(200, 78);
            this.PeopleInTheRoomComboBox.Name = "PeopleInTheRoomComboBox";
            this.PeopleInTheRoomComboBox.Size = new System.Drawing.Size(98, 21);
            this.PeopleInTheRoomComboBox.TabIndex = 9;
            // 
            // TagMeasurementsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 188);
            this.Controls.Add(this.PeopleInTheRoomComboBox);
            this.Controls.Add(this.WindowsOpenedComboBox);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.PeopleInTheRoomLabel);
            this.Controls.Add(this.WindowsOpenedLabel);
            this.Name = "TagMeasurementsForm";
            this.Text = "TagMeasurementsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Label PeopleInTheRoomLabel;
        private System.Windows.Forms.Label WindowsOpenedLabel;
        public System.Windows.Forms.ComboBox WindowsOpenedComboBox;
        public System.Windows.Forms.ComboBox PeopleInTheRoomComboBox;
    }
}
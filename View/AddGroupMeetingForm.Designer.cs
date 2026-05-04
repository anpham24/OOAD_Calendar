namespace OOAD_Calendar.View
{
    partial class AddGroupMeetingForm
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
			this.dtpEnd = new System.Windows.Forms.DateTimePicker();
			this.dtpStart = new System.Windows.Forms.DateTimePicker();
			this.label7 = new System.Windows.Forms.Label();
			this.btnAddGuest = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.cboReminder = new System.Windows.Forms.ComboBox();
			this.txtLocation = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lbParticipants = new System.Windows.Forms.ListBox();
			this.label8 = new System.Windows.Forms.Label();
			this.cboParticipants = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// dtpEnd
			// 
			this.dtpEnd.CustomFormat = "dd/MM/yyyy   HH:mm";
			this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpEnd.Location = new System.Drawing.Point(265, 172);
			this.dtpEnd.Name = "dtpEnd";
			this.dtpEnd.ShowUpDown = true;
			this.dtpEnd.Size = new System.Drawing.Size(172, 22);
			this.dtpEnd.TabIndex = 35;
			// 
			// dtpStart
			// 
			this.dtpStart.CustomFormat = "dd/MM/yyyy   HH:mm";
			this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpStart.Location = new System.Drawing.Point(265, 118);
			this.dtpStart.Name = "dtpStart";
			this.dtpStart.ShowUpDown = true;
			this.dtpStart.Size = new System.Drawing.Size(172, 22);
			this.dtpStart.TabIndex = 34;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(95, 172);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(130, 19);
			this.label7.TabIndex = 33;
			this.label7.Text = "Thời gian kết thúc";
			// 
			// btnAddGuest
			// 
			this.btnAddGuest.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAddGuest.Location = new System.Drawing.Point(519, 315);
			this.btnAddGuest.Name = "btnAddGuest";
			this.btnAddGuest.Size = new System.Drawing.Size(95, 30);
			this.btnAddGuest.TabIndex = 32;
			this.btnAddGuest.Text = "Thêm";
			this.btnAddGuest.UseVisualStyleBackColor = true;
			this.btnAddGuest.Click += new System.EventHandler(this.btnAddGuest_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(95, 362);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(187, 19);
			this.label6.TabIndex = 30;
			this.label6.Text = "Danh sách người tham gia:";
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(265, 589);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(79, 43);
			this.btnCancel.TabIndex = 29;
			this.btnCancel.Text = "Hủy";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(95, 274);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(73, 19);
			this.label5.TabIndex = 28;
			this.label5.Text = "Nhắc nhở";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(94, 224);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 19);
			this.label4.TabIndex = 27;
			this.label4.Text = "Địa điểm";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(94, 121);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(124, 19);
			this.label3.TabIndex = 26;
			this.label3.Text = "Thời gian bắt đầu";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(94, 74);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(92, 19);
			this.label2.TabIndex = 25;
			this.label2.Text = "Tên lịch hẹn";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.label1.Location = new System.Drawing.Point(366, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(105, 32);
			this.label1.TabIndex = 23;
			this.label1.Text = "Sự kiện";
			// 
			// btnSave
			// 
			this.btnSave.BackColor = System.Drawing.SystemColors.HotTrack;
			this.btnSave.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnSave.Location = new System.Drawing.Point(489, 589);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(94, 40);
			this.btnSave.TabIndex = 22;
			this.btnSave.Text = "Lưu";
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// cboReminder
			// 
			this.cboReminder.FormattingEnabled = true;
			this.cboReminder.Items.AddRange(new object[] {
            "Không nhắc nhở",
            "15 phút",
            "30 phút",
            "45 phút",
            "60 phút",
            "90 phút",
            "120 phút",
            "150 phút",
            "180 phút",
            "210 phút",
            "240 phút",
            "270 phút",
            "300 phút"});
			this.cboReminder.Location = new System.Drawing.Point(225, 269);
			this.cboReminder.Name = "cboReminder";
			this.cboReminder.Size = new System.Drawing.Size(137, 24);
			this.cboReminder.TabIndex = 21;
			// 
			// txtLocation
			// 
			this.txtLocation.Location = new System.Drawing.Point(225, 224);
			this.txtLocation.Name = "txtLocation";
			this.txtLocation.Size = new System.Drawing.Size(274, 22);
			this.txtLocation.TabIndex = 20;
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(225, 73);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(274, 22);
			this.txtName.TabIndex = 19;
			// 
			// lbParticipants
			// 
			this.lbParticipants.FormattingEnabled = true;
			this.lbParticipants.ItemHeight = 16;
			this.lbParticipants.Location = new System.Drawing.Point(175, 402);
			this.lbParticipants.Name = "lbParticipants";
			this.lbParticipants.Size = new System.Drawing.Size(439, 164);
			this.lbParticipants.TabIndex = 24;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(95, 320);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(149, 19);
			this.label8.TabIndex = 30;
			this.label8.Text = "Chọn người tham gia";
			// 
			// cboParticipants
			// 
			this.cboParticipants.FormattingEnabled = true;
			this.cboParticipants.Location = new System.Drawing.Point(265, 320);
			this.cboParticipants.Name = "cboParticipants";
			this.cboParticipants.Size = new System.Drawing.Size(234, 24);
			this.cboParticipants.TabIndex = 36;
			// 
			// AddGroupMeetingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(842, 647);
			this.Controls.Add(this.cboParticipants);
			this.Controls.Add(this.dtpEnd);
			this.Controls.Add(this.dtpStart);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.btnAddGuest);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lbParticipants);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.cboReminder);
			this.Controls.Add(this.txtLocation);
			this.Controls.Add(this.txtName);
			this.Name = "AddGroupMeetingForm";
			this.Text = "AddGroupMeetingForm";
			this.Load += new System.EventHandler(this.AddGroupMeetingForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAddGuest;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cboReminder;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.ListBox lbParticipants;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox cboParticipants;
	}
}
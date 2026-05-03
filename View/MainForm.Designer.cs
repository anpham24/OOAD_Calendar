namespace OOAD_Calendar.View
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
			this.btnAppointMent = new System.Windows.Forms.Button();
			this.dgvEvents = new System.Windows.Forms.DataGridView();
			this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
			this.btnGruopMeeting = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
			this.SuspendLayout();
			// 
			// btnAppointMent
			// 
			this.btnAppointMent.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAppointMent.Location = new System.Drawing.Point(52, 49);
			this.btnAppointMent.Name = "btnAppointMent";
			this.btnAppointMent.Size = new System.Drawing.Size(209, 55);
			this.btnAppointMent.TabIndex = 7;
			this.btnAppointMent.Text = "Tạo AppointMent";
			this.btnAppointMent.UseVisualStyleBackColor = true;
			this.btnAppointMent.Click += new System.EventHandler(this.btnAppointMent_Click);
			// 
			// dgvEvents
			// 
			this.dgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTitle,
            this.colStart,
            this.colEnd,
            this.colLocation});
			this.dgvEvents.Location = new System.Drawing.Point(321, 49);
			this.dgvEvents.Name = "dgvEvents";
			this.dgvEvents.RowHeadersWidth = 51;
			this.dgvEvents.RowTemplate.Height = 24;
			this.dgvEvents.Size = new System.Drawing.Size(876, 568);
			this.dgvEvents.TabIndex = 6;
			// 
			// colTitle
			// 
			this.colTitle.HeaderText = "Tên lịch hẹn";
			this.colTitle.MinimumWidth = 6;
			this.colTitle.Name = "colTitle";
			this.colTitle.Width = 200;
			// 
			// colStart
			// 
			this.colStart.HeaderText = "Thời gian bắt đầu";
			this.colStart.MinimumWidth = 6;
			this.colStart.Name = "colStart";
			this.colStart.Width = 102;
			// 
			// colEnd
			// 
			this.colEnd.HeaderText = "Thời gian kết thúc";
			this.colEnd.MinimumWidth = 6;
			this.colEnd.Name = "colEnd";
			this.colEnd.Width = 102;
			// 
			// colLocation
			// 
			this.colLocation.HeaderText = "Địa điểm";
			this.colLocation.MinimumWidth = 6;
			this.colLocation.Name = "colLocation";
			this.colLocation.Width = 200;
			// 
			// monthCalendar1
			// 
			this.monthCalendar1.Location = new System.Drawing.Point(27, 218);
			this.monthCalendar1.Name = "monthCalendar1";
			this.monthCalendar1.TabIndex = 5;
			// 
			// btnGruopMeeting
			// 
			this.btnGruopMeeting.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGruopMeeting.Location = new System.Drawing.Point(37, 126);
			this.btnGruopMeeting.Name = "btnGruopMeeting";
			this.btnGruopMeeting.Size = new System.Drawing.Size(233, 55);
			this.btnGruopMeeting.TabIndex = 4;
			this.btnGruopMeeting.Text = "Tạo Group Meeting";
			this.btnGruopMeeting.UseVisualStyleBackColor = true;
			this.btnGruopMeeting.Click += new System.EventHandler(this.btnGruopMeeting_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1214, 667);
			this.Controls.Add(this.btnAppointMent);
			this.Controls.Add(this.dgvEvents);
			this.Controls.Add(this.monthCalendar1);
			this.Controls.Add(this.btnGruopMeeting);
			this.Name = "MainForm";
			this.Text = "MainForm";
			((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAppointMent;
        private System.Windows.Forms.DataGridView dgvEvents;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocation;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnGruopMeeting;
    }
}


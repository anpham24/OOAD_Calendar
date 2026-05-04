using OOAD_Calendar.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOAD_Calendar.View
{
	public partial class AddAppointmentForm : Form
	{
		private int currentUserId;
		private EventBLL eventBll = new EventBLL();

		public AddAppointmentForm(int userId, DateTime selectedDate)
		{
			InitializeComponent();
			this.currentUserId = userId;

			dtpStart.Value = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, 8, 0, 0);
			dtpEnd.Value = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, 9, 0, 0);

			cboReminder.SelectedIndex = 0;
		}
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			string name = txtName.Text.Trim();
			string location = txtLocation.Text.Trim();
			DateTime startTime = dtpStart.Value;
			DateTime endTime = dtpEnd.Value;

			if (string.IsNullOrEmpty(name))
			{
				MessageBox.Show("Tên sự kiện không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtName.Focus();
				return;
			}

			if (!eventBll.ValidateTime(startTime, endTime))
			{
				MessageBox.Show("Thời gian kết thúc phải lớn hơn thời gian bắt đầu!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				dtpEnd.Focus();
				return;
			}

			TimeSpan duration = endTime - startTime;
			var matchingMeeting = eventBll.FindMatchingGroupMeeting(name, duration, startTime, endTime);

			if (matchingMeeting != null)
			{
				DialogResult joinResult = MessageBox.Show(
					"Có một cuộc họp nhóm cùng tên và thời gian đang diễn ra. Bạn có muốn tham gia vào cuộc họp này thay vì tạo sự kiện mới không?",
					"Phát hiện họp nhóm",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question);

				if (joinResult == DialogResult.Yes)
				{
					eventBll.JoinGroupMeeting(currentUserId, matchingMeeting.Id);
					MessageBox.Show("Đã tham gia nhóm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

					this.DialogResult = DialogResult.OK;
					this.Close();
					return;
				}
			}


			bool isOverlap = eventBll.HasOverlappingEvents(currentUserId, startTime, endTime);

			if (isOverlap)
			{
				DialogResult overlapResult = MessageBox.Show(
					"Khoảng thời gian này đã có sự kiện khác. Bạn có muốn thay thế (Xóa sự kiện cũ, lưu sự kiện này) không?\n\n- Chọn 'Yes' để thay thế.\n- Chọn 'No' để chọn lại giờ khác.",
					"Trùng lịch trình",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning);

				if (overlapResult == DialogResult.No)
				{
					dtpStart.Focus();
					return;
				}
				else
				{
					eventBll.DeleteOverlappingEvents(currentUserId, startTime, endTime);
				}
			}

			try
			{
				Appointment newAppt = new Appointment
				{
					Name = name,
					StartTime = startTime,
					EndTime = endTime,
					Location = location,
					CalendarId = currentUserId
				};

				List<DateTime> reminders = new List<DateTime>();
				if (cboReminder.SelectedItem != null && cboReminder.SelectedItem.ToString() != "Không nhắc nhở")
				{
					string selectedReminder = cboReminder.SelectedItem.ToString();
					string numberString = selectedReminder.Split(' ')[0];

					if (int.TryParse(numberString, out int minutesToSubtract))
					{
						reminders.Add(startTime.AddMinutes(-minutesToSubtract));
					}
				}

				eventBll.CreateAppointment(newAppt, reminders);

				MessageBox.Show("Tạo lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Có lỗi xảy ra khi lưu: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}

using OOAD_Calendar.BLL;
using OOAD_Calendar.DTO;
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
	public partial class AddGroupMeetingForm : Form
	{
		private int currentUserId;
		private EventBLL eventBll = new EventBLL();
		private List<int> selectedParticipantIds = new List<int>();

		public AddGroupMeetingForm(int userId, DateTime selectedDate)
		{
			InitializeComponent();
			this.currentUserId = userId;

			dtpStart.Value = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, 8, 0, 0);
			dtpEnd.Value = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, 9, 0, 0);

			cboReminder.SelectedIndex = 0;
		}

		private void AddGroupMeetingForm_Load(object sender, EventArgs e)
		{
			UserBLL userBll = new UserBLL();
			List<User> otherUsers = userBll.GetOtherUsers(currentUserId);

			cboParticipants.DataSource = otherUsers;
			cboParticipants.DisplayMember = "UserName"; // Cột muốn hiển thị
			cboParticipants.ValueMember = "UserId";     // Cột chứa giá trị ngầm

			lbParticipants.Items.Clear();
		}
		private void btnAddGuest_Click(object sender, EventArgs e)
		{
			if (cboParticipants.SelectedItem != null)
			{
				User selectedUser = (User)cboParticipants.SelectedItem;

				if (!selectedParticipantIds.Contains(selectedUser.UserId))
				{
					selectedParticipantIds.Add(selectedUser.UserId);
					lbParticipants.Items.Add(selectedUser.UserName);
				}
				else
				{
					MessageBox.Show("Người dùng này đã có trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
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
				MessageBox.Show("Tên cuộc họp không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtName.Focus();
				return;
			}

			if (!eventBll.ValidateTime(startTime, endTime))
			{
				MessageBox.Show("Thời gian kết thúc phải lớn hơn thời gian bắt đầu!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				dtpEnd.Focus();
				return;
			}

			bool isOverlap = eventBll.HasOverlappingEvents(currentUserId, startTime, endTime);

			if (isOverlap)
			{
				DialogResult overlapResult = MessageBox.Show(
					"Khoảng thời gian này bạn đã có lịch trình khác. Bạn có muốn thay thế (Xóa lịch cũ, lưu cuộc họp này) không?\n\n- Chọn 'Yes' để thay thế.\n- Chọn 'No' để chọn lại giờ khác.",
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
				GroupMeeting newMeeting = new GroupMeeting
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

				eventBll.CreateGroupMeeting(newMeeting, reminders, selectedParticipantIds);

				MessageBox.Show("Tạo cuộc họp nhóm và mời thành viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

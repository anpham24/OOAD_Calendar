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
	public partial class MainForm : Form
	{
		private int currentUserId;

		private EventBLL eventBll = new EventBLL();

		public MainForm(int userId)
		{
			InitializeComponent();
			this.currentUserId = userId;
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			DateTime today = DateTime.Today;
			RefreshBoldedDates(today.Month, today.Year);
			LoadEventsForDate(today);
		}

		// ==========================================
		// CÁC HÀM XỬ LÝ GIAO DIỆN VÀ GỌI BLL
		// ==========================================

		// Hàm tô đậm ngày trên lịch
		private void RefreshBoldedDates(int month, int year)
		{
			List<DateTime> boldDates = eventBll.GetDatesWithEvents(currentUserId, month, year);

			monthCalendar1.BoldedDates = boldDates.ToArray();
			monthCalendar1.UpdateBoldedDates(); 
		}

		// Hàm tải sự kiện của 1 ngày lên Grid
		private void LoadEventsForDate(DateTime date)
		{
			dgvEvents.AutoGenerateColumns = false;
			var events = eventBll.GetEventsByDate(currentUserId, date);
			dgvEvents.DataSource = events;
		}

		// ==========================================
		// CÁC SỰ KIỆN TƯƠNG TÁC (EVENTS)
		// ==========================================

		// Khi người dùng click chọn 1 ngày trên lịch
		private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
		{
			DateTime selectedDate = e.Start;
			LoadEventsForDate(selectedDate);
		}

		// Khi click nút "Tạo Appointment"
		private void btnAppointMent_Click(object sender, EventArgs e)
		{
			DateTime selectedDate = monthCalendar1.SelectionStart;
			AddAppointmentForm apptForm = new AddAppointmentForm(currentUserId, selectedDate);

			if (apptForm.ShowDialog() == DialogResult.OK)
			{
				RefreshBoldedDates(selectedDate.Month, selectedDate.Year);
				LoadEventsForDate(selectedDate);
			}
		}

		// Khi click nút "Tạo Group Meeting"
		private void btnGroupMeeting_Click(object sender, EventArgs e)
		{
			DateTime selectedDate = monthCalendar1.SelectionStart;
			AddGroupMeetingForm groupForm = new AddGroupMeetingForm(currentUserId, selectedDate);

			if (groupForm.ShowDialog() == DialogResult.OK)
			{
				RefreshBoldedDates(selectedDate.Month, selectedDate.Year);
				LoadEventsForDate(selectedDate);
			}
		}
		private void btnLogout_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show(
			"Bạn có chắc chắn muốn đăng xuất không?",
			"Xác nhận đăng xuất",
			MessageBoxButtons.YesNo,
			MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				this.DialogResult = DialogResult.Abort;
				this.Close();
			}
		}
	}
}

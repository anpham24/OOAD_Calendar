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
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnGruopMeeting_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionStart;

            AddGroupMeetingForm f = new AddGroupMeetingForm(selectedDate);
            if (f.ShowDialog() == DialogResult.OK)
            {
                // LoadDataToDataGridView();
                MessageBox.Show("Đã cập nhật lịch hẹn cá nhân mới vào danh sách!");
            }
        }

        private void btnAppointMent_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionStart;

            AddAppointmentForm f = new AddAppointmentForm(selectedDate);
            if (f.ShowDialog() == DialogResult.OK)
            {
                // LoadDataToDataGridView();
                MessageBox.Show("Đã cập nhật cuộc họp nhóm mới vào danh sách!");
            }
        }

        private void LoadDataToDataGridView()
        {
            // --- PHẦN NÀY SẼ RÁP VỚI DATABASE SAU ---
        }
    }
}

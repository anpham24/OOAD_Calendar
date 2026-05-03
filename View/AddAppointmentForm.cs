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
        public AddAppointmentForm(DateTime dateFormMain)
        {
            InitializeComponent();

            dtpStart.Value = dateFormMain;
            dtpEnd.Value = dateFormMain.AddHours(1);
        }

        public AddAppointmentForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckInputValidation()) return;
            if (!HandleScheduleConflict()) return;
            if (!HandleGroupMeetingMatching()) return;
            FinalizeSave();
        }

        private bool CheckInputValidation()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text.Trim()))
            {
                MessageBox.Show("Tên lịch hẹn không được để trống!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpEnd.Value <= dtpStart.Value)
            {
                MessageBox.Show("Giờ kết thúc phải sau giờ bắt đầu!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool HandleScheduleConflict()
        {
            bool isConflict = false;
            // sau này bool isConflict = CheckConflictInDatabase();

            if (isConflict)
            {
                var result = MessageBox.Show("Khung giờ này đã có lịch hẹn khác. Bạn có muốn GHI ĐÈ (Xóa lịch cũ) không?",
                            "Xung đột lịch", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // 1. Sau này ráp DB, chỗ này gọi hàm Xóa lịch cũ:
                    // db.Appointments.Remove(lịch_bị_trùng);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private bool HandleGroupMeetingMatching()
        {
            bool isMatchGroup = false; // = CheckGroupInDatabase();
            if (isMatchGroup)
            {
                DialogResult result = MessageBox.Show("Lịch cá nhân này trùng với một cuộc họp nhóm. Bạn có muốn gia nhập nhóm đó luôn không?",
                                "Tham gia nhóm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (result)
                {
                    case DialogResult.Cancel: return false;

                    case DialogResult.Yes:
                        JoinGroupMeeting();
                        this.DialogResult = DialogResult.OK;
                        return false;

                    case DialogResult.No: return true;

                    default: return true;
                }
            }
            return true;
        }

        private void JoinGroupMeeting()
        {
            // 1. Logic Database: Thêm User hiện tại vào ParticipantList của Group đó
            // group.addParticipant(currentUser);  db.SaveChanges();

            MessageBox.Show("Bạn đã được thêm vào cuộc họp nhóm thành công!", "Thông báo");
        }

        private void FinalizeSave()
        {
            try
            {
                // Gọi code lưu của bạn làm Database ở đây
                // db.SaveChanges(); 

                MessageBox.Show("Đã thêm lịch hẹn thành công!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Trả kết quả về cho MainForm biết để Load lại DGV
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi lưu: " + ex.Message, "Lỗi hệ thống",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                DialogResult result = MessageBox.Show("Những thay đổi của bạn chưa được lưu. Bạn có chắc chắn muốn thoát không?",
                    "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No) return;
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

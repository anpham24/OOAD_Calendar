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
        public AddGroupMeetingForm(DateTime dateFormMain)
        {
            InitializeComponent();
            dtpStart.Value = dateFormMain;
            dtpEnd.Value = dateFormMain.AddHours(1);
        }

        public AddGroupMeetingForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Trạm 1: Kiểm tra tính hợp lệ của dữ liệu (Validation)
            if (!CheckInputValidation()) return;

            // Trạm 2: Kiểm tra và xử lý xung đột thời gian (Conflict)
            if (!HandleScheduleConflict()) return;

            // Trạm 3: Kiểm tra và xử lý gia nhập nhóm (Group Meeting)
            if (!HandleGroupMeetingMatching()) return;

            // Cuối cùng: Thực hiện lưu chính thức
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
            // Chỗ này sau này bạn làm DB sẽ viết hàm như: db.Appointments.Any(x => trùng giờ)
            bool isConflict = false;
            // sau này bool isConflict = CheckConflictInDatabase(); Giả sử đây là hàm kiểm tra thực tế

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
                DialogResult result = MessageBox.Show("Tìm thấy cuộc họp nhóm trùng tên. Bạn muốn tham gia chứ?",
                                        "Tham gia nhóm", MessageBoxButtons.YesNoCancel,
                                        MessageBoxIcon.Question);
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
            // --- PHẦN LOGIC CẦN DATABASE (SAU NÀY) ---
            // 1. Tìm đối tượng GroupMeeting đang trùng khớp trong DB
            // var group = db.GroupMeetings.FirstOrDefault(g => g.name == txtTitle.Text);

            // 2. Lấy thông tin User hiện tại (ví dụ User Apaka)
            // var currentUser = db.Users.Find(currentUserId);

            // 3. Gọi phương thức addParticipant như sơ đồ Class đã vẽ
            // group.addParticipant(currentUser);

            // 4. Lưu thay đổi vào DB
            // db.SaveChanges();

            if (lbParticipants != null && !lbParticipants.IsDisposed)
            {
                lbParticipants.Items.Add("Bạn đã tham gia nhóm");
            }

            MessageBox.Show("Hệ thống đã thêm bạn vào danh sách tham gia của cuộc họp nhóm này!",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnAddGuest_Click(object sender, EventArgs e)
        {
            string guest = txtGuestName.Text.Trim();
            if (!string.IsNullOrEmpty(guest) && !lbParticipants.Items.Contains(guest))
            {
                lbParticipants.Items.Add(guest);
                txtGuestName.Clear();
            }
        }

        private void lbParticipants_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && lbParticipants.SelectedIndex != -1)
            {
                string selectedItem = lbParticipants.SelectedItem.ToString();
                if (selectedItem == "Bạn đã tham gia nhóm")
                {
                    MessageBox.Show("Bạn không thể xóa chính mình khỏi cuộc họp nhóm tại đây!");
                    return;
                }

                DialogResult confirm = MessageBox.Show("Bạn có chắc muốn xóa khách mời này?",
                                           "Xác nhận xóa", MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    lbParticipants.Items.RemoveAt(lbParticipants.SelectedIndex);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã nhập gì chưa
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

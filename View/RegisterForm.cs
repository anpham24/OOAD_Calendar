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
	public partial class RegisterForm : Form
	{
		public RegisterForm()
		{
			InitializeComponent();
		}

		private void btnRegister_Click(object sender, EventArgs e)
		{
			string username = txtUsername.Text.Trim();

			if (string.IsNullOrEmpty(username))
			{
				MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtUsername.Focus();
				return;
			}

			try
			{
				UserBLL userBll = new UserBLL();
				bool isSuccess = userBll.Register(username);

				if (isSuccess)
				{
					MessageBox.Show("Tạo tài khoản thành công! Bây giờ bạn có thể đăng nhập.",
									"Thành công",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);

					this.Close();
				}
				else
				{
					MessageBox.Show("Tên đăng nhập này đã tồn tại. Vui lòng chọn tên khác!",
									"Lỗi",
									MessageBoxButtons.OK,
									MessageBoxIcon.Error);
					txtUsername.Focus();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Có lỗi xảy ra trong quá trình đăng ký: " + ex.Message,
								"Lỗi hệ thống",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);
			}
		}
	}
}

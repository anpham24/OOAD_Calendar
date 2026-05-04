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
	public partial class LoginForm : Form
	{
		public LoginForm()
		{
			InitializeComponent();
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			string username = txtUsername.Text.Trim();

			if (string.IsNullOrEmpty(username))
			{
				MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtUsername.Focus();
				return;
			}

			try
			{
				UserBLL userBll = new UserBLL();
				User loggedInUser = userBll.Login(username);

				if (loggedInUser != null)
				{
					this.Hide();
					MainForm mainForm = new MainForm(loggedInUser.UserId);
					DialogResult rs = mainForm.ShowDialog();
					if (rs == DialogResult.Abort)
					{
						txtUsername.Text = "";
						this.Show();
					}
					else
					{
						this.Close();
					}
				}
				else
				{
					MessageBox.Show("Tên đăng nhập không tồn tại! Vui lòng kiểm tra lại hoặc Tạo tài khoản mới.",
									"Lỗi đăng nhập",
									MessageBoxButtons.OK,
									MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Có lỗi xảy ra trong quá trình đăng nhập: " + ex.Message,
								"Lỗi hệ thống",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);
			}
		}
		private void btnNewAccount_Click(object sender, EventArgs e)
		{
			RegisterForm registerForm = new RegisterForm();
			this.Hide();
			registerForm.ShowDialog();
			this.Show();
		}
	}
}

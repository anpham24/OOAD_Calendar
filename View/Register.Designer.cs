namespace OOAD_Calendar.View
{
	partial class Register
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
			this.btnRegister = new System.Windows.Forms.Button();
			this.txtRegister = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnRegister
			// 
			this.btnRegister.Location = new System.Drawing.Point(318, 239);
			this.btnRegister.Name = "btnRegister";
			this.btnRegister.Size = new System.Drawing.Size(136, 33);
			this.btnRegister.TabIndex = 5;
			this.btnRegister.Text = "Đăng ký";
			this.btnRegister.UseVisualStyleBackColor = true;
			// 
			// txtRegister
			// 
			this.txtRegister.Location = new System.Drawing.Point(380, 179);
			this.txtRegister.Name = "txtRegister";
			this.txtRegister.Size = new System.Drawing.Size(168, 22);
			this.txtRegister.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(252, 182);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(98, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Tên đăng nhập";
			// 
			// Register
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnRegister);
			this.Controls.Add(this.txtRegister);
			this.Controls.Add(this.label1);
			this.Name = "Register";
			this.Text = "Register";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnRegister;
		private System.Windows.Forms.TextBox txtRegister;
		private System.Windows.Forms.Label label1;
	}
}
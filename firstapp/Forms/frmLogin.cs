using System;
using System.Drawing;
using System.Windows.Forms;

namespace btlwindow
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            StyleHelper.ApplyFormStyle(this);
            this.BackColor = AppTheme.BackgroundWhite;

            // Title
            lblTitle.Font = AppTheme.FontTitle;
            lblTitle.ForeColor = AppTheme.PrimaryColor;

            // Buttons
            StyleHelper.ApplyPrimaryButton(btnLogin);
            StyleHelper.ApplySecondaryButton(btnRegister);
            StyleHelper.ApplyDangerButton(btnExit);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string matKhau = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ email và mật khẩu!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserModel user = UserRepository.Login(email, matKhau);
            if (user != null)
            {
                CurrentUser.User = user;
                MessageBox.Show($"Đăng nhập thành công!\nXin chào {user.HoTen} ({user.Role})", 
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Email hoặc mật khẩu không đúng!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister registerForm = new frmRegister();
            registerForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}

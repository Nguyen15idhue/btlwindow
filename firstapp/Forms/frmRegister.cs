using System;
using System.Drawing;
using System.Windows.Forms;

namespace btlwindow
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string hoTen = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string matKhau = txtPassword.Text;
            string matKhauXacNhan = txtConfirmPassword.Text;
            string role = cboRole.SelectedItem?.ToString();

            // Validate
            if (string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập email!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (matKhau.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (matKhau != matKhauXacNhan)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Clear();
                txtConfirmPassword.Focus();
                return;
            }

            if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Vui lòng chọn vai trò!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboRole.Focus();
                return;
            }

            // Đăng ký
            bool success = UserRepository.Register(hoTen, email, matKhau, role);
            if (success)
            {
                MessageBox.Show("Đăng ký thành công!\nVui lòng đăng nhập để tiếp tục.", 
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
            txtConfirmPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            // Thêm các vai trò vào ComboBox
            cboRole.Items.Add("Manager");
            cboRole.Items.Add("Employee");
            cboRole.SelectedIndex = 1; // Mặc định là Employee
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace btlwindow
{
    public partial class frmAddTask : Form
    {
        // Property để trả dữ liệu về Form1
        public TaskModel NewTask { get; private set; }
        public bool TaskAdded { get; private set; } = false;

        public frmAddTask()
        {
            InitializeComponent();
        }

        private void frmAddTask_Load(object sender, EventArgs e)
        {
            // Load danh sách độ ưu tiên
            cbDoUuTien.Items.Clear();
            cbDoUuTien.Items.Add("Cao");
            cbDoUuTien.Items.Add("Trung bình");
            cbDoUuTien.Items.Add("Thấp");
            cbDoUuTien.SelectedIndex = 1; // Mặc định Trung bình

            // Load danh sách thành viên
            LoadMembers();

            // Đặt deadline mặc định là ngày mai
            dtpDeadline.Value = DateTime.Today.AddDays(1);
        }

        private void LoadMembers()
        {
            cbNguoiThucHien.Items.Clear();
            cbNguoiThucHien.Items.Add(new KeyValuePair<int, string>(0, "-- Chọn người thực hiện --"));

            var members = TaskRepository.GetMembers();
            foreach (var member in members)
            {
                cbNguoiThucHien.Items.Add(member);
            }

            cbNguoiThucHien.DisplayMember = "Value";
            cbNguoiThucHien.ValueMember = "Key";
            cbNguoiThucHien.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate dữ liệu
            if (string.IsNullOrWhiteSpace(txtTieuDe.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề công việc!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTieuDe.Focus();
                return;
            }

            if (txtTieuDe.Text.Length > 200)
            {
                MessageBox.Show("Tiêu đề không được quá 200 ký tự!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTieuDe.Focus();
                return;
            }

            if (dtpDeadline.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Hạn hoàn thành không được trong quá khứ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDeadline.Focus();
                return;
            }

            // Lấy người thực hiện
            int nguoiThucHienId = 0;
            if (cbNguoiThucHien.SelectedItem is KeyValuePair<int, string> selected)
            {
                nguoiThucHienId = selected.Key;
            }

            // Thêm task vào database với thông tin người tạo
            bool success = TaskRepository.AddTask(
                txtTieuDe.Text.Trim(),
                txtMoTa.Text.Trim(),
                CurrentUser.User.Id, // Người tạo là user hiện tại
                nguoiThucHienId,     // Người được giao
                dtpDeadline.Value,
                cbDoUuTien.SelectedItem?.ToString() ?? "Trung bình"
            );

            if (success)
            {
                TaskAdded = true;
                MessageBox.Show("Thêm công việc thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

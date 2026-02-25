using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace btlwindow
{
    public partial class frmAddTask : Form
    {
        // Property để trả dữ liệu về Form1
        public TaskModel NewTask { get; private set; }
        public bool TaskAdded { get; private set; } = false;

        // Biến để xác định chế độ: Thêm mới hay Chỉnh sửa
        private bool isEditMode = false;
        private TaskModel taskToEdit;

        // Constructor mặc định - Chế độ thêm mới
        public frmAddTask()
        {
            InitializeComponent();
            ApplyTheme();
            isEditMode = false;
        }

        // Constructor cho chế độ chỉnh sửa
        public frmAddTask(TaskModel task)
        {
            InitializeComponent();
            ApplyTheme();
            isEditMode = true;
            taskToEdit = task;
        }

        private void ApplyTheme()
        {
            // Form style
            StyleHelper.ApplyDialogStyle(this);
            this.BackColor = AppTheme.BackgroundWhite;

            // Buttons
            StyleHelper.ApplySuccessButton(btnSave);
            StyleHelper.ApplySecondaryButton(btnCancel);
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

            // Load danh sách nhóm
            LoadGroups();

            // Load danh sách tags
            LoadTags();

            // Đặt deadline mặc định là ngày mai
            dtpDeadline.Value = DateTime.Today.AddDays(1);

            // Nếu là chế độ chỉnh sửa, load dữ liệu task
            if (isEditMode && taskToEdit != null)
            {
                LoadTaskData();
                this.Text = "✏️ Chỉnh sửa Task";
                btnSave.Text = "💾 Cập nhật";
            }
            else
            {
                this.Text = "➕ Thêm Task mới";
                btnSave.Text = "💾 Lưu";
            }
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

        private void LoadGroups()
        {
            cbNhom.Items.Clear();
            cbNhom.Items.Add(new KeyValuePair<int, string>(0, "-- Khong chon nhom --"));

            var groups = TagGroupRepository.GetAllGroups();
            foreach (var group in groups)
            {
                cbNhom.Items.Add(new KeyValuePair<int, string>(group.Id, group.TenNhom));
            }

            cbNhom.DisplayMember = "Value";
            cbNhom.ValueMember = "Key";
            cbNhom.SelectedIndex = 0;
        }

        private void LoadTags()
        {
            clbTags.Items.Clear();
            var tags = TagGroupRepository.GetAllTags();
            foreach (var tag in tags)
            {
                clbTags.Items.Add(tag.TenTag, false);
            }
        }

        // Load dữ liệu task vào form (chế độ Edit)
        private void LoadTaskData()
        {
            txtTieuDe.Text = taskToEdit.TieuDe;
            txtMoTa.Text = taskToEdit.MoTa ?? "";

            // Set deadline
            if (taskToEdit.HanHoanThanh != DateTime.MinValue)
            {
                dtpDeadline.Value = taskToEdit.HanHoanThanh;
            }

            // Set độ ưu tiên
            switch (taskToEdit.DoUuTien)
            {
                case "Cao":
                    cbDoUuTien.SelectedIndex = 0;
                    break;
                case "Trung bình":
                    cbDoUuTien.SelectedIndex = 1;
                    break;
                case "Thấp":
                    cbDoUuTien.SelectedIndex = 2;
                    break;
                default:
                    cbDoUuTien.SelectedIndex = 1;
                    break;
            }

            // Set người thực hiện
            if (taskToEdit.NguoiDuocGiaoId > 0)
            {
                for (int i = 0; i < cbNguoiThucHien.Items.Count; i++)
                {
                    var item = cbNguoiThucHien.Items[i];
                    if (item is KeyValuePair<int, string> kvp && kvp.Key == taskToEdit.NguoiDuocGiaoId)
                    {
                        cbNguoiThucHien.SelectedIndex = i;
                        break;
                    }
                }
            }

            // Set nhóm
            if (taskToEdit.NhomId.HasValue && taskToEdit.NhomId > 0)
            {
                for (int i = 0; i < cbNhom.Items.Count; i++)
                {
                    var item = cbNhom.Items[i];
                    if (item is KeyValuePair<int, string> kvp && kvp.Key == taskToEdit.NhomId.Value)
                    {
                        cbNhom.SelectedIndex = i;
                        break;
                    }
                }
            }

            // Set tags
            if (taskToEdit.Tags != null && taskToEdit.Tags.Count > 0)
            {
                for (int i = 0; i < clbTags.Items.Count; i++)
                {
                    string tagName = clbTags.Items[i].ToString();
                    if (taskToEdit.Tags.Contains(tagName))
                    {
                        clbTags.SetItemChecked(i, true);
                    }
                }
            }
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

            if (dtpDeadline.Value.Date < DateTime.Today && !isEditMode)
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

            // Lấy nhóm
            int? nhomId = null;
            if (cbNhom.SelectedItem is KeyValuePair<int, string> selectedGroup && selectedGroup.Key > 0)
            {
                nhomId = selectedGroup.Key;
            }

            // Lấy tags đã chọn
            List<int> tagIds = new List<int>();
            var allTags = TagGroupRepository.GetAllTags();
            for (int i = 0; i < clbTags.CheckedItems.Count; i++)
            {
                string tagName = clbTags.CheckedItems[i].ToString();
                var tag = allTags.FirstOrDefault(t => t.TenTag == tagName);
                if (tag != null)
                {
                    tagIds.Add(tag.Id);
                }
            }

            bool success = false;

            if (isEditMode)
            {
                // Chế độ chỉnh sửa - Update task
                success = TaskRepository.UpdateTask(
                    taskToEdit.Id,
                    txtTieuDe.Text.Trim(),
                    txtMoTa.Text.Trim(),
                    nguoiThucHienId,
                    dtpDeadline.Value,
                    cbDoUuTien.SelectedItem?.ToString() ?? "Trung bình",
                    nhomId,
                    tagIds
                );

                if (success)
                {
                    TaskAdded = true;
                    MessageBox.Show("Cập nhật công việc thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                // Chế độ thêm mới - Add task
                success = TaskRepository.AddTask(
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace btlwindow
{
    public partial class ucManageMembers : UserControl
    {
        // Pagination properties
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private int totalPages = 0;
        private List<MemberModel> allMembers = new List<MemberModel>();

        public ucManageMembers()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            // Background
            this.BackColor = AppTheme.BackgroundLight;

            // Title
            lblTitle.Font = AppTheme.FontTitle;
            lblTitle.ForeColor = AppTheme.PrimaryColor;

            // Subtitle
            lblSubtitle.Font = AppTheme.FontBody;
            lblSubtitle.ForeColor = AppTheme.TextSecondary;

            // Stats panel
            pnlStats.BackColor = AppTheme.BackgroundWhite;

            // DataGridView styling
            dgvMembers.BackgroundColor = AppTheme.BackgroundWhite;
            dgvMembers.BorderStyle = BorderStyle.None;
            dgvMembers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMembers.ColumnHeadersDefaultCellStyle.BackColor = AppTheme.PrimaryColor;
            dgvMembers.ColumnHeadersDefaultCellStyle.ForeColor = AppTheme.TextWhite;
            dgvMembers.ColumnHeadersDefaultCellStyle.Font = AppTheme.FontBodyBold;
            dgvMembers.ColumnHeadersDefaultCellStyle.SelectionBackColor = AppTheme.PrimaryDark;
            dgvMembers.ColumnHeadersHeight = 40;
            dgvMembers.EnableHeadersVisualStyles = false;
            dgvMembers.DefaultCellStyle.SelectionBackColor = AppTheme.PrimaryLight;
            dgvMembers.DefaultCellStyle.SelectionForeColor = AppTheme.TextWhite;
            dgvMembers.DefaultCellStyle.Font = AppTheme.FontBody;
            dgvMembers.DefaultCellStyle.Padding = new Padding(5);
            dgvMembers.RowTemplate.Height = 35;
            dgvMembers.GridColor = AppTheme.BorderLight;

            // Buttons
            StyleHelper.ApplyPrimaryButton(btnChangeRole);
            StyleHelper.ApplySuccessButton(btnAddMember);
            StyleHelper.ApplyDangerButton(btnDelete);
            StyleHelper.ApplySecondaryButton(btnRefresh);
        }

        private void ucManageMembers_Load(object sender, EventArgs e)
        {
            CheckPermissions();
            cboPageSize.SelectedIndex = 0; // 10 records per page
            LoadMembers();
            UpdateStats();
        }

        private void CheckPermissions()
        {
            // Chỉ Manager mới có quyền thêm, sửa, xóa
            bool isManager = CurrentUser.IsManager;

            btnAddMember.Visible = isManager;
            btnChangeRole.Visible = isManager;
            btnDelete.Visible = isManager;

            if (!isManager)
            {
                lblPermissionInfo.Text = "🔒 Bạn chỉ có quyền xem thông tin thành viên";
                lblPermissionInfo.ForeColor = AppTheme.WarningColor;
                lblPermissionInfo.Visible = true;
            }
            else
            {
                lblPermissionInfo.Text = "🔑 Bạn có toàn quyền quản lý thành viên";
                lblPermissionInfo.ForeColor = AppTheme.SecondaryColor;
                lblPermissionInfo.Visible = true;
            }
        }

        public void LoadMembers()
        {
            try
            {
                // Load all members from database
                allMembers = MemberRepository.GetAllMembers();
                totalRecords = allMembers.Count;
                totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

                // Validate current page
                if (currentPage > totalPages && totalPages > 0)
                    currentPage = totalPages;
                if (currentPage < 1)
                    currentPage = 1;

                // Display paginated data
                DisplayCurrentPage();
                UpdatePaginationControls();
                UpdateStats();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách thành viên: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayCurrentPage()
        {
            dgvMembers.Rows.Clear();

            // Calculate start and end index for current page
            int startIndex = (currentPage - 1) * pageSize;
            int endIndex = Math.Min(startIndex + pageSize, totalRecords);

            // Display data for current page
            for (int i = startIndex; i < endIndex; i++)
            {
                var m = allMembers[i];
                int idx = dgvMembers.Rows.Add(
                    i + 1,  // STT global
                    m.Id, 
                    m.HoTen, 
                    m.Email, 
                    m.Role == "Manager" ? "🔑 Quản lý" : "👤 Nhân viên", 
                    m.NgayTao.ToString("dd/MM/yyyy")
                );

                dgvMembers.Rows[idx].Tag = m;

                // Highlight Manager rows
                if (m.Role == "Manager")
                {
                    dgvMembers.Rows[idx].DefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
                    dgvMembers.Rows[idx].DefaultCellStyle.Font = new Font(AppTheme.FontFamily, 9F, FontStyle.Bold);
                }

                // Highlight current user
                if (m.Id == CurrentUser.User.Id)
                {
                    dgvMembers.Rows[idx].DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 220);
                }
            }
        }

        private void UpdatePaginationControls()
        {
            // Update page info label
            lblPageInfo.Text = $"Trang {currentPage} / {Math.Max(1, totalPages)} (Tổng: {totalRecords} bản ghi)";

            // Enable/disable navigation buttons
            btnFirstPage.Enabled = currentPage > 1;
            btnPrevPage.Enabled = currentPage > 1;
            btnNextPage.Enabled = currentPage < totalPages;
            btnLastPage.Enabled = currentPage < totalPages;

            // Change button colors based on enabled state
            Color enabledColor = AppTheme.PrimaryColor;
            Color disabledColor = Color.FromArgb(189, 195, 199);

            btnFirstPage.BackColor = btnFirstPage.Enabled ? enabledColor : disabledColor;
            btnPrevPage.BackColor = btnPrevPage.Enabled ? enabledColor : disabledColor;
            btnNextPage.BackColor = btnNextPage.Enabled ? enabledColor : disabledColor;
            btnLastPage.BackColor = btnLastPage.Enabled ? enabledColor : disabledColor;
        }

        private void UpdateStats()
        {
            int totalMembers = allMembers.Count;
            int managers = allMembers.FindAll(m => m.Role == "Manager").Count;
            int employees = allMembers.FindAll(m => m.Role == "Employee").Count;

            lblTotalMembers.Text = totalMembers.ToString();
            lblTotalManagers.Text = managers.ToString();
            lblTotalEmployees.Text = employees.ToString();
        }

        // Pagination event handlers
        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            DisplayCurrentPage();
            UpdatePaginationControls();
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayCurrentPage();
                UpdatePaginationControls();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                DisplayCurrentPage();
                UpdatePaginationControls();
            }
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            currentPage = Math.Max(1, totalPages);
            DisplayCurrentPage();
            UpdatePaginationControls();
        }

        private void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Parse page size from combo box
            string selected = cboPageSize.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selected))
            {
                string[] parts = selected.Split(' ');
                if (parts.Length > 0 && int.TryParse(parts[0], out int newSize))
                {
                    pageSize = newSize;
                    currentPage = 1; // Reset to first page
                    LoadMembers();
                }
            }
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.IsManager)
            {
                MessageBox.Show("Bạn không có quyền thêm thành viên!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (frmRegister frm = new frmRegister())
            {
                frm.Text = "Thêm thành viên mới";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadMembers();
                    MessageBox.Show("Đã thêm thành viên thành công!", "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnChangeRole_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.IsManager)
            {
                MessageBox.Show("Bạn không có quyền thay đổi vai trò!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvMembers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn thành viên cần thay đổi vai trò!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MemberModel m = dgvMembers.SelectedRows[0].Tag as MemberModel;
            if (m == null) return;

            if (m.Id == CurrentUser.User.Id)
            {
                MessageBox.Show("Không thể thay đổi vai trò của chính mình!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string currentRole = m.Role == "Manager" ? "Quản lý" : "Nhân viên";
            string newRole = m.Role == "Manager" ? "Employee" : "Manager";
            string newRoleDisplay = newRole == "Manager" ? "Quản lý" : "Nhân viên";

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn thay đổi vai trò của '{m.HoTen}' từ '{currentRole}' thành '{newRoleDisplay}'?",
                "Xác nhận thay đổi vai trò",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                if (MemberRepository.UpdateMemberRole(m.Id, newRole))
                {
                    LoadMembers();
                    MessageBox.Show($"Đã cập nhật vai trò thành công!", "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.IsManager)
            {
                MessageBox.Show("Bạn không có quyền xóa thành viên!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvMembers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn thành viên cần xóa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MemberModel m = dgvMembers.SelectedRows[0].Tag as MemberModel;
            if (m == null) return;

            if (m.Id == CurrentUser.User.Id)
            {
                MessageBox.Show("Không thể xóa chính mình!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"⚠️ CẢNH BÁO: Bạn có chắc chắn muốn xóa thành viên '{m.HoTen}' ({m.Email})?\n\n" +
                "Hành động này không thể hoàn tác!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                if (MemberRepository.DeleteMember(m.Id))
                {
                    LoadMembers();
                    MessageBox.Show("Đã xóa thành viên thành công!", "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadMembers();
            MessageBox.Show("Đã làm mới danh sách!", "Thông báo", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvMembers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            MemberModel m = dgvMembers.Rows[e.RowIndex].Tag as MemberModel;
            if (m == null) return;

            string roleDisplay = m.Role == "Manager" ? "Quản lý" : "Nhân viên";
            string info = $"📋 Thông tin chi tiết:\n\n" +
                         $"👤 Họ tên: {m.HoTen}\n" +
                         $"📧 Email: {m.Email}\n" +
                         $"🔑 Vai trò: {roleDisplay}\n" +
                         $"📅 Ngày tham gia: {m.NgayTao:dd/MM/yyyy HH:mm}\n" +
                         $"🆔 ID: {m.Id}";

            MessageBox.Show(info, "Chi tiết thành viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

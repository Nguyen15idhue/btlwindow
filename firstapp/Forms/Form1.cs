using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace btlwindow
{
    public partial class Form1 : Form
    {
        // Danh sách tất cả task (cache)
        private List<TaskModel> allTasks = new List<TaskModel>();

        public Form1()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            // Form style
            this.BackColor = AppTheme.BackgroundLight;
            this.Font = new Font(AppTheme.FontFamily, 9F);

            // Sidebar
            panelSidebar.BackColor = AppTheme.BackgroundSidebar;
            lblLogo.Font = AppTheme.FontTitle;
            lblLogo.ForeColor = AppTheme.TextWhite;

            // Menu buttons
            StyleHelper.ApplySidebarButton(btnDashboard, true);
            StyleHelper.ApplySidebarButton(btnQuanLyThanhVien);
            StyleHelper.ApplySidebarButton(btnReport);
            StyleHelper.ApplySuccessButton(btnOpenAddForm);
            btnOpenAddForm.TextAlign = ContentAlignment.MiddleLeft;
            btnOpenAddForm.Padding = new Padding(15, 0, 0, 0);
            StyleHelper.ApplyDangerButton(btnLogout);

            // User info
            lblUserInfo.Font = AppTheme.FontBodyBold;
            lblUserInfo.ForeColor = AppTheme.TextWhite;
            lblUserRole.Font = AppTheme.FontSmall;
            lblUserRole.ForeColor = AppTheme.BorderLight;

            // Top panel
            panelTop.BackColor = AppTheme.BackgroundWhite;
            lblSearch.Font = AppTheme.FontBodyBold;
            lblSearch.ForeColor = AppTheme.TextPrimary;
            lblFilter.Font = AppTheme.FontBodyBold;
            lblFilter.ForeColor = AppTheme.TextPrimary;
            lblSort.Font = AppTheme.FontBodyBold;
            lblSort.ForeColor = AppTheme.TextPrimary;

            // Export button
            StyleHelper.ApplySuccessButton(btnExportCSV);

            // Main content
            panelMain.BackColor = AppTheme.BackgroundLight;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin user đang đăng nhập
            if (CurrentUser.User != null)
            {
                lblUserInfo.Text = $"👤 {CurrentUser.User.HoTen}";
                lblUserRole.Text = CurrentUser.User.Role == "Manager" ? "🔑 Quản lý" : "👷 Nhân viên";
            }

            // Khởi tạo giá trị mặc định cho ComboBox
            cbFilterPriority.SelectedIndex = 0; // "Tất cả"
            cbSort.SelectedIndex = 0; // "Mặc định"

            // Enable Drag & Drop cho các FlowLayoutPanel
            SetupDragAndDrop();

            // Load dữ liệu
            LoadAllTasks();
        }

        // ============================================================
        // SETUP DRAG & DROP
        // ============================================================
        private void SetupDragAndDrop()
        {
            // Enable drag & drop cho các FlowLayoutPanel
            flpTodo.AllowDrop = true;
            flpDoing.AllowDrop = true;
            flpDone.AllowDrop = true;

            // Todo column events
            flpTodo.DragEnter += FlowLayoutPanel_DragEnter;
            flpTodo.DragOver += FlowLayoutPanel_DragOver;
            flpTodo.DragDrop += (s, e) => FlowLayoutPanel_DragDrop(s, e, "Todo");

            // Doing column events
            flpDoing.DragEnter += FlowLayoutPanel_DragEnter;
            flpDoing.DragOver += FlowLayoutPanel_DragOver;
            flpDoing.DragDrop += (s, e) => FlowLayoutPanel_DragDrop(s, e, "Doing");

            // Done column events
            flpDone.DragEnter += FlowLayoutPanel_DragEnter;
            flpDone.DragOver += FlowLayoutPanel_DragOver;
            flpDone.DragDrop += (s, e) => FlowLayoutPanel_DragDrop(s, e, "Done");
        }

        // ============================================================
        // DRAG ENTER - CHO PHÉP DROP
        // ============================================================
        private void FlowLayoutPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TaskModel)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        // ============================================================
        // DRAG OVER - LIÊN TỤC CHO PHÉP DROP
        // ============================================================
        private void FlowLayoutPanel_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TaskModel)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        // ============================================================
        // DRAG DROP - CẬP NHẬT TRẠNG THÁI TASK
        // ============================================================
        private void FlowLayoutPanel_DragDrop(object sender, DragEventArgs e, string newStatus)
        {
            if (e.Data.GetDataPresent(typeof(TaskModel)))
            {
                TaskModel task = (TaskModel)e.Data.GetData(typeof(TaskModel));

                // Nếu trạng thái không thay đổi, không làm gì
                if (task.TrangThai == newStatus)
                {
                    return;
                }

                // Cập nhật trạng thái trong database
                bool success = TaskRepository.UpdateTaskStatus(task.Id, newStatus);

                if (success)
                {
                    // Cập nhật trạng thái trong cache
                    task.TrangThai = newStatus;

                    // Refresh bảng Kanban
                    RefreshKanbanBoard();

                    // Hiển thị thông báo nhẹ (có thể bỏ nếu muốn UX mượt hơn)
                    // MessageBox.Show($"Đã chuyển task sang {GetStatusText(newStatus)}", "Thành công", 
                    //     MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật trạng thái task!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ============================================================
        // HELPER - LẤY TÊN TRẠNG THÁI
        // ============================================================
        private string GetStatusText(string status)
        {
            switch (status)
            {
                case "Todo": return "CẦN LÀM";
                case "Doing": return "ĐANG LÀM";
                case "Done": return "ĐÃ XONG";
                default: return status;
            }
        }

        // ============================================================
        // LOAD DỮ LIỆU
        // ============================================================
        private void LoadAllTasks()
        {
            try
            {
                allTasks = TaskRepository.LoadTasks();
                RefreshKanbanBoard();
                UpdateOverdueCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // REFRESH KANBAN BOARD
        // ============================================================
        private void RefreshKanbanBoard()
        {
            // Xóa sạch các thẻ cũ
            flpTodo.Controls.Clear();
            flpDoing.Controls.Clear();
            flpDone.Controls.Clear();

            // Lọc và sắp xếp tasks
            var filteredTasks = ApplyFilters(allTasks);

            // Duyệt qua từng task và tạo thẻ
            foreach (var task in filteredTasks)
            {
                TaskItem item = new TaskItem();
                item.SetData(task);
                item.Width = flpTodo.Width - 30; // Fit width

                // Kết nối các sự kiện từ TaskItem
                item.ViewClicked += TaskItem_ViewClicked;
                item.EditClicked += TaskItem_EditClicked;
                item.DeleteClicked += TaskItem_DeleteClicked;

                // Phân loại vào đúng cột dựa theo trạng thái
                switch (task.TrangThai)
                {
                    case "Todo":
                        flpTodo.Controls.Add(item);
                        break;
                    case "Doing":
                        flpDoing.Controls.Add(item);
                        break;
                    case "Done":
                        flpDone.Controls.Add(item);
                        break;
                    default:
                        flpTodo.Controls.Add(item);
                        break;
                }
            }
        }

        // ============================================================
        // XỬ LÝ SỰ KIỆN NÚT XEM CHI TIẾT TASK
        // ============================================================
        private void TaskItem_ViewClicked(object sender, EventArgs e)
        {
            TaskItem taskItem = sender as TaskItem;
            if (taskItem != null && taskItem.TaskData != null)
            {
                // Mở form xem chi tiết
                frmTaskDetail detailForm = new frmTaskDetail(taskItem.TaskData);
                detailForm.ShowDialog();
            }
        }

        // ============================================================
        // XỬ LÝ SỰ KIỆN NÚT SỬA TASK
        // ============================================================
        private void TaskItem_EditClicked(object sender, EventArgs e)
        {
            TaskItem taskItem = sender as TaskItem;
            if (taskItem != null && taskItem.TaskData != null)
            {
                // Mở form sửa task (sử dụng lại frmAddTask với chế độ Edit)
                frmAddTask editForm = new frmAddTask(taskItem.TaskData);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    // Reload dữ liệu sau khi sửa
                    LoadAllTasks();
                }
            }
        }

        // ============================================================
        // XỬ LÝ SỰ KIỆN NÚT XÓA TASK
        // ============================================================
        private void TaskItem_DeleteClicked(object sender, EventArgs e)
        {
            TaskItem taskItem = sender as TaskItem;
            if (taskItem != null && taskItem.TaskData != null)
            {
                // Xác nhận xóa đã được xử lý trong TaskItem.cs
                // Thực hiện xóa task
                bool success = TaskRepository.DeleteTask(taskItem.TaskData.Id);

                if (success)
                {
                    MessageBox.Show("Đã xóa task thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload dữ liệu
                    LoadAllTasks();
                }
                else
                {
                    MessageBox.Show("Không thể xóa task. Vui lòng thử lại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ============================================================
        // ÁP DỤNG BỘ LỌC VÀ SẮP XẾP
        // ============================================================
        private List<TaskModel> ApplyFilters(List<TaskModel> tasks)
        {
            var result = tasks.AsEnumerable();

            // 1. Tìm kiếm theo tiêu đề
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                string searchText = txtSearch.Text.Trim().ToLower();
                result = result.Where(t => 
                    t.TieuDe != null && t.TieuDe.ToLower().Contains(searchText));
            }

            // 2. Lọc theo độ ưu tiên
            if (cbFilterPriority.SelectedIndex > 0) // Không phải "Tất cả"
            {
                string priority = cbFilterPriority.SelectedItem?.ToString();
                result = result.Where(t => t.DoUuTien == priority);
            }

            // 3. Sắp xếp theo deadline
            if (cbSort.SelectedIndex == 1) // Tăng dần
            {
                result = result.OrderBy(t => t.HanHoanThanh == DateTime.MinValue ? DateTime.MaxValue : t.HanHoanThanh);
            }
            else if (cbSort.SelectedIndex == 2) // Giảm dần
            {
                result = result.OrderByDescending(t => t.HanHoanThanh == DateTime.MinValue ? DateTime.MinValue : t.HanHoanThanh);
            }

            return result.ToList();
        }

        // ============================================================
        // CẬP NHẬT SỐ TASK QUÁ HẠN
        // ============================================================
        private void UpdateOverdueCount()
        {
            int overdueCount = allTasks.Count(t => t.IsOverdue);
            lblOverdueCount.Text = $"⚠️ Quá hạn: {overdueCount:D2}";

            if (overdueCount > 0)
            {
                lblOverdueCount.ForeColor = Color.FromArgb(231, 76, 60);
            }
            else
            {
                lblOverdueCount.ForeColor = Color.FromArgb(46, 204, 113);
            }
        }

        // ============================================================
        // EVENT HANDLERS - TÌM KIẾM
        // ============================================================
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshKanbanBoard();
        }

        // ============================================================
        // EVENT HANDLERS - LỌC THEO ĐỘ ƯU TIÊN
        // ============================================================
        private void cbFilterPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshKanbanBoard();
        }

        // ============================================================
        // EVENT HANDLERS - SẮP XẾP THEO DEADLINE
        // ============================================================
        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshKanbanBoard();
        }

        // ============================================================
        // EVENT HANDLERS - THÊM TASK MỚI
        // ============================================================
        private void btnOpenAddForm_Click(object sender, EventArgs e)
        {
            frmAddTask frmAdd = new frmAddTask();
            if (frmAdd.ShowDialog() == DialogResult.OK)
            {
                // Reload dữ liệu sau khi thêm task mới
                LoadAllTasks();
            }
        }

        // ============================================================
        // EVENT HANDLERS - XUẤT BÁO CÁO CSV
        // ============================================================
        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveDialog.FilterIndex = 1;
                saveDialog.FileName = $"BaoCaoKanban_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                saveDialog.Title = "Xuất báo cáo CSV";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    bool success = TaskRepository.ExportToCSV(allTasks, saveDialog.FileName);
                    if (success)
                    {
                        MessageBox.Show($"Xuất báo cáo thành công!\n\nFile: {saveDialog.FileName}",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Hỏi có muốn mở file không
                        if (MessageBox.Show("Bạn có muốn mở file vừa xuất?", "Mở file",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(saveDialog.FileName);
                        }
                    }
                }
            }
        }

        // ============================================================
        // XỬ LÝ ĐĂNG XUẤT
        // ============================================================
        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Xóa thông tin user hiện tại
                CurrentUser.Logout();

                // Đóng form hiện tại
                this.Hide();

                // Hiển thị lại form đăng nhập
                frmLogin loginForm = new frmLogin();
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Nếu đăng nhập thành công, mở lại Form1 mới
                    Form1 mainForm = new Form1();
                    mainForm.Show();
                }
                else
                {
                    // Nếu không đăng nhập, thoát ứng dụng
                    Application.Exit();
                }
            }
        }

        // ============================================================
        // XỬ LÝ QUẢN LÝ THÀNH VIÊN
        // ============================================================
        private void btnQuanLyThanhVien_Click(object sender, EventArgs e)
        {
            // Ẩn panel chính (Kanban board) với animation
            AnimatePageTransition(() =>
            {
                panelMain.Visible = false;
                panelTop.Visible = false;

                // Xóa các control cũ (nếu có)
                RemovePageControls();

                // Tạo và hiển thị user control quản lý thành viên
                ucManageMembers ucMembers = new ucManageMembers();
                ucMembers.Dock = DockStyle.Fill;
                ucMembers.Tag = "PageContent";

                // Thêm user control vào form
                this.Controls.Add(ucMembers);
                ucMembers.BringToFront();

                // Highlight nút menu đang active
                HighlightActiveMenu(btnQuanLyThanhVien);
            });
        }

        // ============================================================
        // XỬ LÝ QUAY LẠI DASHBOARD
        // ============================================================
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            AnimatePageTransition(() =>
            {
                // Xóa các page control
                RemovePageControls();

                // Hiện lại Kanban board
                panelMain.Visible = true;
                panelTop.Visible = true;

                // Reload dữ liệu
                LoadAllTasks();

                // Highlight nút menu đang active
                HighlightActiveMenu(btnDashboard);
            });
        }

        // ============================================================
        // XÓA CÁC PAGE CONTROL
        // ============================================================
        private void RemovePageControls()
        {
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                Control ctrl = this.Controls[i];
                if (ctrl.Tag?.ToString() == "PageContent")
                {
                    this.Controls.Remove(ctrl);
                    ctrl.Dispose();
                }
            }
        }

        // ============================================================
        // ANIMATION CHUYỂN TRANG
        // ============================================================
        private void AnimatePageTransition(Action onComplete)
        {
            // Disable controls during transition
            this.Enabled = false;

            Timer timer = new Timer();
            timer.Interval = 5;
            int step = 0;
            int maxSteps = 8;

            timer.Tick += (s, e) =>
            {
                step++;
                if (step >= maxSteps / 2 && step == maxSteps / 2)
                {
                    // Thực hiện chuyển trang ở giữa animation
                    onComplete?.Invoke();
                }

                if (step >= maxSteps)
                {
                    timer.Stop();
                    timer.Dispose();
                    this.Enabled = true;
                }
            };

            timer.Start();
        }

        // ============================================================
        // XỬ LÝ QUẢN LÝ BÁO CÁO
        // ============================================================
        private void btnReport_Click(object sender, EventArgs e)
        {
            // Ẩn panel chính (Kanban board) với animation
            AnimatePageTransition(() =>
            {
                panelMain.Visible = false;
                panelTop.Visible = false;

                // Xóa các control cũ (nếu có)
                RemovePageControls();

                // Tạo và hiển thị user control báo cáo
                ucReport uc = new ucReport();
                uc.Dock = DockStyle.Fill;
                uc.Tag = "PageContent";

                // Thêm user control vào form
                this.Controls.Add(uc);
                uc.BringToFront();

                // Highlight nút menu đang active
                HighlightActiveMenu(btnReport);
            });
        }

        // ============================================================
        // XỬ LÝ TAG & NHÓM
        // ============================================================
        private void btnTagGroup_Click(object sender, EventArgs e)
        {
            AnimatePageTransition(() =>
            {
                panelMain.Visible = false;
                panelTop.Visible = false;

                // Xóa các control cũ (nếu có)
                RemovePageControls();

                // Tạo và hiển thị user control tag & nhóm
                ucTagGroup uc = new ucTagGroup();
                uc.Dock = DockStyle.Fill;
                uc.Tag = "PageContent";

                // Thêm user control vào form
                this.Controls.Add(uc);
                uc.BringToFront();

                // Highlight nút menu đang active
                HighlightActiveMenu(btnTagGroup);
            });
        }

        // ============================================================
        // HIGHLIGHT MENU ĐANG ACTIVE
        // ============================================================
        private void HighlightActiveMenu(Button activeBtn)
        {
            // Reset tất cả nút về màu mặc định
            btnDashboard.BackColor = AppTheme.PrimaryLight;
            btnQuanLyThanhVien.BackColor = AppTheme.PrimaryLight;
            btnReport.BackColor = AppTheme.PrimaryLight;
            btnTagGroup.BackColor = AppTheme.PrimaryLight;

            // Highlight nút đang active
            activeBtn.BackColor = AppTheme.PrimaryDark;
        }
    }
}
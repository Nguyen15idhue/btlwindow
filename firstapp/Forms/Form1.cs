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

            // Load dữ liệu
            LoadAllTasks();
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
                CurrentUser.Logout();
                this.Close();

                // Hiển thị lại form đăng nhập
                frmLogin loginForm = new frmLogin();
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Form1());
                }
            }
        }
    }
}
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace btlwindow
{
    public partial class TaskItem : UserControl
    {
        // Biến lưu trữ data gốc (để sau này dùng kéo thả)
        public TaskModel TaskData { get; set; }

        public TaskItem()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        // Hàm này để Form1 gọi, truyền dữ liệu vào thẻ
        public void SetData(TaskModel task)
        {
            TaskData = task;

            // Gán dữ liệu lên các Label
            lblTitle.Text = task.TieuDe ?? "Không có tiêu đề";
            lblAssignee.Text = "👤 " + (task.TenNguoiDuocGiao ?? "Chưa giao");

            // Xử lý hiển thị ngày tháng cho đẹp
            if (task.HanHoanThanh != DateTime.MinValue)
            {
                lblDeadline.Text = "📅 " + task.HanHoanThanh.ToString("dd/MM/yyyy");

                // Logic đổi màu nếu quá hạn
                if (task.IsOverdue)
                {
                    lblDeadline.ForeColor = Color.FromArgb(231, 76, 60);
                    lblDeadline.Text += " ⚠️";
                    this.BackColor = Color.FromArgb(255, 235, 235);
                }
                else
                {
                    lblDeadline.ForeColor = Color.FromArgb(127, 140, 141);
                }
            }
            else
            {
                lblDeadline.Text = "📅 Không thời hạn";
                lblDeadline.ForeColor = Color.FromArgb(127, 140, 141);
            }

            // Hiển thị độ ưu tiên
            SetPriorityStyle(task.DoUuTien);
        }

        private void SetPriorityStyle(string priority)
        {
            switch (priority)
            {
                case "Cao":
                    lblPriority.Text = "🔴 Cao";
                    lblPriority.ForeColor = Color.FromArgb(231, 76, 60);
                    panelPriorityBar.BackColor = Color.FromArgb(231, 76, 60);
                    break;
                case "Trung bình":
                    lblPriority.Text = "🟡 TB";
                    lblPriority.ForeColor = Color.FromArgb(241, 196, 15);
                    panelPriorityBar.BackColor = Color.FromArgb(241, 196, 15);
                    break;
                case "Thấp":
                    lblPriority.Text = "🟢 Thấp";
                    lblPriority.ForeColor = Color.FromArgb(46, 204, 113);
                    panelPriorityBar.BackColor = Color.FromArgb(46, 204, 113);
                    break;
                default:
                    lblPriority.Text = "⚪ N/A";
                    lblPriority.ForeColor = Color.Gray;
                    panelPriorityBar.BackColor = Color.Gray;
                    break;
            }
        }
    }
}
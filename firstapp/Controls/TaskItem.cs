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

        // Events để Form1 lắng nghe
        public event EventHandler ViewClicked;
        public event EventHandler EditClicked;
        public event EventHandler DeleteClicked;

        public TaskItem()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            // Enable drag & drop
            this.AllowDrop = false; // TaskItem không nhận drop
        }

        // Override OnMouseDown để catch drag từ toàn bộ control
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left && TaskData != null)
            {
                // Chỉ drag nếu không click vào button
                Control clickedControl = this.GetChildAtPoint(e.Location);

                // Nếu click vào button, không drag
                if (clickedControl is Button)
                {
                    return;
                }

                // Bắt đầu drag operation
                try
                {
                    this.DoDragDrop(this.TaskData, DragDropEffects.Move);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi drag: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

            // Hiển thị nhóm công việc
            if (!string.IsNullOrEmpty(task.TenNhom))
            {
                lblGroup.Text = "📁 " + task.TenNhom;
                lblGroup.Visible = true;
                if (!string.IsNullOrEmpty(task.MauNhom))
                {
                    lblGroup.ForeColor = ColorTranslator.FromHtml(task.MauNhom);
                }
            }
            else
            {
                lblGroup.Visible = false;
            }

            // Hiển thị tags
            DisplayTags(task.Tags, task.TagsColors);

            // Hiển thị/ẩn nút sửa, xóa dựa vào quyền
            bool canEdit = task.CanEdit(CurrentUser.User.Id, CurrentUser.IsManager);
            btnEdit.Visible = canEdit;
            btnDelete.Visible = canEdit;

            // Enable drag cho các control con (Label, Panel...)
            EnableDragForChildren();
        }

        // Enable drag cho tất cả control con
        private void EnableDragForChildren()
        {
            foreach (Control ctrl in this.Controls)
            {
                // Không enable drag cho Button
                if (!(ctrl is Button))
                {
                    ctrl.MouseDown += Control_MouseDown;
                }
            }
        }

        // MouseDown cho các control con
        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && TaskData != null)
            {
                try
                {
                    this.DoDragDrop(this.TaskData, DragDropEffects.Move);
                }
                catch { }
            }
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

        private void DisplayTags(System.Collections.Generic.List<string> tags, System.Collections.Generic.List<string> colors)
        {
            flpTags.Controls.Clear();

            if (tags == null || tags.Count == 0)
            {
                flpTags.Visible = false;
                return;
            }

            flpTags.Visible = true;

            for (int i = 0; i < tags.Count && i < 3; i++) // Giới hạn 3 tags
            {
                Label tagLabel = new Label
                {
                    Text = tags[i],
                    AutoSize = true,
                    Font = new Font("Segoe UI", 6.5F, FontStyle.Bold),
                    ForeColor = Color.White,
                    Padding = new Padding(4, 2, 4, 2),
                    Margin = new Padding(0, 0, 3, 0)
                };

                // Set màu background
                if (colors != null && i < colors.Count && !string.IsNullOrEmpty(colors[i]))
                {
                    try
                    {
                        tagLabel.BackColor = ColorTranslator.FromHtml(colors[i]);
                    }
                    catch
                    {
                        tagLabel.BackColor = Color.FromArgb(149, 165, 166);
                    }
                }
                else
                {
                    tagLabel.BackColor = Color.FromArgb(149, 165, 166);
                }

                flpTags.Controls.Add(tagLabel);
            }

            // Nếu có nhiều hơn 3 tags, hiển thị "+X"
            if (tags.Count > 3)
            {
                Label moreLabel = new Label
                {
                    Text = $"+{tags.Count - 3}",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 6.5F, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = Color.FromArgb(149, 165, 166),
                    Padding = new Padding(4, 2, 4, 2)
                };
                flpTags.Controls.Add(moreLabel);
            }
        }

        // Event handlers cho các nút
        private void btnView_Click(object sender, EventArgs e)
        {
            ViewClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa task '{TaskData.TieuDe}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                DeleteClicked?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
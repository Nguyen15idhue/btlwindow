using System;
using System.Drawing;
using System.Windows.Forms;

namespace btlwindow
{
    public partial class frmTaskDetail : Form
    {
        private TaskModel task;

        public frmTaskDetail(TaskModel taskData)
        {
            InitializeComponent();
            task = taskData;
        }

        private void frmTaskDetail_Load(object sender, EventArgs e)
        {
            if (task == null) return;

            // Hiển thị tiêu đề
            this.Text = "Chi tiết: " + task.TieuDe;
            lblTitleValue.Text = task.TieuDe;
            
            // Hiển thị mô tả
            txtDescription.Text = task.MoTa ?? "Không có mô tả";
            
            // Hiển thị người tạo và người được giao
            lblCreatorValue.Text = task.TenNguoiTao ?? "Không rõ";
            lblAssigneeValue.Text = task.TenNguoiDuocGiao ?? "Chưa giao";
            
            // Hiển thị deadline
            if (task.HanHoanThanh != DateTime.MinValue)
            {
                lblDeadlineValue.Text = task.HanHoanThanh.ToString("dd/MM/yyyy HH:mm");
                
                if (task.IsOverdue)
                {
                    lblDeadlineValue.ForeColor = Color.FromArgb(231, 76, 60);
                    lblDeadlineValue.Text += " ⚠️ (Quá hạn)";
                }
                else
                {
                    lblDeadlineValue.ForeColor = Color.FromArgb(46, 204, 113);
                }
            }
            else
            {
                lblDeadlineValue.Text = "Không có thời hạn";
                lblDeadlineValue.ForeColor = Color.Gray;
            }

            // Hiển thị độ ưu tiên
            lblPriorityValue.Text = task.DoUuTien ?? "Trung bình";
            switch (task.DoUuTien)
            {
                case "Cao":
                    lblPriorityValue.ForeColor = Color.FromArgb(231, 76, 60);
                    lblPriorityValue.Font = new Font(lblPriorityValue.Font, FontStyle.Bold);
                    break;
                case "Trung bình":
                    lblPriorityValue.ForeColor = Color.FromArgb(241, 196, 15);
                    break;
                case "Thấp":
                    lblPriorityValue.ForeColor = Color.FromArgb(46, 204, 113);
                    break;
            }

            // Hiển thị trạng thái
            lblStatusValue.Text = GetStatusText(task.TrangThai);
            lblStatusValue.Padding = new Padding(5, 2, 5, 2);
            switch (task.TrangThai)
            {
                case "Todo":
                    lblStatusValue.ForeColor = Color.FromArgb(241, 196, 15);
                    lblStatusValue.BackColor = Color.FromArgb(255, 249, 196);
                    break;
                case "Doing":
                    lblStatusValue.ForeColor = Color.FromArgb(52, 152, 219);
                    lblStatusValue.BackColor = Color.FromArgb(214, 234, 248);
                    break;
                case "Done":
                    lblStatusValue.ForeColor = Color.FromArgb(46, 204, 113);
                    lblStatusValue.BackColor = Color.FromArgb(212, 239, 223);
                    break;
            }

            // Hiển thị nhóm
            if (!string.IsNullOrEmpty(task.TenNhom))
            {
                lblGroupValue.Text = task.TenNhom;
                if (!string.IsNullOrEmpty(task.MauNhom))
                {
                    try
                    {
                        lblGroupValue.ForeColor = ColorTranslator.FromHtml(task.MauNhom);
                    }
                    catch { }
                }
            }
            else
            {
                lblGroupValue.Text = "Không có nhóm";
                lblGroupValue.ForeColor = Color.Gray;
            }

            // Hiển thị tags
            if (task.Tags != null && task.Tags.Count > 0)
            {
                DisplayTags();
            }
            else
            {
                flpTags.Visible = false;
            }
        }

        private string GetStatusText(string status)
        {
            switch (status)
            {
                case "Todo":
                    return "📋 CẦN LÀM";
                case "Doing":
                    return "🔄 ĐANG LÀM";
                case "Done":
                    return "✅ ĐÃ XONG";
                default:
                    return status;
            }
        }

        private void DisplayTags()
        {
            flpTags.Controls.Clear();

            for (int i = 0; i < task.Tags.Count; i++)
            {
                Label tagLabel = new Label
                {
                    Text = "  " + task.Tags[i] + "  ",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                    ForeColor = Color.White,
                    Padding = new Padding(6, 3, 6, 3),
                    Margin = new Padding(0, 0, 5, 5)
                };

                // Set màu background
                if (task.TagsColors != null && i < task.TagsColors.Count && !string.IsNullOrEmpty(task.TagsColors[i]))
                {
                    try
                    {
                        tagLabel.BackColor = ColorTranslator.FromHtml(task.TagsColors[i]);
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
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

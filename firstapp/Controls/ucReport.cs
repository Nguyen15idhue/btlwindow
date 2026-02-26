using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace btlwindow
{
    public partial class ucReport : UserControl
    {
        private List<TaskModel> allTasks = new List<TaskModel>();
        private List<TaskModel> filteredTasks = new List<TaskModel>();
        private DateTime filterDateFrom;
        private DateTime filterDateTo;

        public ucReport()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            // Title
            lblTitle.Font = AppTheme.FontTitle;
            lblTitle.ForeColor = AppTheme.PrimaryColor;

            // Subtitle
            lblSubtitle.Font = AppTheme.FontBody;
            lblSubtitle.ForeColor = AppTheme.TextSecondary;

            // Buttons
            StyleHelper.ApplyDangerButton(btnExportPDF);
            StyleHelper.ApplySuccessButton(btnExportExcel);
            StyleHelper.ApplyPrimaryButton(btnExportCSV);
            StyleHelper.ApplySecondaryButton(btnRefresh);
            StyleHelper.ApplyPrimaryButton(btnApplyFilter);
            StyleHelper.ApplySecondaryButton(btnResetFilter);
        }

        private void ucReport_Load(object sender, EventArgs e)
        {
            // Initialize date range
            cboTimeRange.SelectedIndex = 3; // "Năm nay" by default
            dtpFrom.Enabled = false;
            dtpTo.Enabled = false;

            LoadReport();
        }

        private void cboTimeRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isCustom = cboTimeRange.SelectedIndex == 4; // "Tùy chỉnh"
            dtpFrom.Enabled = isCustom;
            dtpTo.Enabled = isCustom;

            if (!isCustom)
            {
                SetDateRangeBySelection();
            }
        }

        private void SetDateRangeBySelection()
        {
            DateTime now = DateTime.Now;

            switch (cboTimeRange.SelectedIndex)
            {
                case 0: // Hôm nay
                    filterDateFrom = now.Date;
                    filterDateTo = now.Date.AddDays(1).AddSeconds(-1);
                    break;
                case 1: // Tuần này
                    int diff = (7 + (now.DayOfWeek - DayOfWeek.Monday)) % 7;
                    filterDateFrom = now.AddDays(-1 * diff).Date;
                    filterDateTo = filterDateFrom.AddDays(7).AddSeconds(-1);
                    break;
                case 2: // Tháng này
                    filterDateFrom = new DateTime(now.Year, now.Month, 1);
                    filterDateTo = filterDateFrom.AddMonths(1).AddSeconds(-1);
                    break;
                case 3: // Năm nay
                    filterDateFrom = new DateTime(now.Year, 1, 1);
                    filterDateTo = new DateTime(now.Year, 12, 31, 23, 59, 59);
                    break;
            }

            dtpFrom.Value = filterDateFrom;
            dtpTo.Value = filterDateTo;
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            if (cboTimeRange.SelectedIndex == 4) // Tùy chỉnh
            {
                filterDateFrom = dtpFrom.Value.Date;
                filterDateTo = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);
            }

            LoadReport();
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            cboTimeRange.SelectedIndex = 3; // Năm nay
            LoadReport();
        }

        public void LoadReport()
        {
            try
            {
                // Load all tasks
                allTasks = TaskRepository.LoadTasks();

                // Filter by date range
                if (cboTimeRange.SelectedIndex >= 0)
                {
                    filteredTasks = allTasks.Where(t => 
                        t.NgayTao >= filterDateFrom && t.NgayTao <= filterDateTo
                    ).ToList();
                }
                else
                {
                    filteredTasks = allTasks;
                }

                // Update statistics
                UpdateStatistics();

                // Update charts
                UpdateCharts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải báo cáo: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatistics()
        {
            int total = filteredTasks.Count;
            int todo = filteredTasks.Count(t => t.TrangThai == "Todo");
            int doing = filteredTasks.Count(t => t.TrangThai == "Doing");
            int done = filteredTasks.Count(t => t.TrangThai == "Done");
            int overdue = filteredTasks.Count(t => t.IsOverdue);

            lblTotalTasks.Text = total.ToString();
            lblTodo.Text = todo.ToString();
            lblDoing.Text = doing.ToString();
            lblDone.Text = done.ToString();
            lblOverdue.Text = overdue.ToString();

            // Progress
            if (total > 0)
            {
                double pct = (double)done / total * 100;
                lblProgress.Text = pct.ToString("F1") + "%";
                prgProgress.Value = Math.Min(100, (int)pct);
            }
            else
            {
                lblProgress.Text = "0%";
                prgProgress.Value = 0;
            }
        }

        private void UpdateCharts()
        {
            UpdateStatusChart();
            UpdatePriorityChart();
            UpdateTimelineChart();
        }

        private void UpdateStatusChart()
        {
            chartStatus.Series.Clear();
            chartStatus.Titles.Clear();
            chartStatus.Titles.Add("Biểu đồ trạng thái công việc");
            chartStatus.Titles[0].Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            Series series = new Series("Status");
            series.ChartType = SeriesChartType.Pie;

            int todo = filteredTasks.Count(t => t.TrangThai == "Todo");
            int doing = filteredTasks.Count(t => t.TrangThai == "Doing");
            int done = filteredTasks.Count(t => t.TrangThai == "Done");

            if (todo > 0)
            {
                DataPoint dp = series.Points.Add(todo);
                dp.LegendText = $"Cần làm ({todo})";
                dp.Label = $"{todo}";
                dp.Color = Color.FromArgb(52, 152, 219);
            }
            if (doing > 0)
            {
                DataPoint dp = series.Points.Add(doing);
                dp.LegendText = $"Đang làm ({doing})";
                dp.Label = $"{doing}";
                dp.Color = Color.FromArgb(243, 156, 18);
            }
            if (done > 0)
            {
                DataPoint dp = series.Points.Add(done);
                dp.LegendText = $"Hoàn thành ({done})";
                dp.Label = $"{done}";
                dp.Color = Color.FromArgb(39, 174, 96);
            }

            series["PieLabelStyle"] = "Outside";
            chartStatus.Series.Add(series);
        }

        private void UpdatePriorityChart()
        {
            chartPriority.Series.Clear();
            chartPriority.Titles.Clear();
            chartPriority.Titles.Add("Biểu đồ độ ưu tiên");
            chartPriority.Titles[0].Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            // Ensure ChartArea exists
            if (chartPriority.ChartAreas.Count == 0)
            {
                chartPriority.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea("ChartArea1"));
            }

            Series series = new Series("Priority");
            series.ChartType = SeriesChartType.Column;

            int cao = filteredTasks.Count(t => t.DoUuTien == "Cao");
            int trungBinh = filteredTasks.Count(t => t.DoUuTien == "Trung bình" || t.DoUuTien == "Trung binh");
            int thap = filteredTasks.Count(t => t.DoUuTien == "Thấp" || t.DoUuTien == "Thap");

            int idx0 = series.Points.AddXY("Cao", cao);
            series.Points[idx0].Color = Color.FromArgb(231, 76, 60);

            int idx1 = series.Points.AddXY("Trung bình", trungBinh);
            series.Points[idx1].Color = Color.FromArgb(243, 156, 18);

            int idx2 = series.Points.AddXY("Thấp", thap);
            series.Points[idx2].Color = Color.FromArgb(46, 204, 113);

            chartPriority.Series.Add(series);
            chartPriority.ChartAreas[0].AxisX.Title = "Độ ưu tiên";
            chartPriority.ChartAreas[0].AxisY.Title = "Số lượng";
        }

        private void UpdateTimelineChart()
        {
            chartTimeline.Series.Clear();
            chartTimeline.Titles.Clear();
            chartTimeline.Titles.Add("Xu hướng tạo công việc");
            chartTimeline.Titles[0].Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            // Ensure ChartArea exists
            if (chartTimeline.ChartAreas.Count == 0)
            {
                chartTimeline.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea("ChartArea1"));
            }

            Series series = new Series("Timeline");
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 3;
            series.Color = Color.FromArgb(52, 152, 219);
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 8;

            // Group by date and count
            var groupedByDate = filteredTasks
                .GroupBy(t => t.NgayTao.Date)
                .OrderBy(g => g.Key)
                .Select(g => new { Date = g.Key, Count = g.Count() })
                .ToList();

            if (groupedByDate.Count > 0)
            {
                foreach (var item in groupedByDate)
                {
                    series.Points.AddXY(item.Date.ToString("dd/MM"), item.Count);
                }

                chartTimeline.Series.Add(series);
                chartTimeline.ChartAreas[0].AxisX.Title = "Ngày";
                chartTimeline.ChartAreas[0].AxisY.Title = "Số công việc";
                chartTimeline.ChartAreas[0].AxisX.Interval = 1;
                chartTimeline.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            }
        }

        // Export methods
        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng xuất PDF đang được phát triển.\n" +
                "Bạn có thể sử dụng xuất Excel hoặc CSV để thay thế.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng xuất Excel đang được phát triển.\n" +
                "Vui lòng sử dụng xuất CSV để thay thế.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV files (*.csv)|*.csv";
                sfd.Title = "Xuất báo cáo CSV";
                sfd.FileName = $"BaoCao_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportToCSV(sfd.FileName);
                    MessageBox.Show($"Đã xuất báo cáo thành công!\n\nFile: {sfd.FileName}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất CSV: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToCSV(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                // Header
                sw.WriteLine("=== BÁO CÁO THỐNG KÊ CÔNG VIỆC ===");
                sw.WriteLine($"Thời gian tạo báo cáo: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                sw.WriteLine($"Khoảng thời gian: {filterDateFrom:dd/MM/yyyy} - {filterDateTo:dd/MM/yyyy}");
                sw.WriteLine();

                // Statistics
                sw.WriteLine("=== THỐNG KÊ TỔNG QUAN ===");
                sw.WriteLine($"Tổng số công việc,{filteredTasks.Count}");
                sw.WriteLine($"Cần làm,{filteredTasks.Count(t => t.TrangThai == "Todo")}");
                sw.WriteLine($"Đang làm,{filteredTasks.Count(t => t.TrangThai == "Doing")}");
                sw.WriteLine($"Hoàn thành,{filteredTasks.Count(t => t.TrangThai == "Done")}");
                sw.WriteLine($"Quá hạn,{filteredTasks.Count(t => t.IsOverdue)}");
                sw.WriteLine();

                // Task list
                sw.WriteLine("=== DANH SÁCH CHI TIẾT ===");
                sw.WriteLine("STT,Tiêu đề,Trạng thái,Độ ưu tiên,Người thực hiện,Hạn hoàn thành,Ngày tạo,Quá hạn");

                int stt = 1;
                foreach (var task in filteredTasks)
                {
                    sw.WriteLine($"{stt}," +
                        $"\"{EscapeCSV(task.TieuDe)}\"," +
                        $"\"{task.TrangThai}\"," +
                        $"\"{task.DoUuTien ?? "Trung bình"}\"," +
                        $"\"{task.TenNguoiDuocGiao ?? "Chưa giao"}\"," +
                        $"{task.HanHoanThanh:dd/MM/yyyy}," +
                        $"{task.NgayTao:dd/MM/yyyy}," +
                        $"{(task.IsOverdue ? "Có" : "Không")}");
                    stt++;
                }
            }
        }

        private string EscapeCSV(string value)
        {
            if (string.IsNullOrEmpty(value)) return "";
            return value.Replace("\"", "\"\"");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReport();
            MessageBox.Show("Đã làm mới báo cáo!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
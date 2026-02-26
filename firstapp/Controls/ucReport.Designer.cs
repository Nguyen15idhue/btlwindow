namespace btlwindow
{
    partial class ucReport
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();

            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.lblTotalTasksLabel = new System.Windows.Forms.Label();
            this.lblTotalTasks = new System.Windows.Forms.Label();
            this.lblTodoLabel = new System.Windows.Forms.Label();
            this.lblTodo = new System.Windows.Forms.Label();
            this.lblDoingLabel = new System.Windows.Forms.Label();
            this.lblDoing = new System.Windows.Forms.Label();
            this.lblDoneLabel = new System.Windows.Forms.Label();
            this.lblDone = new System.Windows.Forms.Label();
            this.lblOverdueLabel = new System.Windows.Forms.Label();
            this.lblOverdue = new System.Windows.Forms.Label();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.lblProgressLabel = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.prgProgress = new System.Windows.Forms.ProgressBar();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblFilterLabel = new System.Windows.Forms.Label();
            this.cboTimeRange = new System.Windows.Forms.ComboBox();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblToLabel = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.btnResetFilter = new System.Windows.Forms.Button();
            this.chartStatus = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPriority = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTimeline = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnExportCSV = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlStats.SuspendLayout();
            this.pnlProgress.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPriority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTimeline)).BeginInit();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 32);
            this.lblTitle.Text = "📊 Báo cáo & Thống kê";

            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblSubtitle.Location = new System.Drawing.Point(23, 55);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(350, 19);
            this.lblSubtitle.Text = "Theo dõi tiến độ và phân tích công việc";

            // 
            // pnlStats
            // 
            this.pnlStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStats.BackColor = System.Drawing.Color.White;
            this.pnlStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStats.Controls.Add(this.lblTotalTasksLabel);
            this.pnlStats.Controls.Add(this.lblTotalTasks);
            this.pnlStats.Controls.Add(this.lblTodoLabel);
            this.pnlStats.Controls.Add(this.lblTodo);
            this.pnlStats.Controls.Add(this.lblDoingLabel);
            this.pnlStats.Controls.Add(this.lblDoing);
            this.pnlStats.Controls.Add(this.lblDoneLabel);
            this.pnlStats.Controls.Add(this.lblDone);
            this.pnlStats.Controls.Add(this.lblOverdueLabel);
            this.pnlStats.Controls.Add(this.lblOverdue);
            this.pnlStats.Location = new System.Drawing.Point(15, 90);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Padding = new System.Windows.Forms.Padding(10);
            this.pnlStats.Size = new System.Drawing.Size(620, 100);

            // Stats labels
            this.lblTotalTasksLabel.AutoSize = true;
            this.lblTotalTasksLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalTasksLabel.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblTotalTasksLabel.Location = new System.Drawing.Point(20, 15);
            this.lblTotalTasksLabel.Text = "📋 Tổng công việc";

            this.lblTotalTasks.AutoSize = true;
            this.lblTotalTasks.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalTasks.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lblTotalTasks.Location = new System.Drawing.Point(20, 40);
            this.lblTotalTasks.Text = "0";

            this.lblTodoLabel.AutoSize = true;
            this.lblTodoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTodoLabel.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblTodoLabel.Location = new System.Drawing.Point(150, 15);
            this.lblTodoLabel.Text = "📝 Cần làm";

            this.lblTodo.AutoSize = true;
            this.lblTodo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTodo.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lblTodo.Location = new System.Drawing.Point(150, 40);
            this.lblTodo.Text = "0";

            this.lblDoingLabel.AutoSize = true;
            this.lblDoingLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDoingLabel.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblDoingLabel.Location = new System.Drawing.Point(260, 15);
            this.lblDoingLabel.Text = "⚙️ Đang làm";

            this.lblDoing.AutoSize = true;
            this.lblDoing.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblDoing.ForeColor = System.Drawing.Color.FromArgb(243, 156, 18);
            this.lblDoing.Location = new System.Drawing.Point(260, 40);
            this.lblDoing.Text = "0";

            this.lblDoneLabel.AutoSize = true;
            this.lblDoneLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDoneLabel.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblDoneLabel.Location = new System.Drawing.Point(380, 15);
            this.lblDoneLabel.Text = "✅ Hoàn thành";

            this.lblDone.AutoSize = true;
            this.lblDone.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblDone.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblDone.Location = new System.Drawing.Point(380, 40);
            this.lblDone.Text = "0";

            this.lblOverdueLabel.AutoSize = true;
            this.lblOverdueLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOverdueLabel.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblOverdueLabel.Location = new System.Drawing.Point(510, 15);
            this.lblOverdueLabel.Text = "⚠️ Quá hạn";

            this.lblOverdue.AutoSize = true;
            this.lblOverdue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblOverdue.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.lblOverdue.Location = new System.Drawing.Point(510, 40);
            this.lblOverdue.Text = "0";

            // 
            // pnlProgress
            // 
            this.pnlProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProgress.BackColor = System.Drawing.Color.White;
            this.pnlProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProgress.Controls.Add(this.lblProgressLabel);
            this.pnlProgress.Controls.Add(this.lblProgress);
            this.pnlProgress.Controls.Add(this.prgProgress);
            this.pnlProgress.Location = new System.Drawing.Point(645, 90);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Padding = new System.Windows.Forms.Padding(10);
            this.pnlProgress.Size = new System.Drawing.Size(340, 100);

            this.lblProgressLabel.AutoSize = true;
            this.lblProgressLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProgressLabel.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblProgressLabel.Location = new System.Drawing.Point(20, 15);
            this.lblProgressLabel.Text = "📈 Tiến độ tổng thể";

            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblProgress.ForeColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.lblProgress.Location = new System.Drawing.Point(20, 40);
            this.lblProgress.Text = "0%";

            this.prgProgress.Location = new System.Drawing.Point(150, 45);
            this.prgProgress.Name = "prgProgress";
            this.prgProgress.Size = new System.Drawing.Size(170, 30);
            this.prgProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;

            // 
            // pnlFilter
            // 
            this.pnlFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilter.Controls.Add(this.lblFilterLabel);
            this.pnlFilter.Controls.Add(this.cboTimeRange);
            this.pnlFilter.Controls.Add(this.dtpFrom);
            this.pnlFilter.Controls.Add(this.lblToLabel);
            this.pnlFilter.Controls.Add(this.dtpTo);
            this.pnlFilter.Controls.Add(this.btnApplyFilter);
            this.pnlFilter.Controls.Add(this.btnResetFilter);
            this.pnlFilter.Location = new System.Drawing.Point(15, 200);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(10);
            this.pnlFilter.Size = new System.Drawing.Size(970, 60);

            this.lblFilterLabel.AutoSize = true;
            this.lblFilterLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFilterLabel.Location = new System.Drawing.Point(15, 20);
            this.lblFilterLabel.Text = "🔍 Lọc theo:";

            this.cboTimeRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimeRange.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboTimeRange.FormattingEnabled = true;
            this.cboTimeRange.Items.AddRange(new object[] {
            "Hôm nay",
            "Tuần này",
            "Tháng này",
            "Năm nay",
            "Tùy chỉnh"});
            this.cboTimeRange.Location = new System.Drawing.Point(90, 17);
            this.cboTimeRange.Name = "cboTimeRange";
            this.cboTimeRange.Size = new System.Drawing.Size(120, 23);
            this.cboTimeRange.SelectedIndexChanged += new System.EventHandler(this.cboTimeRange_SelectedIndexChanged);

            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(220, 17);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(120, 23);

            this.lblToLabel.AutoSize = true;
            this.lblToLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblToLabel.Location = new System.Drawing.Point(345, 20);
            this.lblToLabel.Text = "đến";

            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(375, 17);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(120, 23);

            this.btnApplyFilter.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnApplyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnApplyFilter.ForeColor = System.Drawing.Color.White;
            this.btnApplyFilter.Location = new System.Drawing.Point(505, 12);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(100, 35);
            this.btnApplyFilter.Text = "✓ Áp dụng";
            this.btnApplyFilter.UseVisualStyleBackColor = false;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);

            this.btnResetFilter.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnResetFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnResetFilter.ForeColor = System.Drawing.Color.White;
            this.btnResetFilter.Location = new System.Drawing.Point(615, 12);
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Size = new System.Drawing.Size(100, 35);
            this.btnResetFilter.Text = "↺ Đặt lại";
            this.btnResetFilter.UseVisualStyleBackColor = false;
            this.btnResetFilter.Click += new System.EventHandler(this.btnResetFilter_Click);

            // 
            // chartStatus
            // 
            chartArea1.Name = "ChartArea1";
            this.chartStatus.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartStatus.Legends.Add(legend1);
            this.chartStatus.Location = new System.Drawing.Point(15, 270);
            this.chartStatus.Name = "chartStatus";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Status";
            this.chartStatus.Series.Add(series1);
            this.chartStatus.Size = new System.Drawing.Size(310, 280);
            this.chartStatus.Text = "Trạng thái công việc";

            // 
            // chartPriority
            // 
            this.chartPriority.Location = new System.Drawing.Point(335, 270);
            this.chartPriority.Name = "chartPriority";
            this.chartPriority.Size = new System.Drawing.Size(310, 280);
            this.chartPriority.Text = "Độ ưu tiên";

            // 
            // chartTimeline
            // 
            this.chartTimeline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chartTimeline.Location = new System.Drawing.Point(655, 270);
            this.chartTimeline.Name = "chartTimeline";
            this.chartTimeline.Size = new System.Drawing.Size(330, 280);
            this.chartTimeline.Text = "Xu hướng theo thời gian";

            // 
            // pnlActions
            // 
            this.pnlActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlActions.BackColor = System.Drawing.Color.White;
            this.pnlActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlActions.Controls.Add(this.btnExportPDF);
            this.pnlActions.Controls.Add(this.btnExportExcel);
            this.pnlActions.Controls.Add(this.btnExportCSV);
            this.pnlActions.Controls.Add(this.btnRefresh);
            this.pnlActions.Location = new System.Drawing.Point(15, 560);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(10);
            this.pnlActions.Size = new System.Drawing.Size(970, 60);

            this.btnExportPDF.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnExportPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportPDF.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportPDF.Location = new System.Drawing.Point(15, 10);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(130, 38);
            this.btnExportPDF.Text = "📄 Xuất PDF";
            this.btnExportPDF.UseVisualStyleBackColor = false;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);

            this.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(155, 10);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(130, 38);
            this.btnExportExcel.Text = "📊 Xuất Excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);

            this.btnExportCSV.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnExportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportCSV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportCSV.ForeColor = System.Drawing.Color.White;
            this.btnExportCSV.Location = new System.Drawing.Point(295, 10);
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.Size = new System.Drawing.Size(130, 38);
            this.btnExportCSV.Text = "📋 Xuất CSV";
            this.btnExportCSV.UseVisualStyleBackColor = false;
            this.btnExportCSV.Click += new System.EventHandler(this.btnExportCSV_Click);

            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(435, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(130, 38);
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // 
            // ucReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlProgress);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.chartStatus);
            this.Controls.Add(this.chartPriority);
            this.Controls.Add(this.chartTimeline);
            this.Controls.Add(this.pnlActions);
            this.Name = "ucReport";
            this.Size = new System.Drawing.Size(1000, 650);
            this.Load += new System.EventHandler(this.ucReport_Load);
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            this.pnlProgress.ResumeLayout(false);
            this.pnlProgress.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPriority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTimeline)).EndInit();
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblTotalTasksLabel;
        private System.Windows.Forms.Label lblTotalTasks;
        private System.Windows.Forms.Label lblTodoLabel;
        private System.Windows.Forms.Label lblTodo;
        private System.Windows.Forms.Label lblDoingLabel;
        private System.Windows.Forms.Label lblDoing;
        private System.Windows.Forms.Label lblDoneLabel;
        private System.Windows.Forms.Label lblDone;
        private System.Windows.Forms.Label lblOverdueLabel;
        private System.Windows.Forms.Label lblOverdue;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.Label lblProgressLabel;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ProgressBar prgProgress;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblFilterLabel;
        private System.Windows.Forms.ComboBox cboTimeRange;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblToLabel;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Button btnResetFilter;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStatus;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPriority;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTimeline;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnExportCSV;
        private System.Windows.Forms.Button btnRefresh;
    }
}
namespace btlwindow
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnTagGroup = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.btnQuanLyThanhVien = new System.Windows.Forms.Button();
            this.btnOpenAddForm = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.lblLogo = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnExportCSV = new System.Windows.Forms.Button();
            this.lblOverdueCount = new System.Windows.Forms.Label();
            this.cbSort = new System.Windows.Forms.ComboBox();
            this.lblSort = new System.Windows.Forms.Label();
            this.cbFilterPriority = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbTodo = new System.Windows.Forms.GroupBox();
            this.flpTodo = new System.Windows.Forms.FlowLayoutPanel();
            this.gbDoing = new System.Windows.Forms.GroupBox();
            this.flpDoing = new System.Windows.Forms.FlowLayoutPanel();
            this.gbDone = new System.Windows.Forms.GroupBox();
            this.flpDone = new System.Windows.Forms.FlowLayoutPanel();
            this.panelSidebar.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbTodo.SuspendLayout();
            this.gbDoing.SuspendLayout();
            this.gbDone.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelSidebar.Controls.Add(this.btnReport);
            this.panelSidebar.Controls.Add(this.btnTagGroup);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.lblUserRole);
            this.panelSidebar.Controls.Add(this.lblUserInfo);
            this.panelSidebar.Controls.Add(this.btnQuanLyThanhVien);
            this.panelSidebar.Controls.Add(this.btnOpenAddForm);
            this.panelSidebar.Controls.Add(this.btnDashboard);
            this.panelSidebar.Controls.Add(this.lblLogo);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(250, 650);
            this.panelSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(10, 575);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(230, 40);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "🚪 Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblUserRole
            // 
            this.lblUserRole.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUserRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lblUserRole.Location = new System.Drawing.Point(10, 545);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(230, 20);
            this.lblUserRole.TabIndex = 5;
            this.lblUserRole.Text = "Vai trò";
            this.lblUserRole.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUserInfo.ForeColor = System.Drawing.Color.White;
            this.lblUserInfo.Location = new System.Drawing.Point(10, 520);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(230, 25);
            this.lblUserInfo.TabIndex = 4;
            this.lblUserInfo.Text = "👤 Tên người dùng";
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnQuanLyThanhVien
            // 
            this.btnQuanLyThanhVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnQuanLyThanhVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuanLyThanhVien.FlatAppearance.BorderSize = 0;
            this.btnQuanLyThanhVien.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(173)))), ((int)(((byte)(226)))));
            this.btnQuanLyThanhVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyThanhVien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyThanhVien.ForeColor = System.Drawing.Color.White;
            this.btnQuanLyThanhVien.Location = new System.Drawing.Point(10, 220);
            this.btnQuanLyThanhVien.Name = "btnQuanLyThanhVien";
            this.btnQuanLyThanhVien.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnQuanLyThanhVien.Size = new System.Drawing.Size(230, 45);
            this.btnQuanLyThanhVien.TabIndex = 3;
            this.btnQuanLyThanhVien.Text = "👥 Quản lý thành viên";
            this.btnQuanLyThanhVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyThanhVien.UseVisualStyleBackColor = false;
            this.btnQuanLyThanhVien.Click += new System.EventHandler(this.btnQuanLyThanhVien_Click);
            // 
            // btnOpenAddForm
            // 
            this.btnOpenAddForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnOpenAddForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenAddForm.FlatAppearance.BorderSize = 0;
            this.btnOpenAddForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btnOpenAddForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenAddForm.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenAddForm.ForeColor = System.Drawing.Color.White;
            this.btnOpenAddForm.Location = new System.Drawing.Point(10, 160);
            this.btnOpenAddForm.Name = "btnOpenAddForm";
            this.btnOpenAddForm.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnOpenAddForm.Size = new System.Drawing.Size(230, 45);
            this.btnOpenAddForm.TabIndex = 2;
            this.btnOpenAddForm.Text = "➕ Thêm Task mới";
            this.btnOpenAddForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenAddForm.UseVisualStyleBackColor = false;
            this.btnOpenAddForm.Click += new System.EventHandler(this.btnOpenAddForm_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReport.FlatAppearance.BorderSize = 0;
            this.btnReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(173)))), ((int)(((byte)(226)))));
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.Location = new System.Drawing.Point(10, 280);
            this.btnReport.Name = "btnReport";
            this.btnReport.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnReport.Size = new System.Drawing.Size(230, 45);
            this.btnReport.TabIndex = 4;
            this.btnReport.Text = "📊 Báo cáo thống kê";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnTagGroup
            // 
            this.btnTagGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTagGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTagGroup.FlatAppearance.BorderSize = 0;
            this.btnTagGroup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(173)))), ((int)(((byte)(226)))));
            this.btnTagGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTagGroup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTagGroup.ForeColor = System.Drawing.Color.White;
            this.btnTagGroup.Location = new System.Drawing.Point(10, 340);
            this.btnTagGroup.Name = "btnTagGroup";
            this.btnTagGroup.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnTagGroup.Size = new System.Drawing.Size(230, 45);
            this.btnTagGroup.TabIndex = 5;
            this.btnTagGroup.Text = "🏷️ Tag & Nhóm";
            this.btnTagGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTagGroup.UseVisualStyleBackColor = false;
            this.btnTagGroup.Click += new System.EventHandler(this.btnTagGroup_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(173)))), ((int)(((byte)(226)))));
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(10, 100);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(230, 45);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "🏠 Bảng điều khiển";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // lblLogo
            // 
            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(0, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(250, 80);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "📋 KANBAN";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.btnExportCSV);
            this.panelTop.Controls.Add(this.lblOverdueCount);
            this.panelTop.Controls.Add(this.cbSort);
            this.panelTop.Controls.Add(this.lblSort);
            this.panelTop.Controls.Add(this.cbFilterPriority);
            this.panelTop.Controls.Add(this.lblFilter);
            this.panelTop.Controls.Add(this.txtSearch);
            this.panelTop.Controls.Add(this.lblSearch);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(250, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(15);
            this.panelTop.Size = new System.Drawing.Size(950, 70);
            this.panelTop.TabIndex = 1;
            // 
            // btnExportCSV
            // 
            this.btnExportCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportCSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnExportCSV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportCSV.FlatAppearance.BorderSize = 0;
            this.btnExportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportCSV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportCSV.ForeColor = System.Drawing.Color.White;
            this.btnExportCSV.Location = new System.Drawing.Point(790, 16);
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.Size = new System.Drawing.Size(140, 36);
            this.btnExportCSV.TabIndex = 7;
            this.btnExportCSV.Text = "📥 Xuất BC";
            this.btnExportCSV.UseVisualStyleBackColor = false;
            this.btnExportCSV.Click += new System.EventHandler(this.btnExportCSV_Click);
            // 
            // lblOverdueCount
            // 
            this.lblOverdueCount.AutoSize = true;
            this.lblOverdueCount.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverdueCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblOverdueCount.Location = new System.Drawing.Point(800, 22);
            this.lblOverdueCount.Name = "lblOverdueCount";
            this.lblOverdueCount.Size = new System.Drawing.Size(134, 25);
            this.lblOverdueCount.TabIndex = 6;
            this.lblOverdueCount.Text = "⚠️ Quá hạn: 0";
            // 
            // cbSort
            // 
            this.cbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSort.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSort.FormattingEnabled = true;
            this.cbSort.Items.AddRange(new object[] {
            "Mặc định",
            "Hạn chót tăng dần",
            "Hạn chót giảm dần"});
            this.cbSort.Location = new System.Drawing.Point(625, 19);
            this.cbSort.Name = "cbSort";
            this.cbSort.Size = new System.Drawing.Size(160, 31);
            this.cbSort.TabIndex = 5;
            this.cbSort.SelectedIndexChanged += new System.EventHandler(this.cbSort_SelectedIndexChanged);
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblSort.Location = new System.Drawing.Point(545, 23);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(79, 23);
            this.lblSort.TabIndex = 4;
            this.lblSort.Text = "Sắp xếp:";
            // 
            // cbFilterPriority
            // 
            this.cbFilterPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterPriority.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterPriority.FormattingEnabled = true;
            this.cbFilterPriority.Items.AddRange(new object[] {
            "Tất cả",
            "Cao",
            "Trung bình",
            "Thấp"});
            this.cbFilterPriority.Location = new System.Drawing.Point(400, 19);
            this.cbFilterPriority.Name = "cbFilterPriority";
            this.cbFilterPriority.Size = new System.Drawing.Size(130, 31);
            this.cbFilterPriority.TabIndex = 3;
            this.cbFilterPriority.SelectedIndexChanged += new System.EventHandler(this.cbFilterPriority_SelectedIndexChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblFilter.Location = new System.Drawing.Point(300, 23);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(100, 23);
            this.lblFilter.TabIndex = 2;
            this.lblFilter.Text = "Độ ưu tiên:";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(105, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(180, 30);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblSearch.Location = new System.Drawing.Point(15, 23);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(91, 23);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Tìm kiếm:";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelMain.Controls.Add(this.tableLayoutPanel1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(250, 70);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(15);
            this.panelMain.Size = new System.Drawing.Size(950, 580);
            this.panelMain.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.gbTodo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbDoing, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbDone, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 15);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(920, 550);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gbTodo
            // 
            this.gbTodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.gbTodo.Controls.Add(this.flpTodo);
            this.gbTodo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTodo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTodo.ForeColor = System.Drawing.Color.White;
            this.gbTodo.Location = new System.Drawing.Point(5, 5);
            this.gbTodo.Margin = new System.Windows.Forms.Padding(5);
            this.gbTodo.Name = "gbTodo";
            this.gbTodo.Padding = new System.Windows.Forms.Padding(8);
            this.gbTodo.Size = new System.Drawing.Size(296, 540);
            this.gbTodo.TabIndex = 0;
            this.gbTodo.TabStop = false;
            this.gbTodo.Text = "📋 TODO (Cần làm)";
            // 
            // flpTodo
            // 
            this.flpTodo.AutoScroll = true;
            this.flpTodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.flpTodo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTodo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpTodo.Location = new System.Drawing.Point(8, 35);
            this.flpTodo.Name = "flpTodo";
            this.flpTodo.Padding = new System.Windows.Forms.Padding(5);
            this.flpTodo.Size = new System.Drawing.Size(280, 497);
            this.flpTodo.TabIndex = 0;
            this.flpTodo.WrapContents = false;
            // 
            // gbDoing
            // 
            this.gbDoing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.gbDoing.Controls.Add(this.flpDoing);
            this.gbDoing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDoing.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDoing.ForeColor = System.Drawing.Color.White;
            this.gbDoing.Location = new System.Drawing.Point(311, 5);
            this.gbDoing.Margin = new System.Windows.Forms.Padding(5);
            this.gbDoing.Name = "gbDoing";
            this.gbDoing.Padding = new System.Windows.Forms.Padding(8);
            this.gbDoing.Size = new System.Drawing.Size(296, 540);
            this.gbDoing.TabIndex = 1;
            this.gbDoing.TabStop = false;
            this.gbDoing.Text = "🔄 DOING (Đang làm)";
            // 
            // flpDoing
            // 
            this.flpDoing.AutoScroll = true;
            this.flpDoing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.flpDoing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpDoing.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpDoing.Location = new System.Drawing.Point(8, 35);
            this.flpDoing.Name = "flpDoing";
            this.flpDoing.Padding = new System.Windows.Forms.Padding(5);
            this.flpDoing.Size = new System.Drawing.Size(280, 497);
            this.flpDoing.TabIndex = 0;
            this.flpDoing.WrapContents = false;
            // 
            // gbDone
            // 
            this.gbDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.gbDone.Controls.Add(this.flpDone);
            this.gbDone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDone.ForeColor = System.Drawing.Color.White;
            this.gbDone.Location = new System.Drawing.Point(617, 5);
            this.gbDone.Margin = new System.Windows.Forms.Padding(5);
            this.gbDone.Name = "gbDone";
            this.gbDone.Padding = new System.Windows.Forms.Padding(8);
            this.gbDone.Size = new System.Drawing.Size(298, 540);
            this.gbDone.TabIndex = 2;
            this.gbDone.TabStop = false;
            this.gbDone.Text = "✅ DONE (Đã xong)";
            // 
            // flpDone
            // 
            this.flpDone.AutoScroll = true;
            this.flpDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.flpDone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpDone.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpDone.Location = new System.Drawing.Point(8, 35);
            this.flpDone.Name = "flpDone";
            this.flpDone.Padding = new System.Windows.Forms.Padding(5);
            this.flpDone.Size = new System.Drawing.Size(282, 497);
            this.flpDone.TabIndex = 0;
            this.flpDone.WrapContents = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelSidebar);
            this.MinimumSize = new System.Drawing.Size(1100, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "📋 Kanban Task Manager - Quản lý công việc";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbTodo.ResumeLayout(false);
            this.gbDoing.ResumeLayout(false);
            this.gbDone.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // Sidebar controls
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnOpenAddForm;
        private System.Windows.Forms.Button btnQuanLyThanhVien;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnTagGroup;

        // Top panel controls
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cbFilterPriority;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.ComboBox cbSort;
        private System.Windows.Forms.Label lblOverdueCount;
        private System.Windows.Forms.Button btnExportCSV;

        // Main panel controls
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbTodo;
        private System.Windows.Forms.GroupBox gbDoing;
        private System.Windows.Forms.GroupBox gbDone;
        private System.Windows.Forms.FlowLayoutPanel flpTodo;
        private System.Windows.Forms.FlowLayoutPanel flpDoing;
        private System.Windows.Forms.FlowLayoutPanel flpDone;
    }
}


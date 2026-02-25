namespace btlwindow
{
    partial class ucManageMembers
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblPermissionInfo = new System.Windows.Forms.Label();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.lblTotalMembersLabel = new System.Windows.Forms.Label();
            this.lblTotalMembers = new System.Windows.Forms.Label();
            this.lblTotalManagersLabel = new System.Windows.Forms.Label();
            this.lblTotalManagers = new System.Windows.Forms.Label();
            this.lblTotalEmployeesLabel = new System.Windows.Forms.Label();
            this.lblTotalEmployees = new System.Windows.Forms.Label();
            this.dgvMembers = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnAddMember = new System.Windows.Forms.Button();
            this.btnChangeRole = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlPagination = new System.Windows.Forms.Panel();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.cboPageSize = new System.Windows.Forms.ComboBox();
            this.pnlStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.pnlActions.SuspendLayout();
            this.pnlPagination.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 32);
            this.lblTitle.Text = "👥 Quản lý thành viên";

            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblSubtitle.Location = new System.Drawing.Point(23, 55);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(350, 19);
            this.lblSubtitle.Text = "Quản lý danh sách thành viên và phân quyền hệ thống";

            // 
            // lblPermissionInfo
            // 
            this.lblPermissionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left))));
            this.lblPermissionInfo.AutoSize = true;
            this.lblPermissionInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblPermissionInfo.Location = new System.Drawing.Point(18, 75);
            this.lblPermissionInfo.Name = "lblPermissionInfo";
            this.lblPermissionInfo.Size = new System.Drawing.Size(200, 15);
            this.lblPermissionInfo.Text = "";
            this.lblPermissionInfo.Visible = false;

            // 
            // pnlStats
            // 
            this.pnlStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStats.BackColor = System.Drawing.Color.White;
            this.pnlStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStats.Controls.Add(this.lblTotalMembersLabel);
            this.pnlStats.Controls.Add(this.lblTotalMembers);
            this.pnlStats.Controls.Add(this.lblTotalManagersLabel);
            this.pnlStats.Controls.Add(this.lblTotalManagers);
            this.pnlStats.Controls.Add(this.lblTotalEmployeesLabel);
            this.pnlStats.Controls.Add(this.lblTotalEmployees);
            this.pnlStats.Location = new System.Drawing.Point(15, 105);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(970, 80);
            this.pnlStats.Padding = new System.Windows.Forms.Padding(10);

            // 
            // lblTotalMembersLabel
            // 
            this.lblTotalMembersLabel.AutoSize = true;
            this.lblTotalMembersLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalMembersLabel.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblTotalMembersLabel.Location = new System.Drawing.Point(20, 15);
            this.lblTotalMembersLabel.Text = "📊 Tổng thành viên";

            // 
            // lblTotalMembers
            // 
            this.lblTotalMembers.AutoSize = true;
            this.lblTotalMembers.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalMembers.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lblTotalMembers.Location = new System.Drawing.Point(20, 35);
            this.lblTotalMembers.Text = "0";

            // 
            // lblTotalManagersLabel
            // 
            this.lblTotalManagersLabel.AutoSize = true;
            this.lblTotalManagersLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalManagersLabel.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblTotalManagersLabel.Location = new System.Drawing.Point(270, 15);
            this.lblTotalManagersLabel.Text = "🔑 Quản lý";

            // 
            // lblTotalManagers
            // 
            this.lblTotalManagers.AutoSize = true;
            this.lblTotalManagers.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalManagers.ForeColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.lblTotalManagers.Location = new System.Drawing.Point(270, 35);
            this.lblTotalManagers.Text = "0";

            // 
            // lblTotalEmployeesLabel
            // 
            this.lblTotalEmployeesLabel.AutoSize = true;
            this.lblTotalEmployeesLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalEmployeesLabel.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblTotalEmployeesLabel.Location = new System.Drawing.Point(520, 15);
            this.lblTotalEmployeesLabel.Text = "👤 Nhân viên";

            // 
            // lblTotalEmployees
            // 
            this.lblTotalEmployees.AutoSize = true;
            this.lblTotalEmployees.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalEmployees.ForeColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.lblTotalEmployees.Location = new System.Drawing.Point(520, 35);
            this.lblTotalEmployees.Text = "0";

            // 
            // dgvMembers
            // 
            this.dgvMembers.AllowUserToAddRows = false;
            this.dgvMembers.AllowUserToDeleteRows = false;
            this.dgvMembers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMembers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMembers.BackgroundColor = System.Drawing.Color.White;
            this.dgvMembers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colId,
            this.colHoTen,
            this.colEmail,
            this.colRole,
            this.colNgayTao});
            this.dgvMembers.Location = new System.Drawing.Point(15, 200);
            this.dgvMembers.MultiSelect = false;
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.ReadOnly = true;
            this.dgvMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembers.Size = new System.Drawing.Size(970, 420);
            this.dgvMembers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMembers_CellDoubleClick);

            // 
            // colSTT
            // 
            this.colSTT.HeaderText = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            this.colSTT.FillWeight = 8;

            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;

            // 
            // colHoTen
            // 
            this.colHoTen.HeaderText = "Họ và tên";
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.ReadOnly = true;
            this.colHoTen.FillWeight = 25;

            // 
            // colEmail
            // 
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            this.colEmail.FillWeight = 35;

            // 
            // colRole
            // 
            this.colRole.HeaderText = "Vai trò";
            this.colRole.Name = "colRole";
            this.colRole.ReadOnly = true;
            this.colRole.FillWeight = 20;

            // 
            // colNgayTao
            // 
            this.colNgayTao.HeaderText = "Ngày tham gia";
            this.colNgayTao.Name = "colNgayTao";
            this.colNgayTao.ReadOnly = true;
            this.colNgayTao.FillWeight = 15;

            // 
            // pnlActions
            // 
            this.pnlActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlActions.BackColor = System.Drawing.Color.White;
            this.pnlActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlActions.Controls.Add(this.btnAddMember);
            this.pnlActions.Controls.Add(this.btnChangeRole);
            this.pnlActions.Controls.Add(this.btnDelete);
            this.pnlActions.Controls.Add(this.btnRefresh);
            this.pnlActions.Location = new System.Drawing.Point(15, 635);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(10);
            this.pnlActions.Size = new System.Drawing.Size(970, 70);

            // 
            // btnAddMember
            // 
            this.btnAddMember.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnAddMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMember.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddMember.ForeColor = System.Drawing.Color.White;
            this.btnAddMember.Location = new System.Drawing.Point(15, 10);
            this.btnAddMember.Name = "btnAddMember";
            this.btnAddMember.Size = new System.Drawing.Size(150, 38);
            this.btnAddMember.Text = "➕ Thêm thành viên";
            this.btnAddMember.UseVisualStyleBackColor = false;
            this.btnAddMember.Click += new System.EventHandler(this.btnAddMember_Click);

            // 
            // btnChangeRole
            // 
            this.btnChangeRole.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnChangeRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeRole.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnChangeRole.ForeColor = System.Drawing.Color.White;
            this.btnChangeRole.Location = new System.Drawing.Point(180, 10);
            this.btnChangeRole.Name = "btnChangeRole";
            this.btnChangeRole.Size = new System.Drawing.Size(140, 38);
            this.btnChangeRole.Text = "🔄 Đổi vai trò";
            this.btnChangeRole.UseVisualStyleBackColor = false;
            this.btnChangeRole.Click += new System.EventHandler(this.btnChangeRole_Click);

            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(335, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 38);
            this.btnDelete.Text = "🗑️ Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(470, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 38);
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // 
            // pnlPagination
            // 
            this.pnlPagination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPagination.BackColor = System.Drawing.Color.White;
            this.pnlPagination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPagination.Controls.Add(this.btnFirstPage);
            this.pnlPagination.Controls.Add(this.btnPrevPage);
            this.pnlPagination.Controls.Add(this.lblPageInfo);
            this.pnlPagination.Controls.Add(this.btnNextPage);
            this.pnlPagination.Controls.Add(this.btnLastPage);
            this.pnlPagination.Controls.Add(this.cboPageSize);
            this.pnlPagination.Location = new System.Drawing.Point(15, 710);
            this.pnlPagination.Name = "pnlPagination";
            this.pnlPagination.Padding = new System.Windows.Forms.Padding(10);
            this.pnlPagination.Size = new System.Drawing.Size(970, 60);

            // 
            // btnFirstPage
            // 
            this.btnFirstPage.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnFirstPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirstPage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFirstPage.ForeColor = System.Drawing.Color.White;
            this.btnFirstPage.Location = new System.Drawing.Point(15, 10);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(80, 35);
            this.btnFirstPage.Text = "⏮ Đầu";
            this.btnFirstPage.UseVisualStyleBackColor = false;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);

            // 
            // btnPrevPage
            // 
            this.btnPrevPage.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnPrevPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevPage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrevPage.ForeColor = System.Drawing.Color.White;
            this.btnPrevPage.Location = new System.Drawing.Point(105, 10);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(80, 35);
            this.btnPrevPage.Text = "◀ Trước";
            this.btnPrevPage.UseVisualStyleBackColor = false;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);

            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPageInfo.Location = new System.Drawing.Point(200, 18);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(200, 15);
            this.lblPageInfo.Text = "Trang 1 / 1 (Tổng: 0 bản ghi)";

            // 
            // btnNextPage
            // 
            this.btnNextPage.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextPage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNextPage.ForeColor = System.Drawing.Color.White;
            this.btnNextPage.Location = new System.Drawing.Point(420, 10);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(80, 35);
            this.btnNextPage.Text = "Sau ▶";
            this.btnNextPage.UseVisualStyleBackColor = false;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);

            // 
            // btnLastPage
            // 
            this.btnLastPage.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnLastPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLastPage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLastPage.ForeColor = System.Drawing.Color.White;
            this.btnLastPage.Location = new System.Drawing.Point(510, 10);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(80, 35);
            this.btnLastPage.Text = "Cuối ⏭";
            this.btnLastPage.UseVisualStyleBackColor = false;
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);

            // 
            // cboPageSize
            // 
            this.cboPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPageSize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboPageSize.FormattingEnabled = true;
            this.cboPageSize.Items.AddRange(new object[] {
            "10 bản ghi",
            "25 bản ghi",
            "50 bản ghi",
            "100 bản ghi"});
            this.cboPageSize.Location = new System.Drawing.Point(620, 13);
            this.cboPageSize.Name = "cboPageSize";
            this.cboPageSize.Size = new System.Drawing.Size(120, 23);
            this.cboPageSize.SelectedIndexChanged += new System.EventHandler(this.cboPageSize_SelectedIndexChanged);

            // 
            // ucManageMembers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblPermissionInfo);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.dgvMembers);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlPagination);
            this.Name = "ucManageMembers";
            this.Size = new System.Drawing.Size(1000, 800);
            this.Load += new System.EventHandler(this.ucManageMembers_Load);
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.pnlActions.ResumeLayout(false);
            this.pnlPagination.ResumeLayout(false);
            this.pnlPagination.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblPermissionInfo;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblTotalMembersLabel;
        private System.Windows.Forms.Label lblTotalMembers;
        private System.Windows.Forms.Label lblTotalManagersLabel;
        private System.Windows.Forms.Label lblTotalManagers;
        private System.Windows.Forms.Label lblTotalEmployeesLabel;
        private System.Windows.Forms.Label lblTotalEmployees;
        private System.Windows.Forms.DataGridView dgvMembers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayTao;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnAddMember;
        private System.Windows.Forms.Button btnChangeRole;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.ComboBox cboPageSize;
    }
}

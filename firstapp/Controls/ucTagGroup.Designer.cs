namespace btlwindow
{
    partial class ucTagGroup
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabTags = new System.Windows.Forms.TabPage();
            this.dgvTags = new System.Windows.Forms.DataGridView();
            this.colTagId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTagName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTagColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTagDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTagsActions = new System.Windows.Forms.Panel();
            this.btnAddTag = new System.Windows.Forms.Button();
            this.btnEditTag = new System.Windows.Forms.Button();
            this.btnDeleteTag = new System.Windows.Forms.Button();
            this.btnRefreshTags = new System.Windows.Forms.Button();
            this.pnlTagsStats = new System.Windows.Forms.Panel();
            this.lblTotalTagsLabel = new System.Windows.Forms.Label();
            this.lblTotalTags = new System.Windows.Forms.Label();
            this.tabGroups = new System.Windows.Forms.TabPage();
            this.dgvGroups = new System.Windows.Forms.DataGridView();
            this.colGroupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGroupColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGroupDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlGroupsActions = new System.Windows.Forms.Panel();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.btnEditGroup = new System.Windows.Forms.Button();
            this.btnDeleteGroup = new System.Windows.Forms.Button();
            this.btnRefreshGroups = new System.Windows.Forms.Button();
            this.pnlGroupsStats = new System.Windows.Forms.Panel();
            this.lblTotalGroupsLabel = new System.Windows.Forms.Label();
            this.lblTotalGroups = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabTags.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTags)).BeginInit();
            this.pnlTagsActions.SuspendLayout();
            this.pnlTagsStats.SuspendLayout();
            this.tabGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).BeginInit();
            this.pnlGroupsActions.SuspendLayout();
            this.pnlGroupsStats.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(250, 32);
            this.lblTitle.Text = "🏷️ Quản lý Tags & Nhóm";

            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblSubtitle.Location = new System.Drawing.Point(23, 55);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(400, 19);
            this.lblSubtitle.Text = "Quản lý tags và nhóm công việc cho hệ thống";

            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabTags);
            this.tabControl.Controls.Add(this.tabGroups);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(15, 90);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(970, 680);

            // ==================== TAB TAGS ====================
            // 
            // tabTags
            // 
            this.tabTags.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.tabTags.Controls.Add(this.pnlTagsStats);
            this.tabTags.Controls.Add(this.dgvTags);
            this.tabTags.Controls.Add(this.pnlTagsActions);
            this.tabTags.Location = new System.Drawing.Point(4, 26);
            this.tabTags.Name = "tabTags";
            this.tabTags.Padding = new System.Windows.Forms.Padding(10);
            this.tabTags.Size = new System.Drawing.Size(962, 650);
            this.tabTags.Text = "🏷️ Tags";

            // 
            // pnlTagsStats
            // 
            this.pnlTagsStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTagsStats.BackColor = System.Drawing.Color.White;
            this.pnlTagsStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTagsStats.Controls.Add(this.lblTotalTagsLabel);
            this.pnlTagsStats.Controls.Add(this.lblTotalTags);
            this.pnlTagsStats.Location = new System.Drawing.Point(10, 10);
            this.pnlTagsStats.Name = "pnlTagsStats";
            this.pnlTagsStats.Padding = new System.Windows.Forms.Padding(10);
            this.pnlTagsStats.Size = new System.Drawing.Size(940, 80);

            // 
            // lblTotalTagsLabel
            // 
            this.lblTotalTagsLabel.AutoSize = true;
            this.lblTotalTagsLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalTagsLabel.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblTotalTagsLabel.Location = new System.Drawing.Point(20, 15);
            this.lblTotalTagsLabel.Text = "📊 Tổng số Tags";

            // 
            // lblTotalTags
            // 
            this.lblTotalTags.AutoSize = true;
            this.lblTotalTags.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalTags.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lblTotalTags.Location = new System.Drawing.Point(20, 35);
            this.lblTotalTags.Text = "0";

            // 
            // dgvTags
            // 
            this.dgvTags.AllowUserToAddRows = false;
            this.dgvTags.AllowUserToDeleteRows = false;
            this.dgvTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTags.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTags.BackgroundColor = System.Drawing.Color.White;
            this.dgvTags.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTagId,
            this.colTagName,
            this.colTagColor,
            this.colTagDate});
            this.dgvTags.Location = new System.Drawing.Point(10, 100);
            this.dgvTags.MultiSelect = false;
            this.dgvTags.Name = "dgvTags";
            this.dgvTags.ReadOnly = true;
            this.dgvTags.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTags.Size = new System.Drawing.Size(940, 470);

            // 
            // colTagId
            // 
            this.colTagId.HeaderText = "ID";
            this.colTagId.Name = "colTagId";
            this.colTagId.ReadOnly = true;
            this.colTagId.Visible = false;

            // 
            // colTagName
            // 
            this.colTagName.HeaderText = "Tên Tag";
            this.colTagName.Name = "colTagName";
            this.colTagName.ReadOnly = true;
            this.colTagName.FillWeight = 40;

            // 
            // colTagColor
            // 
            this.colTagColor.HeaderText = "Màu sắc";
            this.colTagColor.Name = "colTagColor";
            this.colTagColor.ReadOnly = true;
            this.colTagColor.FillWeight = 30;

            // 
            // colTagDate
            // 
            this.colTagDate.HeaderText = "Ngày tạo";
            this.colTagDate.Name = "colTagDate";
            this.colTagDate.ReadOnly = true;
            this.colTagDate.FillWeight = 30;

            // 
            // pnlTagsActions
            // 
            this.pnlTagsActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTagsActions.BackColor = System.Drawing.Color.White;
            this.pnlTagsActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTagsActions.Controls.Add(this.btnAddTag);
            this.pnlTagsActions.Controls.Add(this.btnEditTag);
            this.pnlTagsActions.Controls.Add(this.btnDeleteTag);
            this.pnlTagsActions.Controls.Add(this.btnRefreshTags);
            this.pnlTagsActions.Location = new System.Drawing.Point(10, 580);
            this.pnlTagsActions.Name = "pnlTagsActions";
            this.pnlTagsActions.Padding = new System.Windows.Forms.Padding(10);
            this.pnlTagsActions.Size = new System.Drawing.Size(940, 60);

            // 
            // btnAddTag
            // 
            this.btnAddTag.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnAddTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTag.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddTag.ForeColor = System.Drawing.Color.White;
            this.btnAddTag.Location = new System.Drawing.Point(15, 10);
            this.btnAddTag.Name = "btnAddTag";
            this.btnAddTag.Size = new System.Drawing.Size(120, 38);
            this.btnAddTag.Text = "➕ Thêm Tag";
            this.btnAddTag.UseVisualStyleBackColor = false;
            this.btnAddTag.Click += new System.EventHandler(this.btnAddTag_Click);

            // 
            // btnEditTag
            // 
            this.btnEditTag.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnEditTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditTag.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditTag.ForeColor = System.Drawing.Color.White;
            this.btnEditTag.Location = new System.Drawing.Point(145, 10);
            this.btnEditTag.Name = "btnEditTag";
            this.btnEditTag.Size = new System.Drawing.Size(120, 38);
            this.btnEditTag.Text = "✏️ Sửa";
            this.btnEditTag.UseVisualStyleBackColor = false;
            this.btnEditTag.Click += new System.EventHandler(this.btnEditTag_Click);

            // 
            // btnDeleteTag
            // 
            this.btnDeleteTag.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnDeleteTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTag.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteTag.ForeColor = System.Drawing.Color.White;
            this.btnDeleteTag.Location = new System.Drawing.Point(275, 10);
            this.btnDeleteTag.Name = "btnDeleteTag";
            this.btnDeleteTag.Size = new System.Drawing.Size(120, 38);
            this.btnDeleteTag.Text = "🗑️ Xóa";
            this.btnDeleteTag.UseVisualStyleBackColor = false;
            this.btnDeleteTag.Click += new System.EventHandler(this.btnDeleteTag_Click);

            // 
            // btnRefreshTags
            // 
            this.btnRefreshTags.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnRefreshTags.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshTags.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefreshTags.ForeColor = System.Drawing.Color.White;
            this.btnRefreshTags.Location = new System.Drawing.Point(405, 10);
            this.btnRefreshTags.Name = "btnRefreshTags";
            this.btnRefreshTags.Size = new System.Drawing.Size(120, 38);
            this.btnRefreshTags.Text = "🔄 Làm mới";
            this.btnRefreshTags.UseVisualStyleBackColor = false;
            this.btnRefreshTags.Click += new System.EventHandler(this.btnRefreshTags_Click);

            // ==================== TAB GROUPS ====================
            // 
            // tabGroups
            // 
            this.tabGroups.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.tabGroups.Controls.Add(this.pnlGroupsStats);
            this.tabGroups.Controls.Add(this.dgvGroups);
            this.tabGroups.Controls.Add(this.pnlGroupsActions);
            this.tabGroups.Location = new System.Drawing.Point(4, 26);
            this.tabGroups.Name = "tabGroups";
            this.tabGroups.Padding = new System.Windows.Forms.Padding(10);
            this.tabGroups.Size = new System.Drawing.Size(962, 650);
            this.tabGroups.Text = "📁 Nhóm";

            // 
            // pnlGroupsStats
            // 
            this.pnlGroupsStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGroupsStats.BackColor = System.Drawing.Color.White;
            this.pnlGroupsStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGroupsStats.Controls.Add(this.lblTotalGroupsLabel);
            this.pnlGroupsStats.Controls.Add(this.lblTotalGroups);
            this.pnlGroupsStats.Location = new System.Drawing.Point(10, 10);
            this.pnlGroupsStats.Name = "pnlGroupsStats";
            this.pnlGroupsStats.Padding = new System.Windows.Forms.Padding(10);
            this.pnlGroupsStats.Size = new System.Drawing.Size(940, 80);

            // 
            // lblTotalGroupsLabel
            // 
            this.lblTotalGroupsLabel.AutoSize = true;
            this.lblTotalGroupsLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalGroupsLabel.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblTotalGroupsLabel.Location = new System.Drawing.Point(20, 15);
            this.lblTotalGroupsLabel.Text = "📊 Tổng số Nhóm";

            // 
            // lblTotalGroups
            // 
            this.lblTotalGroups.AutoSize = true;
            this.lblTotalGroups.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalGroups.ForeColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.lblTotalGroups.Location = new System.Drawing.Point(20, 35);
            this.lblTotalGroups.Text = "0";

            // 
            // dgvGroups
            // 
            this.dgvGroups.AllowUserToAddRows = false;
            this.dgvGroups.AllowUserToDeleteRows = false;
            this.dgvGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGroups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGroups.BackgroundColor = System.Drawing.Color.White;
            this.dgvGroups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGroupId,
            this.colGroupName,
            this.colGroupColor,
            this.colGroupDesc});
            this.dgvGroups.Location = new System.Drawing.Point(10, 100);
            this.dgvGroups.MultiSelect = false;
            this.dgvGroups.Name = "dgvGroups";
            this.dgvGroups.ReadOnly = true;
            this.dgvGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroups.Size = new System.Drawing.Size(940, 470);

            // 
            // colGroupId
            // 
            this.colGroupId.HeaderText = "ID";
            this.colGroupId.Name = "colGroupId";
            this.colGroupId.ReadOnly = true;
            this.colGroupId.Visible = false;

            // 
            // colGroupName
            // 
            this.colGroupName.HeaderText = "Tên Nhóm";
            this.colGroupName.Name = "colGroupName";
            this.colGroupName.ReadOnly = true;
            this.colGroupName.FillWeight = 30;

            // 
            // colGroupColor
            // 
            this.colGroupColor.HeaderText = "Màu sắc";
            this.colGroupColor.Name = "colGroupColor";
            this.colGroupColor.ReadOnly = true;
            this.colGroupColor.FillWeight = 20;

            // 
            // colGroupDesc
            // 
            this.colGroupDesc.HeaderText = "Mô tả";
            this.colGroupDesc.Name = "colGroupDesc";
            this.colGroupDesc.ReadOnly = true;
            this.colGroupDesc.FillWeight = 50;

            // 
            // pnlGroupsActions
            // 
            this.pnlGroupsActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGroupsActions.BackColor = System.Drawing.Color.White;
            this.pnlGroupsActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGroupsActions.Controls.Add(this.btnAddGroup);
            this.pnlGroupsActions.Controls.Add(this.btnEditGroup);
            this.pnlGroupsActions.Controls.Add(this.btnDeleteGroup);
            this.pnlGroupsActions.Controls.Add(this.btnRefreshGroups);
            this.pnlGroupsActions.Location = new System.Drawing.Point(10, 580);
            this.pnlGroupsActions.Name = "pnlGroupsActions";
            this.pnlGroupsActions.Padding = new System.Windows.Forms.Padding(10);
            this.pnlGroupsActions.Size = new System.Drawing.Size(940, 60);

            // 
            // btnAddGroup
            // 
            this.btnAddGroup.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnAddGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGroup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddGroup.ForeColor = System.Drawing.Color.White;
            this.btnAddGroup.Location = new System.Drawing.Point(15, 10);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(120, 38);
            this.btnAddGroup.Text = "➕ Thêm Nhóm";
            this.btnAddGroup.UseVisualStyleBackColor = false;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);

            // 
            // btnEditGroup
            // 
            this.btnEditGroup.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnEditGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditGroup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditGroup.ForeColor = System.Drawing.Color.White;
            this.btnEditGroup.Location = new System.Drawing.Point(145, 10);
            this.btnEditGroup.Name = "btnEditGroup";
            this.btnEditGroup.Size = new System.Drawing.Size(120, 38);
            this.btnEditGroup.Text = "✏️ Sửa";
            this.btnEditGroup.UseVisualStyleBackColor = false;
            this.btnEditGroup.Click += new System.EventHandler(this.btnEditGroup_Click);

            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnDeleteGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteGroup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteGroup.ForeColor = System.Drawing.Color.White;
            this.btnDeleteGroup.Location = new System.Drawing.Point(275, 10);
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(120, 38);
            this.btnDeleteGroup.Text = "🗑️ Xóa";
            this.btnDeleteGroup.UseVisualStyleBackColor = false;
            this.btnDeleteGroup.Click += new System.EventHandler(this.btnDeleteGroup_Click);

            // 
            // btnRefreshGroups
            // 
            this.btnRefreshGroups.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnRefreshGroups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshGroups.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefreshGroups.ForeColor = System.Drawing.Color.White;
            this.btnRefreshGroups.Location = new System.Drawing.Point(405, 10);
            this.btnRefreshGroups.Name = "btnRefreshGroups";
            this.btnRefreshGroups.Size = new System.Drawing.Size(120, 38);
            this.btnRefreshGroups.Text = "🔄 Làm mới";
            this.btnRefreshGroups.UseVisualStyleBackColor = false;
            this.btnRefreshGroups.Click += new System.EventHandler(this.btnRefreshGroups_Click);

            // 
            // ucTagGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.tabControl);
            this.Name = "ucTagGroup";
            this.Size = new System.Drawing.Size(1000, 800);
            this.Load += new System.EventHandler(this.ucTagGroup_Load);
            this.tabControl.ResumeLayout(false);
            this.tabTags.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTags)).EndInit();
            this.pnlTagsActions.ResumeLayout(false);
            this.pnlTagsStats.ResumeLayout(false);
            this.pnlTagsStats.PerformLayout();
            this.tabGroups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).EndInit();
            this.pnlGroupsActions.ResumeLayout(false);
            this.pnlGroupsStats.ResumeLayout(false);
            this.pnlGroupsStats.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.TabControl tabControl;

        // Tab Tags
        private System.Windows.Forms.TabPage tabTags;
        private System.Windows.Forms.DataGridView dgvTags;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTagId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTagName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTagColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTagDate;
        private System.Windows.Forms.Panel pnlTagsActions;
        private System.Windows.Forms.Button btnAddTag;
        private System.Windows.Forms.Button btnEditTag;
        private System.Windows.Forms.Button btnDeleteTag;
        private System.Windows.Forms.Button btnRefreshTags;
        private System.Windows.Forms.Panel pnlTagsStats;
        private System.Windows.Forms.Label lblTotalTagsLabel;
        private System.Windows.Forms.Label lblTotalTags;

        // Tab Groups
        private System.Windows.Forms.TabPage tabGroups;
        private System.Windows.Forms.DataGridView dgvGroups;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroupColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroupDesc;
        private System.Windows.Forms.Panel pnlGroupsActions;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.Button btnEditGroup;
        private System.Windows.Forms.Button btnDeleteGroup;
        private System.Windows.Forms.Button btnRefreshGroups;
        private System.Windows.Forms.Panel pnlGroupsStats;
        private System.Windows.Forms.Label lblTotalGroupsLabel;
        private System.Windows.Forms.Label lblTotalGroups;
    }
}
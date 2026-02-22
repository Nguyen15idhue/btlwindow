namespace btlwindow
{
    partial class frmTaskDetail
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblTitleLabel = new System.Windows.Forms.Label();
            this.lblTitleValue = new System.Windows.Forms.Label();
            this.lblDescriptionLabel = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblCreatorLabel = new System.Windows.Forms.Label();
            this.lblCreatorValue = new System.Windows.Forms.Label();
            this.lblAssigneeLabel = new System.Windows.Forms.Label();
            this.lblAssigneeValue = new System.Windows.Forms.Label();
            this.lblDeadlineLabel = new System.Windows.Forms.Label();
            this.lblDeadlineValue = new System.Windows.Forms.Label();
            this.lblPriorityLabel = new System.Windows.Forms.Label();
            this.lblPriorityValue = new System.Windows.Forms.Label();
            this.lblStatusLabel = new System.Windows.Forms.Label();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.lblGroupLabel = new System.Windows.Forms.Label();
            this.lblGroupValue = new System.Windows.Forms.Label();
            this.lblTagsLabel = new System.Windows.Forms.Label();
            this.flpTags = new System.Windows.Forms.FlowLayoutPanel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(600, 60);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(600, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "👁️ CHI TIẾT TASK";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.flpTags);
            this.panelMain.Controls.Add(this.lblTagsLabel);
            this.panelMain.Controls.Add(this.lblGroupValue);
            this.panelMain.Controls.Add(this.lblGroupLabel);
            this.panelMain.Controls.Add(this.lblStatusValue);
            this.panelMain.Controls.Add(this.lblStatusLabel);
            this.panelMain.Controls.Add(this.lblPriorityValue);
            this.panelMain.Controls.Add(this.lblPriorityLabel);
            this.panelMain.Controls.Add(this.lblDeadlineValue);
            this.panelMain.Controls.Add(this.lblDeadlineLabel);
            this.panelMain.Controls.Add(this.lblAssigneeValue);
            this.panelMain.Controls.Add(this.lblAssigneeLabel);
            this.panelMain.Controls.Add(this.lblCreatorValue);
            this.panelMain.Controls.Add(this.lblCreatorLabel);
            this.panelMain.Controls.Add(this.txtDescription);
            this.panelMain.Controls.Add(this.lblDescriptionLabel);
            this.panelMain.Controls.Add(this.lblTitleValue);
            this.panelMain.Controls.Add(this.lblTitleLabel);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 60);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(600, 440);
            this.panelMain.TabIndex = 1;
            // 
            // lblTitleLabel
            // 
            this.lblTitleLabel.AutoSize = true;
            this.lblTitleLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitleLabel.Location = new System.Drawing.Point(20, 25);
            this.lblTitleLabel.Name = "lblTitleLabel";
            this.lblTitleLabel.Size = new System.Drawing.Size(80, 15);
            this.lblTitleLabel.TabIndex = 0;
            this.lblTitleLabel.Text = "📝 Tiêu đề:";
            // 
            // lblTitleValue
            // 
            this.lblTitleValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitleValue.Location = new System.Drawing.Point(20, 45);
            this.lblTitleValue.Name = "lblTitleValue";
            this.lblTitleValue.Size = new System.Drawing.Size(540, 30);
            this.lblTitleValue.TabIndex = 1;
            this.lblTitleValue.Text = "Task Title";
            // 
            // lblDescriptionLabel
            // 
            this.lblDescriptionLabel.AutoSize = true;
            this.lblDescriptionLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDescriptionLabel.Location = new System.Drawing.Point(20, 85);
            this.lblDescriptionLabel.Name = "lblDescriptionLabel";
            this.lblDescriptionLabel.Size = new System.Drawing.Size(65, 15);
            this.lblDescriptionLabel.TabIndex = 2;
            this.lblDescriptionLabel.Text = "📄 Mô tả:";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescription.Location = new System.Drawing.Point(20, 105);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(540, 80);
            this.txtDescription.TabIndex = 3;
            // 
            // lblCreatorLabel
            // 
            this.lblCreatorLabel.AutoSize = true;
            this.lblCreatorLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCreatorLabel.Location = new System.Drawing.Point(20, 200);
            this.lblCreatorLabel.Name = "lblCreatorLabel";
            this.lblCreatorLabel.Size = new System.Drawing.Size(95, 15);
            this.lblCreatorLabel.TabIndex = 4;
            this.lblCreatorLabel.Text = "👤 Người tạo:";
            // 
            // lblCreatorValue
            // 
            this.lblCreatorValue.AutoSize = true;
            this.lblCreatorValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCreatorValue.Location = new System.Drawing.Point(150, 200);
            this.lblCreatorValue.Name = "lblCreatorValue";
            this.lblCreatorValue.Size = new System.Drawing.Size(100, 15);
            this.lblCreatorValue.TabIndex = 5;
            this.lblCreatorValue.Text = "Người tạo";
            // 
            // lblAssigneeLabel
            // 
            this.lblAssigneeLabel.AutoSize = true;
            this.lblAssigneeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAssigneeLabel.Location = new System.Drawing.Point(20, 225);
            this.lblAssigneeLabel.Name = "lblAssigneeLabel";
            this.lblAssigneeLabel.Size = new System.Drawing.Size(130, 15);
            this.lblAssigneeLabel.TabIndex = 6;
            this.lblAssigneeLabel.Text = "👤 Người thực hiện:";
            // 
            // lblAssigneeValue
            // 
            this.lblAssigneeValue.AutoSize = true;
            this.lblAssigneeValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAssigneeValue.Location = new System.Drawing.Point(150, 225);
            this.lblAssigneeValue.Name = "lblAssigneeValue";
            this.lblAssigneeValue.Size = new System.Drawing.Size(100, 15);
            this.lblAssigneeValue.TabIndex = 7;
            this.lblAssigneeValue.Text = "Người được giao";
            // 
            // lblDeadlineLabel
            // 
            this.lblDeadlineLabel.AutoSize = true;
            this.lblDeadlineLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDeadlineLabel.Location = new System.Drawing.Point(20, 250);
            this.lblDeadlineLabel.Name = "lblDeadlineLabel";
            this.lblDeadlineLabel.Size = new System.Drawing.Size(130, 15);
            this.lblDeadlineLabel.TabIndex = 8;
            this.lblDeadlineLabel.Text = "📅 Hạn hoàn thành:";
            // 
            // lblDeadlineValue
            // 
            this.lblDeadlineValue.AutoSize = true;
            this.lblDeadlineValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDeadlineValue.Location = new System.Drawing.Point(150, 250);
            this.lblDeadlineValue.Name = "lblDeadlineValue";
            this.lblDeadlineValue.Size = new System.Drawing.Size(100, 15);
            this.lblDeadlineValue.TabIndex = 9;
            this.lblDeadlineValue.Text = "Deadline";
            // 
            // lblPriorityLabel
            // 
            this.lblPriorityLabel.AutoSize = true;
            this.lblPriorityLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPriorityLabel.Location = new System.Drawing.Point(20, 275);
            this.lblPriorityLabel.Name = "lblPriorityLabel";
            this.lblPriorityLabel.Size = new System.Drawing.Size(105, 15);
            this.lblPriorityLabel.TabIndex = 10;
            this.lblPriorityLabel.Text = "🔴 Độ ưu tiên:";
            // 
            // lblPriorityValue
            // 
            this.lblPriorityValue.AutoSize = true;
            this.lblPriorityValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPriorityValue.Location = new System.Drawing.Point(150, 275);
            this.lblPriorityValue.Name = "lblPriorityValue";
            this.lblPriorityValue.Size = new System.Drawing.Size(80, 15);
            this.lblPriorityValue.TabIndex = 11;
            this.lblPriorityValue.Text = "Độ ưu tiên";
            // 
            // lblStatusLabel
            // 
            this.lblStatusLabel.AutoSize = true;
            this.lblStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatusLabel.Location = new System.Drawing.Point(20, 300);
            this.lblStatusLabel.Name = "lblStatusLabel";
            this.lblStatusLabel.Size = new System.Drawing.Size(100, 15);
            this.lblStatusLabel.TabIndex = 12;
            this.lblStatusLabel.Text = "📋 Trạng thái:";
            // 
            // lblStatusValue
            // 
            this.lblStatusValue.AutoSize = true;
            this.lblStatusValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatusValue.Location = new System.Drawing.Point(150, 298);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(80, 15);
            this.lblStatusValue.TabIndex = 13;
            this.lblStatusValue.Text = "Trạng thái";
            // 
            // lblGroupLabel
            // 
            this.lblGroupLabel.AutoSize = true;
            this.lblGroupLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGroupLabel.Location = new System.Drawing.Point(20, 330);
            this.lblGroupLabel.Name = "lblGroupLabel";
            this.lblGroupLabel.Size = new System.Drawing.Size(70, 15);
            this.lblGroupLabel.TabIndex = 14;
            this.lblGroupLabel.Text = "📁 Nhóm:";
            // 
            // lblGroupValue
            // 
            this.lblGroupValue.AutoSize = true;
            this.lblGroupValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGroupValue.Location = new System.Drawing.Point(150, 330);
            this.lblGroupValue.Name = "lblGroupValue";
            this.lblGroupValue.Size = new System.Drawing.Size(50, 15);
            this.lblGroupValue.TabIndex = 15;
            this.lblGroupValue.Text = "Nhóm";
            // 
            // lblTagsLabel
            // 
            this.lblTagsLabel.AutoSize = true;
            this.lblTagsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTagsLabel.Location = new System.Drawing.Point(20, 360);
            this.lblTagsLabel.Name = "lblTagsLabel";
            this.lblTagsLabel.Size = new System.Drawing.Size(65, 15);
            this.lblTagsLabel.TabIndex = 16;
            this.lblTagsLabel.Text = "🏷️ Tags:";
            // 
            // flpTags
            // 
            this.flpTags.Location = new System.Drawing.Point(20, 380);
            this.flpTags.Name = "flpTags";
            this.flpTags.Size = new System.Drawing.Size(540, 40);
            this.flpTags.TabIndex = 17;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 500);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(600, 60);
            this.panelBottom.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(225, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 40);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "❌ Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmTaskDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 560);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTaskDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết Task";
            this.Load += new System.EventHandler(this.frmTaskDetail_Load);
            this.panelTop.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblTitleLabel;
        private System.Windows.Forms.Label lblTitleValue;
        private System.Windows.Forms.Label lblDescriptionLabel;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblCreatorLabel;
        private System.Windows.Forms.Label lblCreatorValue;
        private System.Windows.Forms.Label lblAssigneeLabel;
        private System.Windows.Forms.Label lblAssigneeValue;
        private System.Windows.Forms.Label lblDeadlineLabel;
        private System.Windows.Forms.Label lblDeadlineValue;
        private System.Windows.Forms.Label lblPriorityLabel;
        private System.Windows.Forms.Label lblPriorityValue;
        private System.Windows.Forms.Label lblStatusLabel;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.Label lblGroupLabel;
        private System.Windows.Forms.Label lblGroupValue;
        private System.Windows.Forms.Label lblTagsLabel;
        private System.Windows.Forms.FlowLayoutPanel flpTags;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnClose;
    }
}

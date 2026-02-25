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
            this.flpTagGroups = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(150, 25);
            this.lblTitle.Text = "Quan ly nhom";

            // btnAddGroup
            this.btnAddGroup.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnAddGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGroup.ForeColor = System.Drawing.Color.White;
            this.btnAddGroup.Location = new System.Drawing.Point(10, 45);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(120, 35);
            this.btnAddGroup.Text = "+ Them nhom";
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);

            // flpTagGroups
            this.flpTagGroups.AutoScroll = true;
            this.flpTagGroups.Location = new System.Drawing.Point(10, 90);
            this.flpTagGroups.Name = "flpTagGroups";
            this.flpTagGroups.Size = new System.Drawing.Size(380, 300);
            this.flpTagGroups.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpTagGroups.WrapContents = false;

            // ucTagGroup
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnAddGroup);
            this.Controls.Add(this.flpTagGroups);
            this.Name = "ucTagGroup";
            this.Size = new System.Drawing.Size(400, 400);
            this.Load += new System.EventHandler(this.ucTagGroup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.FlowLayoutPanel flpTagGroups;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.Label lblTitle;
    }
}
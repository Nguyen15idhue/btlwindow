namespace btlwindow
{
    partial class frmTagEdit
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
            this.lblTenTag = new System.Windows.Forms.Label();
            this.txtTenTag = new System.Windows.Forms.TextBox();
            this.lblMau = new System.Windows.Forms.Label();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // lblTenTag
            // 
            this.lblTenTag.AutoSize = true;
            this.lblTenTag.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTenTag.Location = new System.Drawing.Point(20, 20);
            this.lblTenTag.Name = "lblTenTag";
            this.lblTenTag.Size = new System.Drawing.Size(60, 15);
            this.lblTenTag.Text = "Tên tag:";

            // 
            // txtTenTag
            // 
            this.txtTenTag.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenTag.Location = new System.Drawing.Point(20, 40);
            this.txtTenTag.Name = "txtTenTag";
            this.txtTenTag.Size = new System.Drawing.Size(250, 23);

            // 
            // lblMau
            // 
            this.lblMau.AutoSize = true;
            this.lblMau.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMau.Location = new System.Drawing.Point(20, 75);
            this.lblMau.Name = "lblMau";
            this.lblMau.Size = new System.Drawing.Size(60, 15);
            this.lblMau.Text = "Màu sắc:";

            // 
            // pnlColor
            // 
            this.pnlColor.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.pnlColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlColor.Location = new System.Drawing.Point(20, 95);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(100, 30);
            this.pnlColor.Click += new System.EventHandler(this.pnlColor_Click);

            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(20, 145);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.Text = "💾 Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(130, 145);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.Text = "❌ Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // 
            // frmTagEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.lblTenTag);
            this.Controls.Add(this.txtTenTag);
            this.Controls.Add(this.lblMau);
            this.Controls.Add(this.pnlColor);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTagEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tag";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTenTag;
        private System.Windows.Forms.TextBox txtTenTag;
        private System.Windows.Forms.Label lblMau;
        private System.Windows.Forms.Panel pnlColor;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}

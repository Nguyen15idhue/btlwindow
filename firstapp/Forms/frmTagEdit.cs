using System;
using System.Drawing;
using System.Windows.Forms;

namespace btlwindow
{
    public partial class frmTagEdit : Form
    {
        private TagModel editingTag;
        private string selectedColor = "#3498db"; // Default blue

        public frmTagEdit()
        {
            InitializeComponent();
            this.Text = "Thêm Tag mới";
            pnlColor.BackColor = ColorTranslator.FromHtml(selectedColor);
        }

        public frmTagEdit(TagModel tag)
        {
            InitializeComponent();
            this.Text = "Chỉnh sửa Tag";
            editingTag = tag;
            
            // Load existing data
            txtTenTag.Text = tag.TenTag;
            selectedColor = tag.MauSac;
            pnlColor.BackColor = ColorTranslator.FromHtml(selectedColor);
        }

        private void pnlColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = pnlColor.BackColor;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    pnlColor.BackColor = colorDialog.Color;
                    selectedColor = ColorTranslator.ToHtml(colorDialog.Color);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenTag.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tag!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTag.Focus();
                return;
            }

            bool success;
            if (editingTag == null)
            {
                // Add new tag
                success = TagRepository.AddTag(txtTenTag.Text.Trim(), selectedColor);
            }
            else
            {
                // Update existing tag
                success = TagRepository.UpdateTag(editingTag.Id, txtTenTag.Text.Trim(), selectedColor);
            }

            if (success)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

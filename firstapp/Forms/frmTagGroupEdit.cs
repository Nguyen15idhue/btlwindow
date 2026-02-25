using System;
using System.Drawing;
using System.Windows.Forms;

namespace btlwindow
{
    public partial class frmTagGroupEdit : Form
    {
        private TagGroupModel editingGroup = null;
        private bool isEditMode = false;

        public frmTagGroupEdit()
        {
            InitializeComponent();
            isEditMode = false;
            this.Text = "Them nhom moi";
        }

        public frmTagGroupEdit(TagGroupModel group)
        {
            InitializeComponent();
            isEditMode = true;
            editingGroup = group;
            this.Text = "Chinh sua nhom";
            txtTenNhom.Text = group.TenNhom;
            txtMoTa.Text = group.MoTa;
            pnlColor.BackColor = ColorTranslator.FromHtml(group.MauSac);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNhom.Text))
            {
                MessageBox.Show("Vui long nhap ten nhom!", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string colorHex = ColorTranslator.ToHtml(pnlColor.BackColor);
            bool success;

            if (isEditMode)
            {
                success = TagGroupRepository.UpdateTagGroup(editingGroup.Id, txtTenNhom.Text, colorHex, txtMoTa.Text);
            }
            else
            {
                success = TagGroupRepository.AddTagGroup(txtTenNhom.Text, colorHex, txtMoTa.Text);
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

        private void pnlColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                cd.Color = pnlColor.BackColor;
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    pnlColor.BackColor = cd.Color;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace btlwindow
{
    public partial class ucTagGroup : UserControl
    {
        public event EventHandler OnTagGroupChanged;

        public ucTagGroup()
        {
            InitializeComponent();
        }

        private void ucTagGroup_Load(object sender, EventArgs e)
        {
            LoadTagGroups();
        }

        public void LoadTagGroups()
        {
            flpTagGroups.Controls.Clear();
            List<TagGroupModel> groups = TagGroupRepository.GetAllTagGroups();
            foreach (var group in groups)
            {
                Panel pnl = CreateTagGroupPanel(group);
                flpTagGroups.Controls.Add(pnl);
            }
        }

        private Panel CreateTagGroupPanel(TagGroupModel group)
        {
            Panel pnl = new Panel();
            pnl.Size = new Size(flpTagGroups.Width - 30, 60);
            pnl.BackColor = Color.White;
            pnl.Margin = new Padding(5);
            pnl.Tag = group;

            Panel colorBar = new Panel();
            colorBar.Size = new Size(5, pnl.Height);
            colorBar.Dock = DockStyle.Left;
            try { colorBar.BackColor = ColorTranslator.FromHtml(group.MauSac); }
            catch { colorBar.BackColor = AppTheme.PrimaryColor; }
            pnl.Controls.Add(colorBar);

            Label lblName = new Label();
            lblName.Text = group.TenNhom;
            lblName.Font = AppTheme.FontBodyBold;
            lblName.Location = new Point(15, 10);
            lblName.AutoSize = true;
            pnl.Controls.Add(lblName);

            Label lblDesc = new Label();
            lblDesc.Text = group.MoTa;
            lblDesc.Font = AppTheme.FontSmall;
            lblDesc.ForeColor = AppTheme.TextSecondary;
            lblDesc.Location = new Point(15, 30);
            lblDesc.AutoSize = true;
            pnl.Controls.Add(lblDesc);

            Button btnEdit = new Button();
            btnEdit.Text = "Sua";
            btnEdit.Size = new Size(50, 25);
            btnEdit.Location = new Point(pnl.Width - 120, 18);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.BackColor = AppTheme.PrimaryColor;
            btnEdit.ForeColor = Color.White;
            btnEdit.Click += (s, e) => EditTagGroup(group);
            pnl.Controls.Add(btnEdit);

            Button btnDelete = new Button();
            btnDelete.Text = "Xoa";
            btnDelete.Size = new Size(50, 25);
            btnDelete.Location = new Point(pnl.Width - 60, 18);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.BackColor = AppTheme.DangerColor;
            btnDelete.ForeColor = Color.White;
            btnDelete.Click += (s, e) => DeleteTagGroup(group);
            pnl.Controls.Add(btnDelete);

            return pnl;
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            using (frmTagGroupEdit frm = new frmTagGroupEdit())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadTagGroups();
                    OnTagGroupChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void EditTagGroup(TagGroupModel group)
        {
            using (frmTagGroupEdit frm = new frmTagGroupEdit(group))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadTagGroups();
                    OnTagGroupChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void DeleteTagGroup(TagGroupModel group)
        {
            if (MessageBox.Show("Ban co chac muon xoa nhom '" + group.TenNhom + "'?", "Xac nhan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (TagGroupRepository.DeleteTagGroup(group.Id))
                {
                    LoadTagGroups();
                    OnTagGroupChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
}
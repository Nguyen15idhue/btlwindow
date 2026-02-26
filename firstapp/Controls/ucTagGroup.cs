using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace btlwindow
{
    public partial class ucTagGroup : UserControl
    {
        public event EventHandler OnTagGroupChanged;
        private List<TagModel> allTags = new List<TagModel>();
        private List<TagGroupModel> allGroups = new List<TagGroupModel>();

        public ucTagGroup()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            // Title
            lblTitle.Font = AppTheme.FontTitle;
            lblTitle.ForeColor = AppTheme.PrimaryColor;

            // Subtitle
            lblSubtitle.Font = AppTheme.FontBody;
            lblSubtitle.ForeColor = AppTheme.TextSecondary;

            // Apply theme to Tags DataGridView
            ApplyDataGridViewTheme(dgvTags);

            // Apply theme to Groups DataGridView
            ApplyDataGridViewTheme(dgvGroups);

            // Apply button styles
            StyleHelper.ApplySuccessButton(btnAddTag);
            StyleHelper.ApplyPrimaryButton(btnEditTag);
            StyleHelper.ApplyDangerButton(btnDeleteTag);
            StyleHelper.ApplySecondaryButton(btnRefreshTags);

            StyleHelper.ApplySuccessButton(btnAddGroup);
            StyleHelper.ApplyPrimaryButton(btnEditGroup);
            StyleHelper.ApplyDangerButton(btnDeleteGroup);
            StyleHelper.ApplySecondaryButton(btnRefreshGroups);
        }

        private void ApplyDataGridViewTheme(DataGridView dgv)
        {
            dgv.BackgroundColor = AppTheme.BackgroundWhite;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = AppTheme.PrimaryColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = AppTheme.TextWhite;
            dgv.ColumnHeadersDefaultCellStyle.Font = AppTheme.FontBodyBold;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = AppTheme.PrimaryDark;
            dgv.ColumnHeadersHeight = 40;
            dgv.EnableHeadersVisualStyles = false;
            dgv.DefaultCellStyle.SelectionBackColor = AppTheme.PrimaryLight;
            dgv.DefaultCellStyle.SelectionForeColor = AppTheme.TextWhite;
            dgv.DefaultCellStyle.Font = AppTheme.FontBody;
            dgv.DefaultCellStyle.Padding = new Padding(5);
            dgv.RowTemplate.Height = 35;
            dgv.GridColor = AppTheme.BorderLight;
        }

        private void ucTagGroup_Load(object sender, EventArgs e)
        {
            LoadTags();
            LoadGroups();
        }

        // ==================== TAGS SECTION ====================

        private void LoadTags()
        {
            try
            {
                dgvTags.Rows.Clear();
                allTags = TagGroupRepository.GetAllTags();

                foreach (var tag in allTags)
                {
                    int idx = dgvTags.Rows.Add(
                        tag.Id,
                        tag.TenTag,
                        tag.MauSac,
                        tag.NgayTao != DateTime.MinValue ? tag.NgayTao.ToString("dd/MM/yyyy") : ""
                    );
                    dgvTags.Rows[idx].Tag = tag;

                    // Color the color column cell
                    try
                    {
                        Color color = ColorTranslator.FromHtml(tag.MauSac);
                        dgvTags.Rows[idx].Cells[2].Style.BackColor = color;
                        dgvTags.Rows[idx].Cells[2].Style.ForeColor = GetContrastColor(color);
                    }
                    catch { }
                }

                lblTotalTags.Text = allTags.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách tags: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddTag_Click(object sender, EventArgs e)
        {
            using (frmTagEdit frm = new frmTagEdit())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadTags();
                    OnTagGroupChanged?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show("Đã thêm tag thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEditTag_Click(object sender, EventArgs e)
        {
            if (dgvTags.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tag cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TagModel tag = dgvTags.SelectedRows[0].Tag as TagModel;
            if (tag == null) return;

            using (frmTagEdit frm = new frmTagEdit(tag))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadTags();
                    OnTagGroupChanged?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show("Đã cập nhật tag thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDeleteTag_Click(object sender, EventArgs e)
        {
            if (dgvTags.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tag cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TagModel tag = dgvTags.SelectedRows[0].Tag as TagModel;
            if (tag == null) return;

            DialogResult result = MessageBox.Show(
                $"⚠️ CẢNH BÁO: Bạn có chắc chắn muốn xóa tag '{tag.TenTag}'?\n\n" +
                "Hành động này không thể hoàn tác!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                if (TagRepository.DeleteTag(tag.Id))
                {
                    LoadTags();
                    OnTagGroupChanged?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show("Đã xóa tag thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnRefreshTags_Click(object sender, EventArgs e)
        {
            LoadTags();
            MessageBox.Show("Đã làm mới danh sách tags!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ==================== GROUPS SECTION ====================

        private void LoadGroups()
        {
            try
            {
                dgvGroups.Rows.Clear();
                allGroups = TagGroupRepository.GetAllTagGroups();

                foreach (var group in allGroups)
                {
                    int idx = dgvGroups.Rows.Add(
                        group.Id,
                        group.TenNhom,
                        group.MauSac,
                        group.MoTa ?? ""
                    );
                    dgvGroups.Rows[idx].Tag = group;

                    // Color the color column cell
                    try
                    {
                        Color color = ColorTranslator.FromHtml(group.MauSac);
                        dgvGroups.Rows[idx].Cells[2].Style.BackColor = color;
                        dgvGroups.Rows[idx].Cells[2].Style.ForeColor = GetContrastColor(color);
                    }
                    catch { }
                }

                lblTotalGroups.Text = allGroups.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhóm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            using (frmTagGroupEdit frm = new frmTagGroupEdit())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadGroups();
                    OnTagGroupChanged?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show("Đã thêm nhóm thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEditGroup_Click(object sender, EventArgs e)
        {
            if (dgvGroups.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhóm cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TagGroupModel group = dgvGroups.SelectedRows[0].Tag as TagGroupModel;
            if (group == null) return;

            using (frmTagGroupEdit frm = new frmTagGroupEdit(group))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadGroups();
                    OnTagGroupChanged?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show("Đã cập nhật nhóm thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            if (dgvGroups.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhóm cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TagGroupModel group = dgvGroups.SelectedRows[0].Tag as TagGroupModel;
            if (group == null) return;

            DialogResult result = MessageBox.Show(
                $"⚠️ CẢNH BÁO: Bạn có chắc chắn muốn xóa nhóm '{group.TenNhom}'?\n\n" +
                "Hành động này không thể hoàn tác!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                if (TagGroupRepository.DeleteTagGroup(group.Id))
                {
                    LoadGroups();
                    OnTagGroupChanged?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show("Đã xóa nhóm thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnRefreshGroups_Click(object sender, EventArgs e)
        {
            LoadGroups();
            MessageBox.Show("Đã làm mới danh sách nhóm!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ==================== HELPER METHODS ====================

        private Color GetContrastColor(Color color)
        {
            // Calculate luminance
            double luminance = (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;
            return luminance > 0.5 ? Color.Black : Color.White;
        }

        // Public method to reload both tabs
        public void LoadTagGroups()
        {
            LoadTags();
            LoadGroups();
        }
    }
}
using System.Drawing;
using System.Windows.Forms;

namespace btlwindow
{
    public static class StyleHelper
    {
        public static void ApplyFormStyle(Form form)
        {
            form.BackColor = AppTheme.BackgroundLight;
            form.Font = new Font(AppTheme.FontFamily, 9F);
        }

        public static void ApplyPrimaryButton(Button btn)
        {
            btn.BackColor = AppTheme.PrimaryColor;
            btn.ForeColor = AppTheme.TextWhite;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Font = AppTheme.FontBodyBold;
        }

        public static void ApplySecondaryButton(Button btn)
        {
            btn.BackColor = AppTheme.SecondaryColor;
            btn.ForeColor = AppTheme.TextWhite;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Font = AppTheme.FontBodyBold;
        }

        public static void ApplyDangerButton(Button btn)
        {
            btn.BackColor = AppTheme.DangerColor;
            btn.ForeColor = AppTheme.TextWhite;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Font = AppTheme.FontBodyBold;
        }

        public static void ApplySuccessButton(Button btn)
        {
            btn.BackColor = AppTheme.SecondaryColor;
            btn.ForeColor = AppTheme.TextWhite;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Font = AppTheme.FontBodyBold;
        }

        public static void ApplySidebarButton(Button btn, bool isActive = false)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.ForeColor = AppTheme.TextWhite;
            btn.Cursor = Cursors.Hand;
            btn.Font = AppTheme.FontBody;
            btn.BackColor = isActive ? AppTheme.PrimaryColor : AppTheme.BackgroundSidebar;
        }

        public static void ApplyDialogStyle(Form form)
        {
            form.BackColor = AppTheme.BackgroundWhite;
            form.Font = new Font(AppTheme.FontFamily, 9F);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.StartPosition = FormStartPosition.CenterParent;
        }
    }
}
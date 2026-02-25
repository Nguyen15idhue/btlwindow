using System.Drawing;

namespace btlwindow
{
    public static class AppTheme
    {
        public static Color PrimaryColor = ColorTranslator.FromHtml("#3498db");
        public static Color PrimaryDark = ColorTranslator.FromHtml("#2980b9");
        public static Color SecondaryColor = ColorTranslator.FromHtml("#2ecc71");
        public static Color DangerColor = ColorTranslator.FromHtml("#e74c3c");
        public static Color WarningColor = ColorTranslator.FromHtml("#f39c12");
        public static Color InfoColor = ColorTranslator.FromHtml("#9b59b6");

        public static Color BackgroundLight = ColorTranslator.FromHtml("#f5f6fa");
        public static Color BackgroundWhite = Color.White;
        public static Color BackgroundSidebar = ColorTranslator.FromHtml("#2c3e50");
        public static Color BackgroundCard = Color.White;

        public static Color TextPrimary = ColorTranslator.FromHtml("#2c3e50");
        public static Color TextSecondary = ColorTranslator.FromHtml("#7f8c8d");
        public static Color TextWhite = Color.White;
        public static Color TextMuted = ColorTranslator.FromHtml("#95a5a6");

        public static Color BorderLight = ColorTranslator.FromHtml("#dcdde1");
        public static Color BorderDark = ColorTranslator.FromHtml("#bdc3c7");

        public static Color PriorityHigh = ColorTranslator.FromHtml("#e74c3c");
        public static Color PriorityMedium = ColorTranslator.FromHtml("#f39c12");
        public static Color PriorityLow = ColorTranslator.FromHtml("#27ae60");

        public static Color StatusTodo = ColorTranslator.FromHtml("#3498db");
        public static Color StatusDoing = ColorTranslator.FromHtml("#f39c12");
        public static Color StatusDone = ColorTranslator.FromHtml("#27ae60");

        public static Color SuccessColor = ColorTranslator.FromHtml("#27ae60");
        public static Color PrimaryLight = ColorTranslator.FromHtml("#5dade2");

        public static string FontFamily = "Segoe UI";
        public static Font FontTitle = new Font(FontFamily, 16F, FontStyle.Bold);
        public static Font FontSubtitle = new Font(FontFamily, 12F, FontStyle.Bold);
        public static Font FontBody = new Font(FontFamily, 10F, FontStyle.Regular);
        public static Font FontBodyBold = new Font(FontFamily, 10F, FontStyle.Bold);
        public static Font FontSmall = new Font(FontFamily, 8F, FontStyle.Regular);
        public static Font FontSmallBold = new Font(FontFamily, 8F, FontStyle.Bold);

        public static Color GetPriorityColor(string priority)
        {
            switch (priority)
            {
                case "Cao": return PriorityHigh;
                case "Trung binh": return PriorityMedium;
                case "Thap": return PriorityLow;
                default: return PriorityMedium;
            }
        }

        public static Color GetStatusColor(string status)
        {
            switch (status)
            {
                case "Todo": return StatusTodo;
                case "Doing": return StatusDoing;
                case "Done": return StatusDone;
                default: return StatusTodo;
            }
        }

        public static Color GetColumnColor(string status)
        {
            return GetStatusColor(status);
        }
    }
}
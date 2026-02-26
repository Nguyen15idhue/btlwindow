using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using btlwindow.Forms;

namespace btlwindow.Controls
{
    /// <summary>
    /// Floating button hiển thị ở góc dưới bên phải màn hình
    /// Click để mở chat window
    /// </summary>
    public class FloatingChatButton : Button
    {
        private ChatForm chatForm;
        private Form parentForm;
        private bool isAnimating = false;
        private int pulseSize = 0;
        private Timer pulseTimer;

        public FloatingChatButton(Form parent)
        {
            parentForm = parent;
            InitializeButton();
            SetupPulseAnimation();
        }

        /// <summary>
        /// Khởi tạo button với style floating
        /// </summary>
        private void InitializeButton()
        {
            // Size và vị trí
            this.Size = new Size(60, 60);
            this.BackColor = Color.FromArgb(52, 152, 219);
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.Text = "🤖";
            this.Cursor = Cursors.Hand;
            
            // Style
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            
            // Shadow effect
            this.FlatAppearance.MouseDownBackColor = Color.FromArgb(41, 128, 185);
            this.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);

            // Events
            this.Click += FloatingChatButton_Click;
            this.Paint += FloatingChatButton_Paint;
            this.MouseEnter += FloatingChatButton_MouseEnter;
            this.MouseLeave += FloatingChatButton_MouseLeave;

            // Position at bottom-right
            PositionButton();

            // Handle parent resize
            if (parentForm != null)
            {
                parentForm.Resize += (s, e) => PositionButton();
            }
        }

        /// <summary>
        /// Setup animation pulse effect
        /// </summary>
        private void SetupPulseAnimation()
        {
            pulseTimer = new Timer();
            pulseTimer.Interval = 50; // 50ms
            pulseTimer.Tick += (s, e) =>
            {
                pulseSize++;
                if (pulseSize > 10)
                {
                    pulseSize = 0;
                }
                this.Invalidate(); // Trigger repaint
            };
            pulseTimer.Start();
        }

        /// <summary>
        /// Position button ở góc dưới bên phải
        /// </summary>
        private void PositionButton()
        {
            if (parentForm != null && parentForm.ClientSize.Width > 0)
            {
                int margin = 20;
                this.Location = new Point(
                    parentForm.ClientSize.Width - this.Width - margin,
                    parentForm.ClientSize.Height - this.Height - margin
                );
            }
        }

        /// <summary>
        /// Custom paint - vẽ button tròn với shadow
        /// </summary>
        private void FloatingChatButton_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw pulse effect (outer circle)
            using (Pen pulsePen = new Pen(Color.FromArgb(100, 52, 152, 219), 2))
            {
                int pulseOffset = pulseSize / 2;
                Rectangle pulseRect = new Rectangle(
                    -pulseOffset, 
                    -pulseOffset, 
                    this.Width + pulseOffset * 2, 
                    this.Height + pulseOffset * 2
                );
                e.Graphics.DrawEllipse(pulsePen, pulseRect);
            }

            // Draw shadow
            using (GraphicsPath shadowPath = new GraphicsPath())
            {
                shadowPath.AddEllipse(3, 3, this.Width - 6, this.Height - 6);
                using (PathGradientBrush shadowBrush = new PathGradientBrush(shadowPath))
                {
                    shadowBrush.CenterColor = Color.FromArgb(50, 0, 0, 0);
                    shadowBrush.SurroundColors = new Color[] { Color.Transparent };
                    e.Graphics.FillPath(shadowBrush, shadowPath);
                }
            }

            // Draw main circle
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, this.Width - 1, this.Height - 1);
                this.Region = new Region(path);

                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }

            // Draw text (emoji)
            TextRenderer.DrawText(
                e.Graphics,
                this.Text,
                this.Font,
                new Rectangle(0, 0, this.Width, this.Height),
                this.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }

        /// <summary>
        /// Hover effect
        /// </summary>
        private void FloatingChatButton_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(41, 128, 185);
        }

        /// <summary>
        /// Unhover effect
        /// </summary>
        private void FloatingChatButton_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(52, 152, 219);
        }

        /// <summary>
        /// Xử lý click - mở/đóng chat window
        /// </summary>
        private void FloatingChatButton_Click(object sender, EventArgs e)
        {
            if (chatForm == null || chatForm.IsDisposed)
            {
                OpenChatWindow();
            }
            else
            {
                CloseChatWindow();
            }
        }

        /// <summary>
        /// Mở chat window
        /// </summary>
        private void OpenChatWindow()
        {
            chatForm = new ChatForm();
            
            // Position chat window above the button
            int chatWidth = 450;
            int chatHeight = 600;
            int margin = 10;

            Point buttonLocationOnScreen = parentForm.PointToScreen(this.Location);
            
            chatForm.StartPosition = FormStartPosition.Manual;
            chatForm.Location = new Point(
                buttonLocationOnScreen.X - chatWidth + this.Width,
                buttonLocationOnScreen.Y - chatHeight - margin
            );

            chatForm.Size = new Size(chatWidth, chatHeight);
            
            // Add drop shadow effect
            chatForm.FormBorderStyle = FormBorderStyle.None;
            
            // Show chat
            chatForm.Show(parentForm);
            chatForm.FormClosed += (s, e) => chatForm = null;

            // Animate button
            AnimateButtonClick();
        }

        /// <summary>
        /// Đóng chat window
        /// </summary>
        private void CloseChatWindow()
        {
            if (chatForm != null && !chatForm.IsDisposed)
            {
                chatForm.Close();
                chatForm = null;
            }
        }

        /// <summary>
        /// Animation khi click button
        /// </summary>
        private void AnimateButtonClick()
        {
            if (isAnimating) return;

            isAnimating = true;
            int originalWidth = this.Width;
            int originalHeight = this.Height;
            Point originalLocation = this.Location;

            Timer animTimer = new Timer();
            animTimer.Interval = 10;
            int step = 0;

            animTimer.Tick += (s, e) =>
            {
                step++;
                
                if (step <= 5) // Shrink
                {
                    int newSize = originalWidth - step * 2;
                    this.Size = new Size(newSize, newSize);
                    this.Location = new Point(
                        originalLocation.X + step,
                        originalLocation.Y + step
                    );
                }
                else if (step <= 10) // Grow back
                {
                    int offset = 10 - step;
                    int newSize = originalWidth - offset * 2;
                    this.Size = new Size(newSize, newSize);
                    this.Location = new Point(
                        originalLocation.X + offset,
                        originalLocation.Y + offset
                    );
                }
                else // Done
                {
                    this.Size = new Size(originalWidth, originalHeight);
                    this.Location = originalLocation;
                    animTimer.Stop();
                    animTimer.Dispose();
                    isAnimating = false;
                }
            };

            animTimer.Start();
        }

        /// <summary>
        /// Cleanup khi dispose
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pulseTimer?.Stop();
                pulseTimer?.Dispose();
                chatForm?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

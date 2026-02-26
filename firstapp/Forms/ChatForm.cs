using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using btlwindow.Models;
using btlwindow.Services;

namespace btlwindow.Forms
{
    /// <summary>
    /// Form chat window - giao diện chat với AI
    /// </summary>
    public partial class ChatForm : Form
    {
        private List<ChatMessage> chatHistory = new List<ChatMessage>();
        private bool isProcessing = false;

        public ChatForm()
        {
            InitializeComponent();
            ApplyTheme();
            AddWelcomeMessage();
        }

        /// <summary>
        /// Áp dụng theme cho form
        /// </summary>
        private void ApplyTheme()
        {
            this.BackColor = Color.FromArgb(236, 240, 241);
            
            // Header
            pnlHeader.BackColor = AppTheme.PrimaryColor;
            lblHeaderTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;

            // Chat area
            pnlChatContainer.BackColor = Color.White;

            // Input area
            txtInput.Font = new Font("Segoe UI", 10F);
            btnSend.BackColor = AppTheme.SuccessColor;
            btnSend.ForeColor = Color.White;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.FlatAppearance.BorderSize = 0;

            btnClear.BackColor = Color.FromArgb(149, 165, 166);
            btnClear.ForeColor = Color.White;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.FlatAppearance.BorderSize = 0;

            btnClose.BackColor = Color.FromArgb(192, 57, 43);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
        }

        /// <summary>
        /// Thêm tin nhắn chào mừng
        /// </summary>
        private void AddWelcomeMessage()
        {
            string welcome = @"👋 Xin chào! Tôi là AI Assistant của hệ thống Kanban.

Tôi có thể giúp bạn:

📊 Thống kê công việc theo trạng thái, độ ưu tiên
🔍 Tìm kiếm công việc cụ thể
👥 Xem thông tin người dùng và phân bổ công việc
📈 Phân tích tiến độ và xu hướng
💡 Gợi ý cải thiện quy trình làm việc

Hãy hỏi tôi bất kỳ điều gì về công việc trong hệ thống! 🚀

Ví dụ:
• 'Có bao nhiêu công việc đang làm?'
• 'Ai có nhiều công việc nhất?'
• 'Công việc nào sắp quá hạn?'
• 'Thống kê theo độ ưu tiên'";

            AddMessageToUI("assistant", welcome);
        }

        /// <summary>
        /// Xử lý khi click nút Send
        /// </summary>
        private async void btnSend_Click(object sender, EventArgs e)
        {
            await SendMessageAsync();
        }

        /// <summary>
        /// Xử lý khi nhấn Enter trong textbox
        /// </summary>
        private async void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                await SendMessageAsync();
            }
        }

        /// <summary>
        /// Gửi tin nhắn và nhận phản hồi từ AI
        /// </summary>
        private async Task SendMessageAsync()
        {
            string userMessage = txtInput.Text.Trim();

            // Validate input
            if (string.IsNullOrWhiteSpace(userMessage))
                return;

            if (isProcessing)
            {
                MessageBox.Show("Vui lòng đợi AI trả lời câu hỏi trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Set processing state
            isProcessing = true;
            SetUIProcessingState(true);

            // Add user message to UI
            AddMessageToUI("user", userMessage);
            txtInput.Clear();

            try
            {
                // Step 1: Lấy context từ database (RAG)
                string context = await DatabaseContextService.GetRelevantContextAsync(userMessage);

                // Step 2: Gọi Gemini AI với context
                string aiResponse = await GeminiChatService.AskAsync(userMessage, context);

                // Step 3: Hiển thị response
                AddMessageToUI("assistant", aiResponse);
            }
            catch (Exception ex)
            {
                AddMessageToUI("assistant", 
                    $"❌ Đã xảy ra lỗi: {ex.Message}\n\n" +
                    $"Vui lòng thử lại hoặc liên hệ quản trị viên.");
            }
            finally
            {
                // Reset processing state
                isProcessing = false;
                SetUIProcessingState(false);
                txtInput.Focus();
            }
        }

        /// <summary>
        /// Thêm tin nhắn vào UI (chat bubble)
        /// </summary>
        private void AddMessageToUI(string role, string content)
        {
            // Save to history
            var message = new ChatMessage(role, content);
            chatHistory.Add(message);

            // Create message container panel
            Panel messageContainer = new Panel
            {
                Width = pnlChatContainer.Width - 40,
                AutoSize = true,
                Padding = new Padding(10, 5, 10, 5),
                Margin = new Padding(0, 0, 0, 10)
            };

            // Create message bubble
            Panel messageBubble = new Panel
            {
                AutoSize = true,
                MaximumSize = new Size(messageContainer.Width - 100, 0),
                Padding = new Padding(15, 10, 15, 10),
                Margin = new Padding(0)
            };

            // Style bubble based on role
            if (role == "user")
            {
                messageBubble.BackColor = Color.FromArgb(52, 152, 219);
                messageBubble.Location = new Point(messageContainer.Width - messageBubble.Width - 20, 0);
            }
            else
            {
                messageBubble.BackColor = Color.FromArgb(236, 240, 241);
                messageBubble.Location = new Point(10, 0);
            }

            // Create message label
            Label lblMessage = new Label
            {
                Text = content,
                AutoSize = true,
                MaximumSize = new Size(messageBubble.MaximumSize.Width - 30, 0),
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = role == "user" ? Color.White : Color.Black,
                Padding = new Padding(0)
            };

            // Create timestamp label
            Label lblTime = new Label
            {
                Text = message.FormattedTime,
                AutoSize = true,
                Font = new Font("Segoe UI", 7.5F),
                ForeColor = role == "user" ? Color.FromArgb(230, 230, 230) : Color.Gray,
                Padding = new Padding(0, 5, 0, 0)
            };

            // Add controls to bubble
            messageBubble.Controls.Add(lblMessage);
            messageBubble.Controls.Add(lblTime);

            // Position timestamp
            lblTime.Top = lblMessage.Bottom;

            // Adjust bubble size
            messageBubble.Height = lblTime.Bottom + 10;

            // Adjust container size
            messageContainer.Height = messageBubble.Height + 10;

            // Position bubble in container (align right for user, left for AI)
            if (role == "user")
            {
                messageBubble.Left = messageContainer.Width - messageBubble.Width - 10;
            }

            // Add bubble to container
            messageContainer.Controls.Add(messageBubble);

            // Add container to chat panel
            pnlChatContainer.Controls.Add(messageContainer);

            // Scroll to bottom
            pnlChatContainer.ScrollControlIntoView(messageContainer);
            pnlChatContainer.VerticalScroll.Value = pnlChatContainer.VerticalScroll.Maximum;
        }

        /// <summary>
        /// Set UI state khi đang xử lý
        /// </summary>
        private void SetUIProcessingState(bool processing)
        {
            if (processing)
            {
                btnSend.Text = "⏳";
                btnSend.Enabled = false;
                txtInput.Enabled = false;
                lblHeaderTitle.Text = "🤖 AI đang suy nghĩ...";
                Cursor = Cursors.WaitCursor;
            }
            else
            {
                btnSend.Text = "📤";
                btnSend.Enabled = true;
                txtInput.Enabled = true;
                lblHeaderTitle.Text = "🤖 AI Assistant - Kanban";
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Xóa lịch sử chat
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn có chắc muốn xóa toàn bộ lịch sử chat?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                pnlChatContainer.Controls.Clear();
                chatHistory.Clear();
                AddWelcomeMessage();
            }
        }

        /// <summary>
        /// Đóng form
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Xử lý khi form load
        /// </summary>
        private void ChatForm_Load(object sender, EventArgs e)
        {
            txtInput.Focus();
        }
    }
}

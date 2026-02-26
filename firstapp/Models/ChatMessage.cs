using System;

namespace btlwindow.Models
{
    /// <summary>
    /// Model đại diện cho một tin nhắn trong chat
    /// </summary>
    public class ChatMessage
    {
        /// <summary>
        /// Role: "user" (người dùng) hoặc "assistant" (AI)
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Nội dung tin nhắn
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Thời gian gửi tin nhắn
        /// </summary>
        public DateTime Timestamp { get; set; }

        public ChatMessage(string role, string content)
        {
            Role = role;
            Content = content;
            Timestamp = DateTime.Now;
        }

        /// <summary>
        /// Kiểm tra xem tin nhắn có phải của user không
        /// </summary>
        public bool IsUserMessage => Role == "user";

        /// <summary>
        /// Format thời gian hiển thị
        /// </summary>
        public string FormattedTime => Timestamp.ToString("HH:mm");
    }
}

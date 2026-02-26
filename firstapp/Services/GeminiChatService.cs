using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace btlwindow.Services
{
    /// <summary>
    /// Service tích hợp Google Gemini AI API
    /// Xử lý giao tiếp với Gemini để trả lời câu hỏi
    /// </summary>
    public class GeminiChatService
    {
        // ⚠️ QUAN TRỌNG: Thay YOUR_API_KEY_HERE bằng API key thật từ Google AI Studio
        // Lấy miễn phí tại: https://makersuite.google.com/app/apikey
        private const string GEMINI_API_KEY = "AIzaSyDyvkrEOH52hLLMwiReZgX98cRRzTzz4W0";
        private const string API_URL = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent";

        private static readonly HttpClient httpClient = new HttpClient();

        /// <summary>
        /// System prompt hướng dẫn AI cách trả lời
        /// </summary>
        private const string SYSTEM_PROMPT = @"Bạn là AI Assistant thông minh cho hệ thống quản lý công việc Kanban.

NHIỆM VỤ CỦA BẠN:
- Trả lời câu hỏi của người dùng dựa HOÀN TOÀN trên dữ liệu được cung cấp
- Phân tích và tổng hợp thông tin một cách chính xác
- Đưa ra insights và gợi ý hữu ích

QUY TẮC QUAN TRỌNG:
✓ CHỈ sử dụng dữ liệu trong phần CONTEXT được cung cấp
✓ Nếu không có dữ liệu phù hợp, hãy nói rõ: 'Tôi không tìm thấy thông tin về điều này trong hệ thống'
✓ Trả lời bằng tiếng Việt, ngắn gọn, súc tích
✓ Sử dụng emoji phù hợp để dễ đọc
✓ Nếu có số liệu, hãy tính toán chính xác
✓ Đưa ra gợi ý thực tế để cải thiện công việc

ĐỊNH DẠNG TRẢ LỜI:
- Sử dụng bullet points khi liệt kê
- Làm nổi bật các con số quan trọng
- Kết thúc bằng gợi ý hoặc action items nếu phù hợp

Hãy luôn thân thiện, chuyên nghiệp và hữu ích!";

        /// <summary>
        /// Gửi câu hỏi tới Gemini AI và nhận câu trả lời
        /// </summary>
        /// <param name="userQuestion">Câu hỏi của người dùng</param>
        /// <param name="databaseContext">Context dữ liệu từ database (RAG)</param>
        /// <returns>Câu trả lời từ AI</returns>
        public static async Task<string> AskAsync(string userQuestion, string databaseContext)
        {
            try
            {
                // Kiểm tra input
                if (string.IsNullOrWhiteSpace(userQuestion))
                {
                    return "❌ Vui lòng nhập câu hỏi!";
                }

                // Kiểm tra API key
                if (GEMINI_API_KEY == "YOUR_API_KEY_HERE")
                {
                    return "⚠️ Chưa cấu hình API Key!\n\n" +
                        "Vui lòng:\n" +
                        "1. Truy cập: https://makersuite.google.com/app/apikey\n" +
                        "2. Tạo API Key miễn phí\n" +
                        "3. Copy API Key vào file GeminiChatService.cs\n" +
                        "4. Thay thế 'YOUR_API_KEY_HERE' bằng API Key của bạn";
                }

                // Xây dựng prompt đầy đủ
                string fullPrompt = BuildFullPrompt(userQuestion, databaseContext);

                // Tạo request body theo Gemini REST API format
                var requestBody = new
                {
                    contents = new[]
                    {
                        new
                        {
                            parts = new[]
                            {
                                new { text = fullPrompt }
                            }
                        }
                    },
                    generationConfig = new
                    {
                        temperature = 0.7,
                        maxOutputTokens = 2048,
                        topP = 0.95,
                        topK = 40
                    }
                };

                string jsonRequest = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                // Gọi Gemini API
                string url = $"{API_URL}?key={GEMINI_API_KEY}";
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    return $"❌ Lỗi API ({response.StatusCode}): {errorContent}\n\n" +
                           $"💡 Kiểm tra:\n" +
                           $"- API Key có chính xác không\n" +
                           $"- API Key đã được enable chưa\n" +
                           $"- Kết nối internet";
                }

                string jsonResponse = await response.Content.ReadAsStringAsync();

                // Parse JSON response
                using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
                {
                    JsonElement root = doc.RootElement;

                    if (root.TryGetProperty("candidates", out JsonElement candidates) &&
                        candidates.GetArrayLength() > 0)
                    {
                        JsonElement firstCandidate = candidates[0];

                        if (firstCandidate.TryGetProperty("content", out JsonElement contentObj) &&
                            contentObj.TryGetProperty("parts", out JsonElement parts) &&
                            parts.GetArrayLength() > 0)
                        {
                            JsonElement firstPart = parts[0];

                            if (firstPart.TryGetProperty("text", out JsonElement textElement))
                            {
                                string aiResponse = textElement.GetString();

                                if (!string.IsNullOrWhiteSpace(aiResponse))
                                {
                                    return aiResponse.Trim();
                                }
                            }
                        }
                    }
                }

                return "⚠️ AI không thể tạo câu trả lời cho câu hỏi này. Vui lòng thử lại với câu hỏi khác.";
            }
            catch (HttpRequestException ex)
            {
                return $"❌ Lỗi kết nối: {ex.Message}\n\n" +
                       $"💡 Kiểm tra kết nối internet và thử lại.";
            }
            catch (Exception ex)
            {
                return $"❌ Lỗi: {ex.Message}\n\n" +
                       $"💡 Vui lòng thử lại sau.";
            }
        }

        /// <summary>
        /// Xây dựng prompt đầy đủ gửi tới Gemini
        /// </summary>
        private static string BuildFullPrompt(string userQuestion, string databaseContext)
        {
            return $@"{SYSTEM_PROMPT}

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
📊 CONTEXT - DỮ LIỆU TỪ HỆ THỐNG:
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

{databaseContext}

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
❓ CÂU HỎI CỦA NGƯỜI DÙNG:
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

{userQuestion}

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

Hãy phân tích dữ liệu trên và trả lời câu hỏi một cách chính xác, hữu ích nhất!";
        }

        /// <summary>
        /// Phiên bản đồng bộ của AskAsync (cho WinForms blocking calls)
        /// </summary>
        public static string Ask(string userQuestion, string databaseContext)
        {
            return AskAsync(userQuestion, databaseContext).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Test connection tới Gemini API
        /// </summary>
        public static async Task<bool> TestConnectionAsync()
        {
            try
            {
                if (GEMINI_API_KEY == "YOUR_API_KEY_HERE")
                    return false;

                string response = await AskAsync("Hello", "Test context");
                return !response.StartsWith("❌");
            }
            catch
            {
                return false;
            }
        }
    }
}

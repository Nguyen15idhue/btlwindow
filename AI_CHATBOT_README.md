# 🤖 AI Chatbot Integration - Hướng dẫn sử dụng

## 📋 Tổng quan

Chatbot AI đã được tích hợp vào ứng dụng Kanban Task Manager với các tính năng:

- ✅ **RAG Architecture**: Truy xuất dữ liệu từ MySQL database
- ✅ **Google Gemini AI**: Sử dụng API miễn phí từ Google
- ✅ **Floating Button**: Button tròn ở góc dưới bên phải màn hình
- ✅ **Chat Window**: Giao diện chat hiện đại, dạng bubble
- ✅ **Async/Await**: Xử lý bất đồng bộ, không block UI
- ✅ **Clean Architecture**: Code có cấu trúc rõ ràng, dễ maintain

---

## 🚀 Cài đặt API Key

### Bước 1: Lấy API Key miễn phí

1. Truy cập: **https://makersuite.google.com/app/apikey**
2. Đăng nhập bằng tài khoản Google
3. Click **"Create API Key"**
4. Copy API Key

### Bước 2: Cấu hình trong code

Mở file: `firstapp/Services/GeminiChatService.cs`

Tìm dòng 17:
```csharp
private const string GEMINI_API_KEY = "YOUR_API_KEY_HERE";
```

Thay `YOUR_API_KEY_HERE` bằng API Key bạn vừa lấy:
```csharp
private const string GEMINI_API_KEY = "AIzaSyXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
```

### Bước 3: Build lại project

```bash
Build -> Rebuild Solution
```

---

## 💻 Cách sử dụng

### 1. Mở ứng dụng

Sau khi đăng nhập, bạn sẽ thấy **button tròn màu xanh 🤖** ở góc dưới bên phải.

### 2. Click vào button

- Cửa sổ chat sẽ hiện lên
- AI sẽ chào bạn và giới thiệu chức năng

### 3. Hỏi câu hỏi

Gõ câu hỏi vào ô input và nhấn **Enter** hoặc click nút **📤**

---

## 📝 Các câu hỏi mẫu

### Thống kê tổng quan
```
Có bao nhiêu công việc trong hệ thống?
Bao nhiêu công việc đang làm?
Có bao nhiêu công việc quá hạn?
```

### Tìm kiếm theo trạng thái
```
Những công việc nào đang Todo?
Công việc nào đã hoàn thành?
Liệt kê các công việc đang làm
```

### Phân tích người dùng
```
Ai có nhiều công việc nhất?
Người dùng nào là Manager?
Danh sách người dùng trong hệ thống
```

### Phân tích ưu tiên
```
Có bao nhiêu công việc ưu tiên cao?
Công việc ưu tiên cao nào chưa làm?
Thống kê theo độ ưu tiên
```

### Công việc quá hạn
```
Công việc nào sắp quá hạn?
Liệt kê các công việc quá hạn
Ai có công việc quá hạn?
```

### Gợi ý cải thiện
```
Tôi nên làm gì tiếp theo?
Công việc nào cần ưu tiên?
Đánh giá hiệu suất làm việc
```

---

## 🏗️ Kiến trúc hệ thống

```
User Question
    ↓
FloatingChatButton (Click)
    ↓
ChatForm (UI)
    ↓
DatabaseContextService.GetRelevantContext(question)
    ↓ (Query MySQL)
Database Context Text
    ↓
GeminiChatService.AskAsync(question, context)
    ↓ (HTTP POST to Gemini API)
Gemini AI Response
    ↓
Display in ChatForm
```

---

## 📂 Cấu trúc file

### Models
- `ChatMessage.cs` - Model cho tin nhắn chat

### Services
- `DatabaseContextService.cs` - RAG: Lấy context từ database
- `GeminiChatService.cs` - Gọi Gemini API

### Forms
- `ChatForm.cs` - UI chat window
- `ChatForm.Designer.cs` - Designer code

### Controls
- `FloatingChatButton.cs` - Floating button component

---

## ⚙️ Tuỳ chỉnh

### Thay đổi vị trí floating button

Edit `FloatingChatButton.cs`, method `PositionButton()`:
```csharp
private void PositionButton()
{
    int margin = 20; // Khoảng cách từ cạnh
    this.Location = new Point(
        parentForm.ClientSize.Width - this.Width - margin,  // X: từ phải
        parentForm.ClientSize.Height - this.Height - margin // Y: từ dưới
    );
}
```

### Thay đổi System Prompt

Edit `GeminiChatService.cs`, const `SYSTEM_PROMPT`:
```csharp
private const string SYSTEM_PROMPT = @"Nội dung prompt mới...";
```

### Thay đổi model AI

Edit `GeminiChatService.cs`, const `API_URL`:
```csharp
// Gemini 1.5 Flash (nhanh, miễn phí)
private const string API_URL = "https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent";

// Gemini 1.5 Pro (chậm hơn, thông minh hơn)
private const string API_URL = "https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-pro:generateContent";
```

### Thay đổi màu sắc chat

Edit `ChatForm.cs`, method `AddMessageToUI()`:
```csharp
if (role == "user")
{
    messageBubble.BackColor = Color.FromArgb(52, 152, 219); // Màu xanh user
}
else
{
    messageBubble.BackColor = Color.FromArgb(236, 240, 241); // Màu xám AI
}
```

---

## 🐛 Troubleshooting

### Lỗi: "Chưa cấu hình API Key"
**Nguyên nhân**: Chưa thay API Key trong code  
**Giải pháp**: Follow [Bước 2](#bước-2-cấu-hình-trong-code)

### Lỗi: "Lỗi API (403)"
**Nguyên nhân**: API Key không hợp lệ hoặc đã hết hạn  
**Giải pháp**:  
- Kiểm tra API Key có đúng không
- Tạo API Key mới tại https://makersuite.google.com/app/apikey

### Lỗi: "Lỗi kết nối"
**Nguyên nhân**: Không có internet  
**Giải pháp**: Kiểm tra kết nối mạng

### Chat window không hiện
**Nguyên nhân**: Floating button bị che khuất  
**Giải pháp**: Kiểm tra `floatingChatButton.BringToFront()` trong `Form1.cs`

### AI trả lời sai
**Nguyên nhân**: Context không đủ hoặc câu hỏi quá mơ hồ  
**Giải pháp**:  
- Hỏi câu hỏi cụ thể hơn
- Kiểm tra `DatabaseContextService.GetRelevantContext()`

---

## 📊 Performance

- **Response time trung bình**: 2-5 giây
- **Rate limit**: 60 requests/phút (free tier)
- **Context length**: Tối đa 20 công việc
- **Token limit**: 2048 tokens output

---

## 🔐 Bảo mật

- ⚠️ **KHÔNG** commit API Key lên Git
- ⚠️ **KHÔNG** chia sẻ API Key với người khác
- ✅ Thêm `GeminiChatService.cs` vào `.gitignore` nếu cần
- ✅ Sử dụng environment variables cho production

---

## 🎯 Tính năng tương lai

- [ ] Chat history persistence (lưu lịch sử chat)
- [ ] Voice input (nhập giọng nói)
- [ ] Export chat to PDF
- [ ] Multi-language support
- [ ] Suggested questions
- [ ] Real-time notifications

---

## 👨‍💻 Technical Stack

| Component | Technology |
|-----------|-----------|
| AI Model | Google Gemini 1.5 Flash |
| API | REST API (HTTP POST) |
| JSON Parser | System.Text.Json |
| Database | MySQL |
| ORM | Raw ADO.NET |
| Architecture | RAG (Retrieval Augmented Generation) |

---

## 📞 Support

Nếu gặp vấn đề, hãy:
1. Kiểm tra [Troubleshooting](#-troubleshooting)
2. Xem log trong Output window
3. Tạo issue trên GitHub

---

## 📜 License

MIT License - Free to use and modify

---

**Chúc bạn sử dụng AI Chatbot hiệu quả! 🚀**

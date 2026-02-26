# 🤖 Hướng dẫn cài đặt AI Chatbot - Nhanh & Đơn giản

> Chatbot AI tích hợp vào ứng dụng Kanban Task Manager  
> Trả lời tự động dựa trên dữ liệu thực tế trong hệ thống

---

## 📋 Tóm tắt

- **AI Model**: Google Gemini 2.5 Flash (miễn phí)
- **Thời gian cài đặt**: 5 phút
- **Yêu cầu**: Internet + API Key (miễn phí)

---

## 🚀 Cài đặt (3 bước)

### Bước 1️⃣: Lấy API Key (2 phút)

1. Mở trình duyệt, vào: **https://aistudio.google.com/apikey**

2. Đăng nhập Google

3. Click nút **"Create API Key"**

4. Chọn **"Create API key in new project"**

5. **Copy** API Key (dạng: `AIzaSy...`)

   ```
   Ví dụ: AIzaSyDyvkrEOH52hLLMwiReZgX98cRRzTzz4W0
   ```

---

### Bước 2️⃣: Paste API Key vào code (1 phút)

1. Mở file: `firstapp/Services/GeminiChatService.cs`

2. Tìm dòng 17:
   ```csharp
   private const string GEMINI_API_KEY = "YOUR_API_KEY_HERE";
   ```

3. **Thay thế** bằng API Key của bạn:
   ```csharp
   private const string GEMINI_API_KEY = "AIzaSy...";  // ← Paste API Key vào đây
   ```

4. **Save** file (Ctrl + S)

---

### Bước 3️⃣: Build & Chạy (1 phút)

1. Trong Visual Studio:
   - Click **Build** → **Rebuild Solution**
   - Hoặc nhấn **Ctrl + Shift + B**

2. Chạy ứng dụng:
   - Nhấn **F5** hoặc click **Start**

3. Đăng nhập vào app

---

## 💬 Cách sử dụng

### Mở Chatbot

1. Tìm **button tròn màu xanh 🤖** ở **góc dưới bên phải** màn hình

2. **Click** vào button → Chat window hiện lên

### Hỏi câu hỏi

Gõ câu hỏi vào ô input và nhấn **Enter** (hoặc click 📤)

#### 🎯 Câu hỏi mẫu:

```
✅ Đơn giản:
   - Có bao nhiêu công việc?
   - Bao nhiêu task đang làm?
   - Ai có nhiều việc nhất?

✅ Chi tiết:
   - Công việc nào quá hạn?
   - Thống kê theo độ ưu tiên
   - Liệt kê task của Nguyễn Văn A

✅ Phân tích:
   - Đánh giá hiệu suất làm việc
   - Gợi ý công việc cần ưu tiên
   - Xu hướng hoàn thành công việc
```

---

## 🎨 Giao diện

```
┌─────────────────────────────────────┐
│  🤖 AI Assistant - Kanban      [X]  │  ← Header
├─────────────────────────────────────┤
│                                     │
│  👋 Xin chào! Tôi là AI...         │  ← AI Message (trái)
│                                     │
│              Có bao nhiêu task? 👤  │  ← User Message (phải)
│                                     │
│  📊 Hiện có 39 công việc...        │  ← AI Response
│                                     │
├─────────────────────────────────────┤
│  [Nhập câu hỏi...]          [📤]   │  ← Input
│                          [🗑️ Xóa]   │
└─────────────────────────────────────┘
```

---

## ❓ FAQ - Câu hỏi thường gặp

### 1. Chatbot không hiện button?
**Giải pháp**: 
- Kiểm tra file `Form1.cs` có dòng `InitializeFloatingChatButton();`
- Build lại project

### 2. Lỗi "Chưa cấu hình API Key"?
**Giải pháp**: 
- Kiểm tra lại Bước 2
- API Key phải bỏ dấu ngoặc kép cũ

### 3. Lỗi "API 400/403"?
**Giải pháp**: 
- API Key sai hoặc hết hạn
- Tạo API Key mới tại: https://aistudio.google.com/apikey

### 4. Chat chậm?
**Trả lời**: 
- Response time ~2-5 giây là bình thường
- Phụ thuộc vào kết nối internet

### 5. AI trả lời sai?
**Giải pháp**: 
- Hỏi câu hỏi cụ thể hơn
- Ví dụ: "Công việc đang làm" thay vì "Task"

---

## 🔒 Bảo mật

⚠️ **LƯU Ý QUAN TRỌNG**:

```diff
- ❌ KHÔNG commit API Key lên GitHub
- ❌ KHÔNG chia sẻ API Key với người khác
+ ✅ Giữ API Key riêng tư
+ ✅ Có thể tạo API Key mới bất kỳ lúc nào
```

**Nếu lỡ push API Key lên Git**:
1. Tạo API Key mới
2. Xóa API Key cũ tại: https://aistudio.google.com/apikey
3. Update code với API Key mới

---

## 📊 Giới hạn miễn phí

| Thông số | Giá trị |
|----------|---------|
| Số request/phút | 60 |
| Số request/ngày | Không giới hạn |
| Giá | **MIỄN PHÍ** ✅ |

---

## 🎯 Tính năng Chatbot

- ✅ Truy vấn dữ liệu thời gian thực từ MySQL
- ✅ Phân tích thông minh (RAG - Retrieval Augmented Generation)
- ✅ Trả lời bằng tiếng Việt tự nhiên
- ✅ Gợi ý và insights
- ✅ Lịch sử chat trong session
- ✅ Giao diện đẹp, dễ sử dụng

---

## 🆘 Cần trợ giúp?

1. **Xem log**: Output window trong Visual Studio
2. **Test connection**: Hỏi "Hello" để test
3. **Issue trên GitHub**: https://github.com/Nguyen15idhue/btlwindow/issues

---

## 📝 Checklist

Hoàn thành setup khi:

- [ ] Đã lấy được API Key
- [ ] Đã paste vào `GeminiChatService.cs`
- [ ] Build thành công (0 errors)
- [ ] Thấy button 🤖 ở góc dưới phải
- [ ] Click button → Chat window hiện ra
- [ ] Gõ "Hello" → AI trả lời được

---

**🎉 Xong! Giờ bạn có AI Assistant riêng rồi đấy!**

> Hãy thử hỏi: "Phân tích hiệu suất làm việc của team" 🚀

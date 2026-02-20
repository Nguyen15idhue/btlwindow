# 🚀 HƯỚNG DẪN NHANH - KANBAN TASK MANAGER v2.0 (VỚI PHÂN QUYỀN)

> **Dành cho:** Thành viên mới, chưa từng dùng Visual Studio  
> **Thời gian:** ~30 phút  
> **Mục tiêu:** Chạy được ứng dụng với hệ thống đăng ký/đăng nhập  
> **Phiên bản mới:** Đã có phân quyền Manager/Employee

---

## 📋 BƯỚC 1: CHUẨN BỊ MÁY TÍNH

### Kiểm tra yêu cầu
- ✅ Windows 7/8/10/11 (64-bit)
- ✅ Ổ đĩa trống: ~5GB
- ✅ RAM: tối thiểu 4GB (khuyến nghị 8GB)
- ✅ Kết nối internet

---

## 🔽 BƯỚC 2: TẢI VÀ CÀI ĐẶT PHẦN MỀM

### 2.1 Visual Studio Community 2022 (MIỄN PHÍ)

**Tải về:**
1. Truy cập: https://visualstudio.microsoft.com/vs/community/
2. Click nút **"Download Visual Studio"** (nút màu tím)
3. File tải về: `VisualStudioSetup.exe` (~3MB)

**Cài đặt:**
1. Chạy file `VisualStudioSetup.exe`
2. Chọn **"Continue"** để tải installer
3. Khi hiện màn hình **Workloads**, tích chọn:
   ```
   ☑️ .NET desktop development
      └─ Bao gồm: .NET Framework 4.8, WinForms, ...
   ```
4. Click **"Install"** (sẽ mất 10-20 phút)
5. Sau khi xong, click **"Launch"** để mở Visual Studio

**💡 Lần đầu mở:**
- Chọn **"Not now, maybe later"** (không cần đăng nhập)
- Theme: **"Blue"** hoặc **"Dark"** (tùy thích)
- Click **"Start Visual Studio"**

---

### 2.2 XAMPP (MySQL Server)

**Tải về:**
1. Truy cập: https://www.apachefriends.org/
2. Click **"Download"** cho Windows
3. File tải về: `xampp-windows-x64-X.X.X-installer.exe` (~150MB)

**Cài đặt:**
1. Chạy file installer
2. Nếu có cảnh báo UAC, click **"Yes"**
3. Màn hình **Select Components**:
   ```
   ☑️ MySQL        ← BẮT BUỘC
   ☑️ phpMyAdmin   ← BẮT BUỘC
   ☐ Apache        (không cần, có thể bỏ tích)
   ☐ FileZilla     (không cần)
   ☐ Mercury       (không cần)
   ☐ Tomcat        (không cần)
   ```
4. Chọn thư mục cài đặt: `C:\xampp` (mặc định)
5. Click **"Next"** → **"Next"** → **"Finish"**

**Khởi động MySQL:**
1. Mở **XAMPP Control Panel** (icon trên Desktop)
2. Dòng **MySQL**, click nút **"Start"** (chữ nền xanh lá)
3. Nếu thành công, sẽ hiện **"Running"** màu xanh

---

### 2.3 Git (Quản lý mã nguồn)

**Tải về:**
1. Truy cập: https://git-scm.com/download/win
2. File tải về: `Git-X.X.X-64-bit.exe` (~50MB)

**Cài đặt:**
1. Chạy file installer
2. Tất cả các bước cứ click **"Next"** (giữ mặc định)
3. Quan trọng: Màn hình **"Adjusting your PATH environment"**
   → Chọn: **"Git from the command line and also from 3rd-party software"**
4. Click **"Install"** → **"Finish"**

**Kiểm tra cài đặt:**
1. Mở **Command Prompt** (Gõ `cmd` trong Start Menu)
2. Gõ lệnh:
   ```bash
   git --version
   ```
3. Nếu hiện `git version 2.x.x` → OK ✅

---

## 📦 BƯỚC 3: TẢI MÃ NGUỒN DỰ ÁN

### 3.1 Clone repository từ GitHub

**Cách 1: Dùng Git Bash (khuyến nghị)**

1. Tạo thư mục chứa dự án:
   - Ví dụ: `C:\Projects\`
   
2. Click chuột phải vào thư mục → Chọn **"Git Bash Here"**

3. Trong cửa sổ Git Bash, gõ lệnh:
   ```bash
   git clone https://github.com/Nguyen15idhue/btlwindow.git
   ```

4. Đợi tải về (vài giây), sẽ có thư mục `btlwindow`

**Cách 2: Dùng Visual Studio (dễ hơn)**

1. Mở Visual Studio
2. Màn hình chào mừng, chọn **"Clone a repository"**
3. Dán link:
   ```
   https://github.com/Nguyen15idhue/btlwindow.git
   ```
4. Chọn đường dẫn lưu: `C:\Projects\btlwindow`
5. Click **"Clone"**

---

## 🗄️ BƯỚC 4: TẠO DATABASE

### 4.1 Mở phpMyAdmin

1. Đảm bảo MySQL đang chạy trong XAMPP Control Panel
2. Mở trình duyệt (Chrome, Edge, ...)
3. Truy cập: http://localhost/phpmyadmin/
4. Nếu không vào được → Kiểm tra lại MySQL đã Start chưa

### 4.2 Tạo database

1. Click tab **"Databases"** (phía trên)
2. Ô **"Create database"**, nhập tên:
   ```
   kanban_simple
   ```
3. Collation: Chọn `utf8mb4_unicode_ci`
4. Click nút **"Create"**

### 4.3 Import dữ liệu (⚠️ PHIÊN BẢN MỚI)

1. Click vào database `kanban_simple` vừa tạo (bên trái)
2. Click tab **"Import"** (phía trên)
3. Click nút **"Choose File"**
4. Chọn file **MỚI**:
   ```
   C:\Projects\btlwindow\firstapp\database_with_auth.sql
   ```
   ⚠️ **LƯU Ý:** Dùng file **database_with_auth.sql** (có authentication), KHÔNG dùng database_update.sql cũ
5. Click nút **"Go"** (cuối trang)
6. Nếu thành công, hiện thông báo màu xanh ✅

### 4.4 Kiểm tra

1. Click vào database `kanban_simple` (bên trái)
2. Phải thấy 2 bảng MỚI:
   ```
   ✓ nguoi_dung     (5 users: 2 Managers, 3 Employees)
   ✓ cong_viec      (9 tasks mẫu)
   ```
3. Click vào bảng `nguoi_dung` → Tab **Browse** → Xem 5 users mẫu

---

## 🔨 BƯỚC 5: MỞ VÀ CHẠY DỰ ÁN

### 5.1 Mở project trong Visual Studio

**Cách 1: Double-click vào file project**
1. Vào thư mục: `C:\Projects\btlwindow\firstapp\`
2. Tìm file: `btlwindow.csproj` (icon có logo Visual Studio)
3. Double-click vào file này

**Cách 2: Mở từ Visual Studio**
1. Mở Visual Studio
2. Menu **File** → **Open** → **Project/Solution...**
3. Chọn file: `C:\Projects\btlwindow\firstapp\btlwindow.csproj`
4. Click **"Open"**

### 5.2 Khôi phục NuGet packages

Khi project mở lần đầu, sẽ có thông báo:
```
Some NuGet packages are missing...
```

**Giải quyết:**
1. Click chuột phải vào **Solution 'btlwindow'** (trong Solution Explorer)
2. Chọn **"Restore NuGet Packages"**
3. Đợi 1-2 phút để tải về

**Nếu vẫn lỗi:**
1. Menu **Tools** → **NuGet Package Manager** → **Package Manager Console**
2. Gõ lệnh:
   ```
   Update-Package -Reinstall
   ```

### 5.3 Kiểm tra Connection String

1. Trong **Solution Explorer**, tìm file `TaskRepository.cs`
2. Double-click mở file
3. Tìm dòng:
   ```csharp
   private static string connectionString = 
       "Server=localhost;Database=kanban_simple;Port=3306;User Id=root;Password=;";
   ```
4. Kiểm tra:
   - `localhost`: Giữ nguyên
   - `kanban_simple`: Tên database vừa tạo
   - `root`: Username MySQL (mặc định của XAMPP)
   - `Password=;`: Để trống (XAMPP không có password mặc định)

**💡 Nếu MySQL của bạn có password:**
```csharp
"Server=localhost;Database=kanban_simple;Port=3306;User Id=root;Password=matkhaucuaban;"
```

---

## ▶️ BƯỚC 6: BUILD VÀ CHẠY

### 6.1 Build project

1. Menu **Build** → **Build Solution** (hoặc `Ctrl + Shift + B`)
2. Xem cửa sổ **Output** (phía dưới):
   ```
   ========== Build: 1 succeeded, 0 failed, 0 up-to-date, 0 skipped ==========
   ```
3. Nếu thấy "1 succeeded" → OK ✅

### 6.2 Chạy ứng dụng

1. Click nút **▶️ Start** (hoặc nhấn `F5`)
   - Nút màu xanh lá, ghi chữ "Start" hoặc tên project
   
2. Lần đầu chạy, Windows có thể hỏi:
   ```
   Do you want to allow this app to make changes to your device?
   ```
   → Click **"Yes"**

3. Nếu mọi thứ OK, ứng dụng sẽ mở ra:
   ```
   ┌────────────────────────────────────┐
   │  📋 KANBAN                         │
   │  🏠 Bảng điều khiển               │
   │  ➕ Thêm Task mới                 │
   │  👥 Quản lý thành viên            │
   └────────────────────────────────────┘
   ```

---

## 📂 HIỂU CẤU TRÚC PROJECT

Khi mở Visual Studio, bạn sẽ thấy:

### Solution Explorer (bên phải)
```
📦 Solution 'btlwindow'
  └─ 📁 firstapp (Project)
       ├─ 📁 Properties
       ├─ 📄 Form1.cs              ← Giao diện chính (Kanban board)
       ├─ 📄 frmAddTask.cs         ← Form thêm task mới
       ├─ 📄 TaskItem.cs           ← Card hiển thị 1 task
       ├─ 📄 TaskModel.cs          ← Cấu trúc dữ liệu Task
       ├─ 📄 TaskRepository.cs     ← Kết nối database
       ├─ 📄 Program.cs            ← File khởi động app
       └─ 📄 App.config            ← Cấu hình app
```

### Các file quan trọng:

**1. `Form1.cs` - Màn hình chính**
- Hiển thị bảng Kanban
- Xử lý tìm kiếm, lọc, sắp xếp
- Nút "Thêm Task mới", "Xuất CSV"

**2. `frmAddTask.cs` - Form thêm task**
- Popup nhập thông tin task mới
- Validate dữ liệu
- Lưu vào database

**3. `TaskItem.cs` - Card task**
- Hiển thị 1 task dạng card nhỏ
- Màu sắc theo độ ưu tiên

**4. `TaskRepository.cs` - Xử lý database**
- Lấy danh sách task
- Thêm task mới
- Xuất CSV

**💡 Quy tắc:**
- File `.cs` = Code C#
- File `.Designer.cs` = Giao diện tự động tạo (KHÔNG SỬA TAY)
- File `.resx` = Resources (hình ảnh, icon, ...)

---

## 🧪 TEST THỬ ỨNG DỤNG

### Thử các chức năng:

**1. Xem danh sách task**
- Mở app → Thấy các task ở 3 cột: Todo / Doing / Done ✅

**2. Tìm kiếm task**
- Gõ từ khóa vào ô "Tìm kiếm" → Task lọc realtime ✅

**3. Lọc theo độ ưu tiên**
- Chọn "Cao" / "Trung bình" / "Thấp" trong dropdown ✅

**4. Sắp xếp theo deadline**
- Chọn "Hạn chót tăng dần" / "Hạn chót giảm dần" ✅

**5. Thêm task mới**
- Click nút "➕ Thêm Task mới"
- Nhập thông tin:
  ```
  Tiêu đề: Test task mới
  Mô tả: Đây là task để test
  Người thực hiện: Nguyễn Văn A
  Deadline: Chọn ngày mai
  Độ ưu tiên: Cao
  ```
- Click **"💾 Lưu"**
- Task xuất hiện ở cột **"Todo"** ✅

**6. Xuất báo cáo CSV**
- Click nút "📥 Xuất Báo Cáo"
- Chọn nơi lưu file → Lưu
- Mở file CSV bằng Excel → Xem được data ✅

---

## ❓ TROUBLESHOOTING - XỬ LÝ LỖI THƯỜNG GẶP

### ❌ Lỗi 1: "MySQL.Data.dll not found"

**Nguyên nhân:** Chưa cài NuGet package

**Giải quyết:**
1. Menu **Tools** → **NuGet Package Manager** → **Manage NuGet Packages for Solution...**
2. Tab **Browse**, tìm: `MySql.Data`
3. Chọn version **9.6.0**
4. Tích chọn project `firstapp`
5. Click **"Install"**

---

### ❌ Lỗi 2: "Unable to connect to any of the specified MySQL hosts"

**Nguyên nhân:** MySQL chưa chạy hoặc sai cấu hình

**Giải quyết:**
1. Mở XAMPP Control Panel
2. Dòng MySQL, click **"Start"**
3. Chờ đến khi thấy chữ **"Running"** màu xanh
4. Thử lại app

**Nếu vẫn lỗi:**
- Kiểm tra Port 3306 có bị chiếm không:
  ```bash
  netstat -ano | findstr :3306
  ```
- Nếu có process khác, tắt đi hoặc đổi port MySQL

---

### ❌ Lỗi 3: "Table 'kanban_simple.cong_viec' doesn't exist"

**Nguyên nhân:** Chưa import database

**Giải quyết:**
- Quay lại **BƯỚC 4** và import file `database_update.sql`

---

### ❌ Lỗi 4: Build thành công nhưng app không mở

**Nguyên nhân:** Có thể bị antivirus chặn

**Giải quyết:**
1. Tắt tạm thời antivirus (Windows Defender, Kaspersky, ...)
2. Build lại: `Ctrl + Shift + B`
3. Chạy: `F5`

---

### ❌ Lỗi 5: "Incorrect integer value: 'Cao' for column 'do_uu_tien'"

**Nguyên nhân:** Cột `do_uu_tien` trong database có kiểu INT thay vì VARCHAR

**Giải quyết:**
1. Mở phpMyAdmin
2. Chọn database `kanban_simple`
3. Chạy lệnh SQL:
   ```sql
   ALTER TABLE cong_viec DROP COLUMN IF EXISTS do_uu_tien;
   ALTER TABLE cong_viec ADD COLUMN do_uu_tien VARCHAR(20) DEFAULT 'Trung bình';
   ```
4. Chạy lại app

---

## 📚 HỌC THÊM - TÀI LIỆU THAM KHẢO

### Visual Studio Basics
- **Shortcuts hay dùng:**
  - `F5`: Run (Debug)
  - `Ctrl + F5`: Run (Không debug)
  - `Ctrl + Shift + B`: Build solution
  - `Ctrl + K, Ctrl + D`: Format code
  - `Ctrl + .`: Quick actions (sửa lỗi nhanh)

### C# WinForms Cơ Bản
- **Form:** Cửa sổ chính của app
- **Control:** Button, TextBox, Label, ComboBox, ...
- **Event:** Click, TextChanged, Load, ...
- **Property:** Text, Color, Size, Font, ...

### MySQL Cơ Bản
- **SELECT:** Lấy dữ liệu
- **INSERT:** Thêm dữ liệu
- **UPDATE:** Sửa dữ liệu
- **DELETE:** Xóa dữ liệu

### Git Cơ Bản
```bash
git status           # Xem thay đổi
git add .            # Thêm tất cả file
git commit -m "msg"  # Commit với message
git push            # Đẩy lên GitHub
git pull            # Kéo về từ GitHub
```

---

## 💡 TIPS & TRICKS

### 1. Sao lưu trước khi sửa code
```bash
git add .
git commit -m "Backup trước khi sửa"
```

### 2. Debug hiệu quả
- Đặt **Breakpoint** (click vào số dòng bên trái)
- Chạy `F5` → Dừng tại breakpoint
- Xem giá trị biến trong cửa sổ **Locals**
- `F10`: Chạy từng dòng
- `F5`: Tiếp tục chạy

### 3. Xem lỗi chi tiết
- Khi app crash, xem cửa sổ **Output** (Ctrl + Alt + O)
- Xem **Error List** (Ctrl + \, E)

### 4. Format code đẹp
- `Ctrl + K, Ctrl + D`: Format toàn bộ file
- `Ctrl + K, Ctrl + F`: Format đoạn code chọn

### 5. Tìm nhanh file
- `Ctrl + ,`: Mở **Go to All**
- Gõ tên file hoặc class

---

## 👥 LÀM VIỆC NHÓM

### Quy trình làm việc chuẩn:

**1. Trước khi code:**
```bash
git pull    # Kéo code mới nhất từ GitHub
```

**2. Sau khi code xong:**
```bash
git add .
git commit -m "Thêm chức năng X"
git push
```

**3. Xử lý conflict:**
- Nếu push bị lỗi: `git pull` trước
- Nếu có conflict: Mở file, sửa thủ công, commit lại

### Quy tắc commit message:
```
✅ ĐÚNG:
- "Thêm chức năng tìm kiếm task"
- "Sửa lỗi hiển thị deadline"
- "Cập nhật giao diện form thêm task"

❌ SAI:
- "update"
- "fix bug"
- "sửa"
```

---

## 📞 HỖ TRỢ

### Gặp khó khăn?

**1. Đọc lại tài liệu:**
- File này: `QUICKSTART.md`
- Tài liệu chi tiết: `DOCUMENTATION.md`

**2. Tìm trong Issue GitHub:**
- https://github.com/Nguyen15idhue/btlwindow/issues
- Có thể ai đó gặp lỗi giống bạn

**3. Hỏi nhóm:**
- Group chat / Facebook group
- Email lead developer

**4. Google Search:**
```
visual studio 2022 [mô tả lỗi]
c# winforms [vấn đề gặp phải]
mysql xampp [lỗi cụ thể]
```

---

## ✅ CHECKLIST HOÀN THÀNH

Sau khi làm xong tất cả, check lại:

- [ ] Visual Studio 2022 đã cài đặt
- [ ] XAMPP đã cài đặt, MySQL đang chạy
- [ ] Git đã cài đặt
- [ ] Clone project từ GitHub thành công
- [ ] Database `kanban_simple` đã tạo
- [ ] Import file `database_update.sql` thành công
- [ ] Mở project trong Visual Studio OK
- [ ] Build thành công (0 error)
- [ ] Chạy app thành công (F5)
- [ ] Thử thêm 1 task mới thành công
- [ ] Xuất CSV thành công

**🎉 Nếu tất cả đều check → HOÀN THÀNH!**

---

## 🚀 BƯỚC TIẾP THEO

Bây giờ bạn đã sẵn sàng:
1. ✅ Đọc code để hiểu luồng hoạt động
2. ✅ Sửa lỗi (nếu có)
3. ✅ Thêm tính năng mới
4. ✅ Làm việc nhóm với Git

**Chúc bạn code vui vẻ! 💻🎉**

---

*Cập nhật lần cuối: 2024-12-15*  
*Version: 1.0.0*

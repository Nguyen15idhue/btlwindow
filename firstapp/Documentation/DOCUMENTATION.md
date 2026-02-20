# 📋 KANBAN TASK MANAGER - TÀI LIỆU KỸ THUẬT

## 📌 TỔNG QUAN DỰ ÁN

**Kanban Task Manager** là ứng dụng quản lý công việc theo mô hình Kanban board được phát triển bằng **WinForms .NET Framework 4.8** và **MySQL**.

### 🎯 Mục tiêu
- Quản lý công việc trực quan theo 3 trạng thái: **Todo**, **Doing**, **Done**
- Giao diện hiện đại, chuyên nghiệp
- Tìm kiếm, lọc, sắp xếp task linh hoạt
- Xuất báo cáo CSV
- Quản lý deadline và độ ưu tiên

---

## 🏗️ CẤU TRÚC DỰ ÁN

```
firstapp/
│
├── 📁 Properties/
│   ├── AssemblyInfo.cs
│   ├── Resources.Designer.cs
│   ├── Resources.resx
│   ├── Settings.Designer.cs
│   └── Settings.settings
│
├── 📄 Program.cs                    # Entry point
├── 📄 App.config                    # Cấu hình ứng dụng
├── 📄 packages.config               # NuGet packages
├── 📄 btlwindow.csproj             # Project file
│
├── 🎨 FORMS & UI
│   ├── Form1.cs                     # Main form (Logic)
│   ├── Form1.Designer.cs            # Main form (UI)
│   ├── Form1.resx                   # Main form (Resources)
│   ├── frmAddTask.cs               # Form thêm task (Logic)
│   ├── frmAddTask.Designer.cs      # Form thêm task (UI)
│   ├── frmAddTask.resx             # Form thêm task (Resources)
│   ├── TaskItem.cs                 # UserControl task card (Logic)
│   ├── TaskItem.Designer.cs        # UserControl task card (UI)
│   └── TaskItem.resx               # UserControl task card (Resources)
│
├── 📊 DATA LAYER
│   ├── TaskModel.cs                 # Model dữ liệu task
│   └── TaskRepository.cs            # Repository (CRUD operations)
│
└── 🗄️ DATABASE
    └── database_update.sql          # SQL script khởi tạo DB
```

---

## 📦 THÀNH PHẦN CHÍNH

### 1. **Form1.cs - Main Form (Kanban Board)**

**Chức năng:**
- Hiển thị bảng Kanban với 3 cột
- Tìm kiếm realtime theo tiêu đề
- Lọc theo độ ưu tiên (Cao, Trung bình, Thấp)
- Sắp xếp theo deadline (Tăng/Giảm dần)
- Đếm và hiển thị số task quá hạn
- Xuất báo cáo CSV
- Mở form thêm task mới

**Layout:**
```
┌─────────────────────────────────────────────────┐
│  📋 KANBAN SIDEBAR  │  TOP PANEL (Toolbar)     │
│                     ├───────────────────────────┤
│  🏠 Bảng điều khiển │                           │
│  ➕ Thêm Task mới   │   KANBAN BOARD            │
│  👥 Quản lý thành   │   ┌─────┬─────┬─────┐    │
│      viên           │   │Todo │Doing│Done │    │
│                     │   │     │     │     │    │
└─────────────────────┴───┴─────┴─────┴─────┴────┘
```

**Các thuộc tính chính:**
- `List<TaskModel> allTasks`: Cache dữ liệu task
- `cbFilterPriority`: ComboBox lọc độ ưu tiên
- `cbSort`: ComboBox sắp xếp
- `txtSearch`: TextBox tìm kiếm
- `lblOverdueCount`: Label hiển thị số task quá hạn

**Các phương thức chính:**
```csharp
- LoadAllTasks()                    // Load dữ liệu từ DB
- RefreshKanbanBoard()              // Refresh giao diện
- ApplyFilters()                    // Áp dụng filter/sort
- UpdateOverdueCount()              // Cập nhật số task quá hạn
- btnOpenAddForm_Click()            // Mở form thêm task
- btnExportCSV_Click()              // Xuất CSV
- txtSearch_TextChanged()           // Tìm kiếm realtime
- cbFilterPriority_SelectedIndexChanged()
- cbSort_SelectedIndexChanged()
```

---

### 2. **frmAddTask.cs - Form Thêm Task Mới**

**Chức năng:**
- Nhập tiêu đề task (bắt buộc, max 200 ký tự)
- Nhập mô tả (multiline, tùy chọn)
- Chọn người thực hiện từ ComboBox
- Chọn deadline (DateTimePicker)
- Chọn độ ưu tiên (Cao/Trung bình/Thấp)
- Validate dữ liệu đầu vào
- Lưu vào database và đóng form

**Giao diện:**
```
┌──────────────────────────────────────┐
│  ➕ THÊM CÔNG VIỆC MỚI              │
├──────────────────────────────────────┤
│  Tiêu đề (*): [________________]     │
│  Mô tả:       [________________]     │
│               [________________]     │
│  Người TH:    [Dropdown ▼    ]      │
│  Deadline:    [📅 dd/MM/yyyy]       │
│  Độ ưu tiên:  [Dropdown ▼    ]      │
├──────────────────────────────────────┤
│            [💾 Lưu] [❌ Hủy]         │
└──────────────────────────────────────┘
```

**Validate:**
- Tiêu đề không được để trống
- Tiêu đề không vượt quá 200 ký tự
- Deadline không được trong quá khứ

---

### 3. **TaskItem.cs - UserControl Task Card**

**Chức năng:**
- Hiển thị thông tin 1 task dạng card
- Thanh màu bên trái theo độ ưu tiên
- Hiển thị icon emoji trực quan
- Đổi màu nền nếu task quá hạn

**Giao diện Task Card:**
```
┌───┬─────────────────────────────┐
│ ▌ │ 📝 Tiêu đề công việc       │
│ ▌ │ 👤 Nguyễn Văn A            │
│ ▌ │ 📅 15/12/2024  🔴 Cao      │
└───┴─────────────────────────────┘
  ↑
Thanh màu theo độ ưu tiên:
🔴 Cao        = Đỏ
🟡 Trung bình = Vàng
🟢 Thấp       = Xanh lá
```

**Properties:**
- `TaskModel TaskData`: Dữ liệu task
- `panelPriorityBar`: Thanh màu bên trái
- `lblTitle`, `lblAssignee`, `lblDeadline`, `lblPriority`

---

### 4. **TaskModel.cs - Data Model**

```csharp
public class TaskModel
{
    public int Id { get; set; }
    public string TieuDe { get; set; }              // Tiêu đề
    public string MoTa { get; set; }                // Mô tả
    public string TrangThai { get; set; }           // Todo/Doing/Done
    public int NguoiDuocGiaoId { get; set; }       // ID người được giao
    public string TenNguoiDuocGiao { get; set; }   // Tên người được giao
    public DateTime HanHoanThanh { get; set; }      // Deadline
    public string DoUuTien { get; set; }            // Cao/Trung bình/Thấp
    
    public bool IsOverdue                           // Kiểm tra quá hạn
    {
        get
        {
            return HanHoanThanh != DateTime.MinValue 
                   && HanHoanThanh < DateTime.Today 
                   && TrangThai != "Done";
        }
    }
}
```

---

### 5. **TaskRepository.cs - Data Access Layer**

**Chức năng:**
Xử lý toàn bộ thao tác với database MySQL.

**Connection String:**
```csharp
private static string connectionString = 
    "Server=localhost;Database=kanban_simple;Port=3306;User Id=root;Password=;";
```

**Các phương thức:**

#### `LoadTasks()` - Lấy danh sách task
```csharp
public static List<TaskModel> LoadTasks()
```
- SELECT tất cả task từ bảng `cong_viec`
- Không JOIN `thanh_vien` (tránh lỗi khi bảng chưa có)
- Hiển thị "Người #ID" thay vì tên thật

#### `AddTask()` - Thêm task mới
```csharp
public static bool AddTask(string tieuDe, string moTa, 
                           int nguoiDuocGiaoId, DateTime hanHoanThanh, 
                           string doUuTien)
```
- INSERT vào bảng `cong_viec`
- Mặc định `trang_thai = 'Todo'`
- Validate NULL cho các trường tùy chọn

#### `GetMembers()` - Lấy danh sách thành viên
```csharp
public static List<KeyValuePair<int, string>> GetMembers()
```
- Kiểm tra bảng `thanh_vien` có tồn tại không
- Nếu có: SELECT từ database
- Nếu không: Trả về danh sách mẫu (Nguyễn Văn A, B, C)

#### `ExportToCSV()` - Xuất báo cáo CSV
```csharp
public static bool ExportToCSV(List<TaskModel> tasks, string filePath)
```
- Ghi file CSV với UTF-8 encoding
- Bao gồm: ID, Tiêu đề, Mô tả, Trạng thái, Người TH, Deadline, Độ ưu tiên, Quá hạn

#### `UpdateTaskStatus()` - Cập nhật trạng thái
```csharp
public static bool UpdateTaskStatus(int taskId, string newStatus)
```
- UPDATE `trang_thai` của task
- (Dự phòng cho tính năng kéo thả sau này)

---

## 🗄️ CƠ SỞ DỮ LIỆU

### Database: `kanban_simple`

### Bảng 1: `cong_viec` (Tasks)

```sql
CREATE TABLE cong_viec (
    id                    INT AUTO_INCREMENT PRIMARY KEY,
    tieu_de              VARCHAR(200) NOT NULL,
    mo_ta                TEXT NULL,
    trang_thai           VARCHAR(20) DEFAULT 'Todo',
    nguoi_tao_id         INT,
    nguoi_duoc_giao_id   INT,
    do_uu_tien           VARCHAR(20) DEFAULT 'Trung bình',
    han_hoan_thanh       DATETIME NULL,
    ngay_tao             DATETIME DEFAULT CURRENT_TIMESTAMP
);
```

**Các trạng thái:**
- `Todo`: Công việc cần làm
- `Doing`: Đang làm
- `Done`: Đã hoàn thành

**Độ ưu tiên:**
- `Cao`: Ưu tiên cao (màu đỏ)
- `Trung bình`: Ưu tiên trung bình (màu vàng)
- `Thấp`: Ưu tiên thấp (màu xanh)

### Bảng 2: `thanh_vien` (Members)

```sql
CREATE TABLE thanh_vien (
    id              INT AUTO_INCREMENT PRIMARY KEY,
    ho_ten          VARCHAR(100) NOT NULL,
    email           VARCHAR(100),
    so_dien_thoai   VARCHAR(20),
    ngay_tao        DATETIME DEFAULT CURRENT_TIMESTAMP
);
```

**Dữ liệu mẫu:**
- Nguyễn Văn A
- Trần Thị B
- Lê Văn C
- Phạm Thị D
- Hoàng Văn E

---

## 🎨 THIẾT KẾ GIAO DIỆN

### Màu sắc chủ đạo

| Thành phần | Màu | RGB |
|-----------|-----|-----|
| Sidebar | Xanh dương đậm | `rgb(41, 128, 185)` |
| Button chính | Xanh lá | `rgb(46, 204, 113)` |
| Cột Todo | Vàng cam | `rgb(241, 196, 15)` |
| Cột Doing | Xanh dương | `rgb(52, 152, 219)` |
| Cột Done | Xanh lá | `rgb(46, 204, 113)` |
| Độ ưu tiên Cao | Đỏ | `rgb(231, 76, 60)` |
| Độ ưu tiên TB | Vàng | `rgb(241, 196, 15)` |
| Độ ưu tiên Thấp | Xanh lá | `rgb(46, 204, 113)` |
| Background | Xám nhạt | `rgb(236, 240, 241)` |

### Font chữ
- **Segoe UI** (10F - 18F)
- **Bold** cho tiêu đề
- **Regular** cho nội dung

### Kích thước
- Sidebar: **250px** width
- TopPanel: **70px** height
- Task Card: **260px** width × **100px** height
- Button: **230px** × **45px**
- Form Add Task: **480px** × **450px**

---

## 🚀 HƯỚNG DẪN CÀI ĐẶT

### Yêu cầu hệ thống
- Windows 7/8/10/11
- .NET Framework 4.8
- Visual Studio 2019/2022
- XAMPP (MySQL 5.7+)

### Bước 1: Clone repository
```bash
git clone https://github.com/Nguyen15idhue/btlwindow.git
cd btlwindow
```

### Bước 2: Cài đặt NuGet packages
```
Install-Package MySql.Data -Version 9.6.0
```

Các package được dùng:
- **MySql.Data** 9.6.0
- **BouncyCastle.Cryptography** 2.6.2
- **Google.Protobuf** 3.32.0
- **K4os.Compression.LZ4** 1.3.8
- **System.Configuration.ConfigurationManager** 8.0.0

### Bước 3: Tạo database
1. Mở **phpMyAdmin**
2. Tạo database `kanban_simple`
3. Import file `database_update.sql`

### Bước 4: Cấu hình connection string
Mở `TaskRepository.cs` và chỉnh:
```csharp
private static string connectionString = 
    "Server=localhost;Database=kanban_simple;Port=3306;User Id=root;Password=;";
```

### Bước 5: Build & Run
```
F5 (hoặc Ctrl+F5)
```

---

## ✨ TÍNH NĂNG CHI TIẾT

### 1. Quản lý Task

| Tính năng | Mô tả | Trạng thái |
|----------|-------|------------|
| Xem danh sách task | Hiển thị theo 3 cột Kanban | ✅ Hoàn thành |
| Thêm task mới | Form nhập đầy đủ thông tin | ✅ Hoàn thành |
| Tìm kiếm task | Realtime theo tiêu đề | ✅ Hoàn thành |
| Lọc theo độ ưu tiên | Cao/TB/Thấp | ✅ Hoàn thành |
| Sắp xếp theo deadline | Tăng/Giảm dần | ✅ Hoàn thành |
| Đếm task quá hạn | Hiển thị số lượng | ✅ Hoàn thành |
| Kéo thả task | Thay đổi trạng thái | ❌ Chưa làm |
| Sửa task | Click vào card để sửa | ❌ Chưa làm |
| Xóa task | Nút xóa trên card | ❌ Chưa làm |

### 2. Báo cáo

| Tính năng | Mô tả | Trạng thái |
|----------|-------|------------|
| Xuất CSV | Toàn bộ task | ✅ Hoàn thành |
| Xuất PDF | Báo cáo chi tiết | ❌ Chưa làm |
| Thống kê | Biểu đồ tròn/cột | ❌ Chưa làm |

### 3. Quản lý thành viên

| Tính năng | Mô tả | Trạng thái |
|----------|-------|------------|
| Xem danh sách | Bảng thành viên | ❌ Chưa làm |
| Thêm/Sửa/Xóa | CRUD thành viên | ❌ Chưa làm |

---

## 📊 LUỒNG DỮ LIỆU

```
┌─────────────────┐
│   Form1.cs      │
│  (Main Form)    │
└────────┬────────┘
         │ LoadAllTasks()
         ▼
┌─────────────────┐
│ TaskRepository  │ ◄──────► MySQL Database
│   .LoadTasks()  │          (kanban_simple)
└────────┬────────┘
         │ List<TaskModel>
         ▼
┌─────────────────┐
│ RefreshKanban   │
│ ApplyFilters()  │
└────────┬────────┘
         │ foreach task
         ▼
┌─────────────────┐
│   TaskItem      │ (UserControl)
│   .SetData()    │
└─────────────────┘
```

---

## 🎯 KẾ HOẠCH PHÁT TRIỂN

### Phase 1 - Core Features ✅ (Hoàn thành)
- [x] Layout cơ bản Kanban 3 cột
- [x] Kết nối MySQL
- [x] Load và hiển thị task
- [x] Thêm task mới
- [x] Tìm kiếm/Lọc/Sắp xếp
- [x] Xuất CSV
- [x] Giao diện hiện đại

### Phase 2 - Enhancement 🔄 (Đang làm)
- [ ] Kéo thả task giữa các cột
- [ ] Sửa/Xóa task
- [ ] Quản lý thành viên (CRUD)
- [ ] Phân quyền người dùng
- [ ] Ghi chú/Comment cho task

### Phase 3 - Advanced Features 📅 (Kế hoạch)
- [ ] Notification/Reminder
- [ ] Attachment file
- [ ] Activity log
- [ ] Dark mode
- [ ] Multi-language (EN/VN)
- [ ] Export PDF
- [ ] Dashboard analytics
- [ ] Mobile responsive (migrate to Blazor?)

---

## 🐛 KNOWN ISSUES & FIXES

### Issue 1: Chữ bị cắt ở Sidebar
**Nguyên nhân:** Width quá nhỏ  
**Giải pháp:** Tăng từ 220px → 250px ✅

### Issue 2: Thiếu bảng thanh_vien
**Nguyên nhân:** DB chưa migrate đầy đủ  
**Giải pháp:** Script `database_update.sql` ✅

### Issue 3: Cột do_uu_tien sai kiểu INT
**Nguyên nhân:** Tạo bảng bằng tay sai schema  
**Giải pháp:** DROP và tạo lại với VARCHAR(20) ✅

### Issue 4: Form Add Task không refresh Main Form
**Nguyên nhân:** Không reload sau khi thêm  
**Giải pháp:** Gọi `LoadAllTasks()` sau `ShowDialog()` ✅

---

## 📞 LIÊN HỆ & HỖ TRỢ

- **GitHub Repository:** https://github.com/Nguyen15idhue/btlwindow
- **Developer:** Nguyen15idhue
- **Email:** (thêm email nếu có)

---

## 📄 LICENSE

MIT License - Tự do sử dụng cho mục đích học tập và thương mại.

---

## 🙏 CREDITS

- **UI Design:** Flat Design inspired by Trello
- **Icons:** Emoji Unicode
- **Database:** MySQL via XAMPP
- **Framework:** .NET Framework 4.8
- **IDE:** Visual Studio 2022

---

**Cập nhật lần cuối:** `2024-12-15`  
**Version:** `1.0.0`

🎉 **Cảm ơn bạn đã sử dụng Kanban Task Manager!**

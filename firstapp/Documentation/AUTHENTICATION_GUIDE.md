# 🔐 HỆ THỐNG PHÂN QUYỀN - KANBAN TASK MANAGER

## 📋 TỔNG QUAN

Ứng dụng Kanban Task Manager đã được nâng cấp với **hệ thống đăng ký, đăng nhập và phân quyền** đầy đủ.

### 🎯 Tính năng mới

✅ **Đăng ký tài khoản** - Người dùng có thể tự tạo tài khoản  
✅ **Đăng nhập bảo mật** - Mật khẩu được mã hóa SHA256  
✅ **Phân quyền rõ ràng** - Quản lý (Manager) và Nhân viên (Employee)  
✅ **Kiểm soát truy cập** - Chỉ xem/sửa/xóa task của mình (Employee) hoặc tất cả (Manager)  
✅ **Phân công task** - Giao việc cho người khác trong nhóm  
✅ **Hiển thị người tạo** - Mỗi task hiển thị ai tạo và ai được giao  

---

## 👥 PHÂN QUYỀN

### 1. **Manager (Quản lý)** 🔑

**Quyền:**
- ✅ Xem TẤT CẢ task trong hệ thống
- ✅ Tạo task và giao cho bất kỳ ai
- ✅ Sửa/Xóa BẤT KỲ task nào (kể cả của người khác)
- ✅ Thay đổi trạng thái task
- ✅ Xuất báo cáo CSV

**Trường hợp sử dụng:**
- Trưởng nhóm phân công công việc
- Quản lý dự án theo dõi tiến độ
- Review và điều chỉnh task của team

---

### 2. **Employee (Nhân viên)** 👷

**Quyền:**
- ✅ Xem TẤT CẢ task trong hệ thống
- ✅ Tạo task mới
- ✅ Giao task cho người khác
- ⚠️ CHỈ sửa/xóa task DO MÌNH TẠO
- ✅ Thay đổi trạng thái task được giao cho mình
- ✅ Xuất báo cáo CSV

**Trường hợp sử dụng:**
- Nhân viên tạo task cho công việc của mình
- Nhân viên phối hợp với đồng nghiệp (giao task cho nhau)
- Nhân viên báo cáo vấn đề cho quản lý (tạo task cho Manager)

---

## 🚀 CÀI ĐẶT VÀ SỬ DỤNG

### Bước 1: Import Database

```sql
-- Mở phpMyAdmin
-- Chạy file: database_with_auth.sql
```

File SQL này sẽ tạo:
- Bảng `nguoi_dung` (users)
- Bảng `cong_viec` (tasks) với foreign keys
- 5 tài khoản mẫu
- 9 tasks mẫu

---

### Bước 2: Đăng nhập

Khi khởi động ứng dụng, bạn sẽ thấy **màn hình đăng nhập**.

#### Tài khoản mẫu:

| Email | Mật khẩu | Vai trò | Mô tả |
|-------|----------|---------|-------|
| `manager@kanban.com` | `123456` | Manager | Quản lý - Toàn quyền |
| `employee1@kanban.com` | `123456` | Employee | Nhân viên 1 |
| `employee2@kanban.com` | `123456` | Employee | Nhân viên 2 |
| `employee3@kanban.com` | `123456` | Employee | Nhân viên 3 |
| `manager2@kanban.com` | `123456` | Manager | Quản lý 2 |

---

### Bước 3: Đăng ký tài khoản mới (tùy chọn)

1. Click nút **"📝 Đăng ký tài khoản mới"**
2. Nhập thông tin:
   - Họ tên
   - Email (phải unique)
   - Mật khẩu (tối thiểu 6 ký tự)
   - Xác nhận mật khẩu
   - Vai trò (Manager/Employee)
3. Click **"✅ Đăng ký"**
4. Quay lại màn hình đăng nhập

---

## 🎨 GIAO DIỆN MỚI

### Màn hình Đăng nhập

```
┌──────────────────────────────────┐
│  🔐 Đăng nhập                   │
│  Quản lý công việc Kanban       │
├──────────────────────────────────┤
│  Email:    [________________]   │
│  Mật khẩu: [________________]   │
│  ☐ Hiển thị mật khẩu            │
├──────────────────────────────────┤
│  [🚀 Đăng nhập]                  │
│  [📝 Đăng ký tài khoản mới]     │
│  [❌ Thoát]                      │
└──────────────────────────────────┘
```

---

### Màn hình Đăng ký

```
┌──────────────────────────────────┐
│  📝 Đăng ký                     │
│  Tạo tài khoản mới miễn phí     │
├──────────────────────────────────┤
│  Họ tên:            [_________] │
│  Email:             [_________] │
│  Mật khẩu:          [_________] │
│  Xác nhận MK:       [_________] │
│  Vai trò:           [▼ Dropdown]│
│  ☐ Hiển thị mật khẩu            │
├──────────────────────────────────┤
│  [✅ Đăng ký]                    │
│  [❌ Hủy]                        │
└──────────────────────────────────┘
```

---

### Màn hình chính (Kanban Board)

**Sidebar** giờ hiển thị:
```
┌─────────────────────┐
│   📋 KANBAN        │
├─────────────────────┤
│ 🏠 Bảng điều khiển │
│ ➕ Thêm Task mới   │
│ 👥 Quản lý TV      │
│                     │
│                     │
│                     │
│ 👤 Nguyễn Văn A    │  ← Tên user
│ 🔑 Quản lý         │  ← Vai trò
│ [🚪 Đăng xuất]     │  ← Nút logout
└─────────────────────┘
```

---

## 📊 CẤU TRÚC DATABASE MỚI

### Bảng `nguoi_dung`

```sql
CREATE TABLE nguoi_dung (
    id INT AUTO_INCREMENT PRIMARY KEY,
    ho_ten VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    mat_khau VARCHAR(255) NOT NULL,  -- SHA256 hash
    role VARCHAR(20) NOT NULL,       -- Manager / Employee
    ngay_tao DATETIME DEFAULT CURRENT_TIMESTAMP
);
```

---

### Bảng `cong_viec` (CẬP NHẬT)

```sql
CREATE TABLE cong_viec (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tieu_de VARCHAR(200) NOT NULL,
    mo_ta TEXT NULL,
    trang_thai VARCHAR(20) DEFAULT 'Todo',
    nguoi_tao_id INT NULL,           -- ← MỚI: Người tạo
    nguoi_duoc_giao_id INT NULL,     -- Người được giao
    do_uu_tien VARCHAR(20),
    han_hoan_thanh DATETIME NULL,
    ngay_tao DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (nguoi_tao_id) REFERENCES nguoi_dung(id),
    FOREIGN KEY (nguoi_duoc_giao_id) REFERENCES nguoi_dung(id)
);
```

---

## 🔒 BẢO MẬT

### Mã hóa mật khẩu

- Sử dụng **SHA256** để hash mật khẩu
- Mật khẩu KHÔNG được lưu dạng plain text
- Class: `UserRepository.HashPassword()`

```csharp
// Ví dụ: "123456" -> SHA256
// 8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92
```

### Kiểm tra quyền

```csharp
// Trong TaskModel.cs
public bool CanEdit(int currentUserId, bool isManager)
{
    if (isManager) return true;
    return NguoiTaoId == currentUserId;
}
```

---

## 📝 LUỒNG HOẠT ĐỘNG

### 1. Đăng ký → Đăng nhập

```
User → [Đăng ký] → Nhập thông tin 
     → Validate → Hash password 
     → INSERT database → [Đăng nhập]
```

### 2. Manager tạo task và giao cho Employee

```
Manager đăng nhập
     ↓
Click "➕ Thêm Task mới"
     ↓
Nhập: Tiêu đề, Mô tả, Deadline, Độ ưu tiên
     ↓
Chọn người được giao: Employee B
     ↓
Lưu task (nguoi_tao_id = Manager, nguoi_duoc_giao_id = Employee B)
     ↓
Employee B thấy task và bắt đầu làm
```

### 3. Employee tạo task cho Manager (Báo cáo vấn đề)

```
Employee đăng nhập
     ↓
Click "➕ Thêm Task mới"
     ↓
Nhập: "Bug nghiêm trọng trên production"
     ↓
Giao cho: Manager
     ↓
Lưu task (nguoi_tao_id = Employee, nguoi_duoc_giao_id = Manager)
     ↓
Manager thấy và xử lý
```

### 4. Employee cố sửa task của người khác

```
Employee đăng nhập
     ↓
Thấy task của Employee khác
     ↓
Click sửa/xóa
     ↓
❌ HỆ THỐNG CHẶN: "Bạn không có quyền sửa task này!"
```

---

## 🛠️ CÁC FILES MỚI

| File | Mô tả |
|------|-------|
| `UserModel.cs` | Model User, CurrentUser |
| `UserRepository.cs` | CRUD users, login, register |
| `frmLogin.cs` | Form đăng nhập |
| `frmLogin.Designer.cs` | UI đăng nhập |
| `frmLogin.resx` | Resources |
| `frmRegister.cs` | Form đăng ký |
| `frmRegister.Designer.cs` | UI đăng ký |
| `frmRegister.resx` | Resources |
| `database_with_auth.sql` | Schema mới với auth |

---

## 📦 CẬP NHẬT FILES CŨ

| File | Thay đổi |
|------|----------|
| `Program.cs` | Hiển thị Login trước Form1 |
| `Form1.cs` | Thêm user info, logout |
| `Form1.Designer.cs` | Thêm labels và button |
| `TaskModel.cs` | Thêm NguoiTaoId, CanEdit() |
| `TaskRepository.cs` | LoadTasks với JOIN, AddTask với creator |
| `frmAddTask.cs` | Truyền CurrentUser.Id khi tạo task |

---

## 🎯 KỊCH BẢN TEST

### Test 1: Đăng ký tài khoản

1. Chạy ứng dụng
2. Click "📝 Đăng ký tài khoản mới"
3. Nhập:
   - Họ tên: `Test User`
   - Email: `test@kanban.com`
   - Mật khẩu: `123456`
   - Xác nhận: `123456`
   - Vai trò: `Employee`
4. ✅ Đăng ký thành công

---

### Test 2: Đăng nhập Manager

1. Email: `manager@kanban.com`
2. Password: `123456`
3. ✅ Vào được dashboard
4. ✅ Thấy "🔑 Quản lý" ở sidebar
5. ✅ Có thể xem/sửa/xóa mọi task

---

### Test 3: Employee cố xóa task của người khác

1. Đăng nhập: `employee1@kanban.com`
2. Thấy task do Manager tạo
3. Click nút xóa (nếu có)
4. ❌ Bị chặn: "Không có quyền!"

---

### Test 4: Phân công task

1. Manager đăng nhập
2. Tạo task "Làm báo cáo tháng 12"
3. Giao cho: Employee B
4. Đăng xuất
5. Employee B đăng nhập
6. ✅ Thấy task được giao
7. ✅ Có thể chuyển trạng thái Todo → Doing → Done

---

## ❓ FAQ

**Q: Tôi quên mật khẩu?**  
A: Hiện tại chưa có tính năng reset password. Liên hệ admin để reset trong database.

**Q: Có thể đổi vai trò sau khi đăng ký?**  
A: Hiện tại chưa có UI. Admin có thể UPDATE trực tiếp trong database.

**Q: Employee có thể xóa task được giao cho mình không?**  
A: KHÔNG. Chỉ người TẠO task mới có quyền xóa.

**Q: Manager có thể sửa task của Manager khác không?**  
A: CÓ. Manager có toàn quyền với mọi task.

---

## 🔮 KẾ HOẠCH TƯƠNG LAI

- [ ] Reset password qua email
- [ ] Đổi vai trò trong UI
- [ ] Activity log (ai làm gì, khi nào)
- [ ] Notification realtime
- [ ] Chat/Comment trong task
- [ ] File attachment
- [ ] Two-factor authentication (2FA)
- [ ] Role-based dashboard (Manager thấy thống kê khác Employee)

---

## 🙏 CREDITS

- **Developer:** GitHub Copilot & Nguyen15idhue
- **Framework:** .NET Framework 4.8
- **Database:** MySQL 5.7+
- **UI:** Windows Forms (Flat Design)

---

**Version:** 2.0.0 (Authentication & Authorization Update)  
**Release Date:** 2024-12-15  

🎉 **Chúc bạn quản lý task hiệu quả!**

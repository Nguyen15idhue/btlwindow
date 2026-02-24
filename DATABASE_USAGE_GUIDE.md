# 🎯 HƯỚNG DẪN SỬ DỤNG DATABASE

## ⚡ QUICK START

### 📥 Import Database (Chọn 1 trong 3 cách)

#### Cách 1: MySQL Command Line
```bash
# Windows
cd C:\Users\ADMIN\source\repos\firstapp\firstapp\Database
mysql -u root -p < full_database_setup.sql

# Hoặc nếu cần chỉ định database
mysql -u root -p kanban_simple < full_database_setup.sql
```

#### Cách 2: phpMyAdmin
1. Mở phpMyAdmin (thường là http://localhost/phpmyadmin)
2. Click tab "Import" ở menu trên
3. Click "Choose File" và chọn: `firstapp/Database/full_database_setup.sql`
4. Cuộn xuống dưới và click "Go"
5. Đợi ~2-3 giây cho đến khi thấy "Import has been successfully finished"

#### Cách 3: MySQL Workbench
1. Mở MySQL Workbench
2. Connect vào MySQL server
3. File → Open SQL Script
4. Chọn file `full_database_setup.sql`
5. Click icon ⚡ Execute (hoặc Ctrl+Shift+Enter)

---

## 🔐 TÀI KHOẢN LOGIN

### Manager (Quản lý)
```
Email: manager@kanban.com
Password: 123456
Quyền hạn: 
  ✅ Xem TẤT CẢ tasks
  ✅ Sửa TẤT CẢ tasks
  ✅ Xóa TẤT CẢ tasks
  ✅ Tạo task mới
```

### Employee 1
```
Email: employee1@kanban.com
Password: 123456
Quyền hạn:
  ✅ Xem tasks DO MÌNH TẠO
  ✅ Sửa tasks DO MÌNH TẠO
  ✅ Xóa tasks DO MÌNH TẠO
  ✅ Tạo task mới
  ❌ KHÔNG xem/sửa/xóa tasks của người khác
```

### Employee 2 & 3
```
Email: employee2@kanban.com / employee3@kanban.com
Password: 123456
(Tương tự Employee 1)
```

---

## 📊 DATABASE SCHEMA

### Bảng: `nguoi_dung` (Users)
```sql
CREATE TABLE nguoi_dung (
    id INT PRIMARY KEY AUTO_INCREMENT,
    ho_ten VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    mat_khau VARCHAR(255) NOT NULL,  -- SHA256 hash
    role VARCHAR(20) DEFAULT 'Employee',
    ngay_tao DATETIME DEFAULT CURRENT_TIMESTAMP
);
```

### Bảng: `thanh_vien` (Members)
```sql
CREATE TABLE thanh_vien (
    id INT PRIMARY KEY AUTO_INCREMENT,
    ho_ten VARCHAR(100) NOT NULL,
    email VARCHAR(100),
    so_dien_thoai VARCHAR(20),
    ngay_tao DATETIME DEFAULT CURRENT_TIMESTAMP
);
```

### Bảng: `cong_viec` (Tasks)
```sql
CREATE TABLE cong_viec (
    id INT PRIMARY KEY AUTO_INCREMENT,
    tieu_de VARCHAR(200) NOT NULL,
    mo_ta TEXT,
    trang_thai VARCHAR(20) DEFAULT 'Todo',
    nguoi_tao_id INT,
    nguoi_duoc_giao_id INT,
    do_uu_tien VARCHAR(20) DEFAULT 'Trung bình',
    han_hoan_thanh DATETIME,
    ngay_tao DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (nguoi_tao_id) REFERENCES nguoi_dung(id),
    FOREIGN KEY (nguoi_duoc_giao_id) REFERENCES nguoi_dung(id)
);
```

---

## 🔧 CẤU HÌNH CONNECTION STRING

### App.config
```xml
<connectionStrings>
    <add name="MySqlConnection" 
         connectionString="Server=localhost;Port=3306;Database=kanban_simple;Uid=root;Pwd=YOUR_PASSWORD;charset=utf8mb4;" 
         providerName="MySql.Data.MySqlClient"/>
</connectionStrings>
```

**Thay đổi:**
- `Pwd=YOUR_PASSWORD` → Mật khẩu MySQL của bạn
- `Server=localhost` → Địa chỉ server MySQL (nếu khác)
- `Port=3306` → Port MySQL (nếu khác)

---

## ✅ KIỂM TRA DATABASE

### Verify Installation
```sql
-- 1. Kiểm tra database có tồn tại
SHOW DATABASES LIKE 'kanban_simple';

-- 2. Kiểm tra các bảng
USE kanban_simple;
SHOW TABLES;

-- 3. Kiểm tra số lượng records
SELECT 'Users' AS table_name, COUNT(*) AS total FROM nguoi_dung
UNION ALL
SELECT 'Members', COUNT(*) FROM thanh_vien
UNION ALL
SELECT 'Tasks', COUNT(*) FROM cong_viec;

-- 4. Kiểm tra user accounts
SELECT id, ho_ten, email, role FROM nguoi_dung;

-- 5. Kiểm tra tasks
SELECT 
    cv.id,
    cv.tieu_de,
    cv.trang_thai,
    cv.do_uu_tien,
    u1.ho_ten AS nguoi_tao,
    u2.ho_ten AS nguoi_duoc_giao
FROM cong_viec cv
LEFT JOIN nguoi_dung u1 ON cv.nguoi_tao_id = u1.id
LEFT JOIN nguoi_dung u2 ON cv.nguoi_duoc_giao_id = u2.id;
```

**Kết quả mong đợi:**
- ✅ 5 users (1 Manager, 4 Employees)
- ✅ 5 members
- ✅ 9 tasks (3 Todo, 3 Doing, 3 Done)

---

## 🚨 TROUBLESHOOTING

### Lỗi: "Database kanban_simple already exists"
```sql
-- Option 1: Xóa database cũ (MẤT DỮ LIỆU!)
DROP DATABASE IF EXISTS kanban_simple;

-- Rồi chạy lại full_database_setup.sql

-- Option 2: Chỉ xóa và tạo lại các bảng
USE kanban_simple;
DROP TABLE IF EXISTS cong_viec;
DROP TABLE IF EXISTS thanh_vien;
DROP TABLE IF EXISTS nguoi_dung;

-- Rồi chạy lại phần CREATE TABLE trong file SQL
```

### Lỗi: "Access denied for user 'root'@'localhost'"
```bash
# Kiểm tra mật khẩu MySQL
mysql -u root -p

# Hoặc reset password (nếu quên)
# Xem hướng dẫn tại: https://dev.mysql.com/doc/refman/8.0/en/resetting-permissions.html
```

### Lỗi: "Unknown database 'kanban_simple'"
```sql
-- Tạo database trước
CREATE DATABASE kanban_simple CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Rồi chạy lại import
```

### Lỗi charset/encoding
```sql
-- Đảm bảo database sử dụng UTF8MB4
ALTER DATABASE kanban_simple CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Kiểm tra charset của bảng
SHOW CREATE TABLE cong_viec;
```

---

## 📚 TÀI LIỆU BỔ SUNG

- 📄 `README_MIGRATIONS_AND_SEEDS.md` - Chi tiết về migrations và seeds
- 📄 `database_with_auth.sql` - Schema với authentication
- 📄 `database_update.sql` - Updates bổ sung

---

## 💡 MẸO HỮU ÍCH

### Backup Database
```bash
# Backup toàn bộ database
mysqldump -u root -p kanban_simple > backup_$(date +%Y%m%d).sql

# Backup chỉ schema (không có data)
mysqldump -u root -p --no-data kanban_simple > schema_only.sql

# Backup chỉ data (không có schema)
mysqldump -u root -p --no-create-info kanban_simple > data_only.sql
```

### Reset Database về trạng thái ban đầu
```bash
cd C:\Users\ADMIN\source\repos\firstapp\firstapp\Database
mysql -u root -p -e "DROP DATABASE IF EXISTS kanban_simple;"
mysql -u root -p < full_database_setup.sql
```

### Test Connection từ C#
```csharp
using MySql.Data.MySqlClient;

string connStr = "Server=localhost;Database=kanban_simple;Uid=root;Pwd=YOUR_PASSWORD;";
using (MySqlConnection conn = new MySqlConnection(connStr))
{
    try
    {
        conn.Open();
        Console.WriteLine("✅ Connected successfully!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Connection failed: {ex.Message}");
    }
}
```

---

**✅ DONE! Database đã sẵn sàng sử dụng.**

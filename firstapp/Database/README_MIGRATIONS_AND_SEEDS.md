# 📚 DATABASE MIGRATIONS & SEEDS - HƯỚNG DẪN HOÀN CHỈNH

## 🎯 TỔNG QUAN

Hệ thống migration và seeding cho **Kanban Task Manager** giúp quản lý database một cách chuyên nghiệp, dễ dàng rollback và track changes.

---

## 📁 CẤU TRÚC THƯ MỤC

```
firstapp/Database/
├── full_database_setup.sql          ← Master setup file (Chạy file này!)
├── db-config.json                   ← Database config
│
├── Migrations/                      ← 7 migration files
│   ├── 001_create_tags_table.sql
│   ├── 002_create_nhom_cong_viec_table.sql
│   ├── 003_create_task_tags_relation.sql
│   ├── 004_add_nhom_id_to_tasks.sql
│   ├── 005_create_full_task_view.sql
│   ├── 006_create_stored_procedures.sql
│   └── 007_add_performance_indexes.sql
│
├── Seeds/                           ← 5 seeder files (dữ liệu mẫu)
│   ├── 001_users_seeder.sql        → 10 users
│   ├── 002_tags_seeder.sql         → 20 tags
│   ├── 003_groups_seeder.sql       → 10 nhóm
│   ├── 004_tasks_seeder.sql        → 17 tasks
│   └── 005_task_tags_seeder.sql    → Relations
│
├── Scripts/                         ← PowerShell automation
│   ├── migrate.ps1                 → Migration runner
│   ├── seed.ps1                    → Seeder runner
│   ├── test-connection.ps1         → Test DB connection
│   └── detect-mysql.ps1            → Auto detect MySQL
│
└── Docs/
    └── README_MIGRATIONS_AND_SEEDS.md  ← File này
```

---

## 🚀 QUICK START (3 BƯỚC)

### Cách 1: Chạy trực tiếp SQL (NHANH NHẤT)

```bash
# 1. Start MySQL
Mở XAMPP → Click "Start" MySQL

# 2. Mở phpMyAdmin
http://localhost/phpmyadmin

# 3. Chạy SQL
- Vào tab "SQL"
- Copy toàn bộ file: firstapp/Database/full_database_setup.sql
- Paste và click "Go"

# ✅ XONG!
```

### Cách 2: PowerShell Scripts

```powershell
# Di chuyển vào thư mục Scripts
cd firstapp/Database/Scripts

# Chạy migration
.\migrate.ps1 up

# XONG! Database đã sẵn sàng
```

---

## 📊 DATABASE SCHEMA

### Tables:

1. **nguoi_dung** (Users)
   - id, ho_ten, email, mat_khau (SHA256), role, ngay_tao

2. **nhom_cong_viec** (Work Groups)
   - id, ten_nhom, mo_ta, mau_nhom, ngay_tao

3. **tags** (Tags)
   - id, ten_tag, mau_tag, mo_ta, ngay_tao

4. **cong_viec** (Tasks)
   - id, tieu_de, mo_ta, trang_thai, nguoi_tao_id, nguoi_duoc_giao_id
   - nhom_id, han_hoan_thanh, do_uu_tien, ngay_tao, ngay_cap_nhat

5. **cong_viec_tags** (Task-Tag Relations)
   - id, cong_viec_id, tag_id, ngay_them

6. **schema_migrations** (Migration tracking)
   - id, migration_name, executed_at

### View:

- **v_cong_viec_full**: View với JOIN đầy đủ thông tin (users, tags, groups)

### Stored Procedures:

- `sp_add_tag_to_task(cong_viec_id, tag_id)`
- `sp_remove_tag_from_task(cong_viec_id, tag_id)`
- `sp_get_tasks_by_status(trang_thai)`
- `sp_get_overdue_tasks()`

---

## 🎮 SỬ DỤNG POWERSH SCRIPTS

### Test Connection

```powershell
.\test-connection.ps1

# Output:
# ✅ Kết nối MySQL thành công!
# Database: kanban_simple
# Version: 8.0.x
```

### Migrate

```powershell
# Chạy tất cả migrations
.\migrate.ps1 up

# Reset database (xóa hết và chạy lại)
.\migrate.ps1 fresh

# Kiểm tra status
.\migrate.ps1 status

# Xem help
.\migrate.ps1 help
```

### Seed Data

```powershell
# Chạy tất cả seeders
.\seed.ps1

# Chạy seeder cụ thể
.\seed.ps1 001

# Xem help
.\seed.ps1 help
```

---

## 📝 CHI TIẾT MIGRATIONS

### Migration 001: Create Tags Table
- Tạo bảng `tags`
- Indexes: ten_tag
- 20 tags mặc định

### Migration 002: Create Groups Table
- Tạo bảng `nhom_cong_viec`
- Indexes: ten_nhom
- 10 nhóm mặc định

### Migration 003: Create Task-Tag Relation
- Tạo bảng `cong_viec_tags` (many-to-many)
- Foreign keys CASCADE
- Unique constraint

### Migration 004: Add Group to Tasks
- Thêm cột `nhom_id` vào `cong_viec`
- Foreign key SET NULL
- Index

### Migration 005: Create Full Task View
- View `v_cong_viec_full`
- JOIN 4 tables
- GROUP_CONCAT tags

### Migration 006: Create Stored Procedures
- 4 procedures
- Add/Remove tags
- Get tasks by status
- Get overdue tasks

### Migration 007: Add Performance Indexes
- Index search: `tieu_de`
- Index filters: `trang_thai`, `do_uu_tien`
- Index dates: `han_hoan_thanh`, `ngay_tao`

---

## 🌱 CHI TIẾT SEEDERS

### Seeder 001: Users (10 users)
```
Managers:
- manager@kanban.com / 123456
- admin@kanban.com / 123456
- pm@kanban.com / 123456

Employees:
- dev1@kanban.com / 123456
- designer@kanban.com / 123456
- tester@kanban.com / 123456
- dev2@kanban.com / 123456
- dev3@kanban.com / 123456

Test Accounts:
- test@manager.com / 123456
- test@employee.com / 123456
```

### Seeder 002: Tags (20 tags)
Frontend, Backend, API, Bug, Feature, Testing, UI/UX, Performance, Security, DevOps, Database, Documentation, Refactoring, Enhancement, Critical, Low Priority, Medium Priority, Research, Deployment, Review

### Seeder 003: Groups (10 groups)
Sprint 1, Sprint 2, Sprint 3, Bug Fixes, Development, Testing, Infrastructure, Maintenance, Research, Deployment

### Seeder 004: Tasks (17 tasks)
- 6 Todo tasks
- 4 Doing tasks
- 7 Done tasks

### Seeder 005: Task-Tag Relations
Link tasks với tags (many-to-many)

---

## ⚙️ CONFIG FILE: db-config.json

```json
{
  "host": "localhost",
  "port": 3306,
  "database": "kanban_simple",
  "user": "root",
  "password": "",
  "charset": "utf8mb4"
}
```

---

## 🐛 TROUBLESHOOTING

### Lỗi: "Access denied for user"
```sql
-- Kiểm tra password MySQL
mysql -u root -p

-- Hoặc đặt lại password:
ALTER USER 'root'@'localhost' IDENTIFIED BY '';
```

### Lỗi: "Database already exists"
```sql
-- Xóa database cũ
DROP DATABASE kanban_simple;

-- Chạy lại setup
SOURCE full_database_setup.sql;
```

### Lỗi: "Table already exists"
```powershell
# Dùng migrate fresh
.\migrate.ps1 fresh
```

### Lỗi PowerShell: "execution policy"
```powershell
Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser
```

---

## 🎯 BEST PRACTICES

### 1. Migration Naming
```
[number]_[action]_[table]_[description].sql

Ví dụ:
001_create_tags_table.sql
002_add_column_to_users.sql
003_create_index_on_tasks.sql
```

### 2. Rollback Strategy
```sql
-- Mỗi migration nên có rollback
-- Ví dụ trong migration file:

-- UP
CREATE TABLE my_table (...);

-- DOWN (comment)
-- DROP TABLE my_table;
```

### 3. Seeding Data
```sql
-- Dùng INSERT IGNORE để tránh duplicate
INSERT IGNORE INTO tags (ten_tag) VALUES ('Bug');

-- Hoặc dùng ON DUPLICATE KEY UPDATE
INSERT INTO tags (ten_tag) VALUES ('Bug')
ON DUPLICATE KEY UPDATE ten_tag = 'Bug';
```

---

## 📚 TÀI LIỆU THAM KHẢO

- [MySQL Documentation](https://dev.mysql.com/doc/)
- [Migration Best Practices](https://www.liquibase.org/get-started/best-practices)
- [Database Seeding](https://laravel.com/docs/seeding)

---

## ✅ CHECKLIST SETUP

- [ ] XAMPP installed
- [ ] MySQL running
- [ ] Database created: `kanban_simple`
- [ ] Migrations executed
- [ ] Seeders executed (optional)
- [ ] Test connection successful
- [ ] Application connects successfully

---

**Version:** 2.1  
**Last Updated:** 2024  
**Maintained By:** GitHub Copilot

---

🎉 **HAPPY MIGRATING!** 🚀

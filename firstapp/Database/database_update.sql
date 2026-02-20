-- ============================================================
-- SQL SCRIPT: Cập nhật database kanban_simple
-- ============================================================

-- 1. Tạo bảng thanh_vien (nếu chưa có)
CREATE TABLE IF NOT EXISTS thanh_vien (
    id INT AUTO_INCREMENT PRIMARY KEY,
    ho_ten VARCHAR(100) NOT NULL,
    email VARCHAR(100),
    so_dien_thoai VARCHAR(20),
    ngay_tao DATETIME DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 2. Thêm dữ liệu mẫu cho thanh_vien (chỉ nếu bảng trống)
INSERT IGNORE INTO thanh_vien (id, ho_ten, email) VALUES 
(1, 'Nguyễn Văn A', 'nguyenvana@email.com'),
(2, 'Trần Thị B', 'tranthib@email.com'),
(3, 'Lê Văn C', 'levanc@email.com'),
(4, 'Phạm Thị D', 'phamthid@email.com'),
(5, 'Hoàng Văn E', 'hoangvane@email.com');

-- 3. Thêm cột mo_ta nếu chưa có
ALTER TABLE cong_viec ADD COLUMN IF NOT EXISTS mo_ta TEXT NULL;

-- 4. Xóa cột do_uu_tien cũ (nếu có) và tạo lại với kiểu VARCHAR
-- Bước 4a: Xóa cột cũ nếu có (kiểu INT sai)
ALTER TABLE cong_viec DROP COLUMN IF EXISTS do_uu_tien;

-- Bước 4b: Thêm cột mới với kiểu VARCHAR
ALTER TABLE cong_viec ADD COLUMN do_uu_tien VARCHAR(20) DEFAULT 'Trung bình';

-- 5. Cập nhật dữ liệu mẫu cho độ ưu tiên
UPDATE cong_viec SET do_uu_tien = 'Cao' WHERE id % 3 = 0;
UPDATE cong_viec SET do_uu_tien = 'Trung bình' WHERE id % 3 = 1;
UPDATE cong_viec SET do_uu_tien = 'Thấp' WHERE id % 3 = 2;

-- ============================================================
-- Hoàn tất! Chạy script này trong phpMyAdmin hoặc MySQL Workbench
-- ============================================================

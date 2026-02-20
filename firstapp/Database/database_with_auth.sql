-- ========================================
-- KANBAN TASK MANAGER - DATABASE SETUP
-- Phiên bản với phân quyền User
-- ========================================

-- Tạo database nếu chưa có
CREATE DATABASE IF NOT EXISTS kanban_simple CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE kanban_simple;

-- ========================================
-- 1. Bảng NGƯỜI DÙNG (Users)
-- ========================================
DROP TABLE IF EXISTS nguoi_dung;
CREATE TABLE nguoi_dung (
    id INT AUTO_INCREMENT PRIMARY KEY,
    ho_ten VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    mat_khau VARCHAR(255) NOT NULL,  -- Đã hash SHA256
    role VARCHAR(20) NOT NULL DEFAULT 'Employee',  -- Manager hoặc Employee
    ngay_tao DATETIME DEFAULT CURRENT_TIMESTAMP,
    INDEX idx_email (email),
    INDEX idx_role (role)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ========================================
-- 2. Bảng CÔNG VIỆC (Tasks) - CẬP NHẬT
-- ========================================
DROP TABLE IF EXISTS cong_viec;
CREATE TABLE cong_viec (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tieu_de VARCHAR(200) NOT NULL,
    mo_ta TEXT NULL,
    trang_thai VARCHAR(20) DEFAULT 'Todo',
    nguoi_tao_id INT NULL,                -- Người tạo task
    nguoi_duoc_giao_id INT NULL,          -- Người được giao task
    do_uu_tien VARCHAR(20) DEFAULT 'Trung bình',
    han_hoan_thanh DATETIME NULL,
    ngay_tao DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (nguoi_tao_id) REFERENCES nguoi_dung(id) ON DELETE SET NULL,
    FOREIGN KEY (nguoi_duoc_giao_id) REFERENCES nguoi_dung(id) ON DELETE SET NULL,
    INDEX idx_trang_thai (trang_thai),
    INDEX idx_nguoi_tao (nguoi_tao_id),
    INDEX idx_nguoi_duoc_giao (nguoi_duoc_giao_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ========================================
-- 3. DỮ LIỆU MẪU - USERS
-- ========================================
-- Mật khẩu mặc định cho tất cả user: 123456
-- SHA256 hash của "123456" = 8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92

INSERT INTO nguoi_dung (ho_ten, email, mat_khau, role) VALUES
('Nguyễn Văn A (Manager)', 'manager@kanban.com', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'Manager'),
('Trần Thị B (Employee)', 'employee1@kanban.com', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'Employee'),
('Lê Văn C (Employee)', 'employee2@kanban.com', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'Employee'),
('Phạm Thị D (Employee)', 'employee3@kanban.com', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'Employee'),
('Hoàng Văn E (Manager)', 'manager2@kanban.com', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'Manager');

-- ========================================
-- 4. DỮ LIỆU MẪU - TASKS
-- ========================================
INSERT INTO cong_viec (tieu_de, mo_ta, trang_thai, nguoi_tao_id, nguoi_duoc_giao_id, do_uu_tien, han_hoan_thanh) VALUES
-- Tasks do Manager tạo
('Thiết kế giao diện trang chủ', 'Tạo mockup cho trang chủ website công ty', 'Todo', 1, 2, 'Cao', DATE_ADD(NOW(), INTERVAL 3 DAY)),
('Viết API đăng nhập', 'Implement JWT authentication cho backend', 'Doing', 1, 3, 'Cao', DATE_ADD(NOW(), INTERVAL 5 DAY)),
('Review code module thanh toán', 'Kiểm tra và merge PR #123', 'Todo', 1, 5, 'Trung bình', DATE_ADD(NOW(), INTERVAL 2 DAY)),

-- Tasks do Employees tạo
('Fix bug hiển thị trên mobile', 'Responsive layout bị lỗi trên màn hình nhỏ', 'Todo', 2, 2, 'Cao', DATE_ADD(NOW(), INTERVAL 1 DAY)),
('Cập nhật tài liệu API', 'Thêm mô tả cho các endpoint mới', 'Doing', 3, 3, 'Thấp', DATE_ADD(NOW(), INTERVAL 7 DAY)),
('Test tính năng xuất báo cáo', 'Kiểm tra xuất PDF và CSV', 'Done', 4, 4, 'Trung bình', DATE_SUB(NOW(), INTERVAL 2 DAY)),
('Optimize database queries', 'Cải thiện performance cho module báo cáo', 'Doing', 3, 3, 'Cao', DATE_ADD(NOW(), INTERVAL 4 DAY)),

-- Tasks quá hạn
('Setup CI/CD pipeline', 'Cấu hình Jenkins cho auto deployment', 'Todo', 1, 2, 'Cao', DATE_SUB(NOW(), INTERVAL 2 DAY)),
('Viết unit tests', 'Tăng coverage lên 80%', 'Doing', 2, 2, 'Trung bình', DATE_SUB(NOW(), INTERVAL 1 DAY));

-- ========================================
-- 5. THÔNG TIN ĐĂNG NHẬP MẪU
-- ========================================
/*
TÀI KHOẢN TEST:

1. Manager:
   Email: manager@kanban.com
   Password: 123456
   Quyền: Có thể xem, sửa, xóa TẤT CẢ tasks

2. Employee 1:
   Email: employee1@kanban.com
   Password: 123456
   Quyền: Chỉ xem, sửa, xóa tasks DO MÌNH TẠO

3. Employee 2:
   Email: employee2@kanban.com
   Password: 123456
   Quyền: Chỉ xem, sửa, xóa tasks DO MÌNH TẠO

*/

-- ========================================
-- 6. QUERIES HỮU ÍCH
-- ========================================

-- Xem tất cả users
-- SELECT * FROM nguoi_dung;

-- Xem tasks với thông tin người tạo và người được giao
-- SELECT 
--     cv.id,
--     cv.tieu_de,
--     cv.trang_thai,
--     u1.ho_ten AS nguoi_tao,
--     u2.ho_ten AS nguoi_duoc_giao,
--     cv.han_hoan_thanh,
--     cv.do_uu_tien
-- FROM cong_viec cv
-- LEFT JOIN nguoi_dung u1 ON cv.nguoi_tao_id = u1.id
-- LEFT JOIN nguoi_dung u2 ON cv.nguoi_duoc_giao_id = u2.id;

-- Thống kê tasks theo người tạo
-- SELECT 
--     u.ho_ten,
--     u.role,
--     COUNT(cv.id) AS so_task_tao,
--     SUM(CASE WHEN cv.trang_thai = 'Done' THEN 1 ELSE 0 END) AS task_hoan_thanh
-- FROM nguoi_dung u
-- LEFT JOIN cong_viec cv ON u.id = cv.nguoi_tao_id
-- GROUP BY u.id, u.ho_ten, u.role;

-- ========================================
-- HOÀN TẤT!
-- ========================================

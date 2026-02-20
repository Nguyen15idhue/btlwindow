using MySql.Data.MySqlClient; // Thư viện vừa cài
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms; // Để dùng MessageBox báo lỗi

namespace btlwindow
{
    public class TaskRepository
    {
        // 1. Cấu hình chuỗi kết nối (Connection String)
        // Lưu ý: Nếu dùng XAMPP mặc định thì password để trống, port là 3306.
        private static string connectionString = "Server=localhost;Database=kanban_simple;Port=3306;User Id=root;Password=;";

        // 2. Hàm lấy kết nối
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        // ==========================================================
        // HÀM 1: LoadTasks - Lấy toàn bộ danh sách công việc
        // ==========================================================
        public static List<TaskModel> LoadTasks()
        {
            List<TaskModel> list = new List<TaskModel>();

            // Query đơn giản không cần JOIN thanh_vien
            string query = @"SELECT id, tieu_de, 
                            IFNULL(mo_ta, '') as mo_ta, 
                            trang_thai, 
                            IFNULL(nguoi_duoc_giao_id, 0) as nguoi_duoc_giao_id, 
                            han_hoan_thanh, 
                            IFNULL(do_uu_tien, 'Trung bình') as do_uu_tien
                            FROM cong_viec";

            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TaskModel task = new TaskModel();
                            task.Id = reader.GetInt32("id");
                            task.TieuDe = reader.GetString("tieu_de");
                            task.MoTa = reader.GetString("mo_ta");
                            task.TrangThai = reader.GetString("trang_thai");
                            task.NguoiDuocGiaoId = reader.GetInt32("nguoi_duoc_giao_id");

                            if (!reader.IsDBNull(reader.GetOrdinal("han_hoan_thanh")))
                                task.HanHoanThanh = reader.GetDateTime("han_hoan_thanh");

                            task.DoUuTien = reader.GetString("do_uu_tien");
                            task.TenNguoiDuocGiao = task.NguoiDuocGiaoId > 0 ? "Người #" + task.NguoiDuocGiaoId : "Chưa giao";

                            list.Add(task);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message);
            }

            return list;
        }

        // ==========================================================
        // HÀM 2: AddTask - Thêm mới công việc (Phiên bản đầy đủ với người tạo)
        // ==========================================================
        public static bool AddTask(string tieuDe, string moTa, int nguoiTaoId, int nguoiDuocGiaoId, DateTime hanHoanThanh, string doUuTien)
        {
            string query = @"INSERT INTO cong_viec 
                            (tieu_de, mo_ta, nguoi_tao_id, nguoi_duoc_giao_id, han_hoan_thanh, do_uu_tien, trang_thai, ngay_tao) 
                            VALUES (@tieuDe, @moTa, @nguoiTao, @nguoiDuocGiao, @hanHoanThanh, @doUuTien, 'Todo', NOW())";

            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Dùng tham số @ để tránh lỗi SQL Injection (Bảo mật cơ bản)
                    cmd.Parameters.AddWithValue("@tieuDe", tieuDe);
                    cmd.Parameters.AddWithValue("@moTa", moTa ?? "");
                    cmd.Parameters.AddWithValue("@nguoiTao", nguoiTaoId > 0 ? (object)nguoiTaoId : DBNull.Value);
                    cmd.Parameters.AddWithValue("@nguoiDuocGiao", nguoiDuocGiaoId > 0 ? (object)nguoiDuocGiaoId : DBNull.Value);
                    cmd.Parameters.AddWithValue("@hanHoanThanh", hanHoanThanh);
                    cmd.Parameters.AddWithValue("@doUuTien", doUuTien ?? "Trung bình");

                    cmd.ExecuteNonQuery(); // Thực thi lệnh INSERT (không cần đọc về)
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm task: " + ex.Message);
                return false;
            }
        }

        // ==========================================================
        // HÀM 3: GetMembers - Lấy danh sách người dùng (thay thế GetMembers cũ)
        // ==========================================================
        public static List<KeyValuePair<int, string>> GetMembers()
        {
            var list = new List<KeyValuePair<int, string>>();

            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT id, ho_ten FROM nguoi_dung ORDER BY ho_ten";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            string name = reader.GetString("ho_ten");
                            list.Add(new KeyValuePair<int, string>(id, name));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy danh sách thành viên: " + ex.Message);
            }

            return list;
        }

        // ==========================================================
        // HÀM 4: ExportToCSV - Xuất báo cáo CSV
        // ==========================================================
        public static bool ExportToCSV(List<TaskModel> tasks, string filePath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.UTF8))
                {
                    // Ghi header
                    sw.WriteLine("ID,Tiêu đề,Mô tả,Trạng thái,Người thực hiện,Hạn hoàn thành,Độ ưu tiên,Quá hạn");

                    // Ghi dữ liệu
                    foreach (var task in tasks)
                    {
                        string line = string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\"",
                            task.Id,
                            EscapeCSV(task.TieuDe),
                            EscapeCSV(task.MoTa ?? ""),
                            task.TrangThai,
                            task.TenNguoiDuocGiao ?? "Chưa giao",
                            task.HanHoanThanh != DateTime.MinValue ? task.HanHoanThanh.ToString("dd/MM/yyyy") : "Không có",
                            task.DoUuTien ?? "Trung bình",
                            task.IsOverdue ? "Có" : "Không");
                        sw.WriteLine(line);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất CSV: " + ex.Message);
                return false;
            }
        }

        private static string EscapeCSV(string value)
        {
            if (string.IsNullOrEmpty(value)) return "";
            return value.Replace("\"", "\"\"");
        }

        // ==========================================================
        // HÀM 5: UpdateTaskStatus - Cập nhật trạng thái task
        // ==========================================================
        public static bool UpdateTaskStatus(int taskId, string newStatus)
        {
            string query = "UPDATE cong_viec SET trang_thai = @trangThai WHERE id = @id";

            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@trangThai", newStatus);
                    cmd.Parameters.AddWithValue("@id", taskId);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật trạng thái: " + ex.Message);
                return false;
            }
        }
    }
}
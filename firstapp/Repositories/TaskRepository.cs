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

            // Query với JOIN để lấy tên người tạo và người được giao
            string query = @"SELECT cv.*, 
                            ng_giao.ho_ten as ten_nguoi_duoc_giao,
                            ng_tao.ho_ten as ten_nguoi_tao,
                            n.ten_nhom, n.mau_sac as mau_nhom
                            FROM cong_viec cv
                            LEFT JOIN nguoi_dung ng_giao ON cv.nguoi_duoc_giao_id = ng_giao.id
                            LEFT JOIN nguoi_dung ng_tao ON cv.nguoi_tao_id = ng_tao.id
                            LEFT JOIN nhom_cong_viec n ON cv.nhom_id = n.id
                            ORDER BY cv.ngay_tao DESC";

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
                            task.MoTa = reader.IsDBNull(reader.GetOrdinal("mo_ta")) ? "" : reader.GetString("mo_ta");
                            task.TrangThai = reader.GetString("trang_thai");

                            // Người tạo
                            task.NguoiTaoId = reader.IsDBNull(reader.GetOrdinal("nguoi_tao_id")) ? 0 : reader.GetInt32("nguoi_tao_id");
                            task.TenNguoiTao = reader.IsDBNull(reader.GetOrdinal("ten_nguoi_tao")) ? "" : reader.GetString("ten_nguoi_tao");

                            // Người được giao
                            task.NguoiDuocGiaoId = reader.IsDBNull(reader.GetOrdinal("nguoi_duoc_giao_id")) ? 0 : reader.GetInt32("nguoi_duoc_giao_id");
                            task.TenNguoiDuocGiao = reader.IsDBNull(reader.GetOrdinal("ten_nguoi_duoc_giao")) ? "Chưa giao" : reader.GetString("ten_nguoi_duoc_giao");

                            if (!reader.IsDBNull(reader.GetOrdinal("han_hoan_thanh")))
                                task.HanHoanThanh = reader.GetDateTime("han_hoan_thanh");

                            task.DoUuTien = reader.IsDBNull(reader.GetOrdinal("do_uu_tien")) ? "Trung bình" : reader.GetString("do_uu_tien");

                            if (!reader.IsDBNull(reader.GetOrdinal("ngay_tao")))
                                task.NgayTao = reader.GetDateTime("ngay_tao");

                            // Nhóm
                            task.NhomId = reader.IsDBNull(reader.GetOrdinal("nhom_id")) ? (int?)null : reader.GetInt32("nhom_id");
                            task.TenNhom = reader.IsDBNull(reader.GetOrdinal("ten_nhom")) ? "" : reader.GetString("ten_nhom");
                            task.MauNhom = reader.IsDBNull(reader.GetOrdinal("mau_nhom")) ? "" : reader.GetString("mau_nhom");

                            list.Add(task);
                        }
                    }

                    // Load tags cho mỗi task
                    foreach (var task in list)
                    {
                        LoadTaskTags(task, conn);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message);
            }

            return list;
        }

        // Helper method để load tags cho 1 task
        private static void LoadTaskTags(TaskModel task, MySqlConnection conn)
        {
            string query = @"SELECT t.ten_tag, t.mau_sac 
                            FROM task_tag tt 
                            INNER JOIN tags t ON tt.tag_id = t.id 
                            WHERE tt.task_id = @taskId";
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@taskId", task.Id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        task.Tags.Add(reader.GetString("ten_tag"));
                        task.TagsColors.Add(reader.IsDBNull(reader.GetOrdinal("mau_sac")) ? "#3498db" : reader.GetString("mau_sac"));
                    }
                }
            }
            catch { }
        }

        // ==========================================================
        // HÀM 2: AddTask - Thêm mới công việc (Phiên bản đầy đủ với người tạo)
        // ==========================================================
        public static bool AddTask(string tieuDe, string moTa, int nguoiTaoId, int nguoiDuocGiaoId, DateTime hanHoanThanh, string doUuTien)
        {
            return AddTask(tieuDe, moTa, nguoiTaoId, nguoiDuocGiaoId, hanHoanThanh, doUuTien, null, null);
        }

        // Overload với nhomId và tags
        public static bool AddTask(string tieuDe, string moTa, int nguoiTaoId, int nguoiDuocGiaoId, DateTime hanHoanThanh, string doUuTien, int? nhomId, List<int> tagIds)
        {
            string query = @"INSERT INTO cong_viec 
                            (tieu_de, mo_ta, nguoi_tao_id, nguoi_duoc_giao_id, han_hoan_thanh, do_uu_tien, nhom_id, trang_thai, ngay_tao) 
                            VALUES (@tieuDe, @moTa, @nguoiTao, @nguoiDuocGiao, @hanHoanThanh, @doUuTien, @nhomId, 'Todo', NOW())";

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
                    cmd.Parameters.AddWithValue("@nhomId", nhomId.HasValue && nhomId.Value > 0 ? (object)nhomId.Value : DBNull.Value);

                    cmd.ExecuteNonQuery();

                    // Lấy ID của task vừa thêm
                    long taskId = cmd.LastInsertedId;

                    // Lưu tags vào bảng quan hệ task_tag
                    if (tagIds != null && tagIds.Count > 0)
                    {
                        foreach (int tagId in tagIds)
                        {
                            string tagQuery = "INSERT INTO task_tag (task_id, tag_id) VALUES (@taskId, @tagId)";
                            MySqlCommand tagCmd = new MySqlCommand(tagQuery, conn);
                            tagCmd.Parameters.AddWithValue("@taskId", taskId);
                            tagCmd.Parameters.AddWithValue("@tagId", tagId);
                            tagCmd.ExecuteNonQuery();
                        }
                    }

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

        // ==========================================================
        // HÀM 6: DeleteTask - Xóa task
        // ==========================================================
        public static bool DeleteTask(int taskId)
        {
            string query = "DELETE FROM cong_viec WHERE id = @id";

            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", taskId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa task: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ==========================================================
        // HÀM 7: UpdateTask - Cập nhật thông tin task
        // ==========================================================
        public static bool UpdateTask(int taskId, string tieuDe, string moTa, int nguoiDuocGiaoId, DateTime hanHoanThanh, string doUuTien)
        {
            return UpdateTask(taskId, tieuDe, moTa, nguoiDuocGiaoId, hanHoanThanh, doUuTien, null, null);
        }

        // Overload với nhomId và tags
        public static bool UpdateTask(int taskId, string tieuDe, string moTa, int nguoiDuocGiaoId, DateTime hanHoanThanh, string doUuTien, int? nhomId, List<int> tagIds)
        {
            string query = @"UPDATE cong_viec 
                            SET tieu_de = @tieuDe, 
                                mo_ta = @moTa, 
                                nguoi_duoc_giao_id = @nguoiDuocGiao, 
                                han_hoan_thanh = @hanHoanThanh, 
                                do_uu_tien = @doUuTien,
                                nhom_id = @nhomId
                            WHERE id = @id";

            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tieuDe", tieuDe);
                    cmd.Parameters.AddWithValue("@moTa", moTa ?? "");
                    cmd.Parameters.AddWithValue("@nguoiDuocGiao", nguoiDuocGiaoId > 0 ? (object)nguoiDuocGiaoId : DBNull.Value);
                    cmd.Parameters.AddWithValue("@hanHoanThanh", hanHoanThanh);
                    cmd.Parameters.AddWithValue("@doUuTien", doUuTien ?? "Trung bình");
                    cmd.Parameters.AddWithValue("@nhomId", nhomId.HasValue && nhomId.Value > 0 ? (object)nhomId.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@id", taskId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Xóa tags cũ và thêm mới
                    if (tagIds != null)
                    {
                        // Xóa tất cả tags cũ
                        string deleteTagsQuery = "DELETE FROM task_tag WHERE task_id = @taskId";
                        MySqlCommand deleteCmd = new MySqlCommand(deleteTagsQuery, conn);
                        deleteCmd.Parameters.AddWithValue("@taskId", taskId);
                        deleteCmd.ExecuteNonQuery();

                        // Thêm tags mới
                        foreach (int tagId in tagIds)
                        {
                            string tagQuery = "INSERT INTO task_tag (task_id, tag_id) VALUES (@taskId, @tagId)";
                            MySqlCommand tagCmd = new MySqlCommand(tagQuery, conn);
                            tagCmd.Parameters.AddWithValue("@taskId", taskId);
                            tagCmd.Parameters.AddWithValue("@tagId", tagId);
                            tagCmd.ExecuteNonQuery();
                        }
                    }

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật task: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ==========================================================
        // HÀM 8: GetTaskById - Lấy task theo ID
        // ==========================================================
        public static TaskModel GetTaskById(int taskId)
        {
            string query = @"SELECT cv.*, 
                            ng_giao.ho_ten as ten_nguoi_duoc_giao,
                            ng_tao.ho_ten as ten_nguoi_tao
                            FROM cong_viec cv
                            LEFT JOIN nguoi_dung ng_giao ON cv.nguoi_duoc_giao_id = ng_giao.id
                            LEFT JOIN nguoi_dung ng_tao ON cv.nguoi_tao_id = ng_tao.id
                            WHERE cv.id = @id";

            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", taskId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TaskModel task = new TaskModel();
                            task.Id = reader.GetInt32("id");
                            task.TieuDe = reader.GetString("tieu_de");
                            task.MoTa = reader.IsDBNull(reader.GetOrdinal("mo_ta")) ? "" : reader.GetString("mo_ta");
                            task.TrangThai = reader.GetString("trang_thai");

                            task.NguoiTaoId = reader.IsDBNull(reader.GetOrdinal("nguoi_tao_id")) ? 0 : reader.GetInt32("nguoi_tao_id");
                            task.TenNguoiTao = reader.IsDBNull(reader.GetOrdinal("ten_nguoi_tao")) ? "" : reader.GetString("ten_nguoi_tao");

                            task.NguoiDuocGiaoId = reader.IsDBNull(reader.GetOrdinal("nguoi_duoc_giao_id")) ? 0 : reader.GetInt32("nguoi_duoc_giao_id");
                            task.TenNguoiDuocGiao = reader.IsDBNull(reader.GetOrdinal("ten_nguoi_duoc_giao")) ? "Chưa giao" : reader.GetString("ten_nguoi_duoc_giao");

                            if (!reader.IsDBNull(reader.GetOrdinal("han_hoan_thanh")))
                                task.HanHoanThanh = reader.GetDateTime("han_hoan_thanh");

                            task.DoUuTien = reader.IsDBNull(reader.GetOrdinal("do_uu_tien")) ? "Trung bình" : reader.GetString("do_uu_tien");

                            if (!reader.IsDBNull(reader.GetOrdinal("ngay_tao")))
                                task.NgayTao = reader.GetDateTime("ngay_tao");

                            return task;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy thông tin task: " + ex.Message);
            }

            return null;
        }

        // ==========================================================
        // HÀM 9: GetTasksByDateRange - Lấy tasks theo khoảng thời gian
        // ==========================================================
        public static List<TaskModel> GetTasksByDateRange(DateTime fromDate, DateTime toDate)
        {
            List<TaskModel> list = new List<TaskModel>();

            string query = @"SELECT cv.*, 
                            ng_giao.ho_ten as ten_nguoi_duoc_giao,
                            ng_tao.ho_ten as ten_nguoi_tao
                            FROM cong_viec cv
                            LEFT JOIN nguoi_dung ng_giao ON cv.nguoi_duoc_giao_id = ng_giao.id
                            LEFT JOIN nguoi_dung ng_tao ON cv.nguoi_tao_id = ng_tao.id
                            WHERE cv.ngay_tao >= @fromDate AND cv.ngay_tao <= @toDate
                            ORDER BY cv.ngay_tao DESC";

            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@fromDate", fromDate);
                    cmd.Parameters.AddWithValue("@toDate", toDate);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TaskModel task = new TaskModel();
                            task.Id = reader.GetInt32("id");
                            task.TieuDe = reader.GetString("tieu_de");
                            task.MoTa = reader.IsDBNull(reader.GetOrdinal("mo_ta")) ? "" : reader.GetString("mo_ta");
                            task.TrangThai = reader.GetString("trang_thai");

                            task.NguoiTaoId = reader.IsDBNull(reader.GetOrdinal("nguoi_tao_id")) ? 0 : reader.GetInt32("nguoi_tao_id");
                            task.TenNguoiTao = reader.IsDBNull(reader.GetOrdinal("ten_nguoi_tao")) ? "" : reader.GetString("ten_nguoi_tao");

                            task.NguoiDuocGiaoId = reader.IsDBNull(reader.GetOrdinal("nguoi_duoc_giao_id")) ? 0 : reader.GetInt32("nguoi_duoc_giao_id");
                            task.TenNguoiDuocGiao = reader.IsDBNull(reader.GetOrdinal("ten_nguoi_duoc_giao")) ? "Chưa giao" : reader.GetString("ten_nguoi_duoc_giao");

                            if (!reader.IsDBNull(reader.GetOrdinal("han_hoan_thanh")))
                                task.HanHoanThanh = reader.GetDateTime("han_hoan_thanh");

                            task.DoUuTien = reader.IsDBNull(reader.GetOrdinal("do_uu_tien")) ? "Trung bình" : reader.GetString("do_uu_tien");

                            if (!reader.IsDBNull(reader.GetOrdinal("ngay_tao")))
                                task.NgayTao = reader.GetDateTime("ngay_tao");

                            list.Add(task);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu báo cáo: " + ex.Message);
            }

            return list;
        }
    }
}
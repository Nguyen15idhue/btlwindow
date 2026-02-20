using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace btlwindow
{
    public static class UserRepository
    {
        private static string connectionString = "Server=localhost;Database=kanban_simple;Port=3306;User Id=root;Password=;";

        // Hash mật khẩu bằng SHA256
        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Đăng ký user mới
        public static bool Register(string hoTen, string email, string matKhau, string role)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiểm tra email đã tồn tại chưa
                    string checkQuery = "SELECT COUNT(*) FROM nguoi_dung WHERE email = @email";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@email", email);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Email đã được sử dụng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }

                    // Thêm user mới
                    string query = @"INSERT INTO nguoi_dung (ho_ten, email, mat_khau, role) 
                                    VALUES (@hoTen, @email, @matKhau, @role)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@hoTen", hoTen);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@matKhau", HashPassword(matKhau));
                        cmd.Parameters.AddWithValue("@role", role);
                        
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng ký: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Đăng nhập
        public static UserModel Login(string email, string matKhau)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT id, ho_ten, email, role, ngay_tao 
                                   FROM nguoi_dung 
                                   WHERE email = @email AND mat_khau = @matKhau";
                    
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@matKhau", HashPassword(matKhau));

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new UserModel
                                {
                                    Id = reader.GetInt32("id"),
                                    HoTen = reader.GetString("ho_ten"),
                                    Email = reader.GetString("email"),
                                    Role = reader.GetString("role"),
                                    NgayTao = reader.GetDateTime("ngay_tao")
                                };
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Lấy danh sách tất cả user (để chọn assignee)
        public static List<UserModel> GetAllUsers()
        {
            List<UserModel> users = new List<UserModel>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, ho_ten, email, role FROM nguoi_dung ORDER BY ho_ten";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new UserModel
                            {
                                Id = reader.GetInt32("id"),
                                HoTen = reader.GetString("ho_ten"),
                                Email = reader.GetString("email"),
                                Role = reader.GetString("role")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy danh sách user: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return users;
        }
    }
}

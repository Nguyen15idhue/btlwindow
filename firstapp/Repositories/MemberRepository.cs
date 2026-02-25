using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace btlwindow
{
    public static class MemberRepository
    {
        private static string connectionString = "Server=localhost;Database=kanban_simple;Port=3306;User Id=root;Password=;";

        public static List<MemberModel> GetAllMembers()
        {
            List<MemberModel> list = new List<MemberModel>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, ho_ten, email, role, ngay_tao FROM nguoi_dung ORDER BY ho_ten";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new MemberModel
                            {
                                Id = reader.GetInt32("id"),
                                HoTen = reader.GetString("ho_ten"),
                                Email = reader.GetString("email"),
                                Role = reader.GetString("role"),
                                NgayTao = reader.GetDateTime("ngay_tao")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi lay danh sach thanh vien: " + ex.Message);
            }
            return list;
        }

        public static bool UpdateMemberRole(int id, string newRole)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE nguoi_dung SET role = @role WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@role", newRole);
                        cmd.Parameters.AddWithValue("@id", id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi cap nhat role: " + ex.Message);
                return false;
            }
        }

        public static bool DeleteMember(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM nguoi_dung WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi xoa thanh vien: " + ex.Message);
                return false;
            }
        }
    }
}
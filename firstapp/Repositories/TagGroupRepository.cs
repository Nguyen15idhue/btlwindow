using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace btlwindow
{
    public class TagGroupModel
    {
        public int Id { get; set; }
        public string TenNhom { get; set; }
        public string MauSac { get; set; }
        public string MoTa { get; set; }
    }

    public static class TagGroupRepository
    {
        private static string connectionString = "Server=localhost;Database=kanban_simple;Port=3306;User Id=root;Password=;";

        public static List<TagGroupModel> GetAllTagGroups()
        {
            List<TagGroupModel> list = new List<TagGroupModel>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, ten_nhom, mau_sac, mo_ta FROM nhom_cong_viec ORDER BY ten_nhom";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new TagGroupModel
                            {
                                Id = reader.GetInt32("id"),
                                TenNhom = reader.GetString("ten_nhom"),
                                MauSac = reader.IsDBNull(reader.GetOrdinal("mau_sac")) ? "#3498db" : reader.GetString("mau_sac"),
                                MoTa = reader.IsDBNull(reader.GetOrdinal("mo_ta")) ? "" : reader.GetString("mo_ta")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi lay danh sach nhom: " + ex.Message);
            }
            return list;
        }

        public static bool AddTagGroup(string tenNhom, string mauSac, string moTa)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO nhom_cong_viec (ten_nhom, mau_sac, mo_ta) VALUES (@tenNhom, @mauSac, @moTa)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tenNhom", tenNhom);
                        cmd.Parameters.AddWithValue("@mauSac", mauSac);
                        cmd.Parameters.AddWithValue("@moTa", moTa ?? "");
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi them nhom: " + ex.Message);
                return false;
            }
        }

        public static bool UpdateTagGroup(int id, string tenNhom, string mauSac, string moTa)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE nhom_cong_viec SET ten_nhom = @tenNhom, mau_sac = @mauSac, mo_ta = @moTa WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tenNhom", tenNhom);
                        cmd.Parameters.AddWithValue("@mauSac", mauSac);
                        cmd.Parameters.AddWithValue("@moTa", moTa ?? "");
                        cmd.Parameters.AddWithValue("@id", id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi cap nhat nhom: " + ex.Message);
                return false;
            }
        }

        public static bool DeleteTagGroup(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM nhom_cong_viec WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi xoa nhom: " + ex.Message);
                return false;
            }
        }

        // Alias for GetAllTagGroups
        public static List<TagGroupModel> GetAllGroups()
        {
            return GetAllTagGroups();
        }

        // Get all tags
        public static List<TagModel> GetAllTags()
        {
            List<TagModel> list = new List<TagModel>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, ten_tag, mau_sac FROM tags ORDER BY ten_tag";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new TagModel
                            {
                                Id = reader.GetInt32("id"),
                                TenTag = reader.GetString("ten_tag"),
                                MauSac = reader.IsDBNull(reader.GetOrdinal("mau_sac")) ? "#3498db" : reader.GetString("mau_sac")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi lay danh sach tag: " + ex.Message);
            }
            return list;
        }
    }
}
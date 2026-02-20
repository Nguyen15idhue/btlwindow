using System;

namespace btlwindow
{
    // Model cho người dùng
    public class UserModel
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string Role { get; set; } // "Manager" hoặc "Employee"
        public DateTime NgayTao { get; set; }
    }

    // Enum cho Role
    public enum UserRole
    {
        Manager,
        Employee
    }

    // Lưu thông tin user hiện tại đang đăng nhập
    public static class CurrentUser
    {
        public static UserModel User { get; set; }
        
        public static bool IsManager => User?.Role == "Manager";
        public static bool IsEmployee => User?.Role == "Employee";
        
        public static void Logout()
        {
            User = null;
        }
    }
}

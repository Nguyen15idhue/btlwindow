using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btlwindow.Services
{
    /// <summary>
    /// Service chịu trách nhiệm truy xuất và xây dựng context từ database
    /// Áp dụng RAG (Retrieval Augmented Generation) pattern
    /// </summary>
    public class DatabaseContextService
    {
        /// <summary>
        /// Lấy context dữ liệu relevant dựa trên câu hỏi của user
        /// </summary>
        public static async Task<string> GetRelevantContextAsync(string userQuestion)
        {
            return await Task.Run(() => GetRelevantContext(userQuestion));
        }

        /// <summary>
        /// Phiên bản đồng bộ của GetRelevantContext
        /// </summary>
        public static string GetRelevantContext(string userQuestion)
        {
            try
            {
                StringBuilder context = new StringBuilder();
                
                // Phân tích câu hỏi để lấy keywords
                string lowerQuestion = userQuestion.ToLower();
                bool needsTaskData = ContainsKeywords(lowerQuestion, "công việc", "task", "việc", "job", "dự án");
                bool needsUserData = ContainsKeywords(lowerQuestion, "người", "user", "nhân viên", "thành viên", "ai");
                bool needsStatistics = ContainsKeywords(lowerQuestion, "bao nhiêu", "số lượng", "thống kê", "tổng", "count");

                context.AppendLine("=== THÔNG TIN HỆ THỐNG QUẢN LÝ CÔNG VIỆC KANBAN ===");
                context.AppendLine();

                // Luôn lấy thống kê tổng quan
                AddOverviewStatistics(context);

                // Lấy dữ liệu người dùng nếu cần
                if (needsUserData || needsStatistics)
                {
                    AddUserData(context);
                }

                // Lấy dữ liệu công việc nếu cần
                if (needsTaskData || needsStatistics)
                {
                    AddTaskData(context, userQuestion);
                }

                // Nếu không match keyword nào, lấy hết để AI tự xử lý
                if (!needsTaskData && !needsUserData && !needsStatistics)
                {
                    AddAllData(context);
                }

                return context.ToString();
            }
            catch (Exception ex)
            {
                return $"Lỗi khi truy xuất dữ liệu: {ex.Message}";
            }
        }

        /// <summary>
        /// Thêm thống kê tổng quan vào context
        /// </summary>
        private static void AddOverviewStatistics(StringBuilder context)
        {
            try
            {
                var tasks = TaskRepository.LoadTasks();
                var users = UserRepository.GetAllUsers();

                context.AppendLine("📊 THỐNG KÊ TỔNG QUAN:");
                context.AppendLine($"├─ Tổng số công việc: {tasks.Count}");
                context.AppendLine($"├─ Công việc Todo (Cần làm): {tasks.Count(t => t.TrangThai == "Todo")}");
                context.AppendLine($"├─ Công việc Doing (Đang làm): {tasks.Count(t => t.TrangThai == "Doing")}");
                context.AppendLine($"├─ Công việc Done (Hoàn thành): {tasks.Count(t => t.TrangThai == "Done")}");
                context.AppendLine($"├─ Công việc quá hạn: {tasks.Count(t => t.IsOverdue)}");
                context.AppendLine($"├─ Công việc ưu tiên cao: {tasks.Count(t => t.DoUuTien == "Cao")}");
                context.AppendLine($"├─ Công việc ưu tiên trung bình: {tasks.Count(t => t.DoUuTien == "Trung bình")}");
                context.AppendLine($"├─ Công việc ưu tiên thấp: {tasks.Count(t => t.DoUuTien == "Thấp")}");
                context.AppendLine($"└─ Tổng số người dùng: {users.Count}");
                context.AppendLine();
            }
            catch (Exception ex)
            {
                context.AppendLine($"Lỗi khi lấy thống kê: {ex.Message}");
            }
        }

        /// <summary>
        /// Thêm thông tin người dùng vào context
        /// </summary>
        private static void AddUserData(StringBuilder context)
        {
            try
            {
                var users = UserRepository.GetAllUsers();
                var tasks = TaskRepository.LoadTasks();

                context.AppendLine("👥 DANH SÁCH NGƯỜI DÙNG:");
                foreach (var user in users)
                {
                    int taskCount = tasks.Count(t => t.NguoiDuocGiaoId == user.Id);
                    int completedCount = tasks.Count(t => t.NguoiDuocGiaoId == user.Id && t.TrangThai == "Done");
                    
                    context.AppendLine($"├─ {user.HoTen}");
                    context.AppendLine($"│  ├─ Email: {user.Email}");
                    context.AppendLine($"│  ├─ Vai trò: {user.Role}");
                    context.AppendLine($"│  ├─ Số công việc được giao: {taskCount}");
                    context.AppendLine($"│  └─ Số công việc hoàn thành: {completedCount}");
                }
                context.AppendLine();
            }
            catch (Exception ex)
            {
                context.AppendLine($"Lỗi khi lấy dữ liệu người dùng: {ex.Message}");
            }
        }

        /// <summary>
        /// Thêm thông tin công việc relevant vào context
        /// </summary>
        private static void AddTaskData(StringBuilder context, string userQuestion)
        {
            try
            {
                var tasks = TaskRepository.LoadTasks();

                // Lọc tasks relevant dựa trên keywords trong câu hỏi
                var relevantTasks = FilterRelevantTasks(tasks, userQuestion);

                context.AppendLine("📋 DANH SÁCH CÔNG VIỆC RELEVANT:");
                
                int count = 0;
                foreach (var task in relevantTasks.Take(20)) // Giới hạn 20 tasks để tránh context quá dài
                {
                    count++;
                    context.AppendLine($"├─ [{count}] {task.TieuDe}");
                    context.AppendLine($"│  ├─ ID: {task.Id}");
                    context.AppendLine($"│  ├─ Mô tả: {(string.IsNullOrEmpty(task.MoTa) ? "Không có" : task.MoTa)}");
                    context.AppendLine($"│  ├─ Trạng thái: {task.TrangThai}");
                    context.AppendLine($"│  ├─ Độ ưu tiên: {task.DoUuTien}");
                    context.AppendLine($"│  ├─ Người tạo: {task.TenNguoiTao}");
                    context.AppendLine($"│  ├─ Người được giao: {task.TenNguoiDuocGiao}");
                    context.AppendLine($"│  ├─ Hạn hoàn thành: {task.HanHoanThanh:dd/MM/yyyy HH:mm}");
                    context.AppendLine($"│  ├─ Ngày tạo: {task.NgayTao:dd/MM/yyyy HH:mm}");
                    context.AppendLine($"│  ├─ Quá hạn: {(task.IsOverdue ? "Có" : "Không")}");
                    
                    if (task.Tags != null && task.Tags.Count > 0)
                        context.AppendLine($"│  ├─ Tags: {string.Join(", ", task.Tags)}");
                    
                    if (!string.IsNullOrEmpty(task.TenNhom))
                        context.AppendLine($"│  └─ Nhóm: {task.TenNhom}");
                    else
                        context.AppendLine($"│  └─ Nhóm: Chưa phân nhóm");
                }

                if (count == 0)
                {
                    context.AppendLine("└─ Không tìm thấy công việc phù hợp");
                }

                context.AppendLine();
            }
            catch (Exception ex)
            {
                context.AppendLine($"Lỗi khi lấy dữ liệu công việc: {ex.Message}");
            }
        }

        /// <summary>
        /// Lọc các tasks relevant dựa trên câu hỏi
        /// </summary>
        private static List<TaskModel> FilterRelevantTasks(List<TaskModel> allTasks, string question)
        {
            string lowerQuestion = question.ToLower();

            // Lọc theo trạng thái
            if (ContainsKeywords(lowerQuestion, "todo", "cần làm", "chưa làm"))
                return allTasks.Where(t => t.TrangThai == "Todo").ToList();

            if (ContainsKeywords(lowerQuestion, "doing", "đang làm"))
                return allTasks.Where(t => t.TrangThai == "Doing").ToList();

            if (ContainsKeywords(lowerQuestion, "done", "hoàn thành", "xong"))
                return allTasks.Where(t => t.TrangThai == "Done").ToList();

            // Lọc theo độ ưu tiên
            if (ContainsKeywords(lowerQuestion, "ưu tiên cao", "quan trọng", "gấp"))
                return allTasks.Where(t => t.DoUuTien == "Cao").ToList();

            if (ContainsKeywords(lowerQuestion, "ưu tiên thấp"))
                return allTasks.Where(t => t.DoUuTien == "Thấp").ToList();

            // Lọc theo quá hạn
            if (ContainsKeywords(lowerQuestion, "quá hạn", "trễ", "chậm"))
                return allTasks.Where(t => t.IsOverdue).ToList();

            // Lọc theo keyword trong tiêu đề hoặc mô tả
            var keywords = ExtractKeywords(lowerQuestion);
            if (keywords.Count > 0)
            {
                var filtered = allTasks.Where(t =>
                    keywords.Any(k => (t.TieuDe?.ToLower().Contains(k) ?? false) ||
                                     (t.MoTa?.ToLower().Contains(k) ?? false))
                ).ToList();

                if (filtered.Count > 0)
                    return filtered;
            }

            // Sắp xếp theo mức độ quan trọng: quá hạn > cao > đang làm > todo
            return allTasks
                .OrderByDescending(t => t.IsOverdue)
                .ThenByDescending(t => t.DoUuTien == "Cao")
                .ThenByDescending(t => t.TrangThai == "Doing")
                .ThenByDescending(t => t.TrangThai == "Todo")
                .ToList();
        }

        /// <summary>
        /// Thêm tất cả dữ liệu vào context (fallback)
        /// </summary>
        private static void AddAllData(StringBuilder context)
        {
            AddUserData(context);
            AddTaskData(context, "");
        }

        /// <summary>
        /// Kiểm tra xem text có chứa bất kỳ keyword nào không
        /// </summary>
        private static bool ContainsKeywords(string text, params string[] keywords)
        {
            return keywords.Any(k => text.Contains(k));
        }

        /// <summary>
        /// Trích xuất keywords từ câu hỏi (bỏ stop words)
        /// </summary>
        private static List<string> ExtractKeywords(string question)
        {
            string[] stopWords = { "là", "của", "và", "có", "trong", "thế", "nào", "như", 
                                   "bao", "nhiêu", "gì", "đâu", "ai", "sao", "the", "a", 
                                   "an", "is", "are", "was", "were" };

            var words = question.Split(new[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
            
            return words
                .Where(w => w.Length > 2 && !stopWords.Contains(w.ToLower()))
                .Select(w => w.ToLower())
                .Distinct()
                .ToList();
        }
    }
}

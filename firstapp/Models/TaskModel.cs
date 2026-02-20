using System;

namespace btlwindow
{
    // Đây là cái khuôn chứa dữ liệu 1 công việc, khớp với bảng cong_viec trong SQL
    public class TaskModel
    {
        public int Id { get; set; }
        public string TieuDe { get; set; } // tieu_de
        public string MoTa { get; set; } // mo_ta
        public string TrangThai { get; set; } // trang_thai (Todo, Doing, Done)

        // Người tạo task
        public int NguoiTaoId { get; set; } // nguoi_tao_id
        public string TenNguoiTao { get; set; } // Tên người tạo

        // Người được giao task
        public int NguoiDuocGiaoId { get; set; } // nguoi_duoc_giao_id
        public string TenNguoiDuocGiao { get; set; } // Tên người được giao (từ JOIN)

        public DateTime HanHoanThanh { get; set; } // han_hoan_thanh
        public string DoUuTien { get; set; } // do_uu_tien (Cao, Trung bình, Thấp)

        // Kiểm tra task có quá hạn không
        public bool IsOverdue
        {
            get
            {
                return HanHoanThanh != DateTime.MinValue 
                       && HanHoanThanh < DateTime.Today 
                       && TrangThai != "Done";
            }
        }

        // Kiểm tra xem user hiện tại có thể sửa/xóa task không
        public bool CanEdit(int currentUserId, bool isManager)
        {
            // Manager có thể sửa/xóa tất cả
            if (isManager) return true;

            // Employee chỉ có thể sửa/xóa task của mình
            return NguoiTaoId == currentUserId;
        }
    }
}
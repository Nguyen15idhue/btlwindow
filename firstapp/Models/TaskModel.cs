using System;
using System.Collections.Generic;
using System.Linq;

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

        // Nhóm công việc
        public int? NhomId { get; set; } // nhom_id
        public string TenNhom { get; set; } // ten_nhom
        public string MauNhom { get; set; } // mau_nhom

        // Tags
        public List<string> Tags { get; set; } = new List<string>();
        public List<string> TagsColors { get; set; } = new List<string>();

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

        // Format tags thành chuỗi hiển thị
        public string TagsDisplay
        {
            get
            {
                if (Tags == null || Tags.Count == 0)
                    return "";
                return string.Join(", ", Tags);
            }
        }

        // Kiểm tra task có tag cụ thể không
        public bool HasTag(string tagName)
        {
            return Tags != null && Tags.Any(t => t.Equals(tagName, StringComparison.OrdinalIgnoreCase));
        }
    }

    // Model cho Tag
    public class TagModel
    {
        public int Id { get; set; }
        public string TenTag { get; set; }
        public string MauSac { get; set; }
        public DateTime NgayTao { get; set; }
    }

    // Model cho Nhóm công việc
    public class NhomCongViecModel
    {
        public int Id { get; set; }
        public string TenNhom { get; set; }
        public string MauSac { get; set; }
        public string MoTa { get; set; }
        public int? NguoiTaoId { get; set; }
        public DateTime NgayTao { get; set; }
    }
}
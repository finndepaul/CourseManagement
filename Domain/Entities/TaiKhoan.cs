using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Domain.Entities
{
    public class TaiKhoan
    {
        public int TaiKhoanID { get; set; }
        public string? TenNguoiDung { get; set; }
        public string? TenDangNhap { get; set; }
        public string? MatKhau { get; set; }
        public int? QuyenHanID { get; set; }

        // Khóa ngoại
        public virtual QuyenHan? QuyenHan { get; set; }
        public virtual List<DangKyHoc>? DangKyHocs { get; set; }
        public virtual List<BaiViet>? BaiViets { get; set; }
    }
}

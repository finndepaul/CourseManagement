using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Domain.Entities
{
    public class BaiViet
    {
        public int BaiVietID { get; set; }
        public string? TenBaiViet { get; set; }
        public string? TenTacGia { get; set; }
        public string? NoiDung { get; set; }
        public string? NoiDungNgan { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string? HinhAnh { get; set; }
        public int? ChuDeID { get; set; }
        public int? TaiKhoanID { get; set; }

        // Khóa ngoại
        public virtual ChuDe? ChuDe { get; set; }
        public virtual TaiKhoan? TaiKhoan { get; set;}
    }
}

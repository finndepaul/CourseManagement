using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Domain.Entities
{
    public class LoaiKhoaHoc
    {
        public int LoaiKhoaHocID { get; set; }
        public string? TenLoai { get; set; }

        // Khóa ngoại
        public virtual List<KhoaHoc>? khoaHocs { get; set; }
    }
}

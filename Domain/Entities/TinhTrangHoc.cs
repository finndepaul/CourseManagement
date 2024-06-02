using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Domain.Entities
{
    public class TinhTrangHoc
    {
        public int TinhTrangHocID { get; set; }
        public string? TenTinhTrang { get; set; }

        // Khóa ngoại
        public virtual List<DangKyHoc>? DangKyHocs { get; set; }
    }
}

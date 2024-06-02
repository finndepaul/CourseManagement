using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Domain.Entities
{
    public class QuyenHan
    {
        public int QuyenHanID { get; set; }
        public string? TenQuyenHan { get; set; }

        // Khóa ngoại
        public virtual List<TaiKhoan>? TaiKhoans { get; set; }
    }
}

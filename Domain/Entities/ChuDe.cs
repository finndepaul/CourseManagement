using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Domain.Entities
{
    public class ChuDe
    {
        public int ChuDeID { get; set; }
        public string? TenChuDe { get; set; }
        public string? NoiDung { get; set; }
        public int? LoaiBaiVietID { get; set; }

        // Khóa ngoại
        public virtual LoaiBaiViet? LoaiBaiViet { get; set; }
        public virtual List<BaiViet>? BaiViets { get; set;}
    }
}

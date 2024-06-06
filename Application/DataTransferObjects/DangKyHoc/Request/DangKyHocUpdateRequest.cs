using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Application.DataTransferObjects.DangKyHoc.Request
{
    public class DangKyHocUpdateRequest
    {
        public int DangKyHocID { get; set; }
        public int? KhoaHocID { get; set; }
        public int? HocVienID { get; set; }
        public int? TinhTrangHocID { get; set; }
        public int? TaiKhoanID { get; set; }
    }
}

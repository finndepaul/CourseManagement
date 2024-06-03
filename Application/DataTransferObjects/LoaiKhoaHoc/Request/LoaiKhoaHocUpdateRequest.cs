using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Application.DataTransferObjects.LoaiKhoaHoc.Request
{
    public class LoaiKhoaHocUpdateRequest
    {
        public int LoaiKhoaHocID { get; set; }
        public string? TenLoai { get; set; }
    }
}

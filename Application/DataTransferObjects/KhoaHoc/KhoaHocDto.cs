﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Application.DataTransferObjects.KhoaHoc
{
    public class KhoaHocDto
    {
        public string? TenKhoaHoc { get; set; }
        public int? ThoiGianHoc { get; set; }
        public string? GioiThieu { get; set; }
        public string? NoiDung { get; set; }
        public double? HocPhi { get; set; }
        public int? SoHocVien { get; set; }
        public int? SoLuongMon { get; set; }
        public string? HinhAnh { get; set; }
        public string? TenLoai { get; set; }
    }
}

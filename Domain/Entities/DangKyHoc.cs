﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Domain.Entities
{
    public class DangKyHoc
    {
        public int DangKyHocID { get; set; }
        public int KhoaHocID { get; set; }
        public int HocVienID { get; set; }
        public DateTime NgayDangKy { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int TinhTrangHocID { get; set; }
        public int TaiKhoanID { get; set; }
    }
}

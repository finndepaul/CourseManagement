﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Application.DataTransferObjects.HocVien.Request
{
    public class HocVienCreateRequest
    {
        public string? HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? SDT { get; set; }
        public string? Email { get; set; }
        public string? TinhThanh { get; set; }
        public string? QuanHuyen { get; set; }
        public string? PhuongXa { get; set; }
        public string? SoNha { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Application.DataTransferObjects.TinhTrangHoc.Request
{
    public class TinhTrangHocUpdateRequest
    {
        public int TinhTrangHocID { get; set; }
        public string? TenTinhTrang { get; set; }
    }
}

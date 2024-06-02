using CourseManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Infrastructure.Database.Configurations
{
    public class DangKyHocConfig : IEntityTypeConfiguration<DangKyHoc>
    {
        public void Configure(EntityTypeBuilder<DangKyHoc> builder)
        {
            builder.HasKey(x => x.DangKyHocID);
            // Relationship
            builder.HasOne(x => x.KhoaHoc).WithMany(x => x.DangKyHocs).HasForeignKey(x => x.KhoaHocID);
            builder.HasOne(x => x.HocVien).WithMany(x => x.DangKyHocs).HasForeignKey(x => x.HocVienID);
            builder.HasOne(x => x.TinhTrangHoc).WithMany(x => x.DangKyHocs).HasForeignKey(x => x.TinhTrangHocID);
            builder.HasOne(x => x.TaiKhoan).WithMany(x => x.DangKyHocs).HasForeignKey(x => x.TaiKhoanID);
        }
    }
}

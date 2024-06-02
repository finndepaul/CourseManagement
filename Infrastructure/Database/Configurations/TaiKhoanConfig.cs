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
    public class TaiKhoanConfig : IEntityTypeConfiguration<TaiKhoan>
    {
        public void Configure(EntityTypeBuilder<TaiKhoan> builder)
        {
            builder.HasKey(x => x.TaiKhoanID);
            builder.Property(x => x.TenNguoiDung).HasColumnType("varchar(50)");
            builder.Property(x => x.TenDangNhap).HasColumnType("varchar(50)");
            builder.Property(x => x.MatKhau).HasColumnType("varchar(50)");
            // Relationship
            builder.HasOne(x => x.QuyenHan).WithMany(x => x.TaiKhoans).HasForeignKey(x => x.QuyenHanID);
        }
    }
}

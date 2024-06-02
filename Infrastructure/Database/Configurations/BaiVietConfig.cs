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
    public class BaiVietConfig : IEntityTypeConfiguration<BaiViet>
    {
        public void Configure(EntityTypeBuilder<BaiViet> builder)
        {
            builder.HasKey(x => x.BaiVietID);
            builder.Property(x => x.TenBaiViet).HasColumnType("nvarchar(50)");
            builder.Property(x => x.TenTacGia).HasColumnType("nvarchar(50)");
            builder.Property(x => x.NoiDung).HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.NoiDungNgan).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.HinhAnh).HasColumnType("nvarchar(MAX)");
            // Relationship
            builder.HasOne(x => x.ChuDe).WithMany(x => x.BaiViets).HasForeignKey(x => x.ChuDeID);
            builder.HasOne(x => x.TaiKhoan).WithMany(x => x.BaiViets).HasForeignKey(x => x.TaiKhoanID);
        }
    }
}

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
    public class KhoaHocConfig : IEntityTypeConfiguration<KhoaHoc>
    {
        public void Configure(EntityTypeBuilder<KhoaHoc> builder)
        {
            builder.HasKey(x => x.KhoaHocID);
            builder.Property(x => x.TenKhoaHoc).HasColumnType("nvarchar(50)");
            builder.Property(x => x.GioiThieu).HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.NoiDung).HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.HinhAnh).HasColumnType("nvarchar(MAX)");
            // Relationship
            builder.HasOne(x => x.LoaiKhoaHoc).WithMany(x => x.khoaHocs).HasForeignKey(x => x.LoaiKhoaHocID);
        }
    }
}

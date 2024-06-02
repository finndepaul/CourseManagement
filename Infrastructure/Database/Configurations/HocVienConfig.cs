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
    public class HocVienConfig : IEntityTypeConfiguration<HocVien>
    {
        public void Configure(EntityTypeBuilder<HocVien> builder)
        {
            builder.HasKey(x => x.HocVienID);
            builder.Property(x => x.HinhAnh).HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.HoTen).HasColumnType("nvarchar(50)");
            builder.Property(x => x.SDT).HasColumnType("varchar(11)");
            builder.Property(x => x.Email).HasColumnType("varchar(40)");
            builder.Property(x => x.TinhThanh).HasColumnType("nvarchar(50)");
            builder.Property(x => x.QuanHuyen).HasColumnType("nvarchar(50)");
            builder.Property(x => x.PhuongXa).HasColumnType("nvarchar(50)");
            builder.Property(x => x.SoNha).HasColumnType("varchar(50)");
            // Relationship
        }
    }
}

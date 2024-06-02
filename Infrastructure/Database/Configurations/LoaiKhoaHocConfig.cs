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
    public class LoaiKhoaHocConfig : IEntityTypeConfiguration<LoaiKhoaHoc>
    {
        public void Configure(EntityTypeBuilder<LoaiKhoaHoc> builder)
        {
            builder.HasKey(x => x.LoaiKhoaHocID);
            builder.Property(x => x.TenLoai).HasColumnType("nvarchar(30)");
            // Relationship
        }
    }
}

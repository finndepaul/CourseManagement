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
    public class TinhTrangHocConfig : IEntityTypeConfiguration<TinhTrangHoc>
    {
        public void Configure(EntityTypeBuilder<TinhTrangHoc> builder)
        {
            builder.HasKey(x => x.TinhTrangHocID);
            builder.Property(x => x.TenTinhTrang).HasColumnType("nvarchar(40)");
            // Relationship
        }
    }
}

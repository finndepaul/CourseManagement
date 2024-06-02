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
    public class QuyenHanConfig : IEntityTypeConfiguration<QuyenHan>
    {
        public void Configure(EntityTypeBuilder<QuyenHan> builder)
        {
            builder.HasKey(x => x.QuyenHanID);
            builder.Property(x => x.TenQuyenHan).HasColumnType("nvarchar(50)");
            // Relationship
        }
    }
}

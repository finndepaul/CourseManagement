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
    public class ChuDeConfig : IEntityTypeConfiguration<ChuDe>
    {
        public void Configure(EntityTypeBuilder<ChuDe> builder)
        {
            builder.HasKey(x => x.ChuDeID);
            builder.Property(x => x.TenChuDe).HasColumnType("nvarchar(50)");
            builder.Property(x => x.NoiDung).HasColumnType("nvarchar(MAX)");
            // Relationship
            builder.HasOne(x => x.LoaiBaiViet).WithMany(x => x.ChuDes).HasForeignKey(x => x.LoaiBaiVietID);
        }
    }
}

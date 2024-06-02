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
    public class LoaiBaiVietConfig : IEntityTypeConfiguration<LoaiBaiViet>
    {
        public void Configure(EntityTypeBuilder<LoaiBaiViet> builder)
        {
            builder.HasKey(x => x.LoaiBaiVietID);
            builder.Property(x => x.TenLoai).HasColumnType("nvarchar(50)");
            // Relationship
        }
    }
}

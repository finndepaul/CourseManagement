using CourseManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Infrastructure.Database.AppDbContext
{
    public class CourseManagementDbContext : DbContext
    {
        public CourseManagementDbContext()
        {

        }
        public CourseManagementDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-V6M0EF7\\SQLEXPRESS;Initial Catalog=CourseManagement;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        #region Dbset
        public DbSet<BaiViet> BaiViets { get; set; }
        public DbSet<ChuDe> ChuDes { get; set; }
        public DbSet<DangKyHoc> DangKyHocs { get; set; }
        public DbSet<HocVien> HocViens { get; set; }
        public DbSet<KhoaHoc> KhoaHocs { get; set; }
        public DbSet<LoaiBaiViet> LoaiBaiViets { get; set; }
        public DbSet<LoaiKhoaHoc> LoaiKhoaHocs { get; set; }
        public DbSet<QuyenHan> QuyenHans { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<TinhTrangHoc> TinhTrangHocs { get; set; }
        
        #endregion
    }
}

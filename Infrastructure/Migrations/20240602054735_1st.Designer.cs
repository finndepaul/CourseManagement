﻿// <auto-generated />
using System;
using CourseManagement.Infrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CourseManagement.Infrastructure.Migrations
{
    [DbContext(typeof(CourseManagementDbContext))]
    [Migration("20240602054735_1st")]
    partial class _1st
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseManagement.Domain.Entities.BaiViet", b =>
                {
                    b.Property<int>("BaiVietID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BaiVietID"));

                    b.Property<int?>("ChuDeID")
                        .HasColumnType("int");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("NoiDungNgan")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("TaiKhoanID")
                        .HasColumnType("int");

                    b.Property<string>("TenBaiViet")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenTacGia")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ThoiGianTao")
                        .HasColumnType("datetime2");

                    b.HasKey("BaiVietID");

                    b.HasIndex("ChuDeID");

                    b.HasIndex("TaiKhoanID");

                    b.ToTable("BaiViets");
                });

            modelBuilder.Entity("CourseManagement.Domain.Entities.ChuDe", b =>
                {
                    b.Property<int>("ChuDeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChuDeID"));

                    b.Property<int?>("LoaiBaiVietID")
                        .HasColumnType("int");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("TenChuDe")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ChuDeID");

                    b.HasIndex("LoaiBaiVietID");

                    b.ToTable("ChuDes");
                });

            modelBuilder.Entity("CourseManagement.Domain.Entities.DangKyHoc", b =>
                {
                    b.Property<int>("DangKyHocID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DangKyHocID"));

                    b.Property<int?>("HocVienID")
                        .HasColumnType("int");

                    b.Property<int?>("KhoaHocID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayDangKy")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TaiKhoanID")
                        .HasColumnType("int");

                    b.Property<int?>("TinhTrangHocID")
                        .HasColumnType("int");

                    b.HasKey("DangKyHocID");

                    b.HasIndex("HocVienID");

                    b.HasIndex("KhoaHocID");

                    b.HasIndex("TaiKhoanID");

                    b.HasIndex("TinhTrangHocID");

                    b.ToTable("DangKyHocs");
                });

            modelBuilder.Entity("CourseManagement.Domain.Entities.HocVien", b =>
                {
                    b.Property<int>("HocVienID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HocVienID"));

                    b.Property<string>("Email")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhuongXa")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("QuanHuyen")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SDT")
                        .HasColumnType("varchar(11)");

                    b.Property<string>("SoNha")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TinhThanh")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("HocVienID");

                    b.ToTable("HocViens");
                });

            modelBuilder.Entity("CourseManagement.Domain.Entities.KhoaHoc", b =>
                {
                    b.Property<int>("KhoaHocID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KhoaHocID"));

                    b.Property<string>("GioiThieu")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<double?>("HocPhi")
                        .HasColumnType("float");

                    b.Property<int?>("LoaiKhoaHocID")
                        .HasColumnType("int");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int?>("SoHocVien")
                        .HasColumnType("int");

                    b.Property<int?>("SoLuongMon")
                        .HasColumnType("int");

                    b.Property<string>("TenKhoaHoc")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ThoiGianHoc")
                        .HasColumnType("int");

                    b.HasKey("KhoaHocID");

                    b.HasIndex("LoaiKhoaHocID");

                    b.ToTable("KhoaHocs");
                });

            modelBuilder.Entity("CourseManagement.Domain.Entities.LoaiBaiViet", b =>
                {
                    b.Property<int>("LoaiBaiVietID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoaiBaiVietID"));

                    b.Property<string>("TenLoai")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("LoaiBaiVietID");

                    b.ToTable("LoaiBaiViets");
                });

            modelBuilder.Entity("CourseManagement.Domain.Entities.LoaiKhoaHoc", b =>
                {
                    b.Property<int>("LoaiKhoaHocID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoaiKhoaHocID"));

                    b.Property<string>("TenLoai")
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("LoaiKhoaHocID");

                    b.ToTable("LoaiKhoaHocs");
                });

            modelBuilder.Entity("CourseManagement.Domain.Entities.QuyenHan", b =>
                {
                    b.Property<int>("QuyenHanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuyenHanID"));

                    b.Property<string>("TenQuyenHan")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("QuyenHanID");

                    b.ToTable("QuyenHans");
                });

            modelBuilder.Entity("CourseManagement.Domain.Entities.TaiKhoan", b =>
                {
                    b.Property<int>("TaiKhoanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaiKhoanID"));

                    b.Property<string>("MatKhau")
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("QuyenHanID")
                        .HasColumnType("int");

                    b.Property<string>("TenDangNhap")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TenNguoiDung")
                        .HasColumnType("varchar(50)");

                    b.HasKey("TaiKhoanID");

                    b.HasIndex("QuyenHanID");

                    b.ToTable("TaiKhoans");
                });

            modelBuilder.Entity("CourseManagement.Domain.Entities.TinhTrangHoc", b =>
                {
                    b.Property<int>("TinhTrangHocID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TinhTrangHocID"));

                    b.Property<string>("TenTinhTrang")
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("TinhTrangHocID");

                    b.ToTable("TinhTrangHocs");
                });

            modelBuilder.Entity("CourseManagement.Domain.Entities.BaiViet", b =>
                {
                    b.HasOne("CourseManagement.Domain.Entities.ChuDe", "ChuDe")
                        .WithMany("BaiViets")
                        .HasForeignKey("ChuDeID");

                    b.HasOne("CourseManagement.Domain.Entities.TaiKhoan", "TaiKhoan")
                        .WithMany("BaiViets")
                        .HasForeignKey("TaiKhoanID");

                    b.Navigation("ChuDe");

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("CourseManagement.Domain.Entities.ChuDe", b =>
                {
                    b.HasOne("CourseManagement.Domain.Entities.LoaiBaiViet", "LoaiBaiViet")
                        .WithMany("ChuDes")
                        .HasForeignKey("LoaiBaiVietID");

                    b.Navigation("LoaiBaiViet");
                });

            modelBuilder.Entity("CourseManagement.Domain.Entities.DangKyHoc", b =>
                {
                    b.HasOne("CourseManagement.Domain.Entities.HocVien", "HocVien")
                        .WithMany("DangKyHocs")
                        .HasForeignKey("HocVienID");

                    b.HasOne("CourseManagement.Domain.Entities.KhoaHoc", "KhoaHoc")
                        .WithMany("DangKyHocs")
                        .HasForeignKey("KhoaHocID");

                    b.HasOne("CourseManagement.Domain.Entities.TaiKhoan", "TaiKhoan")
                        .WithMany("DangKyHocs")
                        .HasForeignKey("TaiKhoanID");

                    b.HasOne("CourseManagement.Domain.Entities.TinhTrangHoc", "TinhTrangHoc")
                        .WithMany("DangKyHocs")
                        .HasForeignKey("TinhTrangHocID");

                    b.Navigation("HocVien");

                    b.Navigation("KhoaHoc");

                    b.Navigation("TaiKhoan");

                    b.Navigation("TinhTrangHoc");
                });

            modelBuilder.Entity("CourseManagement.Domain.Entities.KhoaHoc", b =>
                {
                    b.HasOne("CourseManagement.Domain.Entities.LoaiKhoaHoc", "LoaiKhoaHoc")
                        .WithMany("khoaHocs")
                        .HasForeignKey("LoaiKhoaHocID");

                    b.Navigation("LoaiKhoaHoc");
                });

            modelBuilder.Entity("CourseManagement.Domain.Entities.TaiKhoan", b =>
                {
                    b.HasOne("CourseManagement.Domain.Entities.QuyenHan", "QuyenHan")
                        .WithMany("TaiKhoans")
                        .HasForeignKey("QuyenHanID");

                    b.Navigation("QuyenHan");
                });

            modelBuilder.Entity("CourseManagement.Domain.Entities.ChuDe", b =>
                {
                    b.Navigation("BaiViets");
                });

            modelBuilder.Entity("CourseManagement.Domain.Entities.HocVien", b =>
                {
                    b.Navigation("DangKyHocs");
                });

            modelBuilder.Entity("CourseManagement.Domain.Entities.KhoaHoc", b =>
                {
                    b.Navigation("DangKyHocs");
                });

            modelBuilder.Entity("CourseManagement.Domain.Entities.LoaiBaiViet", b =>
                {
                    b.Navigation("ChuDes");
                });

            modelBuilder.Entity("CourseManagement.Domain.Entities.LoaiKhoaHoc", b =>
                {
                    b.Navigation("khoaHocs");
                });

            modelBuilder.Entity("CourseManagement.Domain.Entities.QuyenHan", b =>
                {
                    b.Navigation("TaiKhoans");
                });

            modelBuilder.Entity("CourseManagement.Domain.Entities.TaiKhoan", b =>
                {
                    b.Navigation("BaiViets");

                    b.Navigation("DangKyHocs");
                });

            modelBuilder.Entity("CourseManagement.Domain.Entities.TinhTrangHoc", b =>
                {
                    b.Navigation("DangKyHocs");
                });
#pragma warning restore 612, 618
        }
    }
}

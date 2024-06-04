using CourseManagement.Application.Interfaces.Repositories;
using CourseManagement.Application.ValueObjects.Pagination;
using CourseManagement.Domain.Entities;
using CourseManagement.Infrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Infrastructure.Implements.Repositories
{
    public class KhoaHocRepos : IKhoaHocRepos
    {
        private readonly CourseManagementDbContext _db;
        public KhoaHocRepos()
        {
            _db = new CourseManagementDbContext();
        }
        public async Task<PageResult<KhoaHoc>> GetAll(string? name, PaginationRequest request)
        {
            var model = await _db.KhoaHocs
                //.Include(x => x.LoaiKhoaHoc)
                .AsNoTracking()
                .ToListAsync();
            
            if (!string.IsNullOrWhiteSpace(name))
            {
                model = model.Where(x => x.TenKhoaHoc.ToLower().Contains(name.ToLower())).ToList();
                
            }
            // Cập nhật số lượng học viên cho từng khóa học
            foreach (var khoaHoc in model)
            {
                await UpdateSoLuongHocVien(khoaHoc.KhoaHocID);
            }
            var result = PageResult<KhoaHoc>.ToPageResult(request,model);
            request.TotalCount = model.Count();
            return new PageResult<KhoaHoc>(request,result);
        }
        public async Task<bool> CreateNew(KhoaHoc khoaHoc, CancellationToken cancellationToken)
        {
            try
            {
                await _db.KhoaHocs.AddAsync(khoaHoc);
                await _db.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteRecord(KhoaHoc khoaHoc, CancellationToken cancellationToken)
        {
            try
            {
                var model = await _db.KhoaHocs.FirstOrDefaultAsync(x => x.KhoaHocID == khoaHoc.KhoaHocID);
                if (model == null)
                {
                    return false;
                }
                _db.KhoaHocs.Remove(model);
                await _db.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> UpdateRecord(KhoaHoc khoaHoc, CancellationToken cancellationToken)
        {
            try
            {
                var model = await _db.KhoaHocs.FirstOrDefaultAsync(x => x.KhoaHocID == khoaHoc.KhoaHocID);
                if (model == null)
                {
                    return false;
                }
                model.TenKhoaHoc = khoaHoc.TenKhoaHoc;
                model.ThoiGianHoc = khoaHoc.ThoiGianHoc;
                model.GioiThieu = khoaHoc.GioiThieu;
                model.NoiDung = khoaHoc.NoiDung;
                model.HocPhi = khoaHoc.HocPhi;
                model.SoHocVien = khoaHoc.SoHocVien;
                model.SoLuongMon = khoaHoc.SoLuongMon;
                model.HinhAnh = khoaHoc.HinhAnh;
                model.LoaiKhoaHocID = khoaHoc.LoaiKhoaHocID;
                _db.KhoaHocs.Update(model);
                await _db.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task UpdateSoLuongHocVien(int khoaHocId)
        {
            var dangKyHocs = await _db.DangKyHocs
                .Where(x => x.KhoaHocID == khoaHocId)
                .ToListAsync();

            var soHocVienDangHoc = dangKyHocs.Count(x => x.TinhTrangHocID == 2);
            var soHocVienHoanThanh = dangKyHocs.Count(x => x.TinhTrangHocID == 3);
            var soHocVienChuaHoanThanh = dangKyHocs.Count(x => x.TinhTrangHocID == 4);
            var total = soHocVienDangHoc + soHocVienHoanThanh + soHocVienChuaHoanThanh;
            var khoaHoc = await _db.KhoaHocs.FindAsync(khoaHocId);
            if (khoaHoc != null)
            {
                khoaHoc.SoHocVien = total == 0 ? 0 : total;
                _db.KhoaHocs.Update(khoaHoc);
                await _db.SaveChangesAsync();
            }
        }

    }
}

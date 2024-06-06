using CourseManagement.Application.Interfaces.Repositories;
using CourseManagement.Application.ValueObjects.Pagination;
using CourseManagement.Domain.Entities;
using CourseManagement.Domain.Enum;
using CourseManagement.Infrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Infrastructure.Implements.Repositories
{
    public class DangKyHocRepos : IDangKyHocRepos
    {
        private readonly CourseManagementDbContext _db;
        public DangKyHocRepos()
        {
            _db = new CourseManagementDbContext();
        }
        public async Task<PageResult<DangKyHoc>> GetAll(PaginationRequest request)
        {
            var model = await _db.DangKyHocs
                .AsNoTracking()
                .ToListAsync();
            var result = PageResult<DangKyHoc>.ToPageResult(request, model);
            request.TotalCount = model.Count();
            return new PageResult<DangKyHoc>(request, result);
        }

        public async Task<ErrorMessage> CreateDangKyKhoaHoc(DangKyHoc dangKyHoc, CancellationToken cancellationToken)
        {
            try
            {
                dangKyHoc.NgayDangKy = DateTime.UtcNow;
                if (dangKyHoc.TinhTrangHocID == 2)
                {
                    dangKyHoc.NgayBatDau = DateTime.UtcNow;
                    var khoaHoc = await _db.KhoaHocs.FirstOrDefaultAsync(x => x.KhoaHocID == dangKyHoc.KhoaHocID);
                    if (khoaHoc != null)
                    {
                        if (khoaHoc.ThoiGianHoc.HasValue)
                        {
                            dangKyHoc.NgayKetThuc = dangKyHoc.NgayBatDau.Value.AddDays(khoaHoc.ThoiGianHoc.Value);
                        }
                    }
                }
                else
                {
                    dangKyHoc.NgayBatDau = null;
                    dangKyHoc.NgayKetThuc = null;
                }

                await _db.DangKyHocs.AddAsync(dangKyHoc, cancellationToken);
                await _db.SaveChangesAsync(cancellationToken);
                return ErrorMessage.Successfull;
            }
            catch (Exception)
            {
                return ErrorMessage.Failed;
            }
        }

        public async Task<ErrorMessage> DeleteDangKyKhoaHoc(DangKyHoc dangKyHoc, CancellationToken cancellationToken)
        {
            try
            {
                var model = await _db.DangKyHocs.FirstOrDefaultAsync(x => x.DangKyHocID == dangKyHoc.DangKyHocID, cancellationToken);
                if (model == null)
                {
                    return ErrorMessage.NotFindModel;
                }
                _db.DangKyHocs.Remove(model);
                await _db.SaveChangesAsync(cancellationToken);
                return ErrorMessage.Successfull;
            }
            catch (Exception)
            {
                return ErrorMessage.Failed;
            }
        }
        public async Task<ErrorMessage> UpdateDangKyKhoaHoc(DangKyHoc dangKyHoc, CancellationToken cancellationToken)
        {
            try
            {
                dangKyHoc.NgayDangKy = DateTime.UtcNow;
                if (dangKyHoc.TinhTrangHocID == 2)
                {
                    dangKyHoc.NgayBatDau = DateTime.UtcNow;
                    var khoaHoc = await _db.KhoaHocs.FirstOrDefaultAsync(x => x.KhoaHocID == dangKyHoc.KhoaHocID);
                    if (khoaHoc != null)
                    {
                        if (khoaHoc.ThoiGianHoc.HasValue)
                        {
                            dangKyHoc.NgayKetThuc = dangKyHoc.NgayBatDau.Value.AddDays(khoaHoc.ThoiGianHoc.Value);
                        }
                    }
                }
                else
                {
                    dangKyHoc.NgayBatDau = null;
                    dangKyHoc.NgayKetThuc = null;
                }
                var model = await _db.DangKyHocs.FirstOrDefaultAsync(x => x.DangKyHocID == dangKyHoc.DangKyHocID, cancellationToken);
                if (model == null)
                {
                    return ErrorMessage.NotFindModel;
                }
                model.KhoaHocID = dangKyHoc.KhoaHocID;
                model.HocVienID = dangKyHoc.HocVienID;
                model.TinhTrangHocID = dangKyHoc.TinhTrangHocID;
                model.TaiKhoanID = dangKyHoc.TaiKhoanID;
                _db.DangKyHocs.Update(model);
                await _db.SaveChangesAsync(cancellationToken);
                return ErrorMessage.Successfull;
            }
            catch (Exception)
            {
                return ErrorMessage.Failed;
            }
        }
    }
}

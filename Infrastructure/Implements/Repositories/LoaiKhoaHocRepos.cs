using CourseManagement.Application.Interfaces.Repositories;
using CourseManagement.Domain.Entities;
using CourseManagement.Domain.Enum;
using CourseManagement.Infrastructure.Database.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Infrastructure.Implements.Repositories
{
    public class LoaiKhoaHocRepos : ILoaiKhoaHocRepos
    {
        private readonly CourseManagementDbContext _db;
        public LoaiKhoaHocRepos()
        {
            _db = new();
        }
        public async Task<ErrorMessage> CreateLoaiKhoaHoc(LoaiKhoaHoc loaiKhoaHoc, CancellationToken cancellation)
        {
            try
            {
                await _db.LoaiKhoaHocs.AddAsync(loaiKhoaHoc);
                await _db.SaveChangesAsync(cancellation);
                return ErrorMessage.Successfull;
            }
            catch (Exception)
            {
                return ErrorMessage.Failed;
            }
        }

        public async Task<ErrorMessage> DeleteLoaiKhoaHoc(LoaiKhoaHoc loaiKhoaHoc, CancellationToken cancellation)
        {
            try
            {
                var model = _db.LoaiKhoaHocs.FirstOrDefault(x => x.LoaiKhoaHocID == loaiKhoaHoc.LoaiKhoaHocID);
                if (model == null)
                {
                    return ErrorMessage.ModelIsNull;
                }
                _db.LoaiKhoaHocs.Remove(model);
                await _db.SaveChangesAsync(cancellation);
                return ErrorMessage.Successfull;
            }
            catch (Exception)
            {
                return ErrorMessage.Failed;
            }
        }

        public async Task<ErrorMessage> UpdateLoaiKhoaHoc(LoaiKhoaHoc loaiKhoaHoc, CancellationToken cancellation)
        {
            try
            {
                var model = _db.LoaiKhoaHocs.FirstOrDefault(x => x.LoaiKhoaHocID == loaiKhoaHoc.LoaiKhoaHocID);
                if (model == null)
                {
                    return ErrorMessage.ModelIsNull;
                }
                model.TenLoai = loaiKhoaHoc.TenLoai;
                _db.LoaiKhoaHocs.Update(model);
                await _db.SaveChangesAsync(cancellation);
                return ErrorMessage.Successfull;
            }
            catch (Exception)
            {
                return ErrorMessage.Failed;
            }
        }
    }
}

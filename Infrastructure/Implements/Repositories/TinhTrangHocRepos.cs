using CourseManagement.Application.Interfaces.Repositories;
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
    public class TinhTrangHocRepos : ITinhTrangHocRepos
    {
        private readonly CourseManagementDbContext _db;
        public TinhTrangHocRepos()
        {
            _db = new CourseManagementDbContext();
        }
        public async Task<List<TinhTrangHoc>> GetAll()
        {
            return await _db.TinhTrangHocs
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<ErrorMessage> CreateTinhTrangHoc(TinhTrangHoc tinhTrangHoc, CancellationToken cancellationToken)
        {
            try
            {
                await _db.TinhTrangHocs.AddAsync(tinhTrangHoc, cancellationToken);
                await _db.SaveChangesAsync(cancellationToken);
                return ErrorMessage.Successfull;
            }
            catch (Exception)
            {
                return ErrorMessage.Failed;
            }
        }

        public async Task<ErrorMessage> DeleteTinhTrangHoc(TinhTrangHoc tinhTrangHoc, CancellationToken cancellationToken)
        {
            try
            {
                var model = await _db.TinhTrangHocs.FirstOrDefaultAsync(x => x.TinhTrangHocID == tinhTrangHoc.TinhTrangHocID, cancellationToken);
                if (model == null)
                {
                    return ErrorMessage.NotFindModel;
                }
                _db.TinhTrangHocs.Remove(model);
                await _db.SaveChangesAsync(cancellationToken);
                return ErrorMessage.Successfull;
            }
            catch (Exception)
            {
                return ErrorMessage.Failed;
            }
        }
        public async Task<ErrorMessage> UpdateTinhTrangHoc(TinhTrangHoc tinhTrangHoc, CancellationToken cancellationToken)
        {
            try
            {
                var model = await _db.TinhTrangHocs.FirstOrDefaultAsync(x => x.TinhTrangHocID == tinhTrangHoc.TinhTrangHocID, cancellationToken);
                if (model == null)
                {
                    return ErrorMessage.NotFindModel;
                }
                model.TenTinhTrang = tinhTrangHoc.TenTinhTrang;
                _db.TinhTrangHocs.Update(model);
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

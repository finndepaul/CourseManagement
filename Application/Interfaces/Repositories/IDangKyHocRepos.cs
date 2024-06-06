using CourseManagement.Application.ValueObjects.Pagination;
using CourseManagement.Domain.Entities;
using CourseManagement.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Application.Interfaces.Repositories
{
    public interface IDangKyHocRepos
    {
        Task<PageResult<DangKyHoc>> GetAll(PaginationRequest request);
        Task<ErrorMessage> CreateDangKyKhoaHoc(DangKyHoc dangKyHoc, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateDangKyKhoaHoc(DangKyHoc dangKyHoc, CancellationToken cancellationToken);
        Task<ErrorMessage> DeleteDangKyKhoaHoc(DangKyHoc dangKyHoc, CancellationToken cancellationToken);
    }
}

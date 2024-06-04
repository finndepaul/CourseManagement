using CourseManagement.Application.ValueObjects.Pagination;
using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Application.Interfaces.Repositories
{
    public interface IKhoaHocRepos
    {
        Task<PageResult<KhoaHoc>> GetAll(string? name, PaginationRequest request);
        Task<bool> CreateNew(KhoaHoc khoaHoc, CancellationToken cancellationToken);
        Task<bool> UpdateRecord(KhoaHoc khoaHoc, CancellationToken cancellationToken);
        Task<bool> DeleteRecord(KhoaHoc khoaHoc, CancellationToken cancellationToken);
    }
}

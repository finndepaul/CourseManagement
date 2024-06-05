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
    public interface IHocVienRepos
    {
        Task<PageResult<HocVien>> GetAll(string? keyword, PaginationRequest request);
        Task<ErrorMessage> CreateHocVien(HocVien hocVien, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateHocVien(HocVien hocVien, CancellationToken cancellationToken);
        Task<ErrorMessage> DeleteHocVien(HocVien hocVien, CancellationToken cancellationToken);
    }
}

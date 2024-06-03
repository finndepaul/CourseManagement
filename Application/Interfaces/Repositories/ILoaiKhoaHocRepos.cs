using CourseManagement.Domain.Entities;
using CourseManagement.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Application.Interfaces.Repositories
{
    public interface ILoaiKhoaHocRepos
    {
        Task<ErrorMessage> CreateLoaiKhoaHoc(LoaiKhoaHoc loaiKhoaHoc, CancellationToken cancellation);
        Task<ErrorMessage> UpdateLoaiKhoaHoc(LoaiKhoaHoc loaiKhoaHoc, CancellationToken cancellation);
        Task<ErrorMessage> DeleteLoaiKhoaHoc(LoaiKhoaHoc loaiKhoaHoc, CancellationToken cancellation);
    }
}

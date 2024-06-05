using CourseManagement.Domain.Entities;
using CourseManagement.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Application.Interfaces.Repositories
{
    public interface ITinhTrangHocRepos
    {
        Task<List<TinhTrangHoc>> GetAll();
        Task<ErrorMessage> CreateTinhTrangHoc(TinhTrangHoc tinhTrangHoc, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateTinhTrangHoc(TinhTrangHoc tinhTrangHoc, CancellationToken cancellationToken);
        Task<ErrorMessage> DeleteTinhTrangHoc(TinhTrangHoc tinhTrangHoc, CancellationToken cancellationToken);
    }
}

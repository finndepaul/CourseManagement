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
    public class HocVienRepos : IHocVienRepos
    {
        private readonly CourseManagementDbContext _db;
        public HocVienRepos()
        {
            _db = new CourseManagementDbContext();
        }
        public async Task<PageResult<HocVien>> GetAll(string? keyword, PaginationRequest request)
        {
            var model = await _db.HocViens
                .AsNoTracking()
                .ToListAsync();
            if (keyword != null)
            {
                model = model.Where(x => x.HoTen.ToLower().Contains(keyword.ToLower()) || x.Email.ToLower().Contains(keyword.ToLower())).ToList();
            }
            var result = PageResult<HocVien>.ToPageResult(request,model);
            request.TotalCount = model.Count();
            return new PageResult<HocVien>(request,result);
        }
        public async Task<ErrorMessage> CreateHocVien(HocVien hocVien, CancellationToken cancellationToken)
        {
            try
            {
                bool IsUnique = await CheckUniqueValue(hocVien);
                if (!IsUnique)
                {
                    return ErrorMessage.ValueIsUnique;
                }

                hocVien.HinhAnh = DinhDangHinhAnh(hocVien);
                hocVien.HoTen = DinhDangTen(hocVien);

                await _db.HocViens.AddAsync(hocVien, cancellationToken);
                await _db.SaveChangesAsync(cancellationToken);

                return ErrorMessage.Successfull;
            }
            catch (Exception)
            {
                return ErrorMessage.Failed;
            }
        }

        public async Task<ErrorMessage> UpdateHocVien(HocVien hocVien, CancellationToken cancellationToken)
        {
            try
            {
                bool IsUnique = await CheckUniqueValue(hocVien);
                if (!IsUnique)
                {
                    return ErrorMessage.ValueIsUnique;
                }
                var model = await _db.HocViens.FirstOrDefaultAsync(x => x.HocVienID == hocVien.HocVienID, cancellationToken);
                if (model == null)
                {
                    return ErrorMessage.NotFindModel;
                }
                model.HinhAnh = DinhDangHinhAnh(hocVien);
                model.HoTen = DinhDangTen(hocVien);
                model.NgaySinh = hocVien.NgaySinh;
                model.SDT = hocVien.SDT;
                model.Email = hocVien.Email;
                model.TinhThanh = hocVien.TinhThanh;
                model.QuanHuyen = hocVien.QuanHuyen;
                model.PhuongXa = hocVien.PhuongXa;
                model.SoNha = hocVien.SoNha;
                _db.HocViens.Update(hocVien);
                await _db.SaveChangesAsync(cancellationToken);
                return ErrorMessage.Successfull;
            }
            catch (Exception)
            {
                return ErrorMessage.Failed;
            }
        }

        public async Task<ErrorMessage> DeleteHocVien(HocVien hocVien, CancellationToken cancellationToken)
        {
            try
            {
                var model = await _db.HocViens.FirstOrDefaultAsync(x => x.HocVienID == hocVien.HocVienID, cancellationToken);
                if (model == null)
                {
                    return ErrorMessage.NotFindModel;
                }
                _db.HocViens.Remove(model);
                await _db.SaveChangesAsync(cancellationToken);
                return ErrorMessage.Successfull;
            }
            catch (Exception)
            {
                return ErrorMessage.Failed;
            }
        }
        private async Task<bool> CheckUniqueValue(HocVien hocVien)
        {
            var existingHocVien = await _db.HocViens.FirstOrDefaultAsync(x => x.Email.ToLower() == hocVien.Email.ToLower() || x.SDT.ToLower() == hocVien.SDT.ToLower());

            if (existingHocVien == null || existingHocVien.HocVienID == hocVien.HocVienID)
            {
                return true; 
            }

            return false;
        }

        private string DinhDangTen(HocVien hocVien)
        {
            // Định dạng trường họ tên
            return hocVien.HoTen = hocVien.HoTen?.Trim(); // Loại bỏ khoảng trắng ở đầu và cuối chuỗi  
        }
        private string DinhDangHinhAnh(HocVien hocVien)
        {
            string imagePath = "/images/anh" + hocVien.HocVienID.ToString() + "_avatar.jpg";
            // Đường dẫn đến hình ảnh
            return hocVien.HinhAnh = imagePath;
        }

        
    }
}

using AutoMapper;
using CourseManagement.Application.DataTransferObjects.LoaiKhoaHoc;
using CourseManagement.Application.DataTransferObjects.LoaiKhoaHoc.Request;
using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Infrastructure.Extensions.AutoMapperProfiles
{
    public class LoaiKhoaHocProfile : Profile
    {
        public LoaiKhoaHocProfile()
        {
            CreateMap<LoaiKhoaHocCreateRequest, LoaiKhoaHoc>().ReverseMap();
            CreateMap<LoaiKhoaHocUpdateRequest, LoaiKhoaHoc>().ReverseMap();
            CreateMap<LoaiKhoaHocDeleteRequest, LoaiKhoaHoc>().ReverseMap();
        }
    }
}

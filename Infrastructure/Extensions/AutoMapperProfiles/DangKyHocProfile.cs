using AutoMapper;
using CourseManagement.Application.DataTransferObjects.DangKyHoc.Request;
using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Infrastructure.Extensions.AutoMapperProfiles
{
    public class DangKyHocProfile : Profile
    {
        public DangKyHocProfile()
        {
            CreateMap<DangKyHocCreateRequest, DangKyHoc>();
            CreateMap<DangKyHocUpdateRequest, DangKyHoc>();
            CreateMap<DangKyHocDeleteRequest, DangKyHoc>();
        }
    }
}

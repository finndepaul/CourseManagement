using AutoMapper;
using CourseManagement.Application.DataTransferObjects.HocVien.Request;
using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Infrastructure.Extensions.AutoMapperProfiles
{
    public class HocVienProfile : Profile
    {
        public HocVienProfile()
        {
            CreateMap<HocVienCreateRequest, HocVien>();
            CreateMap<HocVienUpdateRequest, HocVien>();
            CreateMap<HocVienDeleteRequest, HocVien>();
        }
    }
}

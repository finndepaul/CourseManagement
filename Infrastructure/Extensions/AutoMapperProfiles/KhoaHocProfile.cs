using AutoMapper;
using CourseManagement.Application.DataTransferObjects.KhoaHoc;
using CourseManagement.Application.DataTransferObjects.KhoaHoc.Request;
using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Infrastructure.Extensions.AutoMapperProfiles
{
    public class KhoaHocProfile : Profile
    {
        public KhoaHocProfile()
        {
            CreateMap<KhoaHocCreateRequest, KhoaHoc>();
            CreateMap<KhoaHocUpdateRequest, KhoaHoc>();
            CreateMap<KhoaHocDeleteRequest, KhoaHoc>();
            CreateMap<KhoaHocDto, KhoaHoc>().ReverseMap();
        }
    }
}

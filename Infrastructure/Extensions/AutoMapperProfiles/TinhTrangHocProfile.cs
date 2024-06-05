using AutoMapper;
using CourseManagement.Application.DataTransferObjects.TinhTrangHoc;
using CourseManagement.Application.DataTransferObjects.TinhTrangHoc.Request;
using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Infrastructure.Extensions.AutoMapperProfiles
{
    public class TinhTrangHocProfile : Profile
    {
        public TinhTrangHocProfile()
        {
            CreateMap<TinhTrangHocDto, TinhTrangHoc>().ReverseMap();
            CreateMap<TinhTrangHocCreateRequest, TinhTrangHoc>();
            CreateMap<TinhTrangHocUpdateRequest, TinhTrangHoc>();
            CreateMap<TinhTrangHocDeleteRequest, TinhTrangHoc>();
        }
    }
}

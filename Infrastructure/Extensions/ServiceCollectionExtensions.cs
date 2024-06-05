using CourseManagement.Application.Interfaces.Repositories;
using CourseManagement.Infrastructure.Implements.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ILoaiKhoaHocRepos, LoaiKhoaHocRepos>();
            services.AddTransient<IKhoaHocRepos, KhoaHocRepos>();
            services.AddTransient<IHocVienRepos, HocVienRepos>();
            return services;
        }
    }
}

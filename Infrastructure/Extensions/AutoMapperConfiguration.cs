using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Infrastructure.Extensions
{
    public static class AutoMapperConfiguration // sau đó khai báo ở program Project API
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) // net 7 trở lên
        {
            using (var serviceProvider = services.BuildServiceProvider()) 
            {
                var executingAssembly = Assembly.GetExecutingAssembly();
                var entryAssembly = Assembly.GetEntryAssembly();
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                services.AddAutoMapper(configuration => { configuration.AddExpressionMapping(); }, executingAssembly,
                    entryAssembly);
                return services;
            }
        }
    }
}

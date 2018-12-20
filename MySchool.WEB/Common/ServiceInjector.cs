using Microsoft.Extensions.DependencyInjection;
using MySchool.DAL.Repository;
using MySchool.Services.Services.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.WEB.Common
{
    public static class ServiceInjector
    {
        public static void InjectServices(IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<UnitOfWork, UnitOfWork>();
        }
    }
}

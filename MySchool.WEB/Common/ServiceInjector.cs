using Microsoft.Extensions.DependencyInjection;
using MySchool.DAL.Repository;
using MySchool.Services.Services.Classes;
using MySchool.Services.Services.Grades;
using MySchool.Services.Services.Students;
using MySchool.Services.Services.Subjects;
using MySchool.Services.Services.Teachers;

namespace MySchool.WEB.Common
{
    public static class ServiceInjector
    {
        public static void InjectServices(IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<UnitOfWork, UnitOfWork>();
        }
    }
}

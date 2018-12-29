using Microsoft.Extensions.DependencyInjection;
using MySchool.DAL.Repository;
using MySchool.DAL.Repository.ClassRepository;
using MySchool.DAL.Repository.GradeRepository;
using MySchool.DAL.Repository.StudentRepository;
using MySchool.DAL.Repository.SubjectRepository;
using MySchool.DAL.Repository.TeacherRepository;
using MySchool.Services.Services.Classes;
using MySchool.Services.Services.Grades;
using MySchool.Services.Services.Students;
using MySchool.Services.Services.Subjects;
using MySchool.Services.Services.Teachers;

namespace MySchool.WEB.Common
{
    public static class InterfaceInjector
    {
        public static void InjectServices(IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<ISubjectService, SubjectService>();
        }

        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
        }
    }
}

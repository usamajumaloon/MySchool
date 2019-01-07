using AutoMapper;
using MySchool.DAL.Entities;
using MySchool.Services.Models.Classes;
using MySchool.Services.Models.Grades;
using MySchool.Services.Models.Students;
using MySchool.Services.Models.Subjects;
using MySchool.Services.Models.Teachers;

namespace MySchool.WEB.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Student
            CreateMap<StudentCreateModel, Student>().ReverseMap();
            CreateMap<StudentUpdateModel, Student>().ReverseMap();
            CreateMap<StudentModel, Student>().ReverseMap();

            //Teacher
            CreateMap<TeacherCreateModel, Teacher>().ReverseMap();
            CreateMap<TeacherUpdateModel, Teacher>().ReverseMap();
            CreateMap<TeacherModel, Teacher>().ReverseMap();

            //Class
            CreateMap<ClassCreateModel, Class>().ReverseMap();
            CreateMap<ClassUpdateModel, Class>().ReverseMap();
            CreateMap<ClassModel, Class>().ReverseMap();

            //Grade
            CreateMap<GradeCreateModel, Grade>().ReverseMap();
            CreateMap<GradeUpdateModel, Grade>().ReverseMap();
            CreateMap<GradeModel, Grade>().ReverseMap();

            //Subject
            CreateMap<SubjectCreateModel, Subject>().ReverseMap();
            CreateMap<SubjectUpdateModel, Subject>().ReverseMap();
            CreateMap<SubjectModel, Subject>().ReverseMap();
        }
    }
}

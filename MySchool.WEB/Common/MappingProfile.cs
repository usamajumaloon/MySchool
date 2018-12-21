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
            CreateMap<StudentCreateModel, StudentModel>(); 
            CreateMap<StudentUpdateModel, StudentModel>();
            CreateMap<StudentModel, Student>();

            //Teacher
            CreateMap<TeacherCreateModel, TeacherModel>();
            CreateMap<TeacherUpdateModel, TeacherModel>();
            CreateMap<TeacherModel, Teacher>();

            //Class
            CreateMap<ClassCreateModel, ClassModel>();
            CreateMap<ClassUpdateModel, ClassModel>();
            CreateMap<ClassModel, Class>();

            //Grade
            CreateMap<GradeCreateModel, GradeModel>();
            CreateMap<GradeUpdateModel, GradeModel>();
            CreateMap<GradeModel, Grade>();

            //Subject
            CreateMap<SubjectCreateModel, SubjectModel>();
            CreateMap<SubjectUpdateModel, SubjectModel>();
            CreateMap<SubjectModel, Subject>();
        }
    }
}

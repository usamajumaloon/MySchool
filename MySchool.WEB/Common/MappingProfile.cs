using AutoMapper;
using MySchool.DAL.Entities;
using MySchool.Services.Models.Students;

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
        }
    }
}

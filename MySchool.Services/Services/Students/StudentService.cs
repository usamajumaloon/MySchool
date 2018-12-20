using AutoMapper;
using MySchool.DAL.Entities;
using MySchool.DAL.Repository;
using MySchool.Services.Models.Students;

namespace MySchool.Services.Services.Students
{
    public class StudentService: IStudentService
    {
        private UnitOfWork uow;
        private readonly IMapper mapper;

        public StudentService(UnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public void AddStudent(StudentCreateModel input)
        {
            var entity = mapper.Map<Student>(input);
            uow.StudentRepository.Insert(entity);
            uow.Save();
        }
    }
}

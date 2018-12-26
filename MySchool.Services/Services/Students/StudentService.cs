using AutoMapper;
using MySchool.DAL.Entities;
using MySchool.DAL.Repository;
using MySchool.Services.Models.Students;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<StudentModel>> GetStudentAsync()
        {
            var entity = await uow.StudentRepository.Get();
            var model = mapper.Map<IEnumerable<StudentModel>>(entity);
            return model;
        }

        public async Task<StudentModel> GetStudentByIdAsync(int Id)
        {
            var entity = mapper.Map<StudentModel>(await uow.StudentRepository.GetByIDAsync(Id));
            return entity;
        }

        public async Task AddStudentAsync(StudentCreateModel input)
        {
            var entity = mapper.Map<Student>(input);
            await uow.StudentRepository.InsertAsync(entity);
            uow.Save();
        }
        
        public async Task UpdateStudentAsync(StudentUpdateModel input)
        {
            var entity = await uow.StudentRepository.GetByIDAsync(input.Id);
            entity.FirstName = input.FirstName;
            entity.LastName = input.LastName;
            entity.Gender = input.Gender;
            entity.DateOfBirth = input.DateOfBirth;
            entity.GradeClassId = input.GradeClassId;
            uow.Save();
        }

        public async Task DeleteStudentAsync(int Id)
        {
            await uow.StudentRepository.DeleteAsync(Id);
            uow.Save();
        }
    }
}

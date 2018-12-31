using MySchool.Common.Utility;
using MySchool.DAL.Entities;
using MySchool.DAL.Repository.StudentRepository;
using MySchool.Services.Models.Students;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.Services.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository repository;

        public StudentService(IStudentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<StudentModel>> GetStudentAsync()
        {
            var entity = await repository.GetAllStudents();
            var model = entity.MapObjectList<Student, StudentModel>();
            return model;
        }

        public async Task<StudentModel> GetStudentByIdAsync(int Id)
        {
            var entity = await repository.GetStudentById(Id);
            var model = entity.MapObject<Student, StudentModel>();
            return model;
        }

        public async Task<StudentCreateModel> AddStudentAsync(StudentCreateModel input)
        {
            var entity = input.MapObject<StudentCreateModel, Student>();
            await repository.AddStudent(entity);
            repository.Save();
            return input;
        }

        public void UpdateStudentAsync(StudentUpdateModel input)
        {
            var entity = input.MapObject<StudentUpdateModel, Student>();
            repository.UpdateStudent(entity);
            repository.Save();
        }

        public async Task DeleteStudentAsync(int Id)
        {
            await repository.DeleteStudent(Id);
            repository.Save();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MySchool.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.DAL.Repository.StudentRepository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MySchoolDb context;

        public StudentRepository(MySchoolDb context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await context.Students.Where(p => !p.IsDeleted).ToListAsync();
        }

        public async Task<Student> GetStudentById(int Id)
        {
            return await context.Students
                .Where(p => p.Id == Id && !p.IsDeleted)
                .FirstOrDefaultAsync();
        }

        public async Task<Student> AddStudent(Student entity)
        {
            await context.Students.AddAsync(entity);
            return entity;
        }

        public async Task DeleteStudent(int Id)
        {
            var output = await GetStudentById(Id);
            output.IsDeleted = true;
        }

        public async Task UpdateStudent(Student entity)
        {
            var result = await GetStudentById(entity.Id);
            result.FirstName = entity.FirstName;
            result.LastName = entity.LastName;
            result.DateOfBirth = entity.DateOfBirth;
            result.Gender = entity.Gender;
            result.GradeClassId = entity.GradeClassId;
            context.Entry(result).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}

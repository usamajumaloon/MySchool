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
            return await context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int Id)
        {
            return await context.Students
                .Where(p => p.Id == Id)
                .FirstOrDefaultAsync();
        }

        public async Task<Student> AddStudent(Student entity)
        {
            await context.Students.AddAsync(entity);
            return entity;
        }

        public async Task DeleteStudent(int Id)
        {
            Student entityToDelete = await GetStudentById(Id);
            Delete(entityToDelete);
        }

        public void Delete(Student entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                context.Attach(entityToDelete);
            }
            context.Remove(entityToDelete);
        }

        public void UpdateStudent(Student entity)
        {
            context.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}

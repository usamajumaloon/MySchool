using Microsoft.EntityFrameworkCore;
using MySchool.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.DAL.Repository.TeacherRepository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly MySchoolDb context;

        public TeacherRepository(MySchoolDb context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachers()
        {
            return await context.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetTeacherById(int Id)
        {
            return await context.Teachers
                .Where(p => p.Id == Id)
                .FirstOrDefaultAsync();
        }

        public async Task<Teacher> AddTeacher(Teacher entity)
        {
            await context.Teachers.AddAsync(entity);
            return entity;
        }

        public async Task DeleteTeacher(int Id)
        {
            Teacher entityToDelete = await GetTeacherById(Id);
            Delete(entityToDelete);
        }

        public void Delete(Teacher entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                context.Attach(entityToDelete);
            }
            context.Remove(entityToDelete);
        }

        public void UpdateTeacher(Teacher entity)
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

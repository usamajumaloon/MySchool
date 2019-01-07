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
            return await context.Teachers.Where(p=>!p.IsDeleted).ToListAsync();
        }

        public async Task<Teacher> GetTeacherById(int Id)
        {
            return await context.Teachers
                .Where(p => p.Id == Id && !p.IsDeleted)
                .FirstOrDefaultAsync();
        }

        public async Task<Teacher> AddTeacher(Teacher entity)
        {
            await context.Teachers.AddAsync(entity);
            return entity;
        }

        public async Task DeleteTeacher(int Id)
        {
            var output = await GetTeacherById(Id);
            output.IsDeleted = true;
        }

        public async Task UpdateTeacher(Teacher entity)
        {
            var result = await GetTeacherById(entity.Id);
            result.FirstName = entity.FirstName;
            result.LastName = entity.LastName;
            result.DateOfBirth = entity.DateOfBirth;
            result.Gender = entity.Gender;
            result.GradeClassId = entity.GradeClassId;
            result.SubjectId = entity.SubjectId;
            context.Entry(result).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}

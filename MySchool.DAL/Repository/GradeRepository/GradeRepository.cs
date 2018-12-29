using Microsoft.EntityFrameworkCore;
using MySchool.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.DAL.Repository.GradeRepository
{
    public class GradeRepository : IGradeRepository
    {
        private readonly MySchoolDb context;

        public GradeRepository(MySchoolDb context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Grade>> GetAllGrades()
        {
            return await context.Grades.ToListAsync();
        }

        public async Task<Grade> GetGradeById(int Id)
        {
            return await context.Grades
                .Where(p => p.Id == Id)
                .FirstOrDefaultAsync();
        }

        public async Task<Grade> AddGrade(Grade entity)
        {
            await context.Grades.AddAsync(entity);
            return entity;
        }

        public async Task DeleteGrade(int Id)
        {
            Grade entityToDelete = await GetGradeById(Id);
            Delete(entityToDelete);
        }

        public void Delete(Grade entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                context.Attach(entityToDelete);
            }
            context.Remove(entityToDelete);
        }

        public void UpdateGrade(Grade entity)
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

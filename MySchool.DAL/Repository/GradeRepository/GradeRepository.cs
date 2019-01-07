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
            return await context.Grades.Where(p => !p.IsDeleted).ToListAsync();
        }

        public async Task<Grade> GetGradeById(int Id)
        {
            return await context.Grades
                .Where(p => p.Id == Id && !p.IsDeleted)
                .FirstOrDefaultAsync();
        }

        public async Task<Grade> AddGrade(Grade entity)
        {
            await context.Grades.AddAsync(entity);
            return entity;
        }

        public async Task DeleteGrade(int Id)
        {
            var output = await GetGradeById(Id);
            output.IsDeleted = true;
        }
        
        public async Task UpdateGrade(Grade entity)
        {
            var result = await GetGradeById(entity.Id);
            result.Name = entity.Name;
            //context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}

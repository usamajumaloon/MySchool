using Microsoft.EntityFrameworkCore;
using MySchool.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.DAL.Repository.ClassRepository
{
    public class ClassRepository : IClassRepository
    {
        private readonly MySchoolDb context;

        public ClassRepository(MySchoolDb context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Class>> GetAllClasses()
        {
            return await context.Classes.Where(p => !p.IsDeleted).ToListAsync();
        }

        public async Task<Class> GetClassById(int Id)
        {
            return await context.Classes
                .Where(p => p.Id == Id && !p.IsDeleted)
                .FirstOrDefaultAsync();
        }

        public async Task<Class> AddClass(Class entity)
        {
            await context.Classes.AddAsync(entity);
            return entity;
        }

        public async Task DeleteClass(int Id)
        {
            var output = await GetClassById(Id);
            output.IsDeleted = true;
        }

        public async Task UpdateClass(Class entity)
        {
            //context.Entry(entity).State = EntityState.Modified;
            var result = await GetClassById(entity.Id);
            result.Name = entity.Name;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}

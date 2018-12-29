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
            return await context.Classes.ToListAsync();
        }

        public async Task<Class> GetClassById(int Id)
        {
            return await context.Classes
                .Where(p => p.Id == Id)
                .FirstOrDefaultAsync();
        }

        public async Task<Class> AddClass(Class entity)
        {
            await context.Classes.AddAsync(entity);
            return entity;
        }

        public async Task DeleteClass(int Id)
        {
            Class entityToDelete = await GetClassById(Id);
            Delete(entityToDelete);
        }

        public void Delete(Class entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                context.Attach(entityToDelete);
            }
            context.Remove(entityToDelete);
        }

        public void UpdateClass(Class entity)
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

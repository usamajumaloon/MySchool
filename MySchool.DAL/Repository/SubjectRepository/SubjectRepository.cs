using Microsoft.EntityFrameworkCore;
using MySchool.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.DAL.Repository.SubjectRepository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly MySchoolDb context;

        public SubjectRepository(MySchoolDb context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Subject>> GetAllSubjects()
        {
            return await context.Subjects.ToListAsync();
        }

        public async Task<Subject> GetSubjectById(int Id)
        {
            return await context.Subjects
                .Where(p => p.Id == Id)
                .FirstOrDefaultAsync();
        }

        public async Task<Subject> AddSubject(Subject entity)
        {
            await context.Subjects.AddAsync(entity);
            return entity;
        }

        public async Task DeleteSubject(int Id)
        {
            Subject entityToDelete = await GetSubjectById(Id);
            Delete(entityToDelete);
        }

        public void Delete(Subject entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                context.Attach(entityToDelete);
            }
            context.Remove(entityToDelete);
        }

        public void UpdateSubject(Subject entity)
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

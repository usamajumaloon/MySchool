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
            return await context.Subjects.Where(p => !p.IsDeleted).ToListAsync();
        }

        public async Task<Subject> GetSubjectById(int Id)
        {
            return await context.Subjects
                .Where(p => p.Id == Id && !p.IsDeleted)
                .FirstOrDefaultAsync();
        }

        public async Task<Subject> AddSubject(Subject entity)
        {
            await context.Subjects.AddAsync(entity);
            return entity;
        }

        public async Task DeleteSubject(int Id)
        {
            var output = await GetSubjectById(Id);
            output.IsDeleted = true;
        }

        public async Task UpdateSubject(Subject entity)
        {
            var result = await GetSubjectById(entity.Id);
            result.Name = entity.Name;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}

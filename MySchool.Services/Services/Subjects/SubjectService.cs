using MySchool.Common.Utility;
using MySchool.DAL.Entities;
using MySchool.DAL.Repository.SubjectRepository;
using MySchool.Services.Models.Subjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.Services.Services.Subjects
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository repository;

        public SubjectService(ISubjectRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<SubjectModel>> GetSubjectAsync()
        {
            var entity = await repository.GetAllSubjects();
            var model = entity.MapObjectList<Subject, SubjectModel>();
            return model;
        }

        public async Task<SubjectModel> GetSubjectByIdAsync(int Id)
        {
            var result = await repository.GetSubjectById(Id);
            var entity = result.MapObject<Subject, SubjectModel>();
            return entity;
        }

        public async Task AddSubjectAsync(SubjectCreateModel input)
        {
            var entity = input.MapObject<SubjectCreateModel, Subject>();
            await repository.AddSubject(entity);
            repository.Save();
        }

        public void UpdateSubjectAsync(SubjectUpdateModel input)
        {
            var entity = input.MapObject<SubjectUpdateModel, Subject>();
            repository.UpdateSubject(entity);
            repository.Save();
        }

        public async Task DeleteSubjectAsync(int Id)
        {
            await repository.DeleteSubject(Id);
            repository.Save();
        }
    }
}

using AutoMapper;
using MySchool.DAL.Entities;
using MySchool.DAL.Repository;
using MySchool.Services.Models.Subjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.Services.Services.Subjects
{
    public class SubjectService : ISubjectService
    {
        private UnitOfWork uow;
        private readonly IMapper mapper;

        public SubjectService(UnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SubjectModel>> GetSubjectAsync()
        {
            var entity = await uow.SubjectRepository.Get();
            var model = mapper.Map<IEnumerable<SubjectModel>>(entity);
            return model;
        }

        public async Task<SubjectModel> GetSubjectByIdAsync(int Id)
        {
            var entity = mapper.Map<SubjectModel>(await uow.SubjectRepository.GetByIDAsync(Id));
            return entity;
        }

        public async Task AddSubjectAsync(SubjectCreateModel input)
        {
            var entity = mapper.Map<Subject>(input);
            await uow.SubjectRepository.InsertAsync(entity);
            uow.Save();
        }

        public async Task UpdateSubjectAsync(SubjectUpdateModel input)
        {
            var entity = await uow.SubjectRepository.GetByIDAsync(input.Id);
            entity.Name = input.Name;
            uow.Save();
        }

        public async Task DeleteSubjectAsync(int Id)
        {
            await uow.SubjectRepository.DeleteAsync(Id);
            uow.Save();
        }
    }
}

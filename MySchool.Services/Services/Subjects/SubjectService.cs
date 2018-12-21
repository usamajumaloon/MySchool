using AutoMapper;
using MySchool.DAL.Entities;
using MySchool.DAL.Repository;
using MySchool.Services.Models.Subjects;
using System.Collections.Generic;

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

        public IEnumerable<SubjectModel> GetSubject()
        {
            var entity = uow.SubjectRepository.Get();
            var model = mapper.Map<IEnumerable<SubjectModel>>(entity);
            return model;
        }

        public SubjectModel GetSubjectById(int Id)
        {
            var entity = mapper.Map<SubjectModel>(uow.SubjectRepository.GetByID(Id));
            return entity;
        }

        public void AddSubject(SubjectCreateModel input)
        {
            var entity = mapper.Map<Subject>(input);
            uow.SubjectRepository.Insert(entity);
            uow.Save();
        }

        public void UpdateSubject(SubjectUpdateModel input)
        {
            var entity = uow.SubjectRepository.GetByID(input.Id);
            entity.Name = input.Name;
            uow.Save();
        }

        public void DeleteSubject(int Id)
        {
            uow.SubjectRepository.Delete(Id);
            uow.Save();
        }
    }
}

using AutoMapper;
using MySchool.DAL.Entities;
using MySchool.DAL.Repository;
using MySchool.Services.Models.Classes;
using System.Collections.Generic;

namespace MySchool.Services.Services.Classes
{
    public class ClassService: IClassService
    {
        private UnitOfWork uow;
        private readonly IMapper mapper;

        public ClassService(UnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public IEnumerable<ClassModel> GetClass()
        {
            var entity = uow.ClassRepository.Get();
            var model = mapper.Map<IEnumerable<ClassModel>>(entity);
            return model;
        }

        public ClassModel GetClassById(int Id)
        {
            var entity = mapper.Map<ClassModel>(uow.ClassRepository.GetByID(Id));
            return entity;
        }

        public void AddClass(ClassCreateModel input)
        {
            var entity = mapper.Map<Class>(input);
            uow.ClassRepository.Insert(entity);
            uow.Save();
        }

        public void UpdateClass(ClassUpdateModel input)
        {
            var entity = uow.ClassRepository.GetByID(input.Id);
            entity.Name = input.Name;
            uow.Save();
        }

        public void DeleteClass(int Id)
        {
            uow.ClassRepository.Delete(Id);
            uow.Save();
        }
    }
}

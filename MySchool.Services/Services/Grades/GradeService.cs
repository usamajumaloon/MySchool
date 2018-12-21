using AutoMapper;
using MySchool.DAL.Entities;
using MySchool.DAL.Repository;
using MySchool.Services.Models.Grades;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySchool.Services.Services.Grades
{
    public class GradeService: IGradeService
    {
        private UnitOfWork uow;
        private readonly IMapper mapper;

        public GradeService(UnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public IEnumerable<GradeModel> GetGrade()
        {
            var entity = uow.GradeRepository.Get();
            var model = mapper.Map<IEnumerable<GradeModel>>(entity);
            return model;
        }

        public GradeModel GetGradeById(int Id)
        {
            var entity = mapper.Map<GradeModel>(uow.GradeRepository.GetByID(Id));
            return entity;
        }

        public void AddGrade(GradeCreateModel input)
        {
            var entity = mapper.Map<Grade>(input);
            uow.GradeRepository.Insert(entity);
            uow.Save();
        }

        public void UpdateGrade(GradeUpdateModel input)
        {
            var entity = uow.GradeRepository.GetByID(input.Id);
            entity.Name = input.Name;
            uow.Save();
        }

        public void DeleteGrade(int Id)
        {
            uow.GradeRepository.Delete(Id);
            uow.Save();
        }
    }
}

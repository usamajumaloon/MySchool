using AutoMapper;
using MySchool.Common.Utility;
using MySchool.DAL.Entities;
using MySchool.DAL.Repository;
using MySchool.DAL.Repository.GradeRepository;
using MySchool.Services.Models.Grades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Services.Services.Grades
{
    public class GradeService: IGradeService
    {
        private readonly IGradeRepository repository;

        public GradeService(IGradeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<GradeModel>> GetGradeAsync()
        {
            var entity = await repository.GetAllGrades();
            var model = entity.MapObjectList<Grade, GradeModel>();
            return model;
        }

        public async Task<GradeModel> GetGradeByIdAsync(int Id)
        {
            var result = await repository.GetGradeById(Id);
            var entity = result.MapObject<Grade, GradeModel>();
            return entity;
        }

        public async Task AddGradeAsync(GradeCreateModel input)
        {
            var entity = input.MapObject<GradeCreateModel, Grade>();
            await repository.AddGrade(entity);
            repository.Save();
        }

        public void UpdateGradeAsync(GradeUpdateModel input)
        {
            var entity = input.MapObject<GradeUpdateModel, Grade>();
            repository.UpdateGrade(entity);
            repository.Save();
        }

        public async Task DeleteGradeAsync(int Id)
        {
            await repository.DeleteGrade(Id);
            repository.Save();
        }
    }
}

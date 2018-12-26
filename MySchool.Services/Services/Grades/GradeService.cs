using AutoMapper;
using MySchool.DAL.Entities;
using MySchool.DAL.Repository;
using MySchool.Services.Models.Grades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<GradeModel>> GetGradeAsync()
        {
            var entity = await uow.GradeRepository.Get();
            var model = mapper.Map<IEnumerable<GradeModel>>(entity);
            return model;
        }

        public async Task<GradeModel> GetGradeByIdAsync(int Id)
        {
            var entity = mapper.Map<GradeModel>(await uow.GradeRepository.GetByIDAsync(Id));
            return entity;
        }

        public async Task AddGradeAsync(GradeCreateModel input)
        {
            var entity = mapper.Map<Grade>(input);
            await uow.GradeRepository.InsertAsync(entity);
            uow.Save();
        }

        public async Task UpdateGradeAsync(GradeUpdateModel input)
        {
            var entity = await uow.GradeRepository.GetByIDAsync(input.Id);
            entity.Name = input.Name;
            uow.Save();
        }

        public async Task DeleteGradeAsync(int Id)
        {
            await uow.GradeRepository.DeleteAsync(Id);
            uow.Save();
        }
    }
}

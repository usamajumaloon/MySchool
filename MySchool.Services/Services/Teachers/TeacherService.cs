using AutoMapper;
using MySchool.DAL.Entities;
using MySchool.DAL.Repository;
using MySchool.Services.Models.Teachers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Services.Services.Teachers
{
    public class TeacherService: ITeacherService
    {
        private UnitOfWork uow;
        private readonly IMapper mapper;

        public TeacherService(UnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TeacherModel>> GetTeacherAsync()
        {
            var entity = await uow.TeacherRepository.Get();
            var model = mapper.Map<IEnumerable<TeacherModel>>(entity);
            return model;
        }

        public async Task<TeacherModel> GetTeacherByIdAsync(int Id)
        {
            var entity = mapper.Map<TeacherModel>(await uow.TeacherRepository.GetByIDAsync(Id));
            return entity;
        }

        public async Task AddTeacherAsync(TeacherCreateModel input)
        {
            var entity = mapper.Map<Teacher>(input);
            await uow.TeacherRepository.InsertAsync(entity);
            uow.Save();
        }

        public async Task UpdateTeacherAsync(TeacherUpdateModel input)
        {
            var entity = await uow.TeacherRepository.GetByIDAsync(input.Id);
            entity.FirstName = input.FirstName;
            entity.LastName = input.LastName;
            entity.Gender = input.Gender;
            entity.DateOfBirth = input.DateOfBirth;
            entity.GradeClassId = input.GradeClassId;
            entity.SubjectId = input.SubjectId;
            uow.Save();
        }

        public async Task DeleteTeacherAsync(int Id)
        {
            await uow.TeacherRepository.DeleteAsync(Id);
            uow.Save();
        }
    }
}

using AutoMapper;
using MySchool.DAL.Entities;
using MySchool.DAL.Repository;
using MySchool.Services.Models.Teachers;
using System;
using System.Collections.Generic;
using System.Text;

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

        public IEnumerable<TeacherModel> GetTeacher()
        {
            var entity = uow.TeacherRepository.Get();
            var model = mapper.Map<IEnumerable<TeacherModel>>(entity);
            return model;
        }

        public TeacherModel GetTeacherById(int Id)
        {
            var entity = mapper.Map<TeacherModel>(uow.TeacherRepository.GetByID(Id));
            return entity;
        }

        public void AddTeacher(TeacherCreateModel input)
        {
            var entity = mapper.Map<Teacher>(input);
            uow.TeacherRepository.Insert(entity);
            uow.Save();
        }

        public void UpdateTeacher(TeacherUpdateModel input)
        {
            var entity = uow.TeacherRepository.GetByID(input.Id);
            entity.FirstName = input.FirstName;
            entity.LastName = input.LastName;
            entity.Gender = input.Gender;
            entity.DateOfBirth = input.DateOfBirth;
            entity.GradeClassId = input.GradeClassId;
            entity.SubjectId = input.SubjectId;
            uow.Save();
        }

        public void DeleteTeacher(int Id)
        {
            uow.TeacherRepository.Delete(Id);
            uow.Save();
        }
    }
}

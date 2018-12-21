using AutoMapper;
using MySchool.DAL.Entities;
using MySchool.DAL.Repository;
using MySchool.Services.Models.Students;
using System.Collections;
using System.Collections.Generic;

namespace MySchool.Services.Services.Students
{
    public class StudentService: IStudentService
    {
        private UnitOfWork uow;
        private readonly IMapper mapper;

        public StudentService(UnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public IEnumerable<StudentModel> GetStudent()
        {
            var entity = uow.StudentRepository.Get();
            var model = mapper.Map<IEnumerable<StudentModel>>(entity);
            return model;
        }

        public StudentModel GetStudentById(int Id)
        {
            var entity = mapper.Map<StudentModel>(uow.StudentRepository.GetByID(Id));
            return entity;
        }

        public void AddStudent(StudentCreateModel input)
        {
            var entity = mapper.Map<Student>(input);
            uow.StudentRepository.Insert(entity);
            uow.Save();
        }
        
        public void UpdateStudent(StudentUpdateModel input)
        {
            var entity = uow.StudentRepository.GetByID(input.Id);
            entity.FirstName = input.FirstName;
            entity.LastName = input.LastName;
            entity.Gender = input.Gender;
            entity.DateOfBirth = input.DateOfBirth;
            entity.GradeClassId = input.GradeClassId;
            uow.Save();
        }

        public void DeleteStudent(int Id)
        {
            uow.StudentRepository.Delete(Id);
            uow.Save();
        }
    }
}

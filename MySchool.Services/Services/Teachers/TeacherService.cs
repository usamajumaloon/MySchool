using MySchool.Common.Utility;
using MySchool.DAL.Entities;
using MySchool.DAL.Repository.TeacherRepository;
using MySchool.Services.Models.Teachers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.Services.Services.Teachers
{
    public class TeacherService: ITeacherService
    {
        private readonly ITeacherRepository repository;

        public TeacherService(ITeacherRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<TeacherModel>> GetTeacherAsync()
        {
            var entity = await repository.GetAllTeachers();
            var model = entity.MapObjectList<Teacher, TeacherModel>();
            return model;
        }

        public async Task<TeacherModel> GetTeacherByIdAsync(int Id)
        {
            var result = await repository.GetTeacherById(Id);
            var entity = result.MapObject<Teacher, TeacherModel>();
            return entity;
        }

        public async Task<TeacherCreateModel> AddTeacherAsync(TeacherCreateModel input)
        {
            var entity = input.MapObject<TeacherCreateModel, Teacher>();
            await repository.AddTeacher(entity);
            repository.Save();
            return input;
        }

        public async Task UpdateTeacherAsync(TeacherUpdateModel input)
        {
            var entity = input.MapObject<TeacherUpdateModel, Teacher>();
            await repository.UpdateTeacher(entity);
            repository.Save();
        }

        public async Task DeleteTeacherAsync(int Id)
        {
            await repository.DeleteTeacher(Id);
            repository.Save();
        }
    }
}

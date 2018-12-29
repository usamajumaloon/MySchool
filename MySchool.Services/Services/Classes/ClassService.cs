using MySchool.Common.Utility;
using MySchool.DAL.Entities;
using MySchool.DAL.Repository;
using MySchool.DAL.Repository.ClassRepository;
using MySchool.Services.Models.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.Services.Services.Classes
{
    public class ClassService: IClassService
    {
        private readonly IClassRepository repository;

        public ClassService(IClassRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<ClassModel>> GetClassAsync()
        {
            var entity = await repository.GetAllClasses();
            var model = entity.MapObjectList<Class, ClassModel>();
            return model;
        }

        public async Task<ClassModel> GetClassByIdAsync(int Id)
        {
            var result = await repository.GetClassById(Id);
            var entity = result.MapObject<Class, ClassModel>();
            return entity;
        }

        public async Task AddClassAsync(ClassCreateModel input)
        {
            var entity = input.MapObject<ClassCreateModel, Class>();
            await repository.AddClass(entity);
            repository.Save();
        }

        public void UpdateClassAsync(ClassUpdateModel input)
        {
            var entity = input.MapObject<ClassUpdateModel, Class>();
            repository.UpdateClass(entity);
            repository.Save();
        }

        public async Task DeleteClassAsync(int Id)
        {
            await repository.DeleteClass(Id);
            repository.Save();
        }
    }
}

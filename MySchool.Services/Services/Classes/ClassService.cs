using AutoMapper;
using MySchool.DAL.Entities;
using MySchool.DAL.Repository;
using MySchool.Services.Models.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<ClassModel>> GetClassAsync()
        {
            var entity = await uow.ClassRepository.Get();
            var model = mapper.Map<IEnumerable<ClassModel>>(entity);
            return model;
        }

        public async Task<ClassModel> GetClassByIdAsync(int Id)
        {
            var entity = mapper.Map<ClassModel>(await uow.ClassRepository.GetByIDAsync(Id));
            return entity;
        }

        public async Task AddClassAsync(ClassCreateModel input)
        {
            var entity = mapper.Map<Class>(input);
            await uow.ClassRepository.InsertAsync(entity);
            uow.Save();
        }

        public async Task UpdateClassAsync(ClassUpdateModel input)
        {
            var entity = await uow.ClassRepository.GetByIDAsync(input.Id);
            entity.Name = input.Name;
            uow.Save();
        }

        public async Task DeleteClassAsync(int Id)
        {
            await uow.ClassRepository.DeleteAsync(Id);
            uow.Save();
        }
    }
}

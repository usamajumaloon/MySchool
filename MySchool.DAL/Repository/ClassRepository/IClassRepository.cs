using MySchool.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.DAL.Repository.ClassRepository
{
    public interface IClassRepository
    {
        Task<IEnumerable<Class>> GetAllClasses();
        Task<Class> GetClassById(int Id);
        Task<Class> AddClass(Class entity);
        Task DeleteClass(int Id);
        Task UpdateClass(Class entity);
        void Save();
    }
}

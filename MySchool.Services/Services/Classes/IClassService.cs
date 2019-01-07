using MySchool.Services.Models.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Services.Services.Classes
{
    public interface IClassService
    {
        Task<IEnumerable<ClassModel>> GetClassAsync();
        Task<ClassModel> GetClassByIdAsync(int Id);
        Task<ClassCreateModel> AddClassAsync(ClassCreateModel input);
        Task UpdateClassAsync(ClassUpdateModel input);
        Task DeleteClassAsync(int Id);
    }
}

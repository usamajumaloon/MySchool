using MySchool.Services.Models.Teachers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Services.Services.Teachers
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherModel>> GetTeacherAsync();
        Task<TeacherModel> GetTeacherByIdAsync(int Id);
        Task AddTeacherAsync(TeacherCreateModel input);
        Task UpdateTeacherAsync(TeacherUpdateModel input);
        Task DeleteTeacherAsync(int Id);
    }
}

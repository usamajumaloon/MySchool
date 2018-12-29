using MySchool.Services.Models.Students;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.Services.Services.Students
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentModel>> GetStudentAsync();
        Task<StudentModel> GetStudentByIdAsync(int Id);
        Task AddStudentAsync(StudentCreateModel input);
        void UpdateStudentAsync(StudentUpdateModel input);
        Task DeleteStudentAsync(int Id);
    }
}

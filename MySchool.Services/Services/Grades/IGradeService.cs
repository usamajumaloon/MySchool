using MySchool.Services.Models.Grades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.Services.Services.Grades
{
    public interface IGradeService
    {
        Task<IEnumerable<GradeModel>> GetGradeAsync();
        Task<GradeModel> GetGradeByIdAsync(int Id);
        Task AddGradeAsync(GradeCreateModel input);
        Task UpdateGradeAsync(GradeUpdateModel input);
        Task DeleteGradeAsync(int Id);
    }
}

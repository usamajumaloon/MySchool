using MySchool.Services.Models.Grades;
using System.Collections.Generic;

namespace MySchool.Services.Services.Grades
{
    public interface IGradeService
    {
        IEnumerable<GradeModel> GetGrade();
        GradeModel GetGradeById(int Id);
        void AddGrade(GradeCreateModel input);
        void UpdateGrade(GradeUpdateModel input);
        void DeleteGrade(int Id);
    }
}

using MySchool.Services.Models.Subjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Services.Services.Subjects
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectModel>> GetSubjectAsync();
        Task<SubjectModel> GetSubjectByIdAsync(int Id);
        Task<SubjectCreateModel> AddSubjectAsync(SubjectCreateModel input);
        Task UpdateSubjectAsync(SubjectUpdateModel input);
        Task DeleteSubjectAsync(int Id);
    }
}

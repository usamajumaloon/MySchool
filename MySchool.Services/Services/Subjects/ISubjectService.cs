using MySchool.Services.Models.Subjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySchool.Services.Services.Subjects
{
    public interface ISubjectService
    {
        IEnumerable<SubjectModel> GetSubject();
        SubjectModel GetSubjectById(int Id);
        void AddSubject(SubjectCreateModel input);
        void UpdateSubject(SubjectUpdateModel input);
        void DeleteSubject(int Id);
    }
}

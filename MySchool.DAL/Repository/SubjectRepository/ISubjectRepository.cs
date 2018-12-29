using MySchool.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.DAL.Repository.SubjectRepository
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetAllSubjects();
        Task<Subject> GetSubjectById(int Id);
        Task<Subject> AddSubject(Subject entity);
        Task DeleteSubject(int Id);
        void UpdateSubject(Subject entity);
        void Save();
    }
}

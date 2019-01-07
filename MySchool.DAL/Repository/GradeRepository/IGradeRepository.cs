using MySchool.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.DAL.Repository.GradeRepository
{
    public interface IGradeRepository
    {
        Task<IEnumerable<Grade>> GetAllGrades();
        Task<Grade> GetGradeById(int Id);
        Task<Grade> AddGrade(Grade entity);
        Task DeleteGrade(int Id);
        Task UpdateGrade(Grade entity);
        void Save();
    }
}

using MySchool.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.DAL.Repository.TeacherRepository
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllTeachers();
        Task<Teacher> GetTeacherById(int Id);
        Task<Teacher> AddTeacher(Teacher entity);
        Task DeleteTeacher(int Id);
        Task UpdateTeacher(Teacher entity);
        void Save();
    }
}

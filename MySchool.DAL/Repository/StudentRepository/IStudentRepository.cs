using MySchool.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.DAL.Repository.StudentRepository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetStudentById(int Id);
        Task<Student> AddStudent(Student entity);
        Task DeleteStudent(int Id);
        void UpdateStudent(Student entity);
        void Save();
    }
}

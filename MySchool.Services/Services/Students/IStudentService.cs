using MySchool.Services.Models.Students;
using System.Collections.Generic;

namespace MySchool.Services.Services.Students
{
    public interface IStudentService
    {
        IEnumerable<StudentModel> GetStudent();
        StudentModel GetStudentById(int Id);
        void AddStudent(StudentCreateModel input);
        void UpdateStudent(StudentUpdateModel input);
        void DeleteStudent(int Id);
    }
}

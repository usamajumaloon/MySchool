using MySchool.Services.Models.Students;

namespace MySchool.Services.Services.Students
{
    public interface IStudentService
    {
        void AddStudent(StudentCreateModel input);
    }
}

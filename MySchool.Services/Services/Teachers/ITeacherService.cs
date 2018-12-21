using MySchool.Services.Models.Teachers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySchool.Services.Services.Teachers
{
    public interface ITeacherService
    {
        IEnumerable<TeacherModel> GetTeacher();
        TeacherModel GetTeacherById(int Id);
        void AddTeacher(TeacherCreateModel input);
        void UpdateTeacher(TeacherUpdateModel input);
        void DeleteTeacher(int Id);
    }
}
